//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MGDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SamplePrepJournal
    {
        public int Id { get; set; }
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
