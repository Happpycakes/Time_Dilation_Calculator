using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Time_Dialation_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int properYear = GetYear();
            int properAge = GetAge();
            int friendAge = GetFriendAge();
            double speed = Velocity();
            int dialatedTime = DialatedTime();
            Calculate(speed, dialatedTime, properYear, properAge, friendAge);
        }

        static int GetYear()
        {
            // Get year before travel to compare it to their age at end
            #region Display Text
            TypeOut("Hello and welcome to the program, ");

            Thread.Sleep(400);

            TypeOut("Please enter the year");

            Dots(100);
            #endregion         

            int properYear = Convert.ToInt32(Console.ReadLine());
            return properYear;
        }

        static int GetAge()
        {
            // Get their age to compare to friends age
            TypeOut("Please enter your current age: ");

            int properAge = Convert.ToInt32(Console.ReadLine());
            return properAge;
        }

        static int GetFriendAge()
        {
            // Get friends age to compare to their age
            TypeOut("Please enter your best friends age: ");

            int friendAge = Convert.ToInt32(Console.ReadLine());
            return friendAge;
        }

        static double Velocity()
        {
            //Determine speed of subject
            TypeOut("How fast are you going in miles per hour(mph) - Enter \"1\" for the speed of light or \"2\" for half of the speed of light:  ");
            int speedMPH = Convert.ToInt32(Console.ReadLine());

            //in case user picks option 1 or 2
            if (speedMPH == 1)
                speedMPH = 670616629;
            else if (speedMPH == 2)
                speedMPH = 670616629/2;

            // Convert speed from mph to m/s
            double speed = speedMPH * 0.44704;
                return speed;
        }

        static int DialatedTime()
        {
            // Determine stationary time (poor variable names)
            TypeOut("How many years have you been in flight? ");
            int dialatedTime = Convert.ToInt32(Console.ReadLine());
            return dialatedTime;
        }

        static void Calculate(double speed, int dialatedTime, int properYear, int properAge, int friendAge)
        {
            // Light speed MPH = 670,616,62
            int lightSpeed = 299792458;
            TypeOut("Calculating");
            Dots(500);

            // vOc == velocity/lightspeed
            double vOc = (Math.Pow(speed,2) / Math.Pow(lightSpeed, 2));
            // dialated time is time observed by stationary observers
            double stationaryTime = dialatedTime * Math.Sqrt(1 - vOc);

            // Neatly written out so the user can understand
            Console.WriteLine("Only {0} years would have passed for you", Math.Round(stationaryTime, 6));
            Console.Write("Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("Once you stopped it would be the year {0}!" , (properYear + dialatedTime));
            Console.Write("Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("You would be {0} years old and your best friend would be {1} years old!", (properAge + Math.Round(stationaryTime, 1)), (friendAge + dialatedTime));
            Console.Write("Press enter to continue");
            Console.ReadLine();

            TypeOut("Thank you for coming to my Ted Talk.");
            TypeOut("Press enter to exit :)");
            Console.ReadLine();
            
        }

        static void Dots(int milliseconds)
        {
            for (int i = 0; i <= 2; i++)
            {
                Thread.Sleep(milliseconds);
                Console.Write('.');
            }
            Console.Write(' ');
        }

        static void TypeOut(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
        }
    }

}



