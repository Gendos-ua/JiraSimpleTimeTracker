using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraSimpleTimeTracker
{
    class Timer
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private List<EventHandler> externalTickHandlers = new List<EventHandler>();
        public int secondsPassed { get; set; } = 0;
        public bool isRunning { get; set; } = false;

        public Timer()
        {
            timer.Tick += tick;
            timer.Interval = 1000;
        }
        

        public Timer setTickHandler(EventHandler e)
        {
            externalTickHandlers.Add(e);

            return this;
        }

        public Timer start()
        {
            if (!isRunning)
            {
                timer.Start();
                isRunning = true;
            }

            return this;
        }

        public Timer pause()
        {
            if (isRunning)
                timer.Stop();

            isRunning = false;

            return this;
        }

        public Timer stop()
        {
            if (isRunning)
            {
                timer.Stop();
                isRunning = false;
            }
            secondsPassed = 0;

            return this;
        }

        public void tick(object o, EventArgs sender)
        {
            secondsPassed++;
            Console.WriteLine(secondsPassed.ToString());
            foreach (EventHandler e in externalTickHandlers)
                e.Invoke(o, sender);
        }
    }
}
