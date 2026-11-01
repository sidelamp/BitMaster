using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace BitMaster.Forms
{
    /// <summary>
    /// Базовая форма редактирования записи: единая логика сохранения и удаления.
    /// Наследник (CarEdit, DriverEdit, CrewEdit) реализует только работу со своей сущностью.
    /// </summary>
    public class EntityEditForm : Form
    {
        /// <summary>Id редактируемой записи; -1 — создание новой.</summary>
        protected readonly int entityId = -1;

        protected EntityEditForm()
        {
        }

        protected EntityEditForm(int entityId)
        {
            this.entityId = entityId;
        }

        /// <summary>Заполнить поля формы данными записи entityId.</summary>
        protected virtual void FillTextFields() { }

        /// <summary>Проверить поля и сохранить запись в базу. true — успешно.</summary>
        protected virtual bool SaveEntity() { return false; }

        /// <summary>Удалить запись entityId из базы. true — успешно.</summary>
        protected virtual bool DeleteEntity() { return false; }

        protected virtual void ShowWarning(string text)
        {
            MessageBox.Show(this, text, "BitMaster", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected virtual void Save(object sender, EventArgs e)
        {
            if (!SaveEntity())
                return; // причину уже показал наследник

            DialogResult = DialogResult.OK;
            Close();
        }

        // Кнопка "Удалить"
        protected virtual void Delete(object sender, EventArgs e)
        {
            if (entityId < 0)
            {
                // Новая запись ещё не в базе — просто закрываем без сохранения
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            var answer = MessageBox.Show(this, "Удалить запись? Действие нельзя отменить.",
                "BitMaster", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (answer != DialogResult.Yes)
                return;

            if (!DeleteEntity())
                return;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
