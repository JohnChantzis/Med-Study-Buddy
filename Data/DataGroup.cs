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
    public class DataGroup
    {
        public string Name;
        public string Category;
        public GroupBox GroupBox;
        public FlowLayoutPanel Panel;
        public List<DataFile> DataFiles;

        private string FolderPath;
        private FlowLayoutPanel ParentPanel;

        public DataGroup(string FolderPath, FlowLayoutPanel ParentPanel, EventHandler btn_Click)
        {
            var folderInfo = new DirectoryInfo(FolderPath);
            this.Name = folderInfo.Name;
            this.Category = folderInfo.Parent.Name;
            this.FolderPath = FolderPath;
            this.ParentPanel = ParentPanel;

            this.GroupBox = CreateGroupBoxIn(this.ParentPanel, new Size(200, 200));
            this.Panel = CreatePanelIn(this.GroupBox, new Size(450, 0));

            this.DataFiles = CreateDataFiles(btn_Click);
        }



        private GroupBox CreateGroupBoxIn(Control parent, Size size)
        {
            var groupBox = new GroupBox()
            {
                Text = this.Name,
                Size = size,
                AutoSize = true,
                Tag = this
            };

            parent.Controls.Add(groupBox);
            return groupBox;
        }

        private FlowLayoutPanel CreatePanelIn(Control parent, Size size)
        {
            var panel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = size,
                AutoSize = true,
                Tag = this
            };

            parent.Controls.Add(panel);
            return panel;
        }

        private List<DataFile> CreateDataFiles(EventHandler btn_Click)
        {
            var dataFiles = new List<DataFile>();
            var files = Directory.GetFiles(this.FolderPath);

            // Create data files
            foreach (var item in files)
            {
                dataFiles.Add(new DataFile(item, this, btn_Click));
            }

            return dataFiles;
        }

        private static string GetFolderName(string filepath)
        {
            return filepath != null ? filepath.Substring(filepath.LastIndexOf('\\') + 1) : null;
        }

        private static string GetFolderParentName(string filepath)
        {
            return filepath != null ? filepath.Remove(filepath.LastIndexOf('\\') + 1).Substring(filepath.LastIndexOf('\\') + 1) : null;
        }
    }
}
