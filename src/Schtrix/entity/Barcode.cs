using System.Drawing;
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
