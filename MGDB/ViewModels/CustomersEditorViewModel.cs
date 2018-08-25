using Catel.Data;
using Catel.MVVM;
using MGDB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDB.ViewModels
{

    public class CustomersEditorViewModel : ViewModelBase
    {
        private MGDBModelContainer db;

        public CustomersEditorViewModel()
        {
            db = new MGDBModelContainer();
            db.CustomerSet.Load();
            db.MVZSet.Load();
            CustomersList = db.CustomerSet.Local;
            MVZList = new ObservableCollection<MVZ>();

            AddMVZCommand = new Command(OnAddMVZCommandExecute);
            EditMVZCommand = new Command(OnEditMVZCommandExecute);
            AddEditCustomerCommand = new Command(OnAddEditCustomerCommandExecute);
        }

        ~CustomersEditorViewModel()
        {
            db.Dispose();
        }

        #region Properties

        public ObservableCollection<Customer> CustomersList
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersListProperty); }
            set { SetValue(CustomersListProperty, value); }
        }

        public static readonly PropertyData CustomersListProperty = RegisterProperty(nameof(CustomersList), typeof(ObservableCollection<Customer>), null);

        public Customer SelectedCustomer
        {
            get { return GetValue<Customer>(SelectedCustomerProperty); }
            set
            {
                SetValue(SelectedCustomerProperty, value);
                CurrentCustomerName = value.Name;
                MVZList.Clear();
                foreach (var item in value.MVZList)
                {
                    MVZList.Add(item);
                }
            }
        }

        public static readonly PropertyData SelectedCustomerProperty = RegisterProperty(nameof(SelectedCustomer), typeof(Customer), null);

        public string CurrentCustomerName
        {
            get { return GetValue<string>(CurrentCustomerNameProperty); }
            set { SetValue(CurrentCustomerNameProperty, value); }
        }

        public static readonly PropertyData CurrentCustomerNameProperty = RegisterProperty(nameof(CurrentCustomerName), typeof(string), null);

        public ObservableCollection<MVZ> MVZList
        {
            get { return GetValue<ObservableCollection<MVZ>>(MVZListProperty); }
            set { SetValue(MVZListProperty, value); }
        }

        public static readonly PropertyData MVZListProperty = RegisterProperty(nameof(MVZList), typeof(ObservableCollection<MVZ>), null);

        public MVZ SelectedMVZ
        {
            get { return GetValue<MVZ>(SelectedMVZProperty); }
            set
            {
                SetValue(SelectedMVZProperty, value);
                NewMVZText = value.Text;
            }
        }

        public static readonly PropertyData SelectedMVZProperty = RegisterProperty(nameof(SelectedMVZ), typeof(MVZ), null);

        public string NewMVZText
        {
            get { return GetValue<string>(NewMVZTextProperty); }
            set { SetValue(NewMVZTextProperty, value); }
        }

        public static readonly PropertyData NewMVZTextProperty = RegisterProperty(nameof(NewMVZText), typeof(string), null);
        #endregion

        #region Commands

        public Command AddMVZCommand { get; private set; }

        private void OnAddMVZCommandExecute()
        {
            MVZ newMVZ = db.MVZSet.Where(x => x.Text == NewMVZText).FirstOrDefault() ?? new MVZ();
            if (newMVZ.Text == null)
            {
                newMVZ.Text = NewMVZText;
            }
            MVZList.Add(newMVZ);
            NewMVZText = "";
        }

        public Command EditMVZCommand { get; private set; }

        private void OnEditMVZCommandExecute()
        {
            SelectedMVZ.Text = NewMVZText;
            NewMVZText = "";
        }

        public Command AddEditCustomerCommand { get; private set; }

        private void OnAddEditCustomerCommandExecute()
        {
            Customer customer = db.CustomerSet.Where(x => x.Name == CurrentCustomerName).FirstOrDefault() ?? new Customer();
            if (customer.Name == null)
            {
                customer.Name = CurrentCustomerName;
                customer.MVZList = new ObservableCollection<MVZ>();
                foreach (var item in MVZList)
                {
                    customer.MVZList.Add(item);
                }
                CustomersList.Add(customer);
            }
            else
            {
                customer.MVZList.Clear();
                foreach (var item in MVZList)
                {
                    customer.MVZList.Add(item);
                }
            }
            db.SaveChanges();
        }

        #endregion    

        #region Other
        public override string Title { get { return ""; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

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
        #endregion
    }
}
