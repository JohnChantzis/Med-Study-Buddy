using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public partial class CardForm : Form, IDataForm
    {
        Cards cards;
        bool flipped = false;
        int currentItemIndex = 0;

        public CardForm(string title, Cards cards)
        {
            InitializeComponent();
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            label.Resize += new EventHandler(label_Resize);

            this.KeyPreview = true;

            this.Text = title;

            this.cards = cards;
            
            if (!Settings.Default.ShowRandom)
                cards.Shuffle();

            if (!cards.HaveBackSide())
            {
                btnFlip.Dispose();
                labelFlipped.Dispose();
            }

            update();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!btnNext.Enabled) return;

            currentItemIndex++;
            update();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (!btnPrevious.Enabled) return;

            currentItemIndex--;
            update();
        }

        private void update()
        {
            updateCurrentIndexLabel();
            updateLabel();
            updateButtons();
        }

        private void updateLabel(bool solution = false)
        {
            if (!solution)
            {
                if (!flipped)
                {
                    label.Text = cards.Front[currentItemIndex];
                    label.BackColor = Color.AliceBlue;
                }
                else
                {
                    label.Text = cards.Back[currentItemIndex];
                    label.BackColor = Color.MistyRose;
                }
                label.Tag = false;
            }
            else
            {
                if (!flipped)
                {
                    label.Text = cards.Back[currentItemIndex];
                    label.BackColor = Color.MistyRose;
                }
                else
                {
                    label.Text = cards.Front[currentItemIndex];
                    label.BackColor = Color.AliceBlue;
                }
                label.Tag = true;
            }

            label_Resize(this, EventArgs.Empty);
        }

        private void updateCurrentIndexLabel()
        {
            labelCurrentIndex.Text = (currentItemIndex + 1).ToString();
        }

        private void updateButtons()
        {
            if (currentItemIndex >= cards.Front.Count() - 1)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;

            if (currentItemIndex <= 0)
                btnPrevious.Enabled = false;
            else
                btnPrevious.Enabled = true;
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (!cards.HaveBackSide())
                return;

            updateLabel(!(bool)label.Tag);
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (!btnFlip.Enabled) return;

            flipped = !flipped;
            labelFlipped.Text = flipped ? "Flipped" : "Normal";
            updateLabel((bool)label.Tag);
        }

        void label_Resize(object sender, EventArgs e)
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

        public Font GetAdjustedFont(Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int ContainerHeight, int MaxFontSize, int MinFontSize, bool SmallestOnFail)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    btnNext_Click(this, EventArgs.Empty);
                    return true;
                case Keys.Left:
                    btnPrevious_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    btnPrevious_Click(this, EventArgs.Empty);
                    e.Handled = true;
                    break;
                case Keys.D:
                    btnNext_Click(this, EventArgs.Empty);
                    e.Handled = true;
                    break;
                case Keys.Space:
                    label_Click(this, EventArgs.Empty);
                    e.Handled = true;
                    break;
            }
        }
    }
}
