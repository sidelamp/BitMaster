using BitMaster.Data;
using BitMaster.Forms;
using BitMaster.Forms.Car;
using BitMaster.Forms.Crew;
using BitMaster.Forms.Driver;
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
            RefreshCurrentGrid();
        }

        private void RefreshCurrentGrid()
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

        // ---------- Открытие окон редактирования ----------

        // Таблица активной вкладки
        private DataGridView CurrentGrid()
        {
            if (tbGrids.SelectedTab == tabDrivers)
                return dgvDrivers;
            if (tbGrids.SelectedTab == tabCars)
                return dgvCars;
            return dgvCrews;
        }

        // Форма редактирования под активную вкладку; id < 0 — новая запись
        private EntityEditForm CreateEditForm(int id)
        {
            if (tbGrids.SelectedTab == tabDrivers)
                return id < 0 ? (EntityEditForm)new DriverEdit() : new DriverEdit(id);
            if (tbGrids.SelectedTab == tabCars)
                return id < 0 ? (EntityEditForm)new CarEdit() : new CarEdit(id);
            return id < 0 ? (EntityEditForm)new CrewEdit() : new CrewEdit(id);
        }

        // Id выбранной строки активной таблицы
        private int? SelectedId()
        {
            var row = CurrentGrid().CurrentRow;
            if (row == null)
                return null;
            return Convert.ToInt32(row.Cells["Id"].Value);
        }

        private void OpenEditor(int id)
        {
            using (var form = CreateEditForm(id))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    RefreshCurrentGrid();
            }
        }

        // ---------- Обработчики кнопок и меню ----------

        private void AddRow(object sender, EventArgs e)
        {
            OpenEditor(-1);
        }

        private void EditRow(object sender, EventArgs e)
        {
            var id = SelectedId();
            if (id == null)
            {
                MessageBox.Show(this, "Сначала выберите запись.", "BitMaster",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenEditor(id.Value);
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            var id = SelectedId();
            if (id == null)
            {
                MessageBox.Show(this, "Сначала выберите запись.", "BitMaster",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var answer = MessageBox.Show(this, "Удалить выбранную запись?", "BitMaster",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
                return;

            try
            {
                if (tbGrids.SelectedTab == tabDrivers)
                    Database.DeleteDriver(id.Value);
                else if (tbGrids.SelectedTab == tabCars)
                    Database.DeleteCar(id.Value);
                else
                    Database.DeleteCrew(id.Value);
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                // ON DELETE RESTRICT: запись используется в экипаже
                MessageBox.Show(this, "Нельзя удалить запись: она закреплена за экипажем.", "BitMaster",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefreshCurrentGrid();
        }

        // ---------- Двойной клик по строке ----------

        private void DataGridCrews_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                OpenEditor(Convert.ToInt32(dgvCrews.Rows[e.RowIndex].Cells["Id"].Value));
        }

        private void DataGridDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                OpenEditor(Convert.ToInt32(dgvDrivers.Rows[e.RowIndex].Cells["Id"].Value));
        }

        private void DataGridCars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                OpenEditor(Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells["Id"].Value));
        }

        // ---------- Выделение строки правой кнопкой ----------

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
    }
}
