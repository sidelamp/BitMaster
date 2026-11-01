using System;
using System.Windows.Forms;
using BitMaster.Data;
using DriverModel = BitMaster.Data.Driver;

namespace BitMaster.Forms.Driver
{
    public partial class DriverEdit : EntityEditForm
    {
        // Исходные данные записи для определения изменений; null — новая запись
        private DriverModel original;

        public DriverEdit()
        {
            InitializeComponent();
            WireButtons();
            FillExperienceYears();

            this.btnDelete.Enabled = false;
        }

        public DriverEdit(int driverId) : base(driverId)
        {
            InitializeComponent();
            WireButtons();
            FillExperienceYears();
            FillTextFields();
        }

        ~DriverEdit()
        {
            btnSave.Click -= Save;
            btnDelete.Click -= Delete;
        }

        private void WireButtons()
        {
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        private void FillExperienceYears()
        {
            for (int i = 0; i <= 50; i++)
                cmbExpirenceYears.Items.Add(i);
        }

        protected override void FillTextFields()
        {
            var driver = Database.GetDriver(entityId);
            if (driver == null)
            {
                ShowWarning("Водитель не найден в базе.");
                return;
            }

            txtDriverId.Text = driver.Id.ToString();
            txtLastName.Text = driver.LastName;
            txtFirstName.Text = driver.FirstName;
            txtMiddleName.Text = driver.MiddleName;
            maskedTextBox1.Text = driver.LicenseNumber;
            cmbExpirenceYears.SelectedItem = driver.ExperienceYears;

            original = driver;
        }

        protected override bool HasChanges()
        {
            if (original == null)
            {
                // Новая запись: изменения есть, если хоть что-то заполнено
                return !string.IsNullOrWhiteSpace(txtLastName.Text)
                    || !string.IsNullOrWhiteSpace(txtFirstName.Text)
                    || !string.IsNullOrWhiteSpace(txtMiddleName.Text)
                    || !string.IsNullOrWhiteSpace(maskedTextBox1.Text)
                    || cmbExpirenceYears.SelectedItem != null;
            }

            return original.LastName != txtLastName.Text.Trim()
                || original.FirstName != txtFirstName.Text.Trim()
                || Normalize(original.MiddleName) != Normalize(txtMiddleName.Text)
                || original.LicenseNumber != maskedTextBox1.Text
                || original.ExperienceYears != (int)cmbExpirenceYears.SelectedItem;
        }

        private static string Normalize(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "" : s.Trim();
        }

        protected override bool SaveEntity()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowWarning("Заполните фамилию и имя водителя.");
                return false;
            }

            if (!maskedTextBox1.MaskCompleted)
            {
                ShowWarning("Введите номер прав полностью (формат: 0000 000000).");
                return false;
            }

            if (cmbExpirenceYears.SelectedItem == null)
            {
                ShowWarning("Укажите стаж вождения.");
                return false;
            }

            var driver = new DriverModel
            {
                Id = entityId,
                LastName = txtLastName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text.Trim(),
                LicenseNumber = maskedTextBox1.Text,
                ExperienceYears = (int)cmbExpirenceYears.SelectedItem
            };

            try
            {
                Database.SaveDriver(driver);
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                ShowWarning("Водитель с таким номером прав уже существует.");
                return false;
            }
        }

        protected override bool DeleteEntity()
        {
            try
            {
                Database.DeleteDriver(entityId);
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {
                ShowWarning("Нельзя удалить водителя: он закреплен за экипажем.");
                return false;
            }
        }
    }
}
