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

    public class EngineersEditorViewModel : ViewModelBase
    {
        private MGDBModelContainer db;

        public EngineersEditorViewModel()
        {
            db = new MGDBModelContainer();
            db.EngineerSet.Load();
            EngineersList = db.EngineerSet.Local;

            AddEngineerCommand = new Command(OnAddEngineerCommandExecute);
            EditEngineerCommand = new Command(OnEditEngineerCommandExecute);
            ClearTextCommand = new Command(OnClearTextCommandExecute);
        }

        ~EngineersEditorViewModel()
        {
            db.SaveChanges();
            db.Dispose();
        }
        #region Properties
        public ObservableCollection<Engineer> EngineersList
        {
            get { return GetValue<ObservableCollection<Engineer>>(EngineersListProperty); }
            set { SetValue(EngineersListProperty, value); }
        }

        public Engineer SelectedEngineer
        {
            get { return GetValue<Engineer>(SelectedEngineerProperty); }
            set
            {
                SetValue(SelectedEngineerProperty, value);
                EngineerName = value.Name;
                EngineerPassword = value.Password;
            }
        }

        public string EngineerName
        {
            get { return GetValue<string>(EngineerNameProperty); }
            set { SetValue(EngineerNameProperty, value); }
        }

        public string EngineerPassword
        {
            get { return GetValue<string>(EngineerPasswordProperty); }
            set { SetValue(EngineerPasswordProperty, value); }
        }

        public static readonly PropertyData EngineerPasswordProperty = RegisterProperty(nameof(EngineerPassword), typeof(string), null);
        public static readonly PropertyData EngineerNameProperty = RegisterProperty(nameof(EngineerName), typeof(string), null);
        public static readonly PropertyData SelectedEngineerProperty = RegisterProperty(nameof(SelectedEngineer), typeof(Engineer), null);
        public static readonly PropertyData EngineersListProperty = RegisterProperty(nameof(EngineersList), typeof(ObservableCollection<Engineer>), null);
        #endregion

        #region Commands

        public Command AddEngineerCommand { get; private set; }
   
        private void OnAddEngineerCommandExecute()
        {
            Engineer newEngineer = new Engineer();
            newEngineer.Name = EngineerName;
            newEngineer.Password = EngineerPassword;
            db.EngineerSet.Add(newEngineer);
            db.SaveChanges();
        }

        public Command EditEngineerCommand { get; private set; }

        private void OnEditEngineerCommandExecute()
        {
            SelectedEngineer.Name = EngineerName;
            SelectedEngineer.Password = EngineerPassword;
            db.SaveChanges();
        }

        public Command ClearTextCommand { get; private set; }

        private void OnClearTextCommandExecute()
        {
            EngineerName = "";
            EngineerPassword = "";
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
