using System.ComponentModel;

namespace Technical.Permissions.Contracts
{
    /// <summary>
    /// Die Operationen sind in der Entity OperationType (Tabelle OPERATION_TYPES) abgelegt. 
    /// Das Property OperationType.OperationId (Spalte OPT_ID) ist im Enum-Member-Attribut "Description" hinterlegt.
    /// </summary>
    public enum EDefaultOperation
    {
        [Description("Read")] ReadDataAndAccessModule,

        [Description("Write")] WriteData,

        [Description("Delete")] DeleteData
    }
}