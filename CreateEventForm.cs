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
    public partial class CreateEventForm : Form
    {
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
        private Button createButton;
        private Button cancelButton;

        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }

        public CreateEventForm()
        {
            this.Text = "Создать событие";
            this.Size = new System.Drawing.Size(300, 400);
            InitializeControls();
        }

        private void InitializeControls()
        {
            nameLabel = new Label
            {
                Text = "Название:",
                Location = new System.Drawing.Point(10, 10)
            };
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 30),
                Size = new System.Drawing.Size(260, 20)
            };

            startTimeLabel = new Label
            {
                Text = "Время начала:",
                Location = new System.Drawing.Point(10, 60)
            };
            startTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 80),
                Size = new System.Drawing.Size(260, 20)
            };

            endTimeLabel = new Label
            {
                Text = "Время окончания:",
                Location = new System.Drawing.Point(10, 110)
            };
            endTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 130),
                Size = new System.Drawing.Size(260, 20)
            };

            locationLabel = new Label
            {
                Text = "Место:",
                Location = new System.Drawing.Point(10, 160)
            };
            locationTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 180),
                Size = new System.Drawing.Size(260, 20)
            };

            descriptionLabel = new Label
            {
                Text = "Описание:",
                Location = new System.Drawing.Point(10, 210)
            };
            descriptionTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 230),
                Size = new System.Drawing.Size(260, 100),
                Multiline = true
            };

            createButton = new Button
            {
                Text = "Создать",
                Location = new System.Drawing.Point(10, 340),
                Size = new System.Drawing.Size(100, 25)
            };
            createButton.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите название события.");
                    return;
                }

                Name = nameTextBox.Text;
                StartTime = startTimePicker.Value;
                EndTime = endTimePicker.Value;
                Location = locationTextBox.Text;
                Description = descriptionTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            cancelButton = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(170, 340),
                Size = new System.Drawing.Size(100, 25)
            };
            cancelButton.Click += (sender, e) =>
            {
                this.Close();
            };

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
            this.Controls.Add(createButton);
            this.Controls.Add(cancelButton);
        }
    }
}
