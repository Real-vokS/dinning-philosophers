using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace dinning
{
    class Fork
    {
        bool[] fork = new bool[5];

        public void Get(int leftFork, int rightFork)
        {
            lock (this)
            {
                while (fork[leftFork] || fork[rightFork]) Monitor.Wait(this);
                fork[leftFork] = true;
                fork[rightFork] = true;
            }
        }

        public void Put(int leftFork, int rightFork)
        {
            lock (this)
            {
                fork[leftFork] = false;
                fork[rightFork] = false;
                Monitor.PulseAll(this);
            }
        }

    }
}
