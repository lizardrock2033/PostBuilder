using System.Xml;
using System.Xml.Linq;

namespace PostBuilder
{
    public partial class MainForm : Form
    {
        private XDocument xmlDoc;
        private string xmlFilePath = "STPostprocessor.xml";

        public MainForm()
        {
            InitializeComponent();
            LoadXml();
        }

        private void LoadXml()
        {
            try
            {
                xmlDoc = XDocument.Load(xmlFilePath);
                var commands = xmlDoc.Descendants("CLDCommandID").Select(x => x.Value).ToList();
                var allCommands = new List<string>();
                allCommands.AddRange(commands);
                allCommands.Add("< Добавить команду >");
                listBoxCommands.DataSource = allCommands;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки XML: " + ex.Message);
            }
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                if (listBoxCommands.SelectedItems[0]?.ToString() == "< Добавить команду >")
                {
                    listBoxCommands.ClearSelected();
                    AddNewCommand();
                }

                string selectedCommand = listBoxCommands.SelectedItem?.ToString() ?? "";
                var programCode = xmlDoc.Descendants("CLDCommand")
                    .FirstOrDefault(x => x.Element("CLDCommandID")?.Value == selectedCommand)?
                    .Descendants("ProgramCode").FirstOrDefault();

                richTextBoxCode.Text = programCode != null ? programCode.Value.Trim() : "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //if (listBoxCommands.SelectedItem != null)
            //{
            //    string selectedCommand = listBoxCommands.SelectedItem?.ToString() ?? "";
            //    var programCode = xmlDoc.Descendants("CLDCommand")
            //        .FirstOrDefault(x => x.Element("CLDCommandID")?.Value == selectedCommand)?
            //        .Descendants("ProgramCode").FirstOrDefault();

            //    if (programCode != null)
            //    {
            //        programCode.Value = richTextBoxCode.Text;
            //        xmlDoc.Save(xmlFilePath);
            //        MessageBox.Show("Изменения сохранены!");
            //    }
            //}

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SPPX files (*.sppx)|*.sppx|XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".sppx";
            saveFileDialog.FileName = "STPostprocessor.sppx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlDoc.Save(saveFileDialog.FileName);
            }
        }

        private void AddNewCommand()
        {
            string newCommandID = Microsoft.VisualBasic.Interaction.InputBox("Введите CLDCommandID:", "Добавление команды", "");

            if (string.IsNullOrWhiteSpace(newCommandID))
                return;

            XElement? existingNode = xmlDoc.Descendants("CLDCommandID").SingleOrDefault(x => x.Value == newCommandID);
            if (existingNode != null)
            {
                MessageBox.Show("Такая команда уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XElement newCommand = new XElement("CLDCommand",
                new XElement("CLDCommandID", newCommandID),
                new XElement("Handlers",
                    new XElement("Program",
                        new XElement("Enabled", "True"),
                        new XElement("ProgramCode", new XCData($"program {newCommandID}\n\nend\n"))
                    )
                )
            );

            xmlDoc.Element("STPostprocessor")?.Element("CLDCommandsHandlers")?.Add(newCommand);
            xmlDoc.Save(xmlFilePath);
            LoadXml();
        }

        private void listBoxCommands_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItems[0]?.ToString() != "< Добавить команду >")
            {
                string newCommandID = Microsoft.VisualBasic.Interaction.InputBox("Введите новый CLDCommandID:", "Переименование", "");
                if (!string.IsNullOrEmpty(newCommandID))
                {
                    XElement? editNode = xmlDoc.Descendants("CLDCommandID").SingleOrDefault(x => x.Value == listBoxCommands.SelectedItems[0]?.ToString());
                    if (editNode != null)
                    {
                        editNode.Value = newCommandID;
                        xmlDoc.Save(xmlFilePath);
                        LoadXml();
                    }
                }
            }
        }
    }
}
