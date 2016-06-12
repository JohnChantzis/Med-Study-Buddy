using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public partial class TrueFalseForm : Form, IDataForm
    {
        TrueFalse data;
        TrueFalseFormState state = TrueFalseFormState.QuestionsFill;

        public TrueFalseForm(string title, TrueFalse data)
        {
            InitializeComponent();

            label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            label.Resize += new EventHandler(label_Resize);
            this.KeyPreview = true;
            this.Text = title;

            if (Settings.Default.ShowTimer)
                labelTimer.Show();

            if (Settings.Default.Autosave)
                this.data = RestoreData();

            if (this.data == null)
            {
                this.data = data;
                if (Settings.Default.ShowRandom)
                    this.data.Shuffle();
            }

            UpdateUI();
        }



        // States Handling
        private void ChangeStateCompleted()
        {
            state = TrueFalseFormState.Completed;

            // Show Results
            var results = data.GetResults();

            label.Text = ResultsToString(results);
            label.TextAlign = ContentAlignment.MiddleLeft;

            // Change UI Appearance
            panelIndex.Hide();

            if (results.NumberOfMistakes > 0)
            {
                panelButtons.Height = 24;
                btnLeft.Font = new Font(btnLeft.Font.Name, 8.25F);
                btnRight.Font = new Font(btnRight.Font.Name, 8.25F);

                btnLeft.Enabled = false;
                btnLeft.Hide();

                btnSkip.Enabled = false;
                btnSkip.Hide();

                btnRight.Text = "See my Mistakes";
                btnRight.Dock = DockStyle.Fill;

                timer.Enabled = false;
                labelTimer.Hide();
            }
            else
            {
                panelButtons.Hide();
            }

            // Clear Saved

        }
        private static string ResultsToString(QuestionResults results)
        {
            string text;
            string msg;

            if (results.PercentOfCorrectAnswers == 100)
                msg = "Perfect!";
            else if (results.PercentOfCorrectAnswers >= 90)
                msg = "B r a v o ! ! !";
            else if (results.PercentOfCorrectAnswers >= 80)
                msg = "Bravo!!!";
            else if (results.PercentOfCorrectAnswers >= 70)
                msg = "Cool!";
            else if (results.PercentOfCorrectAnswers >= 50)
                msg = "Better luck next time!";
            else if (results.PercentOfCorrectAnswers >= 30)
                msg = "You need try harder...";
            else
                msg = " - Failed! - ";

            text = String.Format("{0}\n\n" +
                "Questions Answered: {1}/{2} ({3}%)\n" +
                "Correct: {4}/{5} ({6}%)\n" +
                "Mistakes: {7}/{8} ({9}%)\n" +
                "Time: {10}",
                msg,
                results.NumberOfAnsweredQuestions, results.NumberOfQuestions, Math.Round(results.PercentOfAnsweredQuestions),
                results.NumberOfCorrectAnswers, results.NumberOfAnsweredQuestions, Math.Round(results.PercentOfCorrectAnswers),
                results.NumberOfMistakes, results.NumberOfAnsweredQuestions, Math.Round(results.PercentOfMistakes),
                results.TimeSpent.ToString());

            return text;
        }

        private void ChangeStateMistakes()
        {
            state = TrueFalseFormState.Mistakes;

            // Change Data
            data = data.GetMistakes();

            // Change UI Appearance
            label.TextAlign = ContentAlignment.MiddleCenter;

            panelIndex.Show();

            btnRight.Dock = DockStyle.Right;
            btnRight.Width = 75;
            btnRight.Text = "Next";

            btnLeft.Text = "Previous";
            btnLeft.Enabled = true;
            btnLeft.Show();

            labelAnswer.Show();

            UpdateUI();
        }

        // Buttons
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (!btnRight.Enabled) return;

            switch (state)
            {
                case TrueFalseFormState.QuestionsFill:
                    AddResult(true);
                    break;
                case TrueFalseFormState.Completed:
                    ChangeStateMistakes();
                    break;
                case TrueFalseFormState.Mistakes:
                    Next();
                    break;
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (!btnLeft.Enabled) return;

            switch (state)
            {
                case TrueFalseFormState.QuestionsFill:
                    AddResult(false);
                    break;
                case TrueFalseFormState.Mistakes:
                    Previous();
                    break;
            }
        }
        private void AddResult(bool result)
        {
            data.Questions[data.CurrentIndex].Answer(result);
            data.CurrentIndex++;
            UpdateUI();
        }
        private void Next()
        {
            data.CurrentIndex++;
            UpdateUI();
        }
        private void Previous()
        {
            data.CurrentIndex--;
            UpdateUI();
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            var current = data.Questions[data.CurrentIndex];
            data.Questions.Remove(current);
            data.Questions.Add(current);

            UpdateUI();
        }

        // Shortcut keys
        private void ShowForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (state == TrueFalseFormState.QuestionsFill)
                switch (e.KeyCode)
                {
                    case Keys.F:
                        btnLeft_Click(this, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.T:
                        btnRight_Click(this, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.Space:
                        btnSkip_Click(this, EventArgs.Empty);
                        e.Handled = true;
                        break;
                }
            else if (state == TrueFalseFormState.Mistakes)
                switch (e.KeyCode)
                {
                    case Keys.A:
                        btnLeft_Click(this, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.D:
                        btnRight_Click(this, EventArgs.Empty);
                        e.Handled = true;
                        break;
                }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (state == TrueFalseFormState.QuestionsFill ||
                state == TrueFalseFormState.Mistakes)
                switch (keyData)
                {
                    case Keys.Right:
                        btnRight_Click(this, EventArgs.Empty);
                        return true;
                    case Keys.Left:
                        btnLeft_Click(this, EventArgs.Empty);
                        return true;
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            data.TotalSeconds++;
            labelTimer.Text = TimeSpan.FromSeconds(data.TotalSeconds).ToString();
        }

        // Autosave
        private void TrueFalseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == TrueFalseFormState.QuestionsFill)
                SaveData();
            else
                DeleteDate();
        }
        private void SaveData()
        {
            var path = @"Saved\" + this.Text;

            if (Settings.Default.Autosave)
            {
                Directory.CreateDirectory("Saved");

                DataSerializer.SerializeObject(data, path);
            }
        }
        private void DeleteDate()
        {
            var path = @"Saved\" + this.Text;

            File.Delete(path);
        }
        private TrueFalse RestoreData()
        {
            TrueFalse data = null;
            var path = @"Saved\" + this.Text;

            if (Directory.Exists("Saved") && File.Exists(path))
                data = DataSerializer.DeSerializeObject<TrueFalse>(path);

            return data;
        }

        // Update UI
        private void UpdateUI()
        {
            if (CheckForCompletion())
                return;
            UpdateCurrentIndexLabel();
            UpdateQuestionNumberLabel();
            UpdateAnswerLabel();
            UpdateLabel();
            UpdateButtons();
        }
        private void UpdateLabel()
        {
            label.Text = data.Questions[data.CurrentIndex].Text;
            label_Resize(this, EventArgs.Empty);
        }
        private void UpdateCurrentIndexLabel()
        {
            labelCurrentIndex.Text = (data.CurrentIndex + 1).ToString() + "/" + data.Questions.Count;
        }
        private void UpdateQuestionNumberLabel()
        {
            // Re-apply settings on runtime
            if (!Settings.Default.ShowQuestionNumbers)
                labelQuestionNumber.Hide();
            else
                labelQuestionNumber.Show();

            labelQuestionNumber.Text = "(" + data.Questions[data.CurrentIndex].Number + ")";
        }
        private void UpdateAnswerLabel()
        {
            labelAnswer.Text = data.Questions[data.CurrentIndex].Solution ? "True" : "False";
        }
        private void UpdateButtons()
        {
            if (state != TrueFalseFormState.Mistakes)
                return;

            if (data.CurrentIndex >= data.Questions.Count() - 1)
                btnRight.Enabled = false;
            else
                btnRight.Enabled = true;

            if (data.CurrentIndex <= 0)
                btnLeft.Enabled = false;
            else
                btnLeft.Enabled = true;
        }
        private bool CheckForCompletion()
        {
            if (state == TrueFalseFormState.QuestionsFill)
            {
                if (data.CurrentIndex > data.Questions.Count() - 1)
                {
                    ChangeStateCompleted();
                    return true;
                }
            }
            return false;
        }


        #region Resize Hacks

        private void label_Resize(object sender, EventArgs e)
        {
            using (var gr = label.CreateGraphics())
            {
                Font font = label.Font;
                for (int size = (int)(label.Height * 72 / gr.DpiY); size >= 8; --size)
                {
                    font = new Font(label.Font.FontFamily, size, label.Font.Style);
                    font = GetAdjustedFont(this.CreateGraphics(), label.Text, label.Font, label.Width, label.Height, 60, 10, false);
                    if (TextRenderer.MeasureText(label.Text, font).Width <= label.ClientSize.Width) break;
                }
                label.Font = font;
            }
        }

        private Font GetAdjustedFont(Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int ContainerHeight, int MaxFontSize, int MinFontSize, bool SmallestOnFail)
        {
            // We utilize MeasureString which we get via a control instance           
            for (int AdjustedSize = MaxFontSize; AdjustedSize >= MinFontSize; AdjustedSize--)
            {
                Font TestFont = new Font(OriginalFont.Name, AdjustedSize, OriginalFont.Style);

                // Test the string with the new size
                SizeF AdjustedSizeNew = GraphicRef.MeasureString(GraphicString, TestFont);

                if (ContainerWidth > Convert.ToInt32(AdjustedSizeNew.Width) &&
                    ContainerHeight > Convert.ToInt32(AdjustedSizeNew.Height))
                {
                    // Good font, return it
                    return TestFont;
                }
            }

            // If you get here there was no fontsize that worked
            // return MinimumSize or Original?
            if (SmallestOnFail)
            {
                return new Font(OriginalFont.Name, MinFontSize, OriginalFont.Style);
            }
            else
            {
                return OriginalFont;
            }
        }

        #endregion
    }
}
