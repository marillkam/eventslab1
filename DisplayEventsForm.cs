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
    public partial class   DisplayEventsForm : Form
    {
        private List<Event> events;
        private TextBox eventsTextBox;

        public DisplayEventsForm(List<Event> events)
        {
            this.events = events;
            this.Text = "Все события";
            this.Size = new System.Drawing.Size(500, 400);
            InitializeControls();
        }

        private void InitializeControls()
        {
            eventsTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(480, 380),
                Multiline = true,
                ScrollBars = ScrollBars.Both
            };

            var allEvents = new StringBuilder();
            foreach (var e in events)
            {
                allEvents.AppendLine(e.ToString());
                allEvents.AppendLine(new string('-', 30));
            }
            eventsTextBox.Text = allEvents.ToString();

            this.Controls.Add(eventsTextBox);
        }
    }
}
