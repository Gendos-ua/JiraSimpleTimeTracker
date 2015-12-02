using System;

namespace JiraSimpleTimeTracker
{
    class JiraIssue
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public int secondsElapsed { get; set; } = 0;
    }
}
