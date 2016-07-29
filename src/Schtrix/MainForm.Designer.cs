using Schtrix.entity;
namespace Schtrix
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webcamComboBox = new System.Windows.Forms.ComboBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.webcamOnCheckBox = new System.Windows.Forms.CheckBox();
            this.barcodePopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmCopyAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pmCopyAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pmOpenUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pmOpenUrlToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pmRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openURLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.opendbtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findImageFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBarcodeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveHistoryToDbtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWebcamshotWhenRecognizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSchtrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.historyListBox = new Schtrix.entity.ListBoxEx();
            this.barcodePopupMenu.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webcamComboBox
            // 
            this.webcamComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webcamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.webcamComboBox.FormattingEnabled = true;
            this.webcamComboBox.Location = new System.Drawing.Point(12, 32);
            this.webcamComboBox.Name = "webcamComboBox";
            this.webcamComboBox.Size = new System.Drawing.Size(243, 21);
            this.webcamComboBox.TabIndex = 1;
            this.webcamComboBox.SelectedIndexChanged += new System.EventHandler(this.webcamComboBox_SelectedIndexChanged);
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previewPanel.Location = new System.Drawing.Point(12, 59);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(320, 240);
            this.previewPanel.TabIndex = 17;
            // 
            // webcamOnCheckBox
            // 
            this.webcamOnCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webcamOnCheckBox.AutoSize = true;
            this.webcamOnCheckBox.Enabled = false;
            this.webcamOnCheckBox.Location = new System.Drawing.Point(261, 36);
            this.webcamOnCheckBox.Name = "webcamOnCheckBox";
            this.webcamOnCheckBox.Size = new System.Drawing.Size(71, 17);
            this.webcamOnCheckBox.TabIndex = 18;
            this.webcamOnCheckBox.Text = "Power on";
            this.webcamOnCheckBox.UseVisualStyleBackColor = true;
            this.webcamOnCheckBox.CheckedChanged += new System.EventHandler(this.webcamOnCheckBox_CheckedChanged);
            // 
            // barcodePopupMenu
            // 
            this.barcodePopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmCopyAsTextToolStripMenuItem,
            this.pmCopyAsImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.pmOpenUrlToolStripMenuItem,
            this.pmOpenUrlToolStripSeparator,
            this.pmRemoveToolStripMenuItem});
            this.barcodePopupMenu.Name = "barcodePopupMenu";
            this.barcodePopupMenu.Size = new System.Drawing.Size(194, 112);
            this.barcodePopupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.barcodePopupMenu_Opening);
            // 
            // pmCopyAsTextToolStripMenuItem
            // 
            this.pmCopyAsTextToolStripMenuItem.Name = "pmCopyAsTextToolStripMenuItem";
            this.pmCopyAsTextToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.pmCopyAsTextToolStripMenuItem.Text = "&Copy As Text";
            this.pmCopyAsTextToolStripMenuItem.Click += new System.EventHandler(this.copyAsTextToolStripMenuItem_Click);
            // 
            // pmCopyAsImageToolStripMenuItem
            // 
            this.pmCopyAsImageToolStripMenuItem.Name = "pmCopyAsImageToolStripMenuItem";
            this.pmCopyAsImageToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.pmCopyAsImageToolStripMenuItem.Text = "Copy As &Image";
            this.pmCopyAsImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // pmOpenUrlToolStripMenuItem
            // 
            this.pmOpenUrlToolStripMenuItem.Name = "pmOpenUrlToolStripMenuItem";
            this.pmOpenUrlToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.pmOpenUrlToolStripMenuItem.Text = "&Open URL";
            this.pmOpenUrlToolStripMenuItem.Click += new System.EventHandler(this.openUrlToolStripMenuItem_Click);
            // 
            // pmOpenUrlToolStripSeparator
            // 
            this.pmOpenUrlToolStripSeparator.Name = "pmOpenUrlToolStripSeparator";
            this.pmOpenUrlToolStripSeparator.Size = new System.Drawing.Size(190, 6);
            // 
            // pmRemoveToolStripMenuItem
            // 
            this.pmRemoveToolStripMenuItem.Name = "pmRemoveToolStripMenuItem";
            this.pmRemoveToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.pmRemoveToolStripMenuItem.Text = "&Remove Selected";
            this.pmRemoveToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 309);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(834, 22);
            this.mainStatusStrip.TabIndex = 22;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openURLToolStripMenuItem1,
            this.toolStripSeparator6,
            this.opendbtxtToolStripMenuItem,
            this.findImageFolderToolStripMenuItem,
            this.toolStripSeparator5,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // openURLToolStripMenuItem1
            // 
            this.openURLToolStripMenuItem1.Name = "openURLToolStripMenuItem1";
            this.openURLToolStripMenuItem1.Size = new System.Drawing.Size(198, 24);
            this.openURLToolStripMenuItem1.Text = "&Open URL";
            this.openURLToolStripMenuItem1.Click += new System.EventHandler(this.openUrlToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(195, 6);
            // 
            // opendbtxtToolStripMenuItem
            // 
            this.opendbtxtToolStripMenuItem.Name = "opendbtxtToolStripMenuItem";
            this.opendbtxtToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.opendbtxtToolStripMenuItem.Text = "Open &History File";
            this.opendbtxtToolStripMenuItem.Click += new System.EventHandler(this.opendbtxtToolStripMenuItem_Click);
            // 
            // findImageFolderToolStripMenuItem
            // 
            this.findImageFolderToolStripMenuItem.Name = "findImageFolderToolStripMenuItem";
            this.findImageFolderToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.findImageFolderToolStripMenuItem.Text = "Find &Image Folder";
            this.findImageFolderToolStripMenuItem.Click += new System.EventHandler(this.findImageFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.quitToolStripMenuItem.Text = "&Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAsTextToolStripMenuItem,
            this.copyAsImageToolStripMenuItem,
            this.toolStripSeparator3,
            this.removeToolStripMenuItem1,
            this.toolStripSeparator4,
            this.cleanHistoryToolStripMenuItem});
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.historyToolStripMenuItem.Text = "&Edit";
            this.historyToolStripMenuItem.DropDownOpening += new System.EventHandler(this.historyToolStripMenuItem_DropDownOpening);
            // 
            // copyAsTextToolStripMenuItem
            // 
            this.copyAsTextToolStripMenuItem.Name = "copyAsTextToolStripMenuItem";
            this.copyAsTextToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.copyAsTextToolStripMenuItem.Text = "&Copy As Text";
            this.copyAsTextToolStripMenuItem.Click += new System.EventHandler(this.copyAsTextToolStripMenuItem_Click);
            // 
            // copyAsImageToolStripMenuItem
            // 
            this.copyAsImageToolStripMenuItem.Name = "copyAsImageToolStripMenuItem";
            this.copyAsImageToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.copyAsImageToolStripMenuItem.Text = "Copy As &Image";
            this.copyAsImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(193, 24);
            this.removeToolStripMenuItem1.Text = "&Remove Selected";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // cleanHistoryToolStripMenuItem
            // 
            this.cleanHistoryToolStripMenuItem.Name = "cleanHistoryToolStripMenuItem";
            this.cleanHistoryToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.cleanHistoryToolStripMenuItem.Text = "Clean &History";
            this.cleanHistoryToolStripMenuItem.Click += new System.EventHandler(this.cleanHistoryToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBarcodeImageToolStripMenuItem,
            this.saveHistoryToDbtxtToolStripMenuItem,
            this.saveWebcamshotWhenRecognizedToolStripMenuItem,
            this.toolStripSeparator2,
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveBarcodeImageToolStripMenuItem
            // 
            this.saveBarcodeImageToolStripMenuItem.CheckOnClick = true;
            this.saveBarcodeImageToolStripMenuItem.Name = "saveBarcodeImageToolStripMenuItem";
            this.saveBarcodeImageToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.saveBarcodeImageToolStripMenuItem.Text = "Autosave Barcode As &Image";
            // 
            // saveHistoryToDbtxtToolStripMenuItem
            // 
            this.saveHistoryToDbtxtToolStripMenuItem.CheckOnClick = true;
            this.saveHistoryToDbtxtToolStripMenuItem.Name = "saveHistoryToDbtxtToolStripMenuItem";
            this.saveHistoryToDbtxtToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.saveHistoryToDbtxtToolStripMenuItem.Text = "Autosave &History to File";
            // 
            // saveWebcamshotWhenRecognizedToolStripMenuItem
            // 
            this.saveWebcamshotWhenRecognizedToolStripMenuItem.CheckOnClick = true;
            this.saveWebcamshotWhenRecognizedToolStripMenuItem.Name = "saveWebcamshotWhenRecognizedToolStripMenuItem";
            this.saveWebcamshotWhenRecognizedToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.saveWebcamshotWhenRecognizedToolStripMenuItem.Text = "Autosave &Screenshot";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(279, 6);
            // 
            // autoCopyRecognizedTextToClipboardToolStripMenuItem
            // 
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem.CheckOnClick = true;
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem.Name = "autoCopyRecognizedTextToClipboardToolStripMenuItem";
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.autoCopyRecognizedTextToClipboardToolStripMenuItem.Text = "Autocopy to Clipboard As &Text";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSchtrixToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutSchtrixToolStripMenuItem
            // 
            this.aboutSchtrixToolStripMenuItem.Name = "aboutSchtrixToolStripMenuItem";
            this.aboutSchtrixToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.aboutSchtrixToolStripMenuItem.Text = "&About Schtrix...";
            this.aboutSchtrixToolStripMenuItem.Click += new System.EventHandler(this.aboutSchtrixToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(834, 28);
            this.mainMenuStrip.TabIndex = 21;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // historyListBox
            // 
            this.historyListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyListBox.ContextMenuStrip = this.barcodePopupMenu;
            this.historyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.Location = new System.Drawing.Point(338, 31);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(484, 268);
            this.historyListBox.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(834, 331);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.webcamOnCheckBox);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.webcamComboBox);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(761, 370);
            this.Name = "MainForm";
            this.Text = "Schtrix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.barcodePopupMenu.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox webcamComboBox;
        private ListBoxEx historyListBox;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.CheckBox webcamOnCheckBox;
        private System.Windows.Forms.ContextMenuStrip barcodePopupMenu;
        private System.Windows.Forms.ToolStripMenuItem pmCopyAsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pmCopyAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pmRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pmOpenUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator pmOpenUrlToolStripSeparator;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openURLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem opendbtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findImageFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cleanHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBarcodeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveHistoryToDbtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWebcamshotWhenRecognizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoCopyRecognizedTextToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSchtrixToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
    }
}

