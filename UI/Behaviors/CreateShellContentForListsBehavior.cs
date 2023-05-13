using MauiList.ViewModels;

using System.Collections.ObjectModel;

namespace MauiList.UI.Behaviors
{
    public class CreateShellContentForListsBehavior :
        BehaviorBase<Shell>
    {
        public static readonly BindableProperty ListViewModelsProperty = BindableProperty.Create(
            nameof(ListViewModels),
            typeof(ObservableCollection<ListViewModel>),
            typeof(CreateShellContentForListsBehavior),
            propertyChanged: OnListViewModelsPropertyChanged);


        public ObservableCollection<ListViewModel> ListViewModels
        {
            get => (ObservableCollection<ListViewModel>)GetValue(ListViewModelsProperty);
            set => SetValue(ListViewModelsProperty, value);
        }


        public static readonly BindableProperty SelectedListProperty = BindableProperty.Create(
            nameof(SelectedList),
            typeof(ListViewModel),
            typeof(CreateShellContentForListsBehavior),
            propertyChanged: OnListViewModelsPropertyChanged);


        public ListViewModel SelectedList
        {
            get => (ListViewModel)GetValue(SelectedListProperty);
            set => SetValue(SelectedListProperty, value);
        }


        private ShellContent selectedContent;


        protected override void OnAttachedTo(
            Shell shell)
        {
            base.OnAttachedTo(
                shell);

            
            shell.BindingContextChanged += OnShellBindingContextChanged;
        }


        private void InsertShellItems()
        {
            int count = 0;

            foreach (var viewModel in ListViewModels)
            {
                var shellContent = CreateShellContentFromListViewModel(
                    viewModel);

                if (viewModel == SelectedList)
                {
                    selectedContent = shellContent;
                }


                AssociatedObject.Items.Insert(
                   count,
                   shellContent);


                count++;
            }


            AssociatedObject.CurrentItem =
                selectedContent ??
                AssociatedObject.Items?
                    .OfType<ShellContent>()?
                    .FirstOrDefault();
        }


        private ShellContent CreateShellContentFromListViewModel(
            ListViewModel viewModel)
        {
            return new ShellContent
            {
                Title = viewModel.List.Name,
                BindingContext = viewModel,
                ContentTemplate = new DataTemplate(() => new Views.ListView()),
            };
        }



        private void OnShellBindingContextChanged(
            object sender,
            EventArgs eventArgs)
        {
            BindingContext = AssociatedObject.BindingContext;
        }


        private static void OnListViewModelsPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            if (bindable is not CreateShellContentForListsBehavior behavior)
            {
                return;
            }

            if (oldValue is ObservableCollection<ListViewModel> oldViewModels)
            {
                foreach (var oldViewModel in oldViewModels)
                {
                    var shellContent = behavior.AssociatedObject.Items.FirstOrDefault(
                        shell => shell.BindingContext == oldViewModel);

                    if (shellContent != null)
                    {
                        behavior.AssociatedObject.Items.Remove(
                            shellContent);
                    }
                }
            }

            if (newValue is not  ObservableCollection<ListViewModel> newViewModels)
            {
                return;
            }


            behavior.InsertShellItems();            
        }
    }
}
