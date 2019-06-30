namespace WindowsFormsApp14
{
    partial class Form1
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.Sort = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.InputTextBox.Enabled = false;
            this.InputTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.InputTextBox.Location = new System.Drawing.Point(12, 46);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ReadOnly = true;
            this.InputTextBox.Size = new System.Drawing.Size(465, 28);
            this.InputTextBox.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(485, 46);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(238, 32);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Инициализация";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // Sort
            // 
            this.Sort.Location = new System.Drawing.Point(417, 262);
            this.Sort.Margin = new System.Windows.Forms.Padding(5);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(255, 32);
            this.Sort.TabIndex = 2;
            this.Sort.Text = "Сортировка";
            this.Sort.UseVisualStyleBackColor = true;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(29, 262);
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(370, 45);
            this.trackBar.TabIndex = 6;
            this.trackBar.Value = 2;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сортируемые элементы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(24, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Скорость воспроизведения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(727, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.InputTextBox);
            this.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(743, 383);
            this.MinimumSize = new System.Drawing.Size(743, 383);
            this.Name = "Form1";
            this.Text = "Сортировка";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button Sort;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

