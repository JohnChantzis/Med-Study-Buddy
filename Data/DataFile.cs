using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public class DataFile
    {
        public string Name;
        public string FilePath;
        public Button Button;
        public DataGroup Group;
        public bool WasClicked;

        public DataFile(string FilePath, DataGroup Group, EventHandler btn_Click)
        {
            this.Name = GetFileName(FilePath);
            this.FilePath = FilePath;
            this.Group = Group;

            CreateButtonIn(Group.Panel);
            LinkButtonClick(btn_Click);
        }



        public void Click()
        {
            this.WasClicked = true;
            this.Button.BackColor = Color.AliceBlue;
        }



        public bool HasSave()
        {
            return Directory.Exists("Saved") && File.Exists(@"Saved/" + Name);
        }

        private void CreateButtonIn(Control parent)
        {
            this.Button = new Button()
            {
                Text = Name,
                Size = new Size(200, 23),
                UseVisualStyleBackColor = true,
                AutoSize = true,
                Tag = this
            };

            if (HasSave() && Settings.Default.Autosave)
                this.Button.BackColor = Color.LightGreen;

            parent.Controls.Add(this.Button);
        }

        private void LinkButtonClick(EventHandler btn_Click)
        {
            this.Button.Click += btn_Click;
        }

        private static string GetFileName(string filepath)
        {
            return filepath.Remove(filepath.LastIndexOf('.')).Substring(filepath.LastIndexOf('\\') + 1);
        }
    }
}
