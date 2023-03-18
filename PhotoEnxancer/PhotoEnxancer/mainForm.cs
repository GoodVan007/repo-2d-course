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

        Photo originalPhoto;
        Photo ResultPhoto;

        Panel parametersPanel;

        public mainForm()
        {
            InitializeComponent();

            var bmp = (Bitmap)Image.FromFile("SmallStark.jpg");
            OriginalPictureBox.Image = bmp;
            originalPhoto = Converters.BitmapToPhoto(bmp);

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
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);
            if (FiltersComboBox.SelectedItem.ToString() == "Brightness")
            {
                var k = (double)((NumericUpDown)parametersPanel.Controls["Ratio"]).Value;
                

                var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);

                if (filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
                {
                    var k = (double)((NumericUpDown)parametersPanel.Controls["coefficient"]).Value;

                    for (var x = 0; x < originalPhoto.Width; x++)
                        for (var y = 0; y < originalPhoto.Height; y++)
                            newPhoto[x, y] = k * originalPhoto[x, y];
                }
            }
            ResultPhoto = newPhoto;
            resultPictureBox.Image = Converters.PhotoToBitmap(ResultPhoto);
        }
    }
}
