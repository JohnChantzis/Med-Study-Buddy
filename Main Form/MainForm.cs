using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public partial class MainForm : Form
    {
        List<DataGroup> groups;
        IDataForm _currentForm;



        public MainForm()
        {
            InitializeComponent();

            LoadSettings();

            if (Directory.Exists(Settings.Default.DataFilesPath))
            {
                try
                {
                    CreateCategories(Settings.Default.DataFilesPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!\n\n" + ex.Message);
                }
            }
        }


        private void LoadSettings()
        {
            randomToolStripMenuItem.Checked = Settings.Default.ShowRandom;
            questionNumbersToolStripMenuItem.Checked = Settings.Default.ShowQuestionNumbers;
            autosaveToolStripMenuItem.Checked = Settings.Default.Autosave;
            showTimerToolStripMenuItem.Checked = Settings.Default.ShowTimer;

            if (!Directory.Exists(Settings.Default.DataFilesPath))
            {
                if (Directory.Exists("Data Files"))
                {
                    Settings.Default.DataFilesPath = "Data Files";
                    return;
                }

                if (Directory.Exists(@"Resources/Data Files"))
                {
                    Settings.Default.DataFilesPath = @"Resources/Data Files";
                    return;
                }

                MessageBox.Show("Error!\n\nThe path does not exist. Please specify a correct path.");
                dataFilePathToolStripMenuItem_Click(this, null);
            }
        }

        private void CreateCategories(string parentFolder)
        {
            foreach (var category in Directory.GetDirectories(parentFolder))
            {
                var info = new DirectoryInfo(category);
                this.selectBoxCategory.Items.Add(info.Name);

                CreateGroups(category);
            }
            this.selectBoxCategory.SelectedItem = Settings.Default.SelectedCategory;
            if (this.selectBoxCategory.SelectedItem == null)
                this.selectBoxCategory.SelectedItem = "- All -";
        }

        private void CreateGroups(string category)
        {
            if (groups == null)
                groups = new List<DataGroup>();

            var folders = Directory.GetDirectories(category);

            // Create groups
            foreach (var group in folders)
            {
                groups.Add(new DataGroup(group, this.panelButtons, btn_Click));
            }

            this.panelButtons.PerformLayout();
        }

        private void SelectGroup()
        {
            foreach (var group in groups)
            {
                if (selectBoxCategory.SelectedItem.ToString() == "- All -")
                    group.GroupBox.Show();
                else if (group.Category == selectBoxCategory.SelectedItem.ToString())
                    group.GroupBox.Show();
                else
                    group.GroupBox.Hide();
            }
        }



        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var dataFile = (DataFile)btn.Tag;

            dataFile.Click();
            var file = dataFile.FilePath;

            var data = DataFileParser.GetData(dataFile.FilePath);

            if (data == null)
                return;

            string title = dataFile.Name;
            ShowForm(title, data);

        }

        private void ShowForm(string title, IData data)
        {
            switch (data.GetType())
            {
                case DataType.TrueFalse:
                    _currentForm = new TrueFalseForm(title, (TrueFalse)data);
                    break;
                case DataType.Cards:
                    _currentForm = new CardForm(title, (Cards)data);
                    break;
                default:
                    return;
            }

            ((Form)_currentForm).Show();
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + " " + Application.ProductVersion + "\nBy John Chantzis\n\nfor...\nAliki Loupou :)\n\nFree & Open Source\nhttps://github.com/JohnChantzis/Med-Study-Buddy", "About");
        }

        private void dataFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm();
            optionsForm.Show();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowRandom = randomToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void questionNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowQuestionNumbers = questionNumbersToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void showTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowTimer = showTimerToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void autosaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Autosave = autosaveToolStripMenuItem.Checked;
            Settings.Default.Save();

            foreach (var g in groups)
            {
                foreach (var item in g.DataFiles)
                {
                    if (!autosaveToolStripMenuItem.Checked)
                    {
                        if (item.Button.BackColor == Color.LightGreen)
                        {
                            item.Button.BackColor = default(Color);
                            item.Button.UseVisualStyleBackColor = true;
                        }
                    }
                    else
                    {
                        if (!item.WasClicked && item.HasSave())
                        {
                            item.Button.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void clearSavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Saved"))
                return;
            var saveFiles = Directory.GetFiles("Saved");

            foreach (var save in saveFiles)
            {
                File.Delete(save);
            }

            Directory.Delete("Saved");

            foreach (var g in groups)
            {
                foreach (var item in g.DataFiles)
                {
                    if (item.Button.BackColor == Color.LightGreen)
                    {
                        item.Button.BackColor = default(Color);
                        item.Button.UseVisualStyleBackColor = true;
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ShowRandom = randomToolStripMenuItem.Checked;
            Settings.Default.ShowQuestionNumbers = questionNumbersToolStripMenuItem.Checked;
            Settings.Default.Autosave = autosaveToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void selectBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SelectedCategory = selectBoxCategory.SelectedItem.ToString();
            Settings.Default.Save();

            SelectGroup();
        }
    }
}
