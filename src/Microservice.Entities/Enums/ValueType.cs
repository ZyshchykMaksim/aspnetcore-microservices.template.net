using System.ComponentModel;

namespace Microservice.Entities.Enums
{
    /// <summary>
    /// The type of value.
    /// </summary>
    public enum ValueType
    {
        [Description("The value without type.")]
        None = 0,

        [Description("The value with Value1 type.")]
        Value1,

        [Description("The value with Value2 type.")]
        Value2
    }
}
