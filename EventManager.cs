using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventslab1
{
    public class EventManager
    {
        private List<Event> events = new List<Event>();
        private ListView listView;

        public EventManager(ListView listView)
        {
            this.listView = listView;
            LoadEvents();
        }

        private void LoadEvents()
        {
            listView.Items.Clear();
            foreach (var e in events)
            {
                listView.Items.Add(new ListViewItem(new[] { e.Name,
e.StartTime.ToString("dd.MM.yyyy HH:mm"), e.Location }));
            }
        }

        public void CreateEvent()
        {
            var createEventForm = new CreateEventForm();
            createEventForm.ShowDialog();
            if (createEventForm.DialogResult == DialogResult.OK)
            {
                var newEvent = new Event(
                    createEventForm.Name,
                    createEventForm.StartTime,
                    createEventForm.EndTime,
                    createEventForm.Location,
                    createEventForm.Description);
                events.Add(newEvent);
                LoadEvents();
                MessageBox.Show("Событие создано.");
            }
        }

        public void EditEvent()
        {
            if (events.Count == 0)
            {
                MessageBox.Show("Список событий пуст.");
                return;
            }

            var editEventForm = new EditEventForm(events);
            editEventForm.ShowDialog();
            if (editEventForm.DialogResult == DialogResult.OK)
            {
                LoadEvents();
            }
        }

        public void DeleteEvent()
        {
            if (events.Count == 0)
            {
                MessageBox.Show("Список событий пуст.");
                return;
            }

            var deleteEventForm = new DeleteEventForm(events);
            deleteEventForm.ShowDialog();
            if (deleteEventForm.DialogResult == DialogResult.OK)
            {
                LoadEvents();
            }
        }

        public void SetEventReminder()
        {
            if (events.Count == 0)
            {
                MessageBox.Show("Список событий пуст.");
                return;
            }

            var setReminderForm = new SetReminderForm(events);
            setReminderForm.ShowDialog();
            if (setReminderForm.DialogResult == DialogResult.OK)
            {
                LoadEvents();
            }
        }

        public void RemoveEventReminder()
        {
            if (events.Count == 0)
            {
                MessageBox.Show("Список событий пуст.");
                return;
            }

            var removeReminderForm = new RemoveReminderForm(events);
            removeReminderForm.ShowDialog();
            if (removeReminderForm.DialogResult == DialogResult.OK)
            {
                LoadEvents();
            }
        }

        public void DisplayEvents()
        {
            var displayEventsForm = new DisplayEventsForm(events);
            displayEventsForm.ShowDialog();
        }
    }
}
