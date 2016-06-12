namespace MedStudyBuddy
{
    partial class TrueFalseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrueFalseForm));
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.labelCurrentIndex = new System.Windows.Forms.Label();
            this.panelIndex = new System.Windows.Forms.Panel();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelQuestionNumber = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelButtons.SuspendLayout();
            this.panelIndex.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(0, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 50);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "False";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(159, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 50);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "True";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSkip);
            this.panelButtons.Controls.Add(this.labelAnswer);
            this.panelButtons.Controls.Add(this.btnLeft);
            this.panelButtons.Controls.Add(this.btnRight);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(5, 167);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(234, 50);
            this.panelButtons.TabIndex = 3;
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSkip.Location = new System.Drawing.Point(95, 27);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(45, 24);
            this.btnSkip.TabIndex = 3;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.BackColor = System.Drawing.Color.Black;
            this.labelAnswer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer.ForeColor = System.Drawing.Color.DarkGray;
            this.labelAnswer.Location = new System.Drawing.Point(75, 0);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Padding = new System.Windows.Forms.Padding(3);
            this.labelAnswer.Size = new System.Drawing.Size(84, 19);
            this.labelAnswer.TabIndex = 2;
            this.labelAnswer.Text = "False";
            this.labelAnswer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelAnswer.Visible = false;
            // 
            // labelCurrentIndex
            // 
            this.labelCurrentIndex.AutoSize = true;
            this.labelCurrentIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCurrentIndex.Location = new System.Drawing.Point(0, 0);
            this.labelCurrentIndex.Name = "labelCurrentIndex";
            this.labelCurrentIndex.Size = new System.Drawing.Size(13, 13);
            this.labelCurrentIndex.TabIndex = 4;
            this.labelCurrentIndex.Text = "0";
            // 
            // panelIndex
            // 
            this.panelIndex.Controls.Add(this.labelTimer);
            this.panelIndex.Controls.Add(this.labelQuestionNumber);
            this.panelIndex.Controls.Add(this.labelCurrentIndex);
            this.panelIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIndex.Location = new System.Drawing.Point(5, 5);
            this.panelIndex.Name = "panelIndex";
            this.panelIndex.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelIndex.Size = new System.Drawing.Size(234, 16);
            this.panelIndex.TabIndex = 5;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTimer.Location = new System.Drawing.Point(185, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(49, 13);
            this.labelTimer.TabIndex = 6;
            this.labelTimer.Text = "00:00:00";
            this.labelTimer.Visible = false;
            // 
            // labelQuestionNumber
            // 
            this.labelQuestionNumber.AutoSize = true;
            this.labelQuestionNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelQuestionNumber.Location = new System.Drawing.Point(13, 0);
            this.labelQuestionNumber.Name = "labelQuestionNumber";
            this.labelQuestionNumber.Size = new System.Drawing.Size(31, 13);
            this.labelQuestionNumber.TabIndex = 5;
            this.labelQuestionNumber.Text = "    (0)";
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(5, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(234, 146);
            this.label.TabIndex = 6;
            this.label.Text = "label";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TrueFalseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 222);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panelIndex);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(260, 260);
            this.Name = "TrueFalseForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "True False";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrueFalseForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowForm_KeyDown);
            this.panelButtons.ResumeLayout(false);
            this.panelIndex.ResumeLayout(false);
            this.panelIndex.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label labelCurrentIndex;
        private System.Windows.Forms.Panel panelIndex;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelQuestionNumber;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer;
    }
}