using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnxancer
{
    public partial class mainForm : Form
    {

        Bitmap originalBmp;
        Bitmap ResultBmp;

        Panel parametersPanel;

        public mainForm()
        {
            InitializeComponent();

            originalBmp = (Bitmap)Image.FromFile("SmallStark.jpg");
            OriginalPictureBox.Image = originalBmp;

            FiltersComboBox.Items.Add("Brightness");
        }

        private void resultPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void OriginalPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FiltersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyButton.Visible = true;
            
            if (parametersPanel != null)
                this.Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = FiltersComboBox.Left;
            parametersPanel.Top = FiltersComboBox.Bottom + 10;
            parametersPanel.Width = FiltersComboBox.Width;
            parametersPanel.Height = ApplyButton.Top - FiltersComboBox.Bottom - 20;

            //parametersPanel.BackColor= Color.Gray;

            this.Controls.Add(parametersPanel);

            var filter = FiltersComboBox.SelectedItem;

            if(FiltersComboBox.SelectedItem.ToString() == "Brightness")
            {
                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametersPanel.Width - 50;
                label.Height = 28;
                label.Text = "Ratio";
                label.Font = new Font(label.Font.FontFamily, 10);
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = parametersPanel.Width - label.Width;
                inputBox.Height = label.Height;
                inputBox.Font = new Font(inputBox.Font.FontFamily, 10);
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Value = 1;
                inputBox.Name = "Ratio";
                parametersPanel.Controls.Add(inputBox);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var newBmp = new Bitmap(originalBmp.Width, originalBmp.Height);
            if (FiltersComboBox.SelectedItem.ToString() == "Brightness")
            {
                var k = (double)((NumericUpDown)parametersPanel.Controls["Ratio"]).Value;
                //MessageBox.Show(k.ToString());

                for(var x = 0; x < originalBmp.Width; x++)
                    for(var y=0;  y<originalBmp.Height; y++)
                    {
                        var pixelColor = originalBmp.GetPixel(x, y);
                        var newR = (int)(pixelColor.R * k);
                        if(newR > 255)
                            newR = 255;

                        var newG = (int)(pixelColor.G * k);
                        if (newG > 255)
                            newG = 255;

                        var newB = (int)(pixelColor.B * k);
                        if (newB > 255)
                            newB = 255;

                        newBmp.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                    }
            }
            ResultBmp = newBmp;
            resultPictureBox.Image = ResultBmp;
        }
    }
}
