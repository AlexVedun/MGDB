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
    class RegistrationJournalViewModel : ViewModelBase
    {
        private MGDBModelContainer db;
        //private bool isChanged = false;

        public RegistrationJournalViewModel()
        {
            db = new MGDBModelContainer();
            //CustomersList = db.CustomerSet.Select(x=>x.Name).ToList();
            db.ResearchSet.Load();
            db.CustomerSet.Load();
            db.MVZSet.Load();
            db.TypeOfResearchSet.Load();
            CustomersList = db.CustomerSet.ToList();
            ResearchType = db.TypeOfResearchSet.ToList();
            //MVZList = db.MVZSet.ToList();
            JournalData = db.ResearchSet.Local;
            //JournalData = (ObservableCollection < Research > )db.ResearchSet.Select(x=> new { x.Number, x.Date, x.Customer, x.MVZ, x.Description, x.NumberOfSamples});
            //using (MGDBModelContainer db = new MGDBModelContainer())
            //{
            //JournalData = new ObservableCollection<MainJournal>();
            //foreach (var item in db.MainJournalSet.ToList())
            //{
            //    JournalData.Add(item);
            //}
            //Engineer engineer = new Engineer();
            //engineer.Name = "Ефременко А.В.";
            //engineer.Password = "1984";
            //db.EngineerSet.Add(engineer);
            //Customer customer = new Customer();
            //customer.Name = "ТЛЦ";
            //customer.MVZList.Add(new MVZ { Text = "000-0091" });
            //customer.MVZList.Add(new MVZ { Text = "000-9091" });
            //customer.MVZList.Add(new MVZ { Text = "009-9091" });
            //db.CustomerSet.Add(customer);
            //TypeOfResearch typeOfRes = new TypeOfResearch();
            //typeOfRes.Type = "Поломки";
            //db.TypeOfResearchSet.Add(typeOfRes);
            //TypeOfResearch typeOfRes2 = new TypeOfResearch();
            //typeOfRes2.Type = "Дефекты металлопродукции";
            //db.TypeOfResearchSet.Add(typeOfRes2);
            //db.SaveChanges();

            //Research rec = new Research();
            //rec.Date = DateTime.Now;
            //rec.Number = "18-002";
            //rec.Customer = db.CustomerSet.FirstOrDefault(x => x.Name == "ТЛЦ");
            //rec.Engineer = db.EngineerSet.FirstOrDefault(x => x.Name == "Ефременко А.В.");
            //rec.MVZ = db.MVZSet.FirstOrDefault(x => x.Text == "009-9091");
            //rec.Type = db.TypeOfResearchSet.FirstOrDefault(x => x.Type == "Дефекты металлопродукции");
            //rec.Description = "Металлографическое исследование пробы от листа";
            //rec.Notation = "Проба от листа";
            //rec.Status = StatusEnum.IsInWork;
            ////rec.FinishDate = DateTime.Now;
            //ResearchData dataJ = new ResearchData();
            //rec.ResearchData = dataJ;
            //db.ResearchSet.Add(rec);
            //db.SaveChanges();
            //MainJournal rec1 = new MainJournal();
            //rec1.
            //JournalData = db.ResearchSet.Local;
            //}

            NewRecordCommand = new Command(OnNewRecordCommandExecute);
            SaveRecordCommand = new Command(OnSaveRecordCommandExecute);
        }

        ~RegistrationJournalViewModel()
        {
            //db.SaveChanges();
            db.Dispose();
        }

        #region Property

        public ObservableCollection<Research> JournalData
        {
            get { return GetValue<ObservableCollection<Research>>(JournalDataProperty); }
            set { SetValue(JournalDataProperty, value); }
        }

        public static readonly PropertyData JournalDataProperty = RegisterProperty(nameof(JournalData), typeof(ObservableCollection<Research>), null);

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
            set
            {
                SetValue(CurrentNumberProperty, value);
                //CurrentResearch.Number = value;
                //db.SaveChanges();
            }
        }

        public static readonly PropertyData CurrentNumberProperty = RegisterProperty(nameof(CurrentNumber), typeof(string), null);

        public DateTime CurrentDate
        {
            get { return GetValue<DateTime>(CurrentDateProperty); }
            set
            {
                SetValue(CurrentDateProperty, value);
                //CurrentResearch.Date = value;
                //db.SaveChanges();
            }
        }

        public static readonly PropertyData CurrentDateProperty = RegisterProperty(nameof(CurrentDate), typeof(DateTime), null);

        public string CurrentDescription
        {
            get { return GetValue<string>(CurrentDescriptionProperty); }
            set
            {
                SetValue(CurrentDescriptionProperty, value);
                //CurrentResearch.Description = value;
                //db.SaveChanges();
            }
        }

        public static readonly PropertyData CurrentDescriptionProperty = RegisterProperty(nameof(CurrentDescription), typeof(string), null);

        public short CurrentNumberOfSamples
        {
            get { return GetValue<short>(CurrentNumberOfSamplesProperty); }
            set
            {
                SetValue(CurrentNumberOfSamplesProperty, value);
                //CurrentResearch.NumberOfSamples = value;
                //db.SaveChanges();
            }
        }

        public static readonly PropertyData CurrentNumberOfSamplesProperty = RegisterProperty(nameof(CurrentNumberOfSamples), typeof(short), null);

        public Customer CurrentCustomer
        {
            get { return GetValue<Customer>(CurrentCustomerProperty); }
            set
            {
                SetValue(CurrentCustomerProperty, value);
                //CurrentResearch.Customer = value;
                MVZList = value.MVZList.ToList();
                //db.SaveChanges();
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
            set
            {
                SetValue(CurrentMVZProperty, value);
                //CurrentResearch.MVZ = value;
                //db.SaveChanges();
            }
        }

        public static readonly PropertyData CurrentMVZProperty = RegisterProperty(nameof(CurrentMVZ), typeof(MVZ), null);

        public int CurrentMVZIndex
        {
            get { return GetValue<int>(CurrentMVZIndexProperty); }
            set { SetValue(CurrentMVZIndexProperty, value); }
        }

        public static readonly PropertyData CurrentMVZIndexProperty = RegisterProperty(nameof(CurrentMVZIndex), typeof(int), null);

        public Research CurrentResearch
        {
            get { return GetValue<Research>(CurrentResearchProperty); }
            set
            {
                SetValue(CurrentResearchProperty, value);
                CurrentNumber = value.Number;
                CurrentDate = value.Date;
                CurrentCustomer = value.Customer;
                //MVZList = value.Customer.MVZList.ToList();
                //CurrentMVZ = value.MVZ;
                CurrentResearchType = value.Type;
                //CurrentMVZ = MVZList.ElementAt(MVZList.IndexOf(value.MVZ));
                CurrentMVZIndex = MVZList.IndexOf(value.MVZ);
                CurrentResearchTypeIndex = ResearchType.IndexOf(value.Type);
                CurrentDescription = value.Description;
                CurrentNumberOfSamples = value.NumberOfSamples;
            }
        }

        public static readonly PropertyData CurrentResearchProperty = RegisterProperty(nameof(CurrentResearch), typeof(Research), null);

        public int CurrentResearchIndex
        {
            get { return GetValue<int>(CurrentResearchIndexProperty); }
            set { SetValue(CurrentResearchIndexProperty, value); }
        }

        public static readonly PropertyData CurrentResearchIndexProperty = RegisterProperty(nameof(CurrentResearchIndex), typeof(int), null);

        public List<TypeOfResearch> ResearchType
        {
            get { return GetValue<List<TypeOfResearch>>(ResearchTypeProperty); }
            set { SetValue(ResearchTypeProperty, value); }
        }

        public static readonly PropertyData ResearchTypeProperty = RegisterProperty(nameof(ResearchType), typeof(List<TypeOfResearch>), null);

        public TypeOfResearch CurrentResearchType
        {
            get { return GetValue<TypeOfResearch>(CurrentResearchTypeProperty); }
            set { SetValue(CurrentResearchTypeProperty, value); }
        }

        public static readonly PropertyData CurrentResearchTypeProperty = RegisterProperty(nameof(CurrentResearchType), typeof(TypeOfResearch), null);

        public int CurrentResearchTypeIndex
        {
            get { return GetValue<int>(CurrentResearchTypeIndexProperty); }
            set { SetValue(CurrentResearchTypeIndexProperty, value); }
        }

        public static readonly PropertyData CurrentResearchTypeIndexProperty = RegisterProperty(nameof(CurrentResearchTypeIndex), typeof(int), null);
        #endregion

        #region Commands

        public Command NewRecordCommand { get; private set; }

        private void OnNewRecordCommandExecute()
        {
            CurrentResearchIndex = -1;
            CurrentDate = DateTime.Now;
            CurrentNumber = "";
            CurrentCustomerIndex = -1;
            CurrentMVZIndex = -1;
            CurrentResearchTypeIndex = -1;
            CurrentDescription = "";
            CurrentNumberOfSamples = 0;
        }

        public Command SaveRecordCommand { get; private set; }

        private void OnSaveRecordCommandExecute()
        {
            Research research = db.ResearchSet.Where(x => x.Number == CurrentNumber).FirstOrDefault() ?? new Research();
            if (research.Number == null)
            {
                research.Number = CurrentNumber;
                research.Date = CurrentDate;
                research.Customer = CurrentCustomer;
                research.MVZ = CurrentMVZ;
                research.Type = CurrentResearchType;
                research.Description = CurrentDescription;
                research.NumberOfSamples = CurrentNumberOfSamples;
                research.ResearchData = new ResearchData();
                db.ResearchSet.Add(research);
            }
            else
            {
                research.Date = CurrentDate;
                research.Customer = CurrentCustomer;
                research.MVZ = CurrentMVZ;
                research.Type = CurrentResearchType;
                research.Description = CurrentDescription;
                research.NumberOfSamples = CurrentNumberOfSamples;
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
