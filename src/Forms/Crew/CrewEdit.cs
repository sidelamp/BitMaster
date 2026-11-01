using System;
using System.Windows.Forms;
using BitMaster.Data;
using CrewModel = BitMaster.Data.Crew;

namespace BitMaster.Forms.Crew
{
    public partial class CrewEdit : EntityEditForm
    {
        public CrewEdit()
        {
            InitializeComponent();
            WireButtons();
            FillCombos();
            cbActiveCrew.Checked = true; // новый экипаж активен по умолчанию
        }

        public CrewEdit(int crewId) : base(crewId)
        {
            InitializeComponent();
            WireButtons();
            FillCombos();
            FillTextFields();
        }

        private void WireButtons()
        {
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        private void FillCombos()
        {
            // Только свободные машины и водители (без активного экипажа);
            // при редактировании текущие значения этого экипажа тоже доступны
            cmbCar.DataSource = Database.GetFreeCarList(entityId);
            cmbCar.DisplayMember = "DisplayName";
            cmbCar.ValueMember = "Id";
            cmbCar.SelectedIndex = -1;

            cmbDriver.DataSource = Database.GetFreeDriverList(entityId);
            cmbDriver.DisplayMember = "DisplayName";
            cmbDriver.ValueMember = "Id";
            cmbDriver.SelectedIndex = -1;
        }

        protected override void FillTextFields()
        {
            var crew = Database.GetCrew(entityId);
            if (crew == null)
            {
                ShowWarning("Экипаж не найден в базе.");
                return;
            }

            txtCrewId.Text = crew.Id.ToString();
            cmbCar.SelectedValue = crew.CarId;
            cmbDriver.SelectedValue = crew.DriverId;
            cbActiveCrew.Checked = crew.Active;
        }

        protected override bool SaveEntity()
        {
            if (cmbCar.SelectedValue == null || cmbDriver.SelectedValue == null)
            {
                ShowWarning("Выберите машину и водителя.");
                return false;
            }

            var crew = new CrewModel
            {
                Id = entityId,
                CarId = (int)cmbCar.SelectedValue,
                DriverId = (int)cmbDriver.SelectedValue,
                Active = cbActiveCrew.Checked
            };

            try
            {
                Database.SaveCrew(crew);
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                // Частичные уникальные индексы: активный экипаж у машины/водителя уже есть
                ShowWarning("У этой машины или водителя уже есть активный экипаж.");
                return false;
            }
        }

        protected override bool DeleteEntity()
        {
            Database.DeleteCrew(entityId);
            return true;
        }
    }
}
