using ERgrin.Api;

namespace ERgrinApiSample
{
    internal class MyProject
    {
        //--------------------------------------------------------------------------------
        // Properties
        //--------------------------------------------------------------------------------

        public List<Model>? Models { get; set; }
        public List<Entity>? Entities { get; set; }
        public List<ERgrin.Api.Attribute>? Attributes { get; set; }
        public List<Domain>? Domains { get; set; }

        //--------------------------------------------------------------------------------
        // Public Methods
        //--------------------------------------------------------------------------------

        public void LoadFile(string filepath)
        {
            Models = null;
            Entities = null;
            Attributes = null;

            project = new Project();
            project.Load(filepath);

            Models = project.Models;
        }

        public void SaveFile(string filePath = default!)
        {
            project?.Apply(filePath);
        }

        public void SetEntities(Model? model, string diagramName)
        {
            Entities = model?.GetEntities(diagramName);
        }

        public void SetDomains(Model? model)
        {
            Domains = model?.Domains;
        }

        public void SetAttribute(Entity? entity)
        {
            Attributes = entity?.Attributes;
        }

        public Model? FindModel(string name)
        {
            return Models?.Where(x => name.Equals(x.LogicalName)).FirstOrDefault();
        }

        public Diagram? FindDiagram(Model? model, string name)
        {
            return model?.Diagrams?.Where(x => name.Equals(x.Name)).FirstOrDefault();
        }

        public Entity? FindEntity(string name)
        {
            return Entities?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public ERgrin.Api.Attribute? FindAttribute(string name)
        {
            return Attributes?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public MyProps GetProps(Entity? entity, ERgrin.Api.Attribute? attribute)
        {
            var props = new MyProps(this);

            // Entity Properties
            props.EntityID = entity?.ID!.ToUpper();
            props.EntityLogicalName = entity?.LogicalName;
            props.EntityPhysicalName = entity?.PhysicalName;
            props.EntityDescription = entity?.Description;

            // Entity Attribute Properties
            props.AttributeID = attribute?.ID!.ToUpper();
            props.AttributeLogicalName = attribute?.LogicalName;
            props.AttributePhysicalName = attribute?.PhysicalName;
            props.AttributeDescription = attribute?.Description;
            props.AttributeNullable = attribute?.Nullable;
            props.AttributeIsKey = attribute?.IsKey;
            props.AttributeIsForeignKey = attribute?.IsForeignKey;
            props.AttributeDomainName = attribute?.DomainName;
            props.AttributeDataType = attribute?.DataType;

            return props;
        }

        //--------------------------------------------------------------------------------
        // Private Fields
        //--------------------------------------------------------------------------------

        private Project? project;
    }
}
