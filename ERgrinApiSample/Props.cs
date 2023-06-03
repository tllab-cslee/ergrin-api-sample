using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp1
{
    internal class Props
    {
        [Category("Entity"), Description("엔티티의 UUID"), DisplayName("UUID"), ReadOnly(true)]
        public string? EntityID { get; set; } = default;

        [Category("Entity"), Description("엔티티의 논리 이름"), DisplayName("Logical Name")]
        public string? EntityLogicalName { get; set; } = default;

        [Category("Entity"), Description("엔티티의 물리 이름"), DisplayName("Physical Name")]
        public string? EntityPhysicalName { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 UUID"), DisplayName("UUID"), ReadOnly(true)]
        public string? AttributeID { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 논리 이름"), DisplayName("Logical Name")]
        public string? AttributeLogicalName { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 물리 이름"), DisplayName("Physical Name")]
        public string? AttributePhysicalName { get; set; } = default;
    }
}
