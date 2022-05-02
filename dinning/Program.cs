using System;
using System.Threading;

namespace dinning
{
    class Program
    {

        static void Main(string[] args)
        {
            //tryk på en knap for at fortsætte programmet

            Fork fork = new Fork();
            new Philosopher(0, 10, 50, fork);
            new Philosopher(1, 20, 40, fork);
            new Philosopher(2, 30, 30, fork);
            new Philosopher(3, 40, 20, fork);
            new Philosopher(4, 50, 10, fork);
        }
    }
}
