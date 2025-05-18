using System;
using System.Collections.Generic;

namespace eventslab1
{
    public class EventManager
    {
        private readonly IEventView _view;
        public List<Event> Events { get; } = new List<Event>();

        public EventManager(IEventView view)
        {
            _view = view;
        }

        public void CreateEvent(string name, DateTime startTime, DateTime endTime, string location, string description)
        {
            try
            {
                var newEvent = new Event(name, startTime, endTime, location, description);
                Events.Add(newEvent);
                UpdateView();
                _view.ShowMessage("Событие успешно создано");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Ошибка: {ex.Message}");
            }
        }

        public void EditEvent(int index, string name, DateTime startTime, DateTime endTime, string location, string description)
        {
            if (index < 0 || index >= Events.Count)
            {
                _view.ShowMessage("Неверный индекс события");
                return;
            }

            try
            {
                Events[index] = new Event(name, startTime, endTime, location, description);
                UpdateView();
                _view.ShowMessage("Событие успешно изменено");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Ошибка: {ex.Message}");
            }
        }

        public void DeleteEvent(int index)
        {
            if (index < 0 || index >= Events.Count)
            {
                _view.ShowMessage("Неверный индекс события");
                return;
            }

            Events.RemoveAt(index);
            UpdateView();
            _view.ShowMessage("Событие успешно удалено");
        }

        public void SetReminder(int index)
        {
            if (index < 0 || index >= Events.Count)
            {
                _view.ShowMessage("Неверный индекс события");
                return;
            }

            Events[index].SetReminder();
            UpdateView();
            _view.ShowMessage("Напоминание установлено");
        }

        public void RemoveReminder(int index)
        {
            if (index < 0 || index >= Events.Count)
            {
                _view.ShowMessage("Неверный индекс события");
                return;
            }

            Events[index].RemoveReminder();
            UpdateView();
            _view.ShowMessage("Напоминание удалено");
        }

        public void LoadEvents()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _view.ClearEvents();
            foreach (var e in Events)
            {
                _view.AddEvent(
                    e.Name,
                    $"{e.StartTime:dd.MM.yyyy HH:mm} - {e.EndTime:dd.MM.yyyy HH:mm}",
                    e.Location
                );
            }
        }
    }
}