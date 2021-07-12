using Camera_sample.Core.Constants;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;

namespace Camera_sample.Core.Services
{
    public class BarcodeService : IBarcodeService
    {
        public BarcodeService()
        {
            var defaults = MobileBarcodeScanningOptions.Default;

            BarcodeReadConfiguration.Default = new BarcodeReadConfiguration
            {
                AutoRotate = false,
                CharacterSet = defaults.CharacterSet,
                DelayBetweenAnalyzingFrames = defaults.DelayBetweenAnalyzingFrames,
                Formats = new List<BarcodeFormat> { BarcodeFormat.ITF },
                InitialDelayBeforeAnalyzingFrames = defaults.InitialDelayBeforeAnalyzingFrames,
                PureBarcode = defaults.PureBarcode,
                TryHarder = defaults.TryHarder,
                TryInverted = defaults.TryInverted,
                UseFrontCameraIfAvailable = defaults.UseFrontCameraIfAvailable
            };
        }

        public async Task<BarcodeResult> Read(BarcodeReadConfiguration config = null, CancellationToken token = default)
        {
            config ??= BarcodeReadConfiguration.Default;

            var scanner = new MobileBarcodeScanner
            {
                UseCustomOverlay = false
            };

            token.Register(scanner.Cancel);

            var scanTask = scanner.Scan(GetXingConfig(config));
            await Task.Delay(500, token);
            scanner.Torch(true);
            var result = await scanTask;
            scanner.Torch(false);
            return string.IsNullOrWhiteSpace(result?.Text) ? BarcodeResult.Fail : new BarcodeResult(result.Text, result.BarcodeFormat);
        }

        private MobileBarcodeScanningOptions GetXingConfig(BarcodeReadConfiguration config)
        {
            return new MobileBarcodeScanningOptions
            {
                AutoRotate = config.AutoRotate,
                CharacterSet = config.CharacterSet,
                DelayBetweenAnalyzingFrames = config.DelayBetweenAnalyzingFrames,
                InitialDelayBeforeAnalyzingFrames = config.InitialDelayBeforeAnalyzingFrames,
                PossibleFormats = config.Formats != null && config.Formats.Count > 0 ? config.Formats : new List<BarcodeFormat>(),
                PureBarcode = config.PureBarcode,
                TryHarder = config.TryHarder,
                TryInverted = config.TryInverted,
                UseFrontCameraIfAvailable = config.UseFrontCameraIfAvailable
            };
        }
    }
}
