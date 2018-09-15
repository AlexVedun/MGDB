namespace MGDB.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Catel.MVVM.Converters;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using System.Linq;

    //class BoolToVisibleOrHidden : System.Windows.Data.IValueConverter
    //{
    //    #region Constructors
    //    /// <summary>
    //    /// The default constructor
    //    /// </summary>
    //    public BoolToVisibleOrHidden() { }
    //    #endregion

    //    #region IValueConverter Members
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        bool bValue = (bool)value;
    //        if (bValue)
    //            return Visibility.Visible;
    //        else
    //            return Visibility.Hidden;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        Visibility visibility = (Visibility)value;

    //        if (visibility == Visibility.Visible)
    //            return true;
    //        else
    //            return false;
    //    }
    //    #endregion
    //}

    public class MainWindowViewModel : ViewModelBase
    {
        private const string registrationJournal = "Журнал регистрации исследований";
        private const string engineersEditor = "Список работников";
        private const string customersEditor = "Заказчики";

        private List<IViewModel> windowsList = new List<IViewModel>();
        private List<string> tabList = new List<string>();
        //private RegistrationJournalViewModel regJournalWindow = new RegistrationJournalViewModel();

        #region Private Methods

        private TabItem CreateTabItem(string _title, IViewModel _view)
        {
            var tabItem = new TabItem();
            //tabItem.Header = _title;
            ContentControl contentControl = new ContentControl();
            contentControl.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            contentControl.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            Binding b = new Binding();
            b.Source = _view;
            b.Converter = new ViewModelToViewConverter();
            contentControl.SetBinding(ContentControl.ContentProperty, b);

            Button closeTabButton = new Button();
            closeTabButton.Width = 18;
            closeTabButton.Height = 18;
            closeTabButton.HorizontalAlignment = HorizontalAlignment.Left;
            closeTabButton.Command = CloseTabCommand;
            Image closeImage = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("../Icons/CloseTabIcon.png", UriKind.Relative);
            bi.EndInit();
            closeImage.Source = bi;
            closeTabButton.Content = closeImage;
            closeTabButton.BorderThickness = new Thickness(0);
            //Binding b2 = new Binding();
            //b2.Source = tabItem.IsSelected;
            ////b2.Converter = new BoolToVisibleOrHidden();
            ////b2.FallbackValue = Visibility.Visible;
            //closeTabButton.SetBinding(Button.IsEnabledProperty, b2);

            Grid tabGrid = new Grid();
            tabGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            tabGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Label label = new Label();
            label.Content = _title;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Center;
            tabGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            tabGrid.Children.Add(closeTabButton);
            Grid.SetColumn(closeTabButton, 1);
            tabItem.Header = tabGrid;


            Grid grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            grid.Margin = new Thickness(5);
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.Children.Add(closeTabButton);
            grid.Children.Add(contentControl);
            //Grid.SetColumn(closeTabButton, 0);
            //Grid.SetRow(closeTabButton, 0);
            Grid.SetColumn(contentControl, 0);
            //Grid.SetColumnSpan(contentControl, 2);
            Grid.SetRow(contentControl, 1);


            //tabItem.Content = contentControl;
            tabItem.Content = grid;
            //tabItem.HorizontalContentAlignment = HorizontalAlignment.Center;
            //tabItem.VerticalContentAlignment = VerticalAlignment.Center;
            SelectedTabItem = tabItem;
            return tabItem;
        }

        private void TabItemCreator (string _tabName)
        {
            IViewModel window;
            int pos = tabList.IndexOf(_tabName);
            if (pos < 0)
            {
                tabList.Add(_tabName);
                switch (_tabName)
                {
                    case registrationJournal:
                        window = new RegistrationJournalViewModel();
                        break;
                    case engineersEditor:
                        window = new EngineersEditorViewModel();
                        break;
                    case customersEditor:
                        window = new CustomersEditorViewModel();
                        break;
                    default:
                        window = null;
                        break;
                }
                TabItems.Add(CreateTabItem(_tabName, window));
            }
            else
            {
                SelectedTabItem = TabItems.ElementAt(pos);
            }
        }

        #endregion


        public MainWindowViewModel()
        {
            Test1 = new Command(OnTest1Execute);
            ExitCommand = new Command(OnExitCommandExecute);
            RegistrationJournalCommand = new Command(OnRegistrationJournalCommandExecute);
            CloseTabCommand = new Command(OnCloseTabCommandExecute);
            EditEngineersCommand = new Command(OnEditEngineersCommandExecute);
            EditCustomersCommand = new Command(OnEditCustomersCommandExecute);
            TabItems = new ObservableCollection<TabItem>();
        }

        public ObservableCollection<TabItem> TabItems
        {
            get { return GetValue<ObservableCollection<TabItem>>(TabItemsProperty); }
            set { SetValue(TabItemsProperty, value); }
        }

        public static readonly PropertyData TabItemsProperty = RegisterProperty(nameof(TabItems), typeof(ObservableCollection<TabItem>), null);

        public IViewModel CurrentWindow
        {
            get { return GetValue<IViewModel>(CurrentWindowProperty); }
            set { SetValue(CurrentWindowProperty, value); }
        }

        public static readonly PropertyData CurrentWindowProperty = RegisterProperty(nameof(CurrentWindow), typeof(IViewModel), null);

        public TabItem SelectedTabItem
        {
            get { return GetValue<TabItem>(SelectedTabItemProperty); }
            set { SetValue(SelectedTabItemProperty, value); }
        }

        public static readonly PropertyData SelectedTabItemProperty = RegisterProperty(nameof(SelectedTabItem), typeof(TabItem), null);

        public Command Test1 { get; private set; }

        private void OnTest1Execute()
        {
            // TODO: Handle command logic here
            var tabItem = new TabItem();
            tabItem.Header = "Test";
            TabItems.Add(tabItem);
        }

        public Command RegistrationJournalCommand { get; private set; }

        private void OnRegistrationJournalCommandExecute()
        {
            //TabItem temp = TabItems.Where(x => (string)x.Header == "Журнал регистрации исследований").FirstOrDefault();
            //if (temp == null)
            //{
            //    RegistrationJournalViewModel window = new RegistrationJournalViewModel();
            //    TabItems.Add(CreateTabItem("Журнал регистрации исследований", window));
            //}
            //else
            //{
            //    SelectedTabItem = temp;
            //}
            TabItemCreator(registrationJournal);
            //string sName = "Журнал регистрации исследований";
            
            //int tabItemNumb = .Key;

            //TabItem tabItem = 

            //windowsList.Add((RegistrationJournalViewModel)tempWindow);
            //var tabItem = new TabItem();
            //tabItem.Header = "Журнал регистрации исследований";
            //ContentControl contentControl = new ContentControl();
            //contentControl.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            //contentControl.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            //Binding b = new Binding();
            //b.Source = regJournalWindow;
            //b.Source = tempWindow;
            //b.Converter = new ViewModelToViewConverter();
            //contentControl.SetBinding(ContentControl.ContentProperty, b);
            //tabItem.Content = contentControl;
            //SelectedTabItem = tabItem;
            //CurrentWindow = (RegistrationJournalViewModel)tempWindow;
            //CurrentWindow = windowsList[windowsList.Count - 1];
            //CurrentWindow = regJournalWindow;
            //TabItems.Add(tabItem);
        }

        public Command EditEngineersCommand { get; private set; }

        private void OnEditEngineersCommandExecute()
        {
            //TabItem temp = TabItems.Where(x => (string)x.Header == "Список работников").FirstOrDefault();
            //if (temp == null)
            //{
            //    EngineersEditorViewModel window = new EngineersEditorViewModel();
            //    TabItems.Add(CreateTabItem("Список работников", window));
            //}
            //else
            //{
            //    SelectedTabItem = temp;
            //}
            TabItemCreator(engineersEditor);
            //string sName = "Список работников";
            //int pos = tabList.IndexOf(sName);
            //if (pos < 0)
            //{
            //    tabList.Add(sName);
            //    EngineersEditorViewModel window = new EngineersEditorViewModel();
            //    TabItems.Add(CreateTabItem(sName, window));
            //}
            //else
            //{
            //    SelectedTabItem = TabItems.ElementAt(pos);
            //}
        }

        public Command EditCustomersCommand { get; private set; }

        private void OnEditCustomersCommandExecute()
        {
            //TabItem temp = TabItems.Where(x => (string)x.Header == "Заказчики").FirstOrDefault();
            //if (temp == null)
            //{
            //    CustomersEditorViewModel window = new CustomersEditorViewModel();
            //    TabItems.Add(CreateTabItem("Заказчики", window));
            //}
            //else
            //{
            //    SelectedTabItem = temp;
            //}
            TabItemCreator(customersEditor);
            //string sName = "Заказчики";
            //int pos = tabList.IndexOf(sName);
            //if (pos < 0)
            //{
            //    tabList.Add(sName);
            //    CustomersEditorViewModel window = new CustomersEditorViewModel();
            //    TabItems.Add(CreateTabItem(sName, window));
            //}
            //else
            //{
            //    SelectedTabItem = TabItems.ElementAt(pos);
            //}
        }

        public Command CloseTabCommand { get; private set; }

        private void OnCloseTabCommandExecute()
        {
            tabList.Remove(tabList.ElementAt(TabItems.IndexOf(SelectedTabItem)));
            TabItems.Remove(SelectedTabItem);
        }

        public Command ExitCommand { get; private set; }

        private void OnExitCommandExecute()
        {
            App.Current.Shutdown();
        }

        public override string Title { get { return "MGDB"; } }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
