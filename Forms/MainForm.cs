using BitMaster.Data;
using System;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvCrews.DataSource = Database.GetCrews();
        }

        private void RefreshDataGrid(object sender, EventArgs e)
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

        private void TabPanelSelectedIndexChanged(object sender, EventArgs e)
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

        private void DataGridCrews_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open CrewEdit form with selected crew id
        }

        private void DataGridDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open DriverEdit form with selected driver id
        }

        private void DataGridCars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open CarEdit form with selected car id
        }

        private void DataGridCrews_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvCrews, e);
        }

        private void DataGridDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvDrivers, e);
        }

        private void DataGridCars_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectRowInDataGridView(dgvCars, e);
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

        private void DeleteRow(object sender, EventArgs e)
        {

        }

        private void EditRow(object sender, EventArgs e)
        {

        }

        private void AddRow(object sender, EventArgs e)
        {

        }
    }
}
