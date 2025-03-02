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
    public partial class EditEventForm : Form
    {
        private List<Event> events;
        private ComboBox eventComboBox;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label startTimeLabel;
        private DateTimePicker startTimePicker;
        private Label endTimeLabel;
        private DateTimePicker endTimePicker;
        private Label locationLabel;
        private TextBox locationTextBox;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Button editButton;
        private Button cancelButton;

        public EditEventForm(List<Event> events)
        {
            this.events = events;
            this.Text = "Редактировать событие";
            this.Size = new System.Drawing.Size(300, 400);
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
            }
            eventComboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (eventComboBox.SelectedIndex >= 0)
                {
                    var selectedEvent = events[eventComboBox.SelectedIndex];
                    nameTextBox.Text = selectedEvent.Name;
                    startTimePicker.Value = selectedEvent.StartTime;
                    endTimePicker.Value = selectedEvent.EndTime;
                    locationTextBox.Text = selectedEvent.Location;
                    descriptionTextBox.Text = selectedEvent.Description;
                }
            };

            nameLabel = new Label
            {
                Text = "Название:",
                Location = new System.Drawing.Point(10, 40)
            };
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 60),
                Size = new System.Drawing.Size(260, 20)
            };

            startTimeLabel = new Label
            {
                Text = "Время начала:",
                Location = new System.Drawing.Point(10, 90)
            };
            startTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 110),
                Size = new System.Drawing.Size(260, 20)
            };

            endTimeLabel = new Label
            {
                Text = "Время окончания:",
                Location = new System.Drawing.Point(10, 140)
            };
            endTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 160),
                Size = new System.Drawing.Size(260, 20)
            };

            locationLabel = new Label
            {
                Text = "Место:",
                Location = new System.Drawing.Point(10, 190)
            };
            locationTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 210),
                Size = new System.Drawing.Size(260, 20)
            };

            descriptionLabel = new Label
            {
                Text = "Описание:",
                Location = new System.Drawing.Point(10, 240)
            };
            descriptionTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 260),
                Size = new System.Drawing.Size(260, 100),
                Multiline = true
            };

            editButton = new Button
            {
                Text = "Редактировать",
                Location = new System.Drawing.Point(10, 370),
                Size = new System.Drawing.Size(100, 25)
            };
            editButton.Click += (sender, e) =>
            {
                if (eventComboBox.SelectedIndex >= 0)
                {
                    var selectedEvent = events[eventComboBox.SelectedIndex];
                    selectedEvent.Name = nameTextBox.Text;
                    selectedEvent.StartTime = startTimePicker.Value;
                    selectedEvent.EndTime = endTimePicker.Value;
                    selectedEvent.Location = locationTextBox.Text;
                    selectedEvent.Description = descriptionTextBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            cancelButton = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(170, 370),
                Size = new System.Drawing.Size(100, 25)
            };
            cancelButton.Click += (sender, e) =>
            {
                this.Close();
            };

            this.Controls.Add(eventComboBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(nameTextBox);
            this.Controls.Add(startTimeLabel);
            this.Controls.Add(startTimePicker);
            this.Controls.Add(endTimeLabel);
            this.Controls.Add(endTimePicker);
            this.Controls.Add(locationLabel);
            this.Controls.Add(locationTextBox);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(descriptionTextBox);
            this.Controls.Add(editButton);
            this.Controls.Add(cancelButton);
        }
    }
}
