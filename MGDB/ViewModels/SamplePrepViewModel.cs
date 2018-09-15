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

namespace MGDB
{
    class SamplePrepViewModel: ViewModelBase
    {
        private MGDBModelContainer db;

        public SamplePrepViewModel()
        {
            db = new MGDBModelContainer();
            db.SamplePrepRecordSet.Load();
            db.CustomerSet.Load();
            db.MVZSet.Load();
            JournalData = db.SamplePrepRecordSet.Local;
            CustomersList = db.CustomerSet.ToList();
            ResearchNumbers = db.ResearchSet.Where(x => x.Status == StatusEnum.IsInWork).Select(x => x.Number).ToList();

            NewRecordCommand = new Command(OnNewRecordCommandExecute);
            SaveRecordCommand = new Command(OnSaveRecordCommandExecute);
        }

        ~SamplePrepViewModel()
        {
            db.Dispose();
        }

        #region Properties

        public ObservableCollection<SamplePrepRecord> JournalData
        {
            get { return GetValue<ObservableCollection<SamplePrepRecord>>(JournalDataProperty); }
            set { SetValue(JournalDataProperty, value); }
        }

        public static readonly PropertyData JournalDataProperty = RegisterProperty(nameof(JournalData), typeof(ObservableCollection<SamplePrepRecord>), null);

        public List<Customer> CustomersList
        {
            get { return GetValue<List<Customer>>(CustomersListProperty); }
            set { SetValue(CustomersListProperty, value); }
        }

        public static readonly PropertyData CustomersListProperty = RegisterProperty(nameof(CustomersList), typeof(List<Customer>), null);

        public List<MVZ> MVZList
        {
            get { return GetValue<List<MVZ>>(MVZListProperty); }
            set { SetValue(MVZListProperty, value); }
        }

        public static readonly PropertyData MVZListProperty = RegisterProperty(nameof(MVZList), typeof(List<MVZ>), null);

        public string CurrentNumber
        {
            get { return GetValue<string>(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        public static readonly PropertyData CurrentNumberProperty = RegisterProperty(nameof(CurrentNumber), typeof(string), null);

        public DateTime CurrentDate
        {
            get { return GetValue<DateTime>(CurrentDateProperty); }
            set { SetValue(CurrentDateProperty, value); }
        }

        public static readonly PropertyData CurrentDateProperty = RegisterProperty(nameof(CurrentDate), typeof(DateTime), null);

        public string CurrentTask
        {
            get { return GetValue<string>(CurrentTaskProperty); }
            set { SetValue(CurrentTaskProperty, value); }
        }

        public static readonly PropertyData CurrentTaskProperty = RegisterProperty(nameof(CurrentTask), typeof(string), null);

        public Customer CurrentCustomer
        {
            get { return GetValue<Customer>(CurrentCustomerProperty); }
            set
            {
                SetValue(CurrentCustomerProperty, value);
                MVZList = value.MVZList.ToList();
            }
        }

        public static readonly PropertyData CurrentCustomerProperty = RegisterProperty(nameof(CurrentCustomer), typeof(Customer), null);

        public int CurrentCustomerIndex
        {
            get { return GetValue<int>(CurrentCustomerIndexProperty); }
            set { SetValue(CurrentCustomerIndexProperty, value); }
        }

        public static readonly PropertyData CurrentCustomerIndexProperty = RegisterProperty(nameof(CurrentCustomerIndex), typeof(int), null);

        public MVZ CurrentMVZ
        {
            get { return GetValue<MVZ>(CurrentMVZProperty); }
            set { SetValue(CurrentMVZProperty, value); }
        }

        public static readonly PropertyData CurrentMVZProperty = RegisterProperty(nameof(CurrentMVZ), typeof(MVZ), null);

        public int CurrentMVZIndex
        {
            get { return GetValue<int>(CurrentMVZIndexProperty); }
            set { SetValue(CurrentMVZIndexProperty, value); }
        }

        public static readonly PropertyData CurrentMVZIndexProperty = RegisterProperty(nameof(CurrentMVZIndex), typeof(int), null);

        public SamplePrepRecord CurrentRecord
        {
            get { return GetValue<SamplePrepRecord>(CurrentRecordProperty); }
            set
            {
                SetValue(CurrentRecordProperty, value);
                CurrentNumber = value.Number;
                CurrentDate = value.Date;
                CurrentCustomer = value.Customer;
                CurrentMVZIndex = MVZList.IndexOf(value.MVZ);
                CurrentTask = value.Task;
                SelectedResearchNumber = value.ResearchNumber;
            }
        }

        public static readonly PropertyData CurrentRecordProperty = RegisterProperty(nameof(CurrentRecord), typeof(SamplePrepRecord), null);

        public int CurrentRecordIndex
        {
            get { return GetValue<int>(CurrentRecordIndexProperty); }
            set { SetValue(CurrentRecordIndexProperty, value); }
        }

        public static readonly PropertyData CurrentRecordIndexProperty = RegisterProperty(nameof(CurrentRecordIndex), typeof(int), null);

        public List<string> ResearchNumbers
        {
            get { return GetValue<List<string>>(ResearchNumbersProperty); }
            set { SetValue(ResearchNumbersProperty, value); }
        }

        public static readonly PropertyData ResearchNumbersProperty = RegisterProperty(nameof(ResearchNumbers), typeof(List<string>), null);

        public string SelectedResearchNumber
        {
            get { return GetValue<string>(SelectedResearchNumberProperty); }
            set { SetValue(SelectedResearchNumberProperty, value); }
        }

        public static readonly PropertyData SelectedResearchNumberProperty = RegisterProperty(nameof(SelectedResearchNumber), typeof(string), null);

        public int ResearchNumberIndex
        {
            get { return GetValue<int>(ResearchNumberIndexProperty); }
            set { SetValue(ResearchNumberIndexProperty, value); }
        }

        public static readonly PropertyData ResearchNumberIndexProperty = RegisterProperty(nameof(ResearchNumberIndex), typeof(int), null);
        #endregion

        #region Methods

        public Command NewRecordCommand { get; private set; }

        private void OnNewRecordCommandExecute()
        {
            CurrentRecordIndex = -1;
            CurrentNumber = "";
            CurrentDate = DateTime.Now;
            CurrentCustomerIndex = -1;
            CurrentMVZIndex = -1;
            CurrentTask = "";
            ResearchNumberIndex = -1;
        }

        public Command SaveRecordCommand { get; private set; }

        private void OnSaveRecordCommandExecute()
        {
            SamplePrepRecord record = db.SamplePrepRecordSet.Where(x => x.Number == CurrentNumber).FirstOrDefault() ?? new SamplePrepRecord();
            if (record.Number == null)
            {
                record.Number = CurrentNumber;
                record.Date = CurrentDate;
                record.Customer = CurrentCustomer;
                record.MVZ = CurrentMVZ;
                record.Task = CurrentTask;
                record.ResearchNumber = SelectedResearchNumber;
                db.SamplePrepRecordSet.Add(record);
            }
            else
            {
                record.Number = CurrentNumber;
                record.Date = CurrentDate;
                record.Customer = CurrentCustomer;
                record.MVZ = CurrentMVZ;
                record.Task = CurrentTask;
                record.ResearchNumber = SelectedResearchNumber;
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
