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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.tbGrids = new System.Windows.Forms.TabControl();
            this.tabCrews = new System.Windows.Forms.TabPage();
            this.dgvCrews = new System.Windows.Forms.DataGridView();
            this.tabDrivers = new System.Windows.Forms.TabPage();
            this.dgvDrivers = new System.Windows.Forms.DataGridView();
            this.tabCars = new System.Windows.Forms.TabPage();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.pnlBottomButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.imgTabList = new System.Windows.Forms.ImageList(this.components);
            this.cmChangeData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCrews = new System.Windows.Forms.Panel();
            this.picCarIcon = new System.Windows.Forms.PictureBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDrivers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCars = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlTabs.SuspendLayout();
            this.tbGrids.SuspendLayout();
            this.tabCrews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrews)).BeginInit();
            this.tabDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).BeginInit();
            this.tabCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.pnlBottomButtons.SuspendLayout();
            this.cmChangeData.SuspendLayout();
            this.pnlCrews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarIcon)).BeginInit();
            this.pnlDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabs.Controls.Add(this.tbGrids);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(953, 687);
            this.pnlTabs.TabIndex = 3;
            // 
            // tbGrids
            // 
            this.tbGrids.Controls.Add(this.tabCrews);
            this.tbGrids.Controls.Add(this.tabDrivers);
            this.tbGrids.Controls.Add(this.tabCars);
            this.tbGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGrids.ImageList = this.imgTabList;
            this.tbGrids.Location = new System.Drawing.Point(0, 0);
            this.tbGrids.Name = "tbGrids";
            this.tbGrids.SelectedIndex = 0;
            this.tbGrids.Size = new System.Drawing.Size(953, 687);
            this.tbGrids.TabIndex = 1;
            this.tbGrids.SelectedIndexChanged += new System.EventHandler(this.tbGrids_SelectedIndexChanged);
            // 
            // tabCrews
            // 
            this.tabCrews.Controls.Add(this.dgvCrews);
            this.tabCrews.Controls.Add(this.pnlCrews);
            this.tabCrews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabCrews.ImageIndex = 1;
            this.tabCrews.Location = new System.Drawing.Point(4, 34);
            this.tabCrews.Name = "tabCrews";
            this.tabCrews.Padding = new System.Windows.Forms.Padding(3);
            this.tabCrews.Size = new System.Drawing.Size(945, 649);
            this.tabCrews.TabIndex = 0;
            this.tabCrews.Text = "Экипажи";
            this.tabCrews.UseVisualStyleBackColor = true;
            // 
            // dgvCrews
            // 
            this.dgvCrews.AllowUserToAddRows = false;
            this.dgvCrews.AllowUserToDeleteRows = false;
            this.dgvCrews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCrews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrews.ContextMenuStrip = this.cmChangeData;
            this.dgvCrews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCrews.Location = new System.Drawing.Point(3, 74);
            this.dgvCrews.MultiSelect = false;
            this.dgvCrews.Name = "dgvCrews";
            this.dgvCrews.ReadOnly = true;
            this.dgvCrews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCrews.Size = new System.Drawing.Size(939, 572);
            this.dgvCrews.TabIndex = 0;
            this.dgvCrews.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCrews_CellDoubleClick);
            this.dgvCrews.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCrews_CellMouseDown);
            // 
            // tabDrivers
            // 
            this.tabDrivers.Controls.Add(this.dgvDrivers);
            this.tabDrivers.Controls.Add(this.pnlDrivers);
            this.tabDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabDrivers.ImageIndex = 2;
            this.tabDrivers.Location = new System.Drawing.Point(4, 34);
            this.tabDrivers.Name = "tabDrivers";
            this.tabDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrivers.Size = new System.Drawing.Size(945, 649);
            this.tabDrivers.TabIndex = 1;
            this.tabDrivers.Text = "Водители";
            this.tabDrivers.UseVisualStyleBackColor = true;
            // 
            // dgvDrivers
            // 
            this.dgvDrivers.AllowUserToAddRows = false;
            this.dgvDrivers.AllowUserToDeleteRows = false;
            this.dgvDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrivers.ContextMenuStrip = this.cmChangeData;
            this.dgvDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrivers.Location = new System.Drawing.Point(3, 74);
            this.dgvDrivers.Name = "dgvDrivers";
            this.dgvDrivers.ReadOnly = true;
            this.dgvDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrivers.Size = new System.Drawing.Size(939, 572);
            this.dgvDrivers.TabIndex = 1;
            this.dgvDrivers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrivers_CellDoubleClick);
            this.dgvDrivers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDrivers_CellMouseDown);
            // 
            // tabCars
            // 
            this.tabCars.Controls.Add(this.dgvCars);
            this.tabCars.Controls.Add(this.pnlCars);
            this.tabCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabCars.ImageIndex = 0;
            this.tabCars.Location = new System.Drawing.Point(4, 34);
            this.tabCars.Name = "tabCars";
            this.tabCars.Padding = new System.Windows.Forms.Padding(3);
            this.tabCars.Size = new System.Drawing.Size(945, 649);
            this.tabCars.TabIndex = 2;
            this.tabCars.Text = "Машины";
            this.tabCars.UseVisualStyleBackColor = true;
            // 
            // dgvCars
            // 
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.ContextMenuStrip = this.cmChangeData;
            this.dgvCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCars.Location = new System.Drawing.Point(3, 74);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(939, 572);
            this.dgvCars.TabIndex = 2;
            this.dgvCars.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellDoubleClick);
            this.dgvCars.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCars_CellMouseDown);
            // 
            // pnlBottomButtons
            // 
            this.pnlBottomButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottomButtons.Controls.Add(this.btnRefresh);
            this.pnlBottomButtons.Controls.Add(this.btnDelete);
            this.pnlBottomButtons.Controls.Add(this.btnEdit);
            this.pnlBottomButtons.Controls.Add(this.btnAdd);
            this.pnlBottomButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomButtons.Location = new System.Drawing.Point(0, 687);
            this.pnlBottomButtons.Name = "pnlBottomButtons";
            this.pnlBottomButtons.Size = new System.Drawing.Size(953, 74);
            this.pnlBottomButtons.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::BitMaster.Properties.Resources.RefreshIcon;
            this.btnRefresh.Location = new System.Drawing.Point(372, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 50);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BitMaster.Properties.Resources.DeleteIcon;
            this.btnDelete.Location = new System.Drawing.Point(252, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 50);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::BitMaster.Properties.Resources.ModifyIcon;
            this.btnEdit.Location = new System.Drawing.Point(132, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(114, 50);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BitMaster.Properties.Resources.AddIcon;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 50);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = " Добавить";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // imgTabList
            // 
            this.imgTabList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTabList.ImageStream")));
            this.imgTabList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTabList.Images.SetKeyName(0, "car.png");
            this.imgTabList.Images.SetKeyName(1, "crew.png");
            this.imgTabList.Images.SetKeyName(2, "driver.png");
            // 
            // cmChangeData
            // 
            this.cmChangeData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.editMenuItem,
            this.deleteMenuItem,
            this.refreshMenuItem});
            this.cmChangeData.Name = "cmChangeData";
            this.cmChangeData.Size = new System.Drawing.Size(181, 114);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Image = global::BitMaster.Properties.Resources.ModifyIcon;
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editMenuItem.Text = "Изменить";
            this.editMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Image = global::BitMaster.Properties.Resources.DeleteIcon;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteMenuItem.Text = "Удалить";
            this.deleteMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Image = global::BitMaster.Properties.Resources.RefreshIcon;
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshMenuItem.Text = "Обновить";
            this.refreshMenuItem.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Image = global::BitMaster.Properties.Resources.AddIcon;
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addMenuItem.Text = "Добавить";
            this.addMenuItem.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlCrews
            // 
            this.pnlCrews.Controls.Add(this.lblSubtitle);
            this.pnlCrews.Controls.Add(this.lblTitle);
            this.pnlCrews.Controls.Add(this.picCarIcon);
            this.pnlCrews.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCrews.Location = new System.Drawing.Point(3, 3);
            this.pnlCrews.Name = "pnlCrews";
            this.pnlCrews.Size = new System.Drawing.Size(939, 71);
            this.pnlCrews.TabIndex = 1;
            // 
            // picCarIcon
            // 
            this.picCarIcon.Image = global::BitMaster.Properties.Resources.CrewIcon;
            this.picCarIcon.Location = new System.Drawing.Point(5, 12);
            this.picCarIcon.Name = "picCarIcon";
            this.picCarIcon.Size = new System.Drawing.Size(42, 42);
            this.picCarIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarIcon.TabIndex = 1;
            this.picCarIcon.TabStop = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(55, 41);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(217, 13);
            this.lblSubtitle.TabIndex = 4;
            this.lblSubtitle.Text = "Список экипажей (водитель + машина)";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(53, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(97, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Экипажи";
            // 
            // pnlDrivers
            // 
            this.pnlDrivers.Controls.Add(this.label1);
            this.pnlDrivers.Controls.Add(this.label2);
            this.pnlDrivers.Controls.Add(this.pictureBox1);
            this.pnlDrivers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDrivers.Location = new System.Drawing.Point(3, 3);
            this.pnlDrivers.Name = "pnlDrivers";
            this.pnlDrivers.Size = new System.Drawing.Size(939, 71);
            this.pnlDrivers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(55, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список водителей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(53, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Водители";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BitMaster.Properties.Resources.DriverIcon;
            this.pictureBox1.Location = new System.Drawing.Point(5, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlCars
            // 
            this.pnlCars.Controls.Add(this.label3);
            this.pnlCars.Controls.Add(this.label4);
            this.pnlCars.Controls.Add(this.pictureBox2);
            this.pnlCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCars.Location = new System.Drawing.Point(3, 3);
            this.pnlCars.Name = "pnlCars";
            this.pnlCars.Size = new System.Drawing.Size(939, 71);
            this.pnlCars.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(55, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Список машин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(53, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Машины";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BitMaster.Properties.Resources.CarIcon;
            this.pictureBox2.Location = new System.Drawing.Point(5, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 761);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlBottomButtons);
            this.MinimumSize = new System.Drawing.Size(511, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экипажи";
            this.pnlTabs.ResumeLayout(false);
            this.tbGrids.ResumeLayout(false);
            this.tabCrews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrews)).EndInit();
            this.tabDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).EndInit();
            this.tabCars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.pnlBottomButtons.ResumeLayout(false);
            this.cmChangeData.ResumeLayout(false);
            this.pnlCrews.ResumeLayout(false);
            this.pnlCrews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCarIcon)).EndInit();
            this.pnlDrivers.ResumeLayout(false);
            this.pnlDrivers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlCars.ResumeLayout(false);
            this.pnlCars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.TabControl tbGrids;
        private System.Windows.Forms.TabPage tabCrews;
        private System.Windows.Forms.DataGridView dgvCrews;
        private System.Windows.Forms.TabPage tabDrivers;
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.TabPage tabCars;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Panel pnlBottomButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ImageList imgTabList;
        private System.Windows.Forms.ContextMenuStrip cmChangeData;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.Panel pnlCrews;
        private System.Windows.Forms.PictureBox picCarIcon;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlCars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

