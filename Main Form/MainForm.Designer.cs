namespace MedStudyBuddy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autosaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectBoxCategory = new System.Windows.Forms.ComboBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showQuestionNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Controls.Add(this.menuStrip1);
            this.panelButtons.Controls.Add(this.selectBoxCategory);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(231, 152);
            this.panelButtons.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(127, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataFilePathToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.questionNumbersToolStripMenuItem,
            this.showTimerToolStripMenuItem,
            this.autosaveToolStripMenuItem,
            this.clearSavesToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "Options";
            // 
            // dataFilePathToolStripMenuItem
            // 
            this.dataFilePathToolStripMenuItem.Name = "dataFilePathToolStripMenuItem";
            this.dataFilePathToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dataFilePathToolStripMenuItem.Text = "Data File Path";
            this.dataFilePathToolStripMenuItem.Click += new System.EventHandler(this.dataFilePathToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Checked = true;
            this.randomToolStripMenuItem.CheckOnClick = true;
            this.randomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.randomToolStripMenuItem.Text = "Show Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // questionNumbersToolStripMenuItem
            // 
            this.questionNumbersToolStripMenuItem.Checked = true;
            this.questionNumbersToolStripMenuItem.CheckOnClick = true;
            this.questionNumbersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.questionNumbersToolStripMenuItem.Name = "questionNumbersToolStripMenuItem";
            this.questionNumbersToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.questionNumbersToolStripMenuItem.Text = "Show Question Numbers";
            this.questionNumbersToolStripMenuItem.Click += new System.EventHandler(this.questionNumbersToolStripMenuItem_Click);
            // 
            // showTimerToolStripMenuItem
            // 
            this.showTimerToolStripMenuItem.Checked = true;
            this.showTimerToolStripMenuItem.CheckOnClick = true;
            this.showTimerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTimerToolStripMenuItem.Name = "showTimerToolStripMenuItem";
            this.showTimerToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.showTimerToolStripMenuItem.Text = "Show Timer";
            this.showTimerToolStripMenuItem.Click += new System.EventHandler(this.showTimerToolStripMenuItem_Click);
            // 
            // autosaveToolStripMenuItem
            // 
            this.autosaveToolStripMenuItem.Checked = true;
            this.autosaveToolStripMenuItem.CheckOnClick = true;
            this.autosaveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveToolStripMenuItem.Name = "autosaveToolStripMenuItem";
            this.autosaveToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.autosaveToolStripMenuItem.Text = "Autosave";
            this.autosaveToolStripMenuItem.Click += new System.EventHandler(this.autosaveToolStripMenuItem_Click);
            // 
            // clearSavesToolStripMenuItem
            // 
            this.clearSavesToolStripMenuItem.Name = "clearSavesToolStripMenuItem";
            this.clearSavesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.clearSavesToolStripMenuItem.Text = "Clear Saves";
            this.clearSavesToolStripMenuItem.Click += new System.EventHandler(this.clearSavesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // selectBoxCategory
            // 
            this.selectBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectBoxCategory.FormattingEnabled = true;
            this.selectBoxCategory.Items.AddRange(new object[] {
            "- All -"});
            this.selectBoxCategory.Location = new System.Drawing.Point(3, 27);
            this.selectBoxCategory.MaxDropDownItems = 12;
            this.selectBoxCategory.Name = "selectBoxCategory";
            this.selectBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.selectBoxCategory.TabIndex = 1;
            this.selectBoxCategory.SelectedIndexChanged += new System.EventHandler(this.selectBoxCategory_SelectedIndexChanged);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // dataFilesToolStripMenuItem
            // 
            this.dataFilesToolStripMenuItem.Name = "dataFilesToolStripMenuItem";
            this.dataFilesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // shuffleToolStripMenuItem
            // 
            this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
            this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // showQuestionNumbersToolStripMenuItem
            // 
            this.showQuestionNumbersToolStripMenuItem.Name = "showQuestionNumbersToolStripMenuItem";
            this.showQuestionNumbersToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(231, 152);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(210, 190);
            this.Name = "MainForm";
            this.Text = "Med Study Buddy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showQuestionNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autosaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSavesToolStripMenuItem;
        private System.Windows.Forms.ComboBox selectBoxCategory;
        private System.Windows.Forms.ToolStripMenuItem showTimerToolStripMenuItem;
    }
}

