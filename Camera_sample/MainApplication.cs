using Android.App;
using Android.Runtime;
using Camera_sample.Core;
using MvvmCross.Platforms.Android.Views;
using System;

namespace Camera_sample
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication()
        {
        }

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Resources.Configuration.SetLocale(new Java.Util.Locale("en-US"));
        }
    }
}