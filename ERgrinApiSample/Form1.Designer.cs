namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            listBox2 = new ListBox();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            propertyGrid1 = new PropertyGrid();
            button2 = new Button();
            button3 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(15, 124);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(397, 204);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 2;
            label1.Text = "ERgrin 파일";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(123, 8);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(614, 27);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(745, 6);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(80, 31);
            button1.TabIndex = 4;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 100);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 5;
            label2.Text = "엔티티(Entity)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 342);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(202, 20);
            label3.TabIndex = 6;
            label3.Text = "엔티티 속성(Entity Attribute)";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new Point(15, 366);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(397, 264);
            listBox2.TabIndex = 7;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 100);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 8;
            label4.Text = "속성(Property)";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "ERgrin Files(*.ergrin)|*.ergrin";
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(424, 124);
            propertyGrid1.Margin = new Padding(4);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(694, 507);
            propertyGrid1.TabIndex = 9;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(855, 6);
            button2.Name = "button2";
            button2.Size = new Size(80, 31);
            button2.TabIndex = 10;
            button2.Text = "저장";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(941, 6);
            button3.Name = "button3";
            button3.Size = new Size(175, 31);
            button3.TabIndex = 11;
            button3.Text = "다른 이름으로 저장...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "ergrin";
            saveFileDialog1.Filter = "ERgrin Files(*.ergrin)|*.ergrin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 55);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 12;
            label5.Text = "모델";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(61, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(351, 28);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(476, 55);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 14;
            label6.Text = "주제영역";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(552, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(564, 28);
            comboBox2.TabIndex = 15;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1131, 643);
            Controls.Add(comboBox2);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(propertyGrid1);
            Controls.Add(label4);
            Controls.Add(listBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "ERgrinApiSample";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private ListBox listBox2;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private PropertyGrid propertyGrid1;
        private Button button3;
        private SaveFileDialog saveFileDialog1;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox comboBox2;
    }
}