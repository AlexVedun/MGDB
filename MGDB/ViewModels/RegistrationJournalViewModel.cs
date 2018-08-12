using Catel.Data;
using Catel.MVVM;
using MGDB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDB
{
    class RegistrationJournalViewModel : ViewModelBase
    {
        public RegistrationJournalViewModel()
        {
            using (MGDBModelContainer db = new MGDBModelContainer())
            {
                //JournalData = new ObservableCollection<MainJournal>();
                //foreach (var item in db.MainJournalSet.ToList())
                //{
                //    JournalData.Add(item);
                //}
                //ListOfEngineers engineer = new ListOfEngineers();
                //engineer.Name = "Ефременко А.В.";
                //engineer.Password = "1984";
                //db.ListOfEngineersSet.Add(engineer);
                //CustomersList customer = new CustomersList();
                //customer.Name = "ТЛЦ";
                //db.CustomersListSet.Add(customer);
                //MVZList MVZ = new MVZList();
                //MVZ.MVZ = "009-9091";
                //db.MVZListSet.Add(MVZ);
                //TypeOfResearch typeOfRes = new TypeOfResearch();
                //typeOfRes.Type = "Поломки";
                //db.TypeOfResearchSet.Add(typeOfRes);
                //TypeOfResearch typeOfRes2 = new TypeOfResearch();
                //typeOfRes2.Type = "Дефекты металлопродукции";
                //db.TypeOfResearchSet.Add(typeOfRes2);

                //MainJournal rec = new MainJournal();
                //rec.Date = DateTime.Now;
                //rec.Number = "18-001";
                //rec.Customer = (ICollection<CustomersList>)db.CustomersListSet.FirstOrDefault(x => x.Name == "ТЛЦ");
                //rec.Engineer = (ICollection<ListOfEngineers>)db.ListOfEngineersSet.FirstOrDefault(x => x.Name == "Ефременко А.В.");
                //rec.MVZ = (ICollection<MVZList>)db.MVZListSet.FirstOrDefault(x => x.MVZ == "009-9091");
                //rec.Type = (ICollection<TypeOfResearch>)db.TypeOfResearchSet.FirstOrDefault(x => x.Type == "Дефекты металлопродукции");
                //rec.Description = "Металлографическое исследование пробы от листа";
                //rec.Notation = "Проба от листа";
                //rec.Status = StatusEnum.IsInWork;
                //db.SaveChanges();
                //MainJournal rec1 = new MainJournal();
                //rec1.
                JournalData = db.MainJournalSet.Local;
            }
        }

        ~RegistrationJournalViewModel()
        {

        }

        public ObservableCollection<MainJournal> JournalData
        {
            get { return GetValue<ObservableCollection<MainJournal>>(JournalDataProperty); }
            set { SetValue(JournalDataProperty, value); }
        }

        public static readonly PropertyData JournalDataProperty = RegisterProperty(nameof(JournalData), typeof(ObservableCollection<MainJournal>), null);
        
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
    }
}
