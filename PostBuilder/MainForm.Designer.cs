namespace PostBuilder
{
    partial class MainForm
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
            listBoxCommands = new ListBox();
            richTextBoxCode = new RichTextBox();
            buttonSave = new Button();
            buttonChoosePattern = new Button();
            buttonSaveCommandChanges = new Button();
            textBoxCommandsFilter = new TextBox();
            SuspendLayout();
            // 
            // listBoxCommands
            // 
            listBoxCommands.FormattingEnabled = true;
            listBoxCommands.ItemHeight = 15;
            listBoxCommands.Location = new Point(27, 99);
            listBoxCommands.Name = "listBoxCommands";
            listBoxCommands.Size = new Size(180, 604);
            listBoxCommands.TabIndex = 0;
            listBoxCommands.SelectedIndexChanged += listBoxCommands_SelectedIndexChanged;
            // 
            // richTextBoxCode
            // 
            richTextBoxCode.Location = new Point(841, 24);
            richTextBoxCode.Name = "richTextBoxCode";
            richTextBoxCode.Size = new Size(389, 655);
            richTextBoxCode.TabIndex = 1;
            richTextBoxCode.Text = "";
            richTextBoxCode.TextChanged += richTextBoxCode_TextChanged;
            richTextBoxCode.Leave += richTextBoxCode_Leave;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1115, 685);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(115, 33);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить как";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonChoosePattern
            // 
            buttonChoosePattern.Location = new Point(27, 17);
            buttonChoosePattern.Name = "buttonChoosePattern";
            buttonChoosePattern.Size = new Size(180, 37);
            buttonChoosePattern.TabIndex = 3;
            buttonChoosePattern.Text = "Загрузить шаблон";
            buttonChoosePattern.UseVisualStyleBackColor = true;
            buttonChoosePattern.Click += buttonChoosePattern_Click;
            // 
            // buttonSaveCommandChanges
            // 
            buttonSaveCommandChanges.Enabled = false;
            buttonSaveCommandChanges.Location = new Point(810, 24);
            buttonSaveCommandChanges.Name = "buttonSaveCommandChanges";
            buttonSaveCommandChanges.Size = new Size(25, 26);
            buttonSaveCommandChanges.TabIndex = 4;
            buttonSaveCommandChanges.Text = "⚫️";
            buttonSaveCommandChanges.UseVisualStyleBackColor = true;
            buttonSaveCommandChanges.Click += buttonSaveCommandChanges_Click;
            // 
            // textBoxCommandsFilter
            // 
            textBoxCommandsFilter.Location = new Point(27, 70);
            textBoxCommandsFilter.Name = "textBoxCommandsFilter";
            textBoxCommandsFilter.PlaceholderText = "Поиск";
            textBoxCommandsFilter.Size = new Size(177, 23);
            textBoxCommandsFilter.TabIndex = 5;
            textBoxCommandsFilter.KeyUp += textBoxCommandsFilter_KeyUp;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 730);
            Controls.Add(textBoxCommandsFilter);
            Controls.Add(buttonSaveCommandChanges);
            Controls.Add(buttonChoosePattern);
            Controls.Add(buttonSave);
            Controls.Add(richTextBoxCode);
            Controls.Add(listBoxCommands);
            Name = "MainForm";
            Text = "PostBuilder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxCommands;
        private RichTextBox richTextBoxCode;
        private Button buttonSave;
        private Button buttonChoosePattern;
        private Button buttonSaveCommandChanges;
        private TextBox textBoxCommandsFilter;
    }
}
