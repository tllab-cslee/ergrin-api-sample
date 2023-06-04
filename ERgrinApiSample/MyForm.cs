using ERgrin.Api;

namespace ERgrinApiSample
{
    public partial class MyForm : Form
    {
        //--------------------------------------------------------------------------------
        // Initializer
        //--------------------------------------------------------------------------------

        public MyForm()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------
        // Control Event Handlers
        //--------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                Reset();

                if (!myProject.LoadFile(textBox1.Text))
                    return;

                UpdateModels(myProject.Models);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("변경된 값을 기존 파일에 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                myProject.SaveFile();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
                myProject.SaveFile(textBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = myProject.FindModel((string)comboBox1.SelectedItem);
            if (model != null && model.ID != selectedModel?.ID)
            {
                selectedModel = model;
                UpdateDiagrams(model.Diagrams);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var diagram = myProject.FindDiagram(selectedModel, (string)comboBox2.SelectedItem);
            if (diagram != null && diagram.ID != selectedDiagram?.ID)
            {
                selectedDiagram = diagram;
                myProject.SetEntities(selectedModel, diagram.Name!);
                UpdateEntities(myProject.Entities);

                myProject.SetDomains(selectedModel);

                selectedEntity = null;
                myProject.SetAttribute(null);
                UpdateAttributes(myProject.Attributes);

                selectedAttribute = null;
                SetProps();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (ListBox)sender;
            Entity? entity = myProject.FindEntity((string)obj.SelectedItem!);
            if (entity != null)
            {
                selectedEntity = entity;
                myProject.SetAttribute(entity);
                UpdateAttributes(myProject.Attributes);

                selectedAttribute = null;
                SetProps();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var obj = (ListBox)sender;
            ERgrin.Api.Attribute? attribute = myProject.FindAttribute((string)obj.SelectedItem!);
            if (attribute != null)
            {
                selectedAttribute = attribute;
                SetProps();
            }
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
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "EntityPhysicalName":
                        if (selectedEntity != null)
                        {
                            selectedEntity.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "EntityDescription":
                        if (selectedEntity != null)
                        {
                            selectedEntity.Description = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeLogicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.LogicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributePhysicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDescription":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Description = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeNullable":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Nullable = item.Value?.Equals(true);
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDomainName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.DomainName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDataType":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.DataType = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                }
            }
        }

        //--------------------------------------------------------------------------------
        // Private Methods
        //--------------------------------------------------------------------------------

        private void Reset()
        {
            selectedModel = null;
            selectedDiagram = null;
            selectedEntity = null;
            selectedAttribute = null;

            UpdateModels(null);
            UpdateDiagrams(null);
            UpdateEntities(null);
            UpdateAttributes(null);

            SetProps();
        }

        private void UpdateModels(List<Model>? models)
        {
            comboBox1.Items.Clear();

            if (models == null)
                return;

            foreach (var model in models)
            {
                comboBox1.Items.Add(model.LogicalName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void UpdateDiagrams(List<Diagram>? diagrams)
        {
            comboBox2.Items.Clear();

            if (diagrams == null)
                return;

            foreach (var diagram in diagrams)
            {
                comboBox2.Items.Add(diagram.Name);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void UpdateEntities(List<Entity>? entities)
        {
            listBox1.Items.Clear();

            if (entities == null)
                return;

            foreach (var entity in entities)
            {
                listBox1.Items.Add(entity.LogicalName!);
            }
        }

        private void UpdateAttributes(List<ERgrin.Api.Attribute>? attributes)
        {
            listBox2.Items.Clear();

            if (attributes == null)
                return;

            foreach (var attribute in attributes)
            {
                listBox2.Items.Add(attribute.LogicalName!);
            }
        }

        private void SetProps()
        {
            propertyGrid1.SelectedObject = myProject.GetProps(selectedEntity, selectedAttribute);
        }

        //--------------------------------------------------------------------------------
        // Private Fields
        //--------------------------------------------------------------------------------

        private Model? selectedModel;
        private Diagram? selectedDiagram;
        private Entity? selectedEntity;
        private ERgrin.Api.Attribute? selectedAttribute;

        private MyProject myProject = new();
    }
}