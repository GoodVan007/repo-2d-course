namespace PhotoEnxancer
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.FiltersComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(370, 12);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(400, 300);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            this.OriginalPictureBox.Click += new System.EventHandler(this.OriginalPictureBox_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(370, 328);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(400, 300);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultPictureBox.TabIndex = 1;
            this.resultPictureBox.TabStop = false;
            this.resultPictureBox.Click += new System.EventHandler(this.resultPictureBox_Click);
            // 
            // FiltersComboBox
            // 
            this.FiltersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FiltersComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FiltersComboBox.FormattingEnabled = true;
            this.FiltersComboBox.Location = new System.Drawing.Point(12, 12);
            this.FiltersComboBox.Name = "FiltersComboBox";
            this.FiltersComboBox.Size = new System.Drawing.Size(340, 28);
            this.FiltersComboBox.TabIndex = 2;
            this.FiltersComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltersComboBox_SelectedIndexChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ApplyButton.Location = new System.Drawing.Point(98, 592);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(174, 36);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Accept";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Visible = false;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.FiltersComboBox);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.OriginalPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "PhotoEnxancer";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.ComboBox FiltersComboBox;
        private System.Windows.Forms.Button ApplyButton;
    }
}

