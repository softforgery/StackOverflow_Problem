using System;
using System.Collections.Generic;
using ZXing;

namespace Camera_sample.Core.Constants
{
    public class BarcodeReadConfiguration
    {

        private static BarcodeReadConfiguration _default;
        public static BarcodeReadConfiguration Default
        {
            get
            {
                _default = _default ?? new BarcodeReadConfiguration();
                return _default;
            }
            set => _default = value ?? throw new ArgumentNullException("Default barcode read options cannot be null");
        }

        public string TopText { get; set; }
        public string BottomText { get; set; }
        public string FlashlightText { get; set; }
        public string CancelText { get; set; }

        public bool? AutoRotate { get; set; }
        public string CharacterSet { get; set; }
        public int DelayBetweenAnalyzingFrames { get; set; }
        public bool? PureBarcode { get; set; }
        public int InitialDelayBeforeAnalyzingFrames { get; set; }
        public bool? TryHarder { get; set; }
        public bool? TryInverted { get; set; }
        public bool? UseFrontCameraIfAvailable { get; set; }

        public List<BarcodeFormat> Formats { get; set; }

        public BarcodeReadConfiguration()
        {
            TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
            BottomText = "Wait for the barcode to automatically scan";
            Formats = new List<BarcodeFormat>(3);
        }
    }
}
