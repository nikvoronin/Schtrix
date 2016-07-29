using Schtrix.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

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
            {
                return;
            }

            Barcode bc = Items[e.Index] as Barcode;
            if (bc != null)
            {
                bc.CachedHeight = bc.Image.Height + PADDING_PX + PADDING_PX;

                e.ItemHeight = (int)bc.CachedHeight;
                e.ItemWidth = this.Width;
            }            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int idx = IndexFromPoint(e.X, e.Y);
            if ((idx > -1) && (Items.Count > 0) )
            {
                SelectedIndex = idx;
            }
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if ((e.Index < 0) || (e.Index >= Items.Count))
            {
                return;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
            }

            Barcode bc = Items[e.Index] as Barcode;
            if (bc != null)
            {
                e.Graphics.DrawImage(bc.Image, e.Bounds.Left + PADDING_PX, e.Bounds.Top + PADDING_PX);

                int fh = SystemFonts.DefaultFont.Height;
                float y = e.Bounds.Y + PADDING_PX;
                float x = e.Bounds.X + bc.Image.Width + PADDING_PX + PADDING_PX;

                switch (bc.BarcodeFormat)
                {
                    case BarcodeFormat.PDF_417:
                        e.Graphics.DrawString(
                            bc.Text,
                            SystemFonts.DefaultFont,
                            Brushes.Black,
                            x, y);
                        y += fh + PADDING_PX;
                        break;
                    default:
                        e.Graphics.DrawString(
                            bc.Text,
                            SystemFonts.DefaultFont,
                            Brushes.Black,
                            x, y);
                        y += fh + PADDING_PX;
                        break;
                }

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
            }
        }
    }
}
