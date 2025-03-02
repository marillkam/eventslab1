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
    public partial class RemoveReminderForm : Form
    {
        private List<Event> events;
        private ComboBox eventComboBox;
        private Button removeReminderButton;
        private Button cancelButton;

        public RemoveReminderForm(List<Event> events)
        {
            this.events = events;
            this.Text = "Снять напоминание";
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

            removeReminderButton = new Button
            {
                Text = "Снять",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(100, 25)
            };
            removeReminderButton.Click += (sender, e) =>
            {
                if (eventComboBox.SelectedIndex >= 0)
                {
                    var selectedEvent = events[eventComboBox.SelectedIndex];
                    selectedEvent.RemoveReminder();
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
            this.Controls.Add(removeReminderButton);
            this.Controls.Add(cancelButton);
        }
    }
}
