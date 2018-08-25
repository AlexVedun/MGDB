namespace MGDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SamplePrepRecord
    {
        public int Id { get; set; }
        [MaxLength(8)]
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public string Task { get; set; }
        public int ListOfEngineersId { get; set; }
        public int CustomersListId { get; set; }
        public int MVZListId { get; set; }
    
        public virtual Engineer Engineer { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual MVZ MVZ { get; set; }
    }
}
