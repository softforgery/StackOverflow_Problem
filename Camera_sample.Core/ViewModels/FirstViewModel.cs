using Camera_sample.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Camera_sample.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IBarcodeService _barcodeService;

        private MvxCommand _scanBarcodeCommand;
        private IMvxAsyncCommand _takePictureCommand;

        public MvxCommand ScanBarcodeCommand => _scanBarcodeCommand ??= new MvxCommand(async () => await OnScanBarcodeCommand());
        public IMvxAsyncCommand TakePictureCommand => _takePictureCommand ??= new MvxAsyncCommand(TakePicture);



        public FirstViewModel(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }

        private async Task OnScanBarcodeCommand()
        {
            try
            {
                var result = await _barcodeService.Read();

                await Task.Delay(new TimeSpan(0, 0, 0, 1));

                if (result.Success)
                {
                    // handle success
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private async Task TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var fileName = $"camera_test_{DateTime.Now.ToString("yyyyMMddHHmmss")}";


            StoreCameraMediaOptions cameraOptions = new StoreCameraMediaOptions()
            {
                Name = fileName + ".jpg",
                CompressionQuality = 40,
                CustomPhotoSize = 35,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000
            };

            using var file = await CrossMedia.Current.TakePhotoAsync(cameraOptions).ConfigureAwait(true);

            if (file != null && file.GetStream().Length > 0)
            {
                using var ms = new MemoryStream();
                await file.GetStream().CopyToAsync(ms);
                file.Dispose();
            }
        }
    }
}
