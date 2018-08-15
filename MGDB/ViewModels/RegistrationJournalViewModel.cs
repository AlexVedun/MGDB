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
                //rec.Number = "18-001";
                //rec.Customer = db.CustomerSet.FirstOrDefault(x => x.Name == "ТЛЦ");
                //rec.Engineer = db.EngineerSet.FirstOrDefault(x => x.Name == "Ефременко А.В.");
                //rec.MVZ = db.MVZSet.FirstOrDefault(x => x.Text == "009-9091");
                //rec.Type = db.TypeOfResearchSet.FirstOrDefault(x => x.Type == "Дефекты металлопродукции");
                //rec.Description = "Металлографическое исследование пробы от листа";
                //rec.Notation = "Проба от листа";
                //rec.Status = StatusEnum.IsInWork;
                //rec.FinishDate = DateTime.Now;
                //ResearchData dataJ = new ResearchData();
                //rec.ResearchData = dataJ;
                //db.ResearchSet.Add(rec);
                //db.SaveChanges();
                //MainJournal rec1 = new MainJournal();
                //rec1.
                JournalData = db.ResearchSet.Local;
            }
        }

        ~RegistrationJournalViewModel()
        {

        }

        public ObservableCollection<Research> JournalData
        {
            get { return GetValue<ObservableCollection<Research>>(JournalDataProperty); }
            set { SetValue(JournalDataProperty, value); }
        }

        public static readonly PropertyData JournalDataProperty = RegisterProperty(nameof(JournalData), typeof(ObservableCollection<Research>), null);
        
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
