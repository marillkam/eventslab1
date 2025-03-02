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
    public partial class SetReminderForm : Form
    {
        private List<Event> events;
        private ComboBox eventComboBox;
        private Button setReminderButton;
        private Button cancelButton;

        public SetReminderForm(List<Event> events)
        {
            this.events = events;
            this.Text = "Установить напоминание";
            this.Size = new System.Drawing.Size(300, 100);
            InitializeControls();
        }

        private void InitializeControls()
        {
            eventComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(260, 20)
            };
            foreach (var e in events)
            {
                eventComboBox.Items.Add(e.Name);
            };

            setReminderButton = new Button
            {
                Text = "Установить",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(100, 25)
            };
            setReminderButton.Click += (sender, e) =>
            {
                if (eventComboBox.SelectedIndex >= 0)
                {
                    var selectedEvent = events[eventComboBox.SelectedIndex];
                    selectedEvent.SetReminder();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            cancelButton = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(170, 40),
                Size = new System.Drawing.Size(100, 25)
            };
            cancelButton.Click += (sender, e) =>
            {
                this.Close();
            };

            this.Controls.Add(eventComboBox);
            this.Controls.Add(setReminderButton);
            this.Controls.Add(cancelButton);
        }
    }
}
