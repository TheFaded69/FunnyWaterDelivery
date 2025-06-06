using System.ComponentModel;

namespace FunnyWaterDelivery.Common.Enums;

public enum EmployeeType : int
{
    None = 0,
    
    /// <summary>
    /// Работник
    /// </summary>
    [Description("Работник")]
    Worker = 1,
    
    /// <summary>
    /// Руководитель
    /// </summary>
    [Description("Руководитель")]
    Supervisor = 2,
}