using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eventslab1
{
    public partial class DisplayEventsForm : Form
    {
        private readonly List<Event> events;
        private TextBox eventsTextBox; // Убрали readonly
        private Button closeButton;    // Убрали readonly

        public DisplayEventsForm(List<Event> events)
        {
            this.events = events;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Настройка формы
            this.Text = "Все события";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Инициализация текстового поля
            eventsTextBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Top,
                Height = 400,
                Font = new Font("Consolas", 10)
            };

            // Инициализация кнопки
            closeButton = new Button
            {
                Text = "Закрыть",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            // Заполнение текстового поля
            var allEvents = new StringBuilder();
            foreach (var e in events)
            {
                allEvents.AppendLine(e.ToString());
                allEvents.AppendLine(new string('-', 50));
            }
            eventsTextBox.Text = allEvents.ToString();

            // Добавление элементов на форму
            this.Controls.Add(eventsTextBox);
            this.Controls.Add(closeButton);
        }
    }
}