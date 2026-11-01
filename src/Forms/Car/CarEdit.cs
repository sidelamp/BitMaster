using BitMaster.Data;
using CarModel = BitMaster.Data.Car;

namespace BitMaster.Forms.Car
{
    public partial class CarEdit : EntityEditForm
    {
        // Исходные данные записи для определения изменений; null — новая запись
        private CarModel original;

        public CarEdit()
        {
            InitializeComponent();
            WireButtons();

            this.btnDelete.Enabled = false;
        }

        public CarEdit(int carId) : base(carId)
        {
            InitializeComponent();
            WireButtons();
            FillTextFields();
        }

        ~CarEdit()
        {
            btnSave.Click -= Save;
            btnDelete.Click -= Delete;
        }

        private void WireButtons()
        {
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        protected override void FillTextFields()
        {
            var car = Database.GetCar(entityId);
            if (car == null)
            {
                ShowWarning("Машина не найдена в базе.");
                return;
            }

            txtCarId.Text = car.Id.ToString();
            cmbBrand.SelectedItem = car.Brand;
            cmbCarType.SelectedItem = car.CarType;
            txtPlateNumber.Text = car.PlateNumber;

            original = car;
        }

        protected override bool HasChanges()
        {
            if (original == null)
            {
                // Новая запись: изменения есть, если хоть что-то заполнено
                return cmbBrand.SelectedItem != null
                    || cmbCarType.SelectedItem != null
                    || !string.IsNullOrWhiteSpace(txtPlateNumber.Text);
            }

            return original.Brand != (string)cmbBrand.SelectedItem
                || original.CarType != (string)cmbCarType.SelectedItem
                || original.PlateNumber != txtPlateNumber.Text.Trim();
        }

        protected override bool SaveEntity()
        {
            if (cmbBrand.SelectedItem == null
                || cmbCarType.SelectedItem == null
                || string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                ShowWarning("Заполните все поля.");
                return false;
            }

            var car = new CarModel
            {
                Id = entityId,
                Brand = cmbBrand.SelectedItem.ToString(),
                CarType = cmbCarType.SelectedItem.ToString(),
                PlateNumber = txtPlateNumber.Text.Trim()
            };

            try
            {
                Database.SaveCar(car);
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                // Сработало ограничение UNIQUE или CHECK
                ShowWarning("Машина с таким гос. номером уже существует.");
                return false;
            }
        }

        protected override bool DeleteEntity()
        {
            try
            {
                Database.DeleteCar(entityId);
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                // ON DELETE RESTRICT: машина закреплена за экипажем
                ShowWarning("Нельзя удалить машину: она закреплена за экипажем.");
                return false;
            }
        }
    }
}
