// IEventView.cs
namespace eventslab1
{
    public interface IEventView
    {
        void ClearEvents();
        void AddEvent(string name, string time, string location);
        void ShowMessage(string message);
    }
}