using Android.OS;
using Android.Runtime;
using Android.Views;
using Camera_sample.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Camera_sample.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register(nameof(FirstFragment))]
    public class FirstFragment : BaseFragment<FirstViewModel>
    {
        protected override int FragmentId => Resource.Layout.fragment_first;

        protected override string Title => "First";

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            Activity.Title = $"";

            var activity = (MainActivity)Activity;
            MainViewModel mainViewModel = activity.ViewModel;

            return view;
        }
    }
}