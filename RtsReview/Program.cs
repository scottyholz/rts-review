using System;
using System.Collections.Generic;
using System.Linq;

namespace RtsReview
{
    class Program
    {
        private static readonly List<string> ValidCodeExerciseOptions = new List<string>{"1", "2", "3"};

        static void Main(string[] args)
        {
            Console.WriteLine("Hello RTS Code Reviewers!");
            Console.WriteLine("Which of the three Code Exercises would you like to do?  Please enter the exercise number.");

            var exerciseOption = Console.ReadLine();

            if (ValidCodeExerciseOptions.All(x => !x.Equals(exerciseOption)))
            {
                ParameterValidationMessage(ValidCodeExerciseOptions, exerciseOption); 
            }

            switch (exerciseOption)
            {
                case "1": PerformExerciseOne();
                    break;
                case "2": PerformExerciseTwo();
                    break;
                case "3": PerformExerciseThree();
                    break;
                default:
                    ParameterValidationMessage(ValidCodeExerciseOptions, exerciseOption);
                    break;
            }

            Console.WriteLine("Thank you for checking out my code! Hope you enjoyed it");
        }

        private static void ParameterValidationMessage(IList<string> validParameters, string enteredValue)
        {
            Console.WriteLine($"hmm... it appears that the parameter you entered -- {enteredValue} -- is not a valid option.");
            Console.WriteLine($"Valid options for this stage are: ");
            foreach (var validParameter in validParameters)
            {
                Console.WriteLine(validParameter);
            }
        }

        private static void PerformExerciseOne()
        {

        }

        private static void PerformExerciseTwo()
        {

        }

        private static void PerformExerciseThree()
        {

        }
    }
}
