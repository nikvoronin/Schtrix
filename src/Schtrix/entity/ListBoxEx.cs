using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schtrix.entity
{
    public class ListBoxEx : ListBox
    {
        private const float PADDING_PX = 5;

        public ListBoxEx()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if ((e.Index < 0) || (e.Index >= Items.Count))
                return;

            Barcode bc = Items[e.Index] as Barcode;
            if (bc != null)
            {
                bc.CachedHeight = bc.Image.Height + PADDING_PX + PADDING_PX;

                e.ItemHeight = (int)bc.CachedHeight;
                e.ItemWidth = Width;
            }            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int idx = IndexFromPoint(e.X, e.Y);
            if ((idx > -1) && (Items.Count > 0) )
                SelectedIndex = idx;
        }

        protected string[] BoundText(string text, Font font, Graphics g)
        {
            string[] parts = null;
            string txt = text;
            while (g.MeasureString(txt, font).Width > Width)
                txt = txt.Substring(0, txt.Length / 2);

            int len = txt.Length;
            int cnt = text.Length / len;
            parts = new string[cnt];
            for(int i = 0; i < cnt; i++)
                parts[i] = text.Substring(cnt * i, len);

            return parts;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if ((e.Index < 0) || (e.Index >= Items.Count))
                return;

            e.Graphics.FillRectangle(
                (e.State & DrawItemState.Selected) == DrawItemState.Selected ?
                    SystemBrushes.Highlight :
                    SystemBrushes.Window,
                e.Bounds);

            Barcode bc = Items[e.Index] as Barcode;
            if (bc != null)
            {
                e.Graphics.DrawImage(bc.Image, e.Bounds.Left + PADDING_PX, e.Bounds.Top + PADDING_PX);

                int fh = SystemFonts.DefaultFont.Height;
                float y = e.Bounds.Y + PADDING_PX;
                float x = e.Bounds.X + bc.Image.Width + PADDING_PX + PADDING_PX;

                string[] parts = BoundText(bc.Text, SystemFonts.DefaultFont, e.Graphics);
                foreach (string str in parts)
                {
                    e.Graphics.DrawString(
                        str,
                        SystemFonts.DefaultFont,
                        Brushes.Black,
                        x, y);

                    y += fh + PADDING_PX;
                } // foreach

                e.Graphics.DrawString(
                    bc.BarcodeFormat.ToString(),
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    x, y);
                y += fh + PADDING_PX;

                DateTime dt = new DateTime(bc.Timestamp);
                e.Graphics.DrawString(
                    dt.ToLongTimeString() + " " + dt.ToLongDateString(),
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    x, y);
                y += fh + PADDING_PX;
            } // if bc != null
        } // OnDrawItem()
    } // class
}
