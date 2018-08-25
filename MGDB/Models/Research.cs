namespace MGDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Research
    {
        public int Id { get; set; }
        [MaxLength(8)]
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public short NumberOfSamples { get; set; }
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
        public virtual MVZ MVZ { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual TypeOfResearch Type { get; set; }
        public virtual ResearchData ResearchData { get; set; }
    }
}
