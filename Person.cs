using System;

namespace ThreadStartProject
{
    class Person
    {
        public event Action GoToSleep;
        public event EventHandler DoWork;
        public string Name { get; set; }
        public void TakeTime(DateTime now)
        {
            if (now.Hour <= 8)
            {
                GoToSleep?.Invoke("1");
            }
            else
            {
                DoWork?.Invoke(this, null);
            }
        
        }
    }

}