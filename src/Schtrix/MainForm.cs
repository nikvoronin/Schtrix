using AForge.Video.DirectShow;
using Schtrix.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ZXing;

namespace Schtrix
{
    public partial class MainForm : Form
    {
        public const string DB_FILENAME = "db.txt";

        FilterInfoCollection webcams;
        VideoCaptureDevice camera;
        Graphics gp;
        Thread thread;
        Bitmap currentFrame;
        Dictionary<string, Barcode> barcodes = new Dictionary<string, Barcode>();
        bool isThreadRun = false;
        string imgPath;
        string appPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Left = Properties.Settings.Default.LocX;
            Top = Properties.Settings.Default.LocY;
            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;
            switch (Properties.Settings.Default.State)
            {
                case 1:
                    WindowState = FormWindowState.Minimized;
                    break;
                case 2:
                    WindowState = FormWindowState.Maximized;
                    break;
                default:
                    WindowState = FormWindowState.Normal;
                    break;
            }

            Assembly execAsm = Assembly.GetExecutingAssembly();
            Text += " " + execAsm.GetName().Version.ToString();

            try
            {
                appPath = Path.GetDirectoryName(Application.ExecutablePath);
                imgPath = appPath + Path.DirectorySeparatorChar + "IMG";
                if (!Directory.Exists(imgPath))
                    Directory.CreateDirectory(imgPath);
            }
            catch { }

            enableSoundsToolStripMenuItem.Checked = Properties.Settings.Default.Sounds;
            autoCopyRecognizedTextToClipboardToolStripMenuItem.Checked = Properties.Settings.Default.AutoCopy;
            saveWebcamshotWhenRecognizedToolStripMenuItem.Checked = Properties.Settings.Default.SaveWebcamShot;
            saveHistoryToDbtxtToolStripMenuItem.Checked = Properties.Settings.Default.SaveHistory;
            saveBarcodeImageToolStripMenuItem.Checked = Properties.Settings.Default.SaveCleanImage;

            gp = Graphics.FromHwnd(previewPanel.Handle);
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            FillWebcamsCombo();

            thread = new Thread(Decode);
            isThreadRun = true;
            thread.Start();
        }

        private void Decode(object obj)
        {
            var reader = new BarcodeReader();

            while (isThreadRun)
            {
                if (currentFrame != null)
                {
                    for (int i = 0; i < 4; i++ )
                    {
                        Result[] result = null;

                        try {
                            result = reader.DecodeMultiple(currentFrame);
                        }
                        catch { }

                        if (result == null)
                            // CW90 ROTATE
                            currentFrame.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        else
                        {   // RECOGNIZED
                            foreach (Result r in result)
                            {
                                if (barcodes.ContainsKey(r.Text))
                                    if (barcodes[r.Text].BarcodeFormat == r.BarcodeFormat)
                                        continue;

                                if (r.BarcodeFormat == BarcodeFormat.UPC_E)
                                    continue;

                                if (saveWebcamshotWhenRecognizedToolStripMenuItem.Checked)
                                {
                                    try {
                                        currentFrame.Save(
                                            imgPath + Path.DirectorySeparatorChar + r.Timestamp.ToString() + ".jpg",
                                            ImageFormat.Jpeg
                                            );
                                    }
                                    catch { }
                                }

                                if (saveHistoryToDbtxtToolStripMenuItem.Checked)
                                {
                                    TextWriter w = new StreamWriter(appPath + Path.DirectorySeparatorChar + DB_FILENAME, true);
                                    w.WriteLine(string.Format(
                                        "{0}\t{1}\t{2}\t{3}\t{4}",
                                        r.Timestamp,
                                        r.BarcodeFormat.ToString(),
                                        saveBarcodeImageToolStripMenuItem.Checked ? 1 : 0,
                                        saveWebcamshotWhenRecognizedToolStripMenuItem.Checked ? 1 : 0,
                                        r.Text
                                        ));
                                    w.Flush();
                                    w.Close();
                                }

                                Invoke(new Action<Result>(OnRecognized), r);
                            } // foreach

                            break;
                        } // elseif
                    } // for i

                    currentFrame.Dispose();
                    currentFrame = null;
                } // if current

                Thread.Sleep(200);
            } // while
        }

        private void OnRecognized(Result r)
        {
            Barcode b = new Barcode(r.Text, r.BarcodeFormat);

            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = r.BarcodeFormat;
            writer.Options.PureBarcode = true;
            writer.Options.Height = 100;
            try { 
                b.Image = writer.Write(r.Text);
            }
            catch {
                b.Image = new Bitmap(writer.Options.Width, writer.Options.Height);
            }

            b.Timestamp = r.Timestamp;
            barcodes.Add(r.Text, b);

            historyListBox.Items.Insert(0, b);

            if (enableSoundsToolStripMenuItem.Checked)
                SystemSounds.Beep.Play();

            if (autoCopyRecognizedTextToClipboardToolStripMenuItem.Checked)
                Clipboard.SetText(r.Text);

            if (saveBarcodeImageToolStripMenuItem.Checked)
            {
                try {
                    b.Image.Save(
                        imgPath + Path.DirectorySeparatorChar + r.Timestamp.ToString() + ".png",
                        ImageFormat.Png
                        );
                }
                catch { }
            } 
        }

        private void FillWebcamsCombo()
        {
            webcamComboBox.Items.Clear();
            int preselectedIdx = 0;
            string deviceName = Properties.Settings.Default.DeviceName;
            for (var index = 0; index < webcams.Count; index++)
            {
                webcamComboBox.Items.Add(new Device { Index = index, Name = webcams[index].Name });
                if (deviceName == webcams[index].Name)
                    preselectedIdx = index;
            }

            if (webcams.Count > 0)
            {
                webcamComboBox.SelectedIndex = preselectedIdx;
                webcamOnCheckBox.Enabled = true;
                webcamOnCheckBox.Checked = Properties.Settings.Default.AutoPowerOn;
            }
        }

        private struct Device
        {
            public int Index;
            public string Name;

            public override string ToString()
            {
                return Name;
            }
        }

        private void webcamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchWebcamOnOff(false);
            Thread.Sleep(1000);
            SwitchWebcamOnOff(true);
        }

        void camera_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (IsDisposed)
                return;

            try {
                if (currentFrame == null)
                    currentFrame = (Bitmap)eventArgs.Frame.Clone();

                Invoke(new Action<Bitmap>(ShowFrame), eventArgs.Frame.Clone());
            }
            catch (ObjectDisposedException) {}
        }

        private void ShowFrame(Bitmap frame)
        {
            float shrinkFact = (float)previewPanel.Width / (float)frame.Width;
            float frameH = frame.Height * shrinkFact;
            gp.DrawImage(frame, 0, previewPanel.Height - frameH, previewPanel.Width, frameH);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                isThreadRun = false;
                SwitchWebcamOnOff(false);
            }

            Properties.Settings.Default["Sounds"] = enableSoundsToolStripMenuItem.Checked;
            Properties.Settings.Default["AutoCopy"] = autoCopyRecognizedTextToClipboardToolStripMenuItem.Checked;
            Properties.Settings.Default["SaveWebcamShot"] = saveWebcamshotWhenRecognizedToolStripMenuItem.Checked;
            Properties.Settings.Default["SaveHistory"] = saveHistoryToDbtxtToolStripMenuItem.Checked;
            Properties.Settings.Default["SaveCleanImage"] = saveBarcodeImageToolStripMenuItem.Checked;
            Properties.Settings.Default["AutoPowerOn"] = webcamOnCheckBox.Checked;

            if (webcamComboBox.SelectedIndex > -1)
                Properties.Settings.Default["DeviceName"] = ((Device)webcamComboBox.SelectedItem).Name;

            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    Properties.Settings.Default["State"] = 1;
                    break;
                case FormWindowState.Maximized:
                    Properties.Settings.Default["State"] = 2;
                    break;
                default:
                    Properties.Settings.Default["LocX"] = Left;
                    Properties.Settings.Default["LocY"] = Top;
                    Properties.Settings.Default["Width"] = Width;
                    Properties.Settings.Default["Height"] = Height;
                    Properties.Settings.Default["State"] = 0;
                    break;
            }

            Properties.Settings.Default.Save();
        }

        private void SwitchWebcamOnOff(bool isSwitchOn)
        {
            if (isSwitchOn) {   // ON
                int index = ((Device)(webcamComboBox.SelectedItem)).Index;
                if ((index < webcams.Count) && webcamOnCheckBox.Checked) {
                    camera = new VideoCaptureDevice(webcams[index].MonikerString);
                    camera.NewFrame += camera_NewFrame;
                    camera.Start();
                }
            }
            else {   // OFF
                if (camera != null) {
                    camera.NewFrame -= camera_NewFrame;
                    if (camera.IsRunning) {
                        camera.SignalToStop();
                        gp.FillRectangle(Brushes.CornflowerBlue, 0, 0, previewPanel.Width, previewPanel.Height);
                    }
                } // if
            } // else
        }

        private void webcamOnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SwitchWebcamOnOff(webcamOnCheckBox.Checked);
        }

        private void barcodePopupMenu_Opening(object sender, CancelEventArgs e)
        {
            if (historyListBox.SelectedIndex < 0)
                e.Cancel = true;
            else
            {
                Barcode bc = historyListBox.Items[historyListBox.SelectedIndex] as Barcode;
                if (bc != null)
                {
                    string rawText = bc.Text.Trim();

                    if(rawText.StartsWith("http") && rawText.Contains("://"))
                    {
                        pmOpenUrlToolStripMenuItem.Visible = true;
                        pmOpenUrlToolStripSeparator.Visible = true;
                    }
                    else
                    {
                        pmOpenUrlToolStripMenuItem.Visible = false;
                        pmOpenUrlToolStripSeparator.Visible = false;
                    }
                } // if bc
            } // else if
        }

        private void RemoveHistoryItem(int index)
        {
            Barcode bc = historyListBox.Items[index] as Barcode;
            if (bc != null)
            {
                barcodes.Remove(bc.Text);
                historyListBox.Items.RemoveAt(index);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyListBox.SelectedIndex > -1)
                RemoveHistoryItem(historyListBox.SelectedIndex);
        }

        private void openUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barcode bc = historyListBox.Items[historyListBox.SelectedIndex] as Barcode;
            if (bc != null)
            {
                try {
                    Process.Start(bc.Text.Trim());
                }
                catch { }
            }
        }

        private void copyAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barcode bc = historyListBox.Items[historyListBox.SelectedIndex] as Barcode;
            if (bc != null)
                Clipboard.SetText(bc.Text);
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barcode bc = historyListBox.Items[historyListBox.SelectedIndex] as Barcode;
            if (bc != null)
                Clipboard.SetImage(bc.Image);
        }

        private void aboutSchtrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void historyToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (historyListBox.SelectedIndex < 0)
            {
                copyAsImageToolStripMenuItem.Enabled = false;
                copyAsTextToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem1.Enabled = false;
            }
            else
            {
                copyAsImageToolStripMenuItem.Enabled = true;
                copyAsTextToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem1.Enabled = true;
            }

            cleanHistoryToolStripMenuItem.Enabled = historyListBox.Items.Count > 0;
        }

        private void opendbtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Process.Start(appPath + Path.DirectorySeparatorChar + DB_FILENAME);
            }
            catch { }
        }

        private void findImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Process.Start(imgPath);
            }
            catch { }
        }

        private void cleanHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barcodes.Clear();
            historyListBox.Items.Clear();
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            try {
                opendbtxtToolStripMenuItem.Enabled = File.Exists(appPath + Path.DirectorySeparatorChar + DB_FILENAME);
            }
            catch { }

            if (historyListBox.SelectedIndex < 0)
                openURLToolStripMenuItem1.Enabled = false;
            else
            {
                Barcode bc = historyListBox.Items[historyListBox.SelectedIndex] as Barcode;
                if (bc == null)
                    openURLToolStripMenuItem1.Enabled = false;
                else {
                    string rawText = bc.Text.Trim();

                    if (rawText.StartsWith("http") && rawText.Contains("://"))
                        openURLToolStripMenuItem1.Enabled = true;
                    else
                        openURLToolStripMenuItem1.Enabled = false;
                } // else if (bc == null)
            } // else if (historyListBox.SelectedIndex < 0)
        } // fileToolStripMenuItem_DropDownOpening
    } // class
}
