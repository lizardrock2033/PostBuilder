using System.Xml;
using System.Xml.Linq;

namespace PostBuilder
{
    public partial class MainForm : Form
    {
        private XDocument xmlDoc;
        private string xmlFilePath = string.Empty;
        private string tempFilePath = string.Empty;
        private List<string> commands = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            LoadXml(false);
        }

        private void LoadXml(bool forceLoad)
        {
            try
            {
                tempFilePath = Path.GetTempPath() + "pbTempPost.sppx";
                if (File.Exists(xmlFilePath) || File.Exists(tempFilePath))
                {                    
                    if (!File.Exists(tempFilePath) || forceLoad)
                        File.Copy(xmlFilePath, tempFilePath, true);

                    xmlDoc = XDocument.Load(tempFilePath);
                    commands = xmlDoc.Descendants("CLDCommandID").Select(x => x.Value).ToList();                    
                }
                listBoxCommands.DataSource = commands;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки поста: " + ex.Message);
            }
        }

        private void SaveChanges()
        {
            if (!string.IsNullOrEmpty(tempFilePath))
                xmlDoc.Save(tempFilePath);

            buttonSaveCommandChanges.Enabled = false;
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                string selectedCommand = listBoxCommands.SelectedItem?.ToString() ?? "";
                var programCode = xmlDoc.Descendants("CLDCommand")
                    .FirstOrDefault(x => x.Element("CLDCommandID")?.Value == selectedCommand)?
                    .Descendants("ProgramCode").FirstOrDefault();

                richTextBoxCode.Text = programCode != null ? programCode.Value.Trim() : "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveChanges();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SPPX files (*.sppx)|*.sppx|XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".sppx";
            saveFileDialog.FileName = "STPostprocessor.sppx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlDoc.Save(saveFileDialog.FileName);
            }
        }

        //private void AddNewCommand()
        //{
        //    string newCommandID = Microsoft.VisualBasic.Interaction.InputBox("Введите CLDCommandID:", "Добавление команды", "");

        //    if (string.IsNullOrWhiteSpace(newCommandID))
        //        return;

        //    XElement? existingNode = xmlDoc.Descendants("CLDCommandID").SingleOrDefault(x => x.Value == newCommandID);
        //    if (existingNode != null)
        //    {
        //        MessageBox.Show("Такая команда уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    XElement newCommand = new XElement("CLDCommand",
        //        new XElement("CLDCommandID", newCommandID),
        //        new XElement("Handlers",
        //            new XElement("Program",
        //                new XElement("Enabled", "True"),
        //                new XElement("ProgramCode", new XCData($"program {newCommandID}\n\nend\n"))
        //            )
        //        )
        //    );

        //    xmlDoc.Element("STPostprocessor")?.Element("CLDCommandsHandlers")?.Add(newCommand);
        //    xmlDoc.Save(xmlFilePath);
        //    LoadXml(true);
        //}

        //private void listBoxCommands_DoubleClick(object sender, EventArgs e)
        //{
        //    if (listBoxCommands.SelectedItems[0]?.ToString() != "< Добавить команду >")
        //    {
        //        string newCommandID = Microsoft.VisualBasic.Interaction.InputBox("Введите новый CLDCommandID:", "Переименование", "");
        //        if (!string.IsNullOrEmpty(newCommandID))
        //        {
        //            XElement? editNode = xmlDoc.Descendants("CLDCommandID").SingleOrDefault(x => x.Value == listBoxCommands.SelectedItems[0]?.ToString());
        //            if (editNode != null)
        //            {
        //                editNode.Value = newCommandID;
        //                xmlDoc.Save(xmlFilePath);
        //                LoadXml(false);
        //            }
        //        }
        //    }
        //}

        private void buttonChoosePattern_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SPPX files (*.sppx)|*.sppx|XML files (*.xml)|*.xml|Text files (*.txt)|*.txt";
            openFileDialog.Title = "Загрузить шаблон для работы";
            openFileDialog.DefaultExt = ".sppx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlFilePath = openFileDialog.FileName;
                LoadXml(true);
            }
        }

        private void richTextBoxCode_Leave(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                string selectedCommand = listBoxCommands.SelectedItem?.ToString() ?? "";
                var programCode = xmlDoc.Descendants("CLDCommand")
                                        .FirstOrDefault(x => x.Element("CLDCommandID")?.Value == selectedCommand)?
                                        .Descendants("ProgramCode").FirstOrDefault();

                if (programCode != null)
                    programCode.ReplaceNodes(new XCData(richTextBoxCode.Text));
            }

            SaveChanges();
        }

        private void richTextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                string selectedCommand = listBoxCommands.SelectedItem?.ToString() ?? "";
                var programCode = xmlDoc.Descendants("CLDCommand")
                                        .FirstOrDefault(x => x.Element("CLDCommandID")?.Value == selectedCommand)?
                                        .Descendants("ProgramCode").FirstOrDefault();
                if (programCode != null && programCode.Value.Trim() != richTextBoxCode.Text)
                {
                    buttonSaveCommandChanges.Enabled = true;
                    buttonSaveCommandChanges.ForeColor = Color.Red;
                }
                else
                {
                    buttonSaveCommandChanges.Enabled = false;
                    buttonSaveCommandChanges.ForeColor = Color.Black;
                }
            }
        }

        private void buttonSaveCommandChanges_Click(object sender, EventArgs e)
        {
            richTextBoxCode_Leave(null, null);
        }

        private void textBoxCommandsFilter_KeyUp(object sender, KeyEventArgs e)
        {
            listBoxCommands.DataSource = commands.Where(x => x.Contains(textBoxCommandsFilter.Text)).ToList();
        }
    }
}
