using System;
using System.Drawing;
using System.Windows.Forms;

namespace eventslab1
{
    public partial class CreateEventForm : Form
    {
        public string EventName => txtName.Text;
        public DateTime StartTime => dtStart.Value;
        public DateTime EndTime => dtEnd.Value;
        public string EventLocation => txtLocation.Text;
        public string EventDescription => txtDescription.Text;

        private readonly TextBox txtName = new TextBox();
        private readonly DateTimePicker dtStart = new DateTimePicker();
        private readonly DateTimePicker dtEnd = new DateTimePicker();
        private readonly TextBox txtLocation = new TextBox();
        private readonly TextBox txtDescription = new TextBox();
        private readonly Button btnCreate = new Button();
        private readonly Button btnCancel = new Button();

        public CreateEventForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Настройка формы
            this.Text = "Создание нового события";
            this.ClientSize = new Size(350, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Название события
            var lblName = new Label
            {
                Text = "Название события:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtName.Location = new Point(20, 45);
            txtName.Size = new Size(300, 20);

            // Время начала
            var lblStart = new Label
            {
                Text = "Дата и время начала:",
                Location = new Point(20, 80),
                AutoSize = true
            };

            dtStart.Location = new Point(20, 105);
            dtStart.Size = new Size(300, 20);
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.CustomFormat = "dd.MM.yyyy HH:mm";
            dtStart.ShowUpDown = true;

            // Время окончания
            var lblEnd = new Label
            {
                Text = "Дата и время окончания:",
                Location = new Point(20, 140),
                AutoSize = true
            };

            dtEnd.Location = new Point(20, 165);
            dtEnd.Size = new Size(300, 20);
            dtEnd.Format = DateTimePickerFormat.Custom;
            dtEnd.CustomFormat = "dd.MM.yyyy HH:mm";
            dtEnd.ShowUpDown = true;
            dtEnd.Value = dtStart.Value.AddHours(1); // По умолчанию +1 час от начала

            // Местоположение
            var lblLocation = new Label
            {
                Text = "Местоположение:",
                Location = new Point(20, 200),
                AutoSize = true
            };

            txtLocation.Location = new Point(20, 225);
            txtLocation.Size = new Size(300, 20);

            // Описание
            var lblDescription = new Label
            {
                Text = "Описание:",
                Location = new Point(20, 250),
                AutoSize = true
            };

            txtDescription.Location = new Point(20, 275);
            txtDescription.Size = new Size(300, 60);
            txtDescription.Multiline = true;

            // Кнопка Создать
            btnCreate.Text = "Создать";
            btnCreate.DialogResult = DialogResult.OK;
            btnCreate.Location = new Point(120, 350);
            btnCreate.Size = new Size(100, 30);
            btnCreate.Click += (s, e) => ValidateForm();

            // Кнопка Отмена
            btnCancel.Text = "Отмена";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(230, 350);
            btnCancel.Size = new Size(100, 30);

            // Добавление элементов на форму
            this.Controls.AddRange(new Control[] {
                lblName, txtName,
                lblStart, dtStart,
                lblEnd, dtEnd,
                lblLocation, txtLocation,
                lblDescription, txtDescription,
                btnCreate, btnCancel
            });
        }

        private void ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название события", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (dtStart.Value >= dtEnd.Value)
            {
                MessageBox.Show("Время окончания должно быть позже времени начала", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}