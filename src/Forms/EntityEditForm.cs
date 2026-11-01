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

        // Закрытие уже подтверждено (сохранение/удаление/ответ пользователя) — не спрашивать повторно
        private bool forceClose;

        protected EntityEditForm()
        {
            KeyPreview = true; // чтобы Esc ловился на уровне формы
        }

        protected EntityEditForm(int entityId) : this()
        {
            this.entityId = entityId;
        }

        /// <summary>Заполнить поля формы данными записи entityId.</summary>
        protected virtual void FillTextFields() { }

        /// <summary>Проверить поля и сохранить запись в базу. true — успешно.</summary>
        protected virtual bool SaveEntity() { return false; }

        /// <summary>Удалить запись entityId из базы. true — успешно.</summary>
        protected virtual bool DeleteEntity() { return false; }

        /// <summary>Есть ли несохранённые изменения в полях формы.</summary>
        protected virtual bool HasChanges() { return false; }

        protected virtual void ShowWarning(string text)
        {
            MessageBox.Show(this, text, "BitMaster", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected virtual void Save(object sender, EventArgs e)
        {
            if (!SaveEntity())
                return; // причину уже показал наследник

            DialogResult = DialogResult.OK;
            forceClose = true;
            Close();
        }

        // Кнопка "Удалить"
        protected virtual void Delete(object sender, EventArgs e)
        {
            if (entityId < 0)
            {
                // Новая запись ещё не в базе — просто закрываем без сохранения
                DialogResult = DialogResult.Cancel;
                forceClose = true;
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
            forceClose = true;
            Close();
        }

        // Esc закрывает форму; вопрос об изменениях задаст OnFormClosing
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
                return;
            }
            base.OnKeyDown(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!forceClose && e.CloseReason == CloseReason.UserClosing && HasChanges())
            {
                var answer = MessageBox.Show(this, "Есть изменения, сохранить?", "BitMaster",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (answer == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (answer == DialogResult.Yes)
                {
                    if (!SaveEntity())
                    {
                        e.Cancel = true;
                        return;
                    }
                    DialogResult = DialogResult.OK; // чтобы MainForm обновил таблицу
                }
            }

            base.OnFormClosing(e);
        }
    }
}
