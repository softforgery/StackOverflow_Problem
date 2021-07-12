using Android.OS;
using Android.Views;
using Camera_sample.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace Camera_sample.Views
{
    public abstract class BaseFragment : MvxFragment
    {
        protected BaseFragment()
        {
            RetainInstance = true;
        }

        private MvxAppCompatActivity ParentActivity => (MvxAppCompatActivity)Activity;

        protected abstract int FragmentId { get; }
        protected abstract string Title { get; }

        public MainViewModel MainViewModel { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // ignore
            _ = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            ParentActivity.Title = Title;          

            MainViewModel = ((MainActivity)Activity).ViewModel;

            return view;
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get => (TViewModel)base.ViewModel;
            set => base.ViewModel = value;
        }
    }
}