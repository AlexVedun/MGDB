namespace MGDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public partial class Research: INotifyPropertyChanged
    {
        private short numberOfSamples;
        private string number;
        private DateTime date;
        private string description;
        private MVZ mvz;
        private Customer customer;
        private TypeOfResearch typeOfResearch;

        public int Id { get; set; }
        [MaxLength(8)]
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                NotifyPropertyChanged();
            }
        }
        public System.DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                NotifyPropertyChanged();
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }
        public short NumberOfSamples
        {
            get
            {
                return numberOfSamples;
            }
            set
            {
                numberOfSamples = value;
                NotifyPropertyChanged();
            }
        }
        [MaxLength(512)]
        public string Notation { get; set; }
        public StatusEnum Status { get; set; }
        [MaxLength(512)]
        public string StatusDescription { get; set; }
        public string ResearchResults { get; set; }
        public Nullable<TypeOfDefectEnum> TypeOfDefect { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        [MaxLengthAttribute]
        public byte[] Document1 { get; set; }
        [MaxLengthAttribute]
        public byte[] Document2 { get; set; }
        [MaxLengthAttribute]
        public byte[] Document3 { get; set; }
        public int ListOfEngineersId { get; set; }
        public int MVZListId { get; set; }
        public int CustomersListId { get; set; }
        public int TypeOfResearchId { get; set; }
    
        public virtual Engineer Engineer { get; set; }
        public virtual MVZ MVZ
        {
            get
            {
                return mvz;
            }
            set
            {
                mvz = value;
                NotifyPropertyChanged();
            }
        }
        public virtual Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                NotifyPropertyChanged();
            }
        }
        public virtual TypeOfResearch Type
        {
            get
            {
                return typeOfResearch;
            }
            set
            {
                typeOfResearch = value;
                NotifyPropertyChanged();
            }
        }
        public virtual ResearchData ResearchData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
