namespace MGDB.Models
{
    using System;
    
    public enum StatusEnum : int
    {
        IsInWork = 0,
        IsDone = 1,
        IsSuspended = 2,
        IsCanceled = 3
    }
}
