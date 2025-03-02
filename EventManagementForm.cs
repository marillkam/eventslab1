using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventslab1
{
    public partial class EventManagementForm : Form
    {
        private EventManager eventManager;
        private ListView listView;
        private Button createEventButton;
        private Button editEventButton;
        private Button deleteEventButton;
        private Button setReminderButton;
        private Button removeReminderButton;
        private Button displayEventsButton;

        public EventManagementForm()
        {
            this.Text = "Управление встречами и мероприятиями";
            this.Width = 500;
            this.Height = 400;
            CreateControls();
            eventManager = new EventManager(listView);
        }

        private void CreateControls()
        {
            listView = new ListView
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(480, 300),
                View = View.Details,
                FullRowSelect = true
            };
            listView.Columns.Add("Название", 150);
            listView.Columns.Add("Время", 150);
            listView.Columns.Add("Место", 100);

            createEventButton = new Button
            {
                Location = new System.Drawing.Point(10, 320),
                Text = "Создать событие",
                Size = new System.Drawing.Size(100, 25)
            };
            createEventButton.Click += (sender, e) => eventManager.CreateEvent();

            editEventButton = new Button
            {
                Location = new System.Drawing.Point(120, 320),
                Text = "Редактировать",
                Size = new System.Drawing.Size(80, 25)
            };
            editEventButton.Click += (sender, e) => eventManager.EditEvent();

            deleteEventButton = new Button
            {
                Location = new System.Drawing.Point(210, 320),
                Text = "Удалить",
                Size = new System.Drawing.Size(80, 25)
            };
            deleteEventButton.Click += (sender, e) => eventManager.DeleteEvent();

            setReminderButton = new Button
            {
                Location = new System.Drawing.Point(300, 320),
                Text = "Напоминание",
                Size = new System.Drawing.Size(100, 25)
            };
            setReminderButton.Click += (sender, e) => eventManager.SetEventReminder();

            removeReminderButton = new Button
            {
                Location = new System.Drawing.Point(410, 320),
                Text = "Снять напоминание",
                Size = new System.Drawing.Size(120, 25)
            };
            removeReminderButton.Click += (sender, e) =>
eventManager.RemoveEventReminder();

            displayEventsButton = new Button
            {
                Location = new System.Drawing.Point(10, 350),
                Text = "Отобразить все",
                Size = new System.Drawing.Size(100, 25)
            };
            displayEventsButton.Click += (sender, e) => eventManager.DisplayEvents();

            this.Controls.Add(listView);
            this.Controls.Add(createEventButton);
            this.Controls.Add(editEventButton);
            this.Controls.Add(deleteEventButton);
            this.Controls.Add(setReminderButton);
            this.Controls.Add(removeReminderButton);
            this.Controls.Add(displayEventsButton);
        }
    }
}
