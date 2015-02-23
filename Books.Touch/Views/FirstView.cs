using CoreGraphics;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using ObjCRuntime;
using UIKit;
using Foundation;

namespace Books.Touch.Views
{
    [Foundation.Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var textField = new UITextField(new CGRect(10, 10, 300, 40));
            Add(textField);

            var activity = new UIActivityIndicatorView(new CGRect(130, 130, 60, 60));
            activity.Color = UIColor.Orange;

            Add(activity);

            var tableView = new UITableView(new CGRect(0, 50, 320, 500), UITableViewStyle.Plain);
            Add(tableView);

			// choice here:
			//
			//   for original demo use:
            //     var source = new MvxStandardTableViewSource(tableView, "TitleText");
			//
			//   or for prettier cells from XIB file use:
			//     tableView.RowHeight = 88;
			//     var source = new MvxSimpleTableViewSource(tableView, BookCell.Key, BookCell.Key);

			tableView.RowHeight = 88;
			var source = new MvxSimpleTableViewSource(tableView, BookCell.Key, BookCell.Key);
			tableView.Source = source;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(textField).To(vm => vm.SearchTerm);
            set.Bind(textField).For(t => t.Enabled).To(vm => vm.IsLoading).WithConversion("InverseBool");
            set.Bind(source).To(vm => vm.Results);
            set.Bind(activity).For("Visibility").To(vm => vm.IsLoading).WithConversion("Visibility");
            set.Bind(tableView).For("Visibility").To(vm => vm.IsLoading).WithConversion("InvertedVisibility");
            set.Apply();

            tableView.ReloadData();
        }
    }
}