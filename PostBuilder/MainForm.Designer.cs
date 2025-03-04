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
            SuspendLayout();
            // 
            // listBoxCommands
            // 
            listBoxCommands.FormattingEnabled = true;
            listBoxCommands.ItemHeight = 15;
            listBoxCommands.Location = new Point(27, 24);
            listBoxCommands.Name = "listBoxCommands";
            listBoxCommands.Size = new Size(508, 664);
            listBoxCommands.TabIndex = 0;
            listBoxCommands.SelectedIndexChanged += listBoxCommands_SelectedIndexChanged;
            listBoxCommands.DoubleClick += listBoxCommands_DoubleClick;
            // 
            // richTextBoxCode
            // 
            richTextBoxCode.Location = new Point(626, 45);
            richTextBoxCode.Name = "richTextBoxCode";
            richTextBoxCode.Size = new Size(389, 104);
            richTextBoxCode.TabIndex = 1;
            richTextBoxCode.Text = "";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1115, 685);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(115, 33);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 730);
            Controls.Add(buttonSave);
            Controls.Add(richTextBoxCode);
            Controls.Add(listBoxCommands);
            Name = "MainForm";
            Text = "PostBuilder";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxCommands;
        private RichTextBox richTextBoxCode;
        private Button buttonSave;
    }
}
