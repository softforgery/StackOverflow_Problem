using ZXing;

namespace Camera_sample.Core.Constants
{
    public class BarcodeResult
    {
        public string Barcode { get; private set; }
        public BarcodeFormat Format { get; private set; }
        public bool Success { get; private set; }

        public static BarcodeResult Fail { get; private set; }

        private BarcodeResult()
        {
        }

        static BarcodeResult()
        {
            Fail = new BarcodeResult
            {
                Success = false
            };
        }

        public BarcodeResult(string barcode, BarcodeFormat format)
        {
            Barcode = barcode;
            Format = format;
            Success = true;
        }
    }
}
