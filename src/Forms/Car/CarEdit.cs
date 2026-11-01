using System;
using System.Windows.Forms;
using BitMaster.Data;
using CarModel = BitMaster.Data.Car;

namespace BitMaster.Forms.Car
{
    public partial class CarEdit : EntityEditForm
    {
        public CarEdit()
        {
            InitializeComponent();
        }

        public CarEdit(int carId) : base(carId)
        {
            InitializeComponent();
            FillTextFields();
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
