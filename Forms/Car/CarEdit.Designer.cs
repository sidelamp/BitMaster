namespace BitMaster.Forms.Car
{
    partial class CarEdit
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.grpMainInfo = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtCarId = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblCarType = new System.Windows.Forms.Label();
            this.cmbCarType = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picCarIcon = new System.Windows.Forms.PictureBox();
            this.grpMainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(72, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(286, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Редактирование автомобиля";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(74, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(300, 13);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Измените данные автомобиля и сохраните изменения";
            // 
            // grpMainInfo
            // 
            this.grpMainInfo.Controls.Add(this.lblId);
            this.grpMainInfo.Controls.Add(this.txtCarId);
            this.grpMainInfo.Controls.Add(this.lblBrand);
            this.grpMainInfo.Controls.Add(this.cmbBrand);
            this.grpMainInfo.Controls.Add(this.lblPlate);
            this.grpMainInfo.Controls.Add(this.txtPlateNumber);
            this.grpMainInfo.Controls.Add(this.lblCarType);
            this.grpMainInfo.Controls.Add(this.cmbCarType);
            this.grpMainInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpMainInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.grpMainInfo.Location = new System.Drawing.Point(16, 84);
            this.grpMainInfo.Name = "grpMainInfo";
            this.grpMainInfo.Size = new System.Drawing.Size(398, 252);
            this.grpMainInfo.TabIndex = 3;
            this.grpMainInfo.TabStop = false;
            this.grpMainInfo.Text = "Основная информация";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblId.Location = new System.Drawing.Point(16, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 17);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // txtCarId
            // 
            this.txtCarId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.txtCarId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCarId.Location = new System.Drawing.Point(19, 54);
            this.txtCarId.Name = "txtCarId";
            this.txtCarId.ReadOnly = true;
            this.txtCarId.Size = new System.Drawing.Size(175, 25);
            this.txtCarId.TabIndex = 1;
            this.txtCarId.TabStop = false;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblBrand.Location = new System.Drawing.Point(16, 100);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(102, 17);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Марка машины";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Items.AddRange(new object[] {
            "Toyota",
            "KIA",
            "Lada"});
            this.cmbBrand.Location = new System.Drawing.Point(19, 122);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(175, 25);
            this.cmbBrand.TabIndex = 0;
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblPlate.Location = new System.Drawing.Point(206, 100);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(74, 17);
            this.lblPlate.TabIndex = 4;
            this.lblPlate.Text = "Гос. номер";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlateNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPlateNumber.Location = new System.Drawing.Point(209, 122);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(175, 25);
            this.txtPlateNumber.TabIndex = 1;
            // 
            // lblCarType
            // 
            this.lblCarType.AutoSize = true;
            this.lblCarType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCarType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCarType.Location = new System.Drawing.Point(16, 168);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(83, 17);
            this.lblCarType.TabIndex = 6;
            this.lblCarType.Text = "Тип машины";
            // 
            // cmbCarType
            // 
            this.cmbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCarType.FormattingEnabled = true;
            this.cmbCarType.Items.AddRange(new object[] {
            "Седан",
            "Легковая",
            "Грузовая",
            "Автобус"});
            this.cmbCarType.Location = new System.Drawing.Point(19, 190);
            this.cmbCarType.Name = "cmbCarType";
            this.cmbCarType.Size = new System.Drawing.Size(175, 25);
            this.cmbCarType.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Image = global::BitMaster.Properties.Resources.DeleteIcon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(268, 352);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(146, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "   Удалить";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Image = global::BitMaster.Properties.Resources.SaveIcon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(16, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(238, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "   Сохранить и закрыть";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picCarIcon
            // 
            this.picCarIcon.Image = global::BitMaster.Properties.Resources.CarIcon;
            this.picCarIcon.Location = new System.Drawing.Point(20, 16);
            this.picCarIcon.Name = "picCarIcon";
            this.picCarIcon.Size = new System.Drawing.Size(42, 42);
            this.picCarIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarIcon.TabIndex = 0;
            this.picCarIcon.TabStop = false;
            // 
            // CarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 407);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpMainInfo);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picCarIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование";
            this.grpMainInfo.ResumeLayout(false);
            this.grpMainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCarIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.GroupBox grpMainInfo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtCarId;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblCarType;
        private System.Windows.Forms.ComboBox cmbCarType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}
