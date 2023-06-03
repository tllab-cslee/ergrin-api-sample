using ERgrin.Api;
using System.Data;

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
                comboBox1.Items.Clear();
                foreach (var model in project.Models)
                {
                    comboBox1.Items.Add(model.LogicalName);
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private void Reset()
        {
            selectedEntity = null;
            selectedAttribute = null;
            selectedModel = null;
            selectedDiagram = null;
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

        private void SetEntities(Model model, string diagramName)
        {
            entities = model.GetEntities(diagramName);
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("변경된 값을 기존 파일에 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                project?.Apply();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                project?.Apply(filePath);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (project?.Models == null)
                return;

            var model = project.Models.Where(x => comboBox1.SelectedItem.Equals(x.LogicalName)).First();
            if (model != null && model.ID != selectedModel?.ID)
            {
                selectedModel = model;
                if (model!.Diagrams != null)
                {
                    comboBox2.Items.Clear();
                    foreach (var diagram in model.Diagrams)
                    {
                        comboBox2.Items.Add(diagram.Name);
                    }
                    comboBox2.SelectedIndex = 0;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedModel?.Diagrams == null)
                return;

            var diagram = selectedModel.Diagrams.Where(x => comboBox2.SelectedItem.Equals(x.Name)).First();
            if (diagram != null && diagram.ID != selectedDiagram?.ID)
            {
                selectedDiagram = diagram;
                SetEntities(selectedModel, diagram.Name!);
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
            props.EntityDescription = selectedEntity?.Description;

            props.AttributeID = selectedAttribute?.ID!.ToUpper();
            props.AttributeLogicalName = selectedAttribute?.LogicalName;
            props.AttributePhysicalName = selectedAttribute?.PhysicalName;
            props.AttributeDescription = selectedAttribute?.Description;
            props.AttributeNullable = selectedAttribute?.Nullable;
            props.AttributeDomainName = selectedAttribute?.DomainName;
            props.AttributeDataType = selectedAttribute?.DataType;

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
                    case "EntityDescription":
                        if (selectedEntity != null)
                        {
                            selectedEntity.Description = item.Value?.ToString() ?? string.Empty;
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
                    case "AttributeDescription":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Description = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeNullable":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Nullable = item.Value?.Equals(true);
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDomainName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.DomainName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDataType":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.DataType = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes();
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                }
            }
        }

        private Project? project;

        private Model? selectedModel;
        private Diagram? selectedDiagram;

        private List<Entity>? entities;
        private List<ERgrin.Api.Attribute>? attributes;

        private Entity? selectedEntity;
        private ERgrin.Api.Attribute? selectedAttribute;
    }
}