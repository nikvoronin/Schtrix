using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace Schtrix.entity
{
    public class Barcode
    {
        public string Text;
        public BarcodeFormat BarcodeFormat;
        public Bitmap Image = null;
        public float CachedHeight = -1;
        public long Timestamp;

        public Barcode(string name, BarcodeFormat format)
        {
            Text = name;
            BarcodeFormat = format;
        }
    }
}
