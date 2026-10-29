namespace BitMaster
{
    partial class MainForm
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
            this.openCarListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openCarListButton
            // 
            this.openCarListButton.Location = new System.Drawing.Point(335, 216);
            this.openCarListButton.Name = "openCarListButton";
            this.openCarListButton.Size = new System.Drawing.Size(156, 54);
            this.openCarListButton.TabIndex = 0;
            this.openCarListButton.Text = "button1";
            this.openCarListButton.UseVisualStyleBackColor = true;
            this.openCarListButton.Click += new System.EventHandler(this.OpenCarListButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 478);
            this.Controls.Add(this.openCarListButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openCarListButton;
    }
}

