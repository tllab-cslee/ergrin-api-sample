using ERgrin.Api;
using System;
using System.Data;
using System.Security;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFile(string filepath)
        {
            Reset();

            project = Project.Create(filepath);
            if (project.Models is not null)
            {
                SetEntities(project.Models.FirstOrDefault()!);
            }
        }

        private void Reset()
        {
            selectedEntity = null;
            selectedAttribute = null;
            entities = null;
            attributes = null;

            SetProps();
            UpdateAttributes();
            UpdateEntities();
        }

        private void UpdateEntities()
        {
            listBox1.Items.Clear();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    listBox1.Items.Add(entity.LogicalName!);
                }
            }
        }

        private void UpdateAttributes()
        {
            listBox2.Items.Clear();

            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    listBox2.Items.Add(attribute.LogicalName!);
                }
            }
        }

        private void SetEntities(Model model)
        {
            entities = model.Entities!;
        }

        private Entity? FindEntity(string name)
        {
            return entities?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        private void SetAttribute(Entity entity)
        {
            attributes = entity.Attributes!;
        }

        private ERgrin.Api.Attribute? FindAttribute(string name)
        {
            return attributes?.Where(x => x.LogicalName == name).FirstOrDefault();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                LoadFile(textBox1.Text);
                UpdateEntities();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (ListBox)sender;
            Entity? entity = FindEntity((string)obj.SelectedItem!);
            if (entity != null)
            {
                selectedEntity = entity;

                SetAttribute(entity);
                UpdateAttributes();

                selectedAttribute = null;

                SetProps();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var obj = (ListBox)sender;
            ERgrin.Api.Attribute? attribute = FindAttribute((string)obj.SelectedItem!);
            if (attribute != null)
            {
                selectedAttribute = attribute;

                SetProps();
            }
        }

        private void SetProps()
        {
            var props = new Props();

            props.EntityID = selectedEntity?.ID!.ToUpper();
            props.EntityLogicalName = selectedEntity?.LogicalName;
            props.EntityPhysicalName = selectedEntity?.PhysicalName;

            props.AttributeID = selectedAttribute?.ID!.ToUpper();
            props.AttributeLogicalName = selectedAttribute?.LogicalName;
            props.AttributePhysicalName = selectedAttribute?.PhysicalName;

            propertyGrid1.SelectedObject = props;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var item = e.ChangedItem;

            if (item != null)
            {
                string propertyName = item.PropertyDescriptor!.Name;

                switch (propertyName)
                {
                    case "EntityLogicalName":
                        if (selectedEntity != null)
                        {
                            selectedEntity.LogicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities();
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "EntityPhysicalName":
                        if (selectedEntity != null)
                        {
                            selectedEntity.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities();
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeLogicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.LogicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributePhysicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                }

                project?.Apply();
            }
        }

        private Project? project;
        private List<Entity>? entities;
        private List<ERgrin.Api.Attribute>? attributes;

        private Entity? selectedEntity;
        private ERgrin.Api.Attribute? selectedAttribute;
    }
}