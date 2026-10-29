namespace BitMaster.Forms
{
    partial class CarList
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
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaveCarListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveCarListButton
            // 
            this.SaveCarListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveCarListButton.Location = new System.Drawing.Point(12, 348);
            this.SaveCarListButton.Name = "SaveCarListButton";
            this.SaveCarListButton.Size = new System.Drawing.Size(136, 65);
            this.SaveCarListButton.TabIndex = 1;
            this.SaveCarListButton.Text = "Сохранить";
            this.SaveCarListButton.UseVisualStyleBackColor = true;
            this.SaveCarListButton.Click += new System.EventHandler(this.SaveCarListButton_Click);
            // 
            // CarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 495);
            this.Controls.Add(this.SaveCarListButton);
            this.Name = "CarList";
            this.Text = "CarList";
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private System.Windows.Forms.Button SaveCarListButton;
    }
}