using ERgrin.Api;
using System.Windows.Forms;

namespace ERgrinApiSample
{
    internal class MyProject
    {
        public List<Model>? Models => project?.Models;
        public List<Entity>? Entities { get; set; }
        public List<ERgrin.Api.Attribute>? Attributes { get; set; }

        public bool LoadFile(string filepath)
        {
            project = Project.Create(filepath);
            
            if (project == null)
                return false;

            if (project.Models == null)
                return false;

            Entities = null;
            Attributes = null;

            return true;
        }

        public void SaveFile(string filePath = default!)
        {
            project?.Apply(filePath);
        }

        public void SetEntities(Model? model, string? diagramName)
        {
            if (model == null)
                return;

            if (diagramName == null)
                return;

            Entities = model.GetEntities(diagramName);
        }

        public void SetAttribute(Entity? entity)
        {
            if (entity == null)
                return;

            Attributes = entity.Attributes;
        }

        public Entity? FindEntity(string name)
        {
            return Entities?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public ERgrin.Api.Attribute? FindAttribute(string name)
        {
            return Attributes?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        public Props GetProps(Entity? entity, ERgrin.Api.Attribute? attribute)
        {
            var props = new Props();

            props.EntityID = entity?.ID!.ToUpper();
            props.EntityLogicalName = entity?.LogicalName;
            props.EntityPhysicalName = entity?.PhysicalName;
            props.EntityDescription = entity?.Description;

            props.AttributeID = attribute?.ID!.ToUpper();
            props.AttributeLogicalName = attribute?.LogicalName;
            props.AttributePhysicalName = attribute?.PhysicalName;
            props.AttributeDescription = attribute?.Description;
            props.AttributeNullable = attribute?.Nullable;
            props.AttributeDomainName = attribute?.DomainName;
            props.AttributeDataType = attribute?.DataType;

            return props;
        }

        private Project? project;
    }
}
