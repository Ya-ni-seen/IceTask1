using System;
using System.Threading;

namespace Markspace
{
    public class Program
    {

        // Declare and initialize variables
        static int numOfScripts = 0;
        static int numOfQuestions = 0;
        static int subtotal = 0;
        static int numOfLecturers = 0;
        static int scriptsPerLecturer = 0;

        static void Main(string[] args)
        {
            // Prompt the user to enter the number of scripts until a valid input is entered
            bool validScript = false;
            string scriptPrompt = "Please enter the number of scripts";
            do
            {
                Console.WriteLine(scriptPrompt);
                numOfScripts = Convert.ToInt32(Console.ReadLine());

                if (numOfScripts <= 0)
                {
                    Console.WriteLine("Number given is invalid!");
                    scriptPrompt = "Please enter the number of scripts (must be greater than 0)";
                }
                else
                {
                    validScript = true;
                }
            } while (validScript == false);

            // Prompt the user to enter the number of questions until a valid input is entered
            bool validQuestions = false;
            string questionPrompt = "Please enter the number of questions in the test";
            do
            {
                Console.WriteLine(questionPrompt);
                numOfQuestions = Convert.ToInt32(Console.ReadLine());

                if (numOfQuestions <= 0 || numOfQuestions >= 10)
                {
                    Console.WriteLine("Number given is invalid!");
                    questionPrompt = "Please enter a number greater than 0";
                }
                else
                {
                    validQuestions = true;
                }
            } while (validQuestions == false);

            // Declare and initialize an array to store the subtotals for each question
            int[] subtotalArray = new int[numOfQuestions];

            // Prompt the user to enter the subtotals for each question
            for (int count = 0; count < numOfQuestions; count++)
            {
                Console.Write($"Enter the subtotal for question {count + 1}: ");
                subtotalArray[count] = Convert.ToInt32(Console.ReadLine());
            }


            Console.WriteLine("Enter the number of lecturers who will be marking: ");
            numOfLecturers = Convert.ToInt32(Console.ReadLine()); // read number of lecturers from user input

            int numScriptsPerLecturer = numOfScripts / numOfLecturers; // calculate number of scripts per lecturer
            int remainingScripts = numOfScripts % numOfLecturers; // calculate remaining scripts
            int[] scriptsPerLecturerArray = new int[numOfLecturers]; // array to hold number of scripts per lecturer

            // distribute scripts evenly among lecturers
            for (int i = 0; i < numOfLecturers; i++)
            {
                scriptsPerLecturerArray[i] = numScriptsPerLecturer;
            }

            // give remaining scripts to the last lecturer
            scriptsPerLecturerArray[numOfLecturers - 1] += remainingScripts;

            // display number of scripts each lecturer is going to mark
            for (int i = 0; i < numOfLecturers; i++)
            {
                Console.WriteLine($"Lecturer {i + 1} will mark {scriptsPerLecturerArray[i]} scripts.");
            }

            double timePerScript = 2.0; // time in seconds to mark each script
            double totalTimeInSeconds = numOfScripts * timePerScript; // total time in seconds
            double totalTimeInMinutes = totalTimeInSeconds / 60.0; // total time in minutes
            int hours = (int)totalTimeInMinutes / 60; // whole number of hours
            int minutes = (int)totalTimeInMinutes % 60; // remaining minutes
            double seconds = totalTimeInSeconds % 60.0; // remaining seconds

            // If remaining seconds are more than 30 but less than 60, increment the total minutes by 1
            if (seconds >= 30.0 && seconds < 60.0)
            {
                minutes++;
            }

            Console.WriteLine($"Estimated time to mark {numOfScripts} scripts: {hours} hours, {minutes} minutes.");

        }
    }
}