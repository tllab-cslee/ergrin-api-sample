using System.ComponentModel;

namespace ERgrinApiSample
{
    internal class MyProps
    {
        //--------------------------------------------------------------------------------
        // Properties
        //--------------------------------------------------------------------------------

        [Category("Entity"), Description("엔티티의 UUID"), DisplayName("\t\tUUID"), ReadOnly(true)]
        public string? EntityID { get; set; } = default;

        [Category("Entity"), Description("엔티티의 논리 이름"), DisplayName("\tLogical Name")]
        public string? EntityLogicalName { get; set; } = default;

        [Category("Entity"), Description("엔티티의 물리 이름"), DisplayName("\tPhysical Name")]
        public string? EntityPhysicalName { get; set; } = default;

        [Category("Entity"), Description("엔티티의 설명"), DisplayName("Description")]
        public string? EntityDescription { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 UUID"), DisplayName("\t\t\tUUID"), ReadOnly(true)]
        public string? AttributeID { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 논리 이름"), DisplayName("\t\tLogical Name")]
        public string? AttributeLogicalName { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 물리 이름"), DisplayName("\t\tPhysical Name")]
        public string? AttributePhysicalName { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 Null 허용 여부"), DisplayName("Nullable")]
        public bool? AttributeNullable { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 PK 여부"), DisplayName("IsKey")]
        public bool? AttributeIsKey { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 FK 여부"), DisplayName("IsForeignKey"), ReadOnly(true)]
        public bool? AttributeIsForeignKey { get; set; } = default;

        [TypeConverter(typeof(DomainNameConverter))]
        [Category("Entity Attribute"), Description("엔티티 속성의 도메인 이름"), DisplayName("Domain Name")]
        public string? AttributeDomainName { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 데이터 타입"), DisplayName("Data Type")]
        public string? AttributeDataType { get; set; } = default;

        [Category("Entity Attribute"), Description("엔티티 속성의 설명"), DisplayName("\tDescription")]
        public string? AttributeDescription { get; set; } = default;

        //--------------------------------------------------------------------------------
        // Initializer / Public Methods
        //--------------------------------------------------------------------------------

        public MyProps(MyProject myProject)
        {
            project = myProject;
        }

        public List<string>? GetDomains()
        {
            return project.Domains?.Select(x => x.Name!).ToList();
        }

        //--------------------------------------------------------------------------------
        // Private Fields
        //--------------------------------------------------------------------------------

        private MyProject project;
    }

    internal class DomainNameConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? context)
        {
            List<string>? list = null;

            if (context?.Instance is ERgrinApiSample.MyProps props)
            {
                list = props.GetDomains();
            }

            StandardValuesCollection cols = new StandardValuesCollection(list);
            return cols;
        }
    }
}
