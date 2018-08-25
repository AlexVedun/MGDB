namespace MGDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResearchData
    {
        public int Id { get; set; }
        public string SampleMarks { get; set; }
        public string Steel { get; set; }
        public string Melt { get; set; }
        public Nullable<byte> MNLZ { get; set; }
        public Nullable<short> Slab { get; set; }
        public string Part { get; set; }
        public Nullable<short> Plate { get; set; }
        public Nullable<float> Thickness { get; set; }
        public string TypeOfTest { get; set; }
        public string Requirements { get; set; }
        public string ResultsOfTest { get; set; }
    }
}
