using BitMaster.Data;
using BitMaster.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitMaster
{
    public partial class MainForm : Form
    {
        private bool driversLoaded;
        private bool carsLoaded;

        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;
            tbGrids.SelectedIndexChanged += tbGrids_SelectedIndexChanged;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvCrews.DataSource = Database.GetCrews();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tbGrids.SelectedTab == tabCrews)
            {
                dgvCrews.DataSource = Database.GetCrews();
            }
            else if (tbGrids.SelectedTab == tabDrivers)
            {
                dgvDrivers.DataSource = Database.GetDrivers();
                driversLoaded = true;
            }
            else if (tbGrids.SelectedTab == tabCars)
            {
                dgvCars.DataSource = Database.GetCars();
                carsLoaded = true;
            }
        }

        private void tbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbGrids.SelectedTab == tabDrivers && !driversLoaded)
            {
                dgvDrivers.DataSource = Database.GetDrivers();
                driversLoaded = true;
            }
            else if (tbGrids.SelectedTab == tabCars && !carsLoaded)
            {
                dgvCars.DataSource = Database.GetCars();
                carsLoaded = true;
            }
        }

        private void dgvCrews_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open CrewEdit form with selected crew id
        }

        private void dgvDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open DriverEdit form with selected driver id
        }

        private void dgvCars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open CarEdit form with selected car id
        }

        private void dgvCrews_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvCrews, e);
        }

        private void dgvDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvDrivers, e);
        }

        private void dgvCars_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvCars, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void SelectRowInDataGridView(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgv.ClearSelection();

                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
        }
    }
}
