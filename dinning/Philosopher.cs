using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace dinning
{
    class Philosopher
    {
        int number;
        int thinkDelay;
        int eatDelay;
        int leftFork, rightFork;
        Fork fork;

        public Philosopher(int number, int thinkDelay, int eatDelay, Fork fork)
        {
            this.number = number;
            this.thinkDelay = thinkDelay;
            this.eatDelay = eatDelay;
            this.fork = fork;

            leftFork = number == 0 ? 4 : number - 1;
            rightFork = (number + 1) % 5;

            new Thread(new ThreadStart(Run)).Start();
        }

        public void Run()
        {
            for (; ; )
            {
                try
                {
                    Thread.Sleep(thinkDelay);
                    fork.Get(leftFork, rightFork);
                    Console.WriteLine("Philosopher " + number + " is eating...");
                    Console.ReadLine();
                    Thread.Sleep(eatDelay);
                    fork.Put(leftFork, rightFork);
                }
                catch
                {
                    return;
                }
            }
        }

    }
}
