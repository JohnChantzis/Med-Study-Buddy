using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            textBox1.Text = Settings.Default.DataFilesPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Error!\n\nThe folder does not exist.\nOptions were not saved.");
                return;
            }

            if (Settings.Default.DataFilesPath != textBox1.Text)
                MessageBox.Show("Restart the application to use the new options.");

            Settings.Default.DataFilesPath = textBox1.Text;
            Settings.Default.Save();
            this.Close();
        }
    }
}
