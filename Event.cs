using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventslab1
{
    public class Event
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool ReminderSet { get; set; }

        public Event(string name, DateTime startTime, DateTime endTime, string location,
string description)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            Description = description;
            ReminderSet = false;
        }

        public void SetReminder()
        {
            ReminderSet = true;
            MessageBox.Show("Напоминание установлено.");
        }

        public void RemoveReminder()
        {
            ReminderSet = false;
            MessageBox.Show("Напоминание снято.");
        }

        public override string ToString()
        {
            return $"Событие: {Name}\nВремя: {StartTime.ToString("dd.MM.yyyy HH:mm")} - { EndTime.ToString("dd.MM.yyyy HH:mm")}\nМесто: { Location}\nОписание:{ Description}\nНапоминание: { (ReminderSet ? "Да" : "Нет")}            "; 
        }
    }
}
