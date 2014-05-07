using System;

namespace Core.Repository.Base
{
    public interface IDataTransferObjectAuditFields
    {
        DateTime InsDat { get; set; }
        string InsOper { get; set; }
        DateTime? MutDat { get; set; }
        string MutOper { get; set; }
    }
}