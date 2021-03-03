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
            Console.WriteLine("You chose Exercise #1 --> Print the number of integers in an array that are above the given input and the number that are below");
            //prompt user for array
            //validate array is in correct format 
                // must start and end with [ ] 
                // must only contain integers (no strings, decimals, etc.) 
                // must be comma separated [1, 3, 5]  vs [1 3 5] vs [1-3-5]
            // edge cases 
                // only int, no commas to separate on.  ex [1] 
                // commas in weird places.  ex [,1,,4,]
                    // -> may do something cool with this where it trys to parse, offers option to accept, otherwise cancels? 

            // if array is valid, prompt for int 
            // validate int is valid

            // if valid, then loop over array and create 2 new lists 
            // get count of each list, display to user. 
            // exit 

        }

        private static void PerformExerciseTwo()
        {
            Console.WriteLine("You chose Exercise #2 --> ");
        }

        private static void PerformExerciseThree()
        {
            Console.WriteLine("You chose Exercise #3 --> ");
        }
    }
}
