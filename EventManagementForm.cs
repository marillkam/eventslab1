// EventManagementForm.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eventslab1
{
    public partial class EventManagementForm : Form, IEventView
    {
        private readonly EventManager _eventManager;
        private readonly ListView listView;
        private readonly Button createEventButton;
        private readonly Button editEventButton;
        private readonly Button deleteEventButton;
        private readonly Button setReminderButton;
        private readonly Button removeReminderButton;
        //private readonly Button displayEventsButton;

        public EventManagementForm()
        {
            InitializeComponent();

            // Инициализация элементов управления
            listView = new ListView();
            createEventButton = new Button();
            editEventButton = new Button();
            deleteEventButton = new Button();
            setReminderButton = new Button();
            removeReminderButton = new Button();
            //displayEventsButton = new Button();

            _eventManager = new EventManager(this);
            SetupControls();
        }

        private void SetupControls()
        {
            // Настройка формы
            this.Text = "Управление встречами и мероприятиями";
            this.Size = new Size(450, 450);

            // Настройка ListView
            listView.Dock = DockStyle.Top;
            listView.Height = 300;
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.Columns.Add("Название", 150);
            listView.Columns.Add("Время", 200);
            listView.Columns.Add("Место", 100);

            // Настройка кнопок
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 40
            };
            var viewAllButton = new Button
            {
                Text = "Просмотреть все",
                Location = new Point(284, 320),
                Size = new Size(120, 25)
            };
            viewAllButton.Click += ViewAllButton_Click;

            // Добавляем кнопку на форму
            this.Controls.Add(viewAllButton);

            createEventButton.Text = "Создать";
            createEventButton.Click += CreateEventButton_Click;

            editEventButton.Text = "Редактир.";
            editEventButton.Click += EditEventButton_Click;

            deleteEventButton.Text = "Удалить";
            deleteEventButton.Click += DeleteEventButton_Click;

            setReminderButton.Text = "Напом.";
            setReminderButton.Click += SetReminderButton_Click;

            removeReminderButton.Text = "Снять напом.";
            removeReminderButton.Click += RemoveReminderButton_Click;

            //displayEventsButton.Text = "Обновить";
            //displayEventsButton.Click += DisplayEventsButton_Click;

            // Добавление элементов
            buttonPanel.Controls.AddRange(new Control[]
            {
                createEventButton,
                editEventButton,
                deleteEventButton,
                setReminderButton,
                removeReminderButton,
                //displayEventsButton
            });

            this.Controls.Add(listView);
            this.Controls.Add(buttonPanel);
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            // Создаем и показываем форму со всеми событиями
            var displayForm = new DisplayEventsForm(_eventManager.Events);
            displayForm.ShowDialog();
        }
        #region Реализация IEventView
        public void ClearEvents()
        {
            listView.Items.Clear();
        }

        public void AddEvent(string name, string time, string location)
        {
            listView.Items.Add(new ListViewItem(new[] { name, time, location }));
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Обработчики событий
        private void CreateEventButton_Click(object sender, EventArgs e)
        {
            var form = new CreateEventForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _eventManager.CreateEvent(
                    form.EventName,
                    form.StartTime,
                    form.EndTime,
                    form.EventLocation,
                    form.EventDescription
                );
            }
            form.Dispose();
        }

        private void EditEventButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                ShowMessage("Выберите событие для редактирования");
                return;
            }

            int selectedIndex = listView.SelectedIndices[0];
            var selectedEvent = _eventManager.Events[selectedIndex];

            var form = new EditEventForm(selectedEvent);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _eventManager.EditEvent(
                    selectedIndex,
                    form.EventName,
                    form.StartTime,
                    form.EndTime,
                    form.EventLocation,
                    form.EventDescription
                );
            }
            form.Dispose();
        }

        private void DeleteEventButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                ShowMessage("Выберите событие для удаления");
                return;
            }

            if (MessageBox.Show("Удалить выбранное событие?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _eventManager.DeleteEvent(listView.SelectedIndices[0]);
            }
        }

        private void SetReminderButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                ShowMessage("Выберите событие для установки напоминания");
                return;
            }
            _eventManager.SetReminder(listView.SelectedIndices[0]);
        }

        private void RemoveReminderButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                ShowMessage("Выберите событие для снятия напоминания");
                return;
            }
            _eventManager.RemoveReminder(listView.SelectedIndices[0]);
        }

        //private void DisplayEventsButton_Click(object sender, EventArgs e)
        //{
        //    _eventManager.LoadEvents();
        //}
        #endregion
    }
}