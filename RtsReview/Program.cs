﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

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

            Console.WriteLine("Thank you for checking out my code! Hope you enjoyed it. Press any key to end.");
            var ending = Console.ReadKey(false);
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

            Console.WriteLine("Please enter an array of integers in the following example format:  [1, 5, 9]");
            var userArrayInput = Console.ReadLine();
            var userArrayStringCount = userArrayInput.Length;
            if (userArrayStringCount == 0)
            {
                Console.WriteLine("hmm... it appears no parameter was entered. Please input a valid array for exercise one");
                var yesNoPromptResponse = YesNoPromptResponse("Do you want to retry this exercise?");
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }

            if (!userArrayInput[0].Equals('[') || !userArrayInput[userArrayStringCount - 1].Equals(']'))
            {
                Console.WriteLine("hmm... it appears your input did either did not start or finish with a bracket -- [  ] ");
                var yesNoPromptResponse = YesNoPromptResponse("Do you want to retry this exercise?");
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }

            var splitArray = userArrayInput
                .Substring(1, userArrayStringCount - 2)
                .Split(",")
                .ToList();

            var fullIntArray = new List<int>();

            foreach (var arrayInput in splitArray)
            {
                if (Int32.TryParse(arrayInput, out int parsedIntResult))
                {
                    fullIntArray.Add(parsedIntResult);
                }
                else
                {
                    Console.WriteLine($"hmm.. we weren't able to parse -- '{arrayInput}' -- into an integer");
                    var yesNoPromptResponse = YesNoPromptResponse("Do you want to continue without this in the list?");
                    if (!yesNoPromptResponse) Environment.Exit(-1);
                }
            }

            Console.WriteLine("Congratulations!!! You have entered a valid array!");
            Console.WriteLine("Please enter a valid integer to compare against.");

            var userInputComparableInt = Console.ReadLine();
            if (Int32.TryParse(userInputComparableInt, out int comparableParsedInt))
            {
                DoExerciseOneComparison(fullIntArray, comparableParsedInt);
            }
            else
            {
                Console.WriteLine($"hmm.. we weren't able to parse -- '{userInputComparableInt}' -- into an integer");
                var yesNoPromptResponse = YesNoPromptResponse("Do you want to retry this exercise?");
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }
        }

        private static void PerformExerciseTwo()
        {
            Console.WriteLine("You chose Exercise #2 --> Rotate the characters in a string by a given input and have the overflow appear at the beginning");
            // prompt user for a string 
            // validate they entered something 
            // prompt for int to cut word by 
            // get length of string
            // validate int they gave is in the correct limit (not greater than the lenght of the string) 
            // get first half of string substring(0, totalLength - int)  
            // get second half of string substring(int, totalLength) 
            //recombine 
        }

        private static void PerformExerciseThree()
        {
            Console.WriteLine("You chose Exercise #3 --> ");
        }

        private static bool YesNoPromptResponse(string yesNoQuestion)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{yesNoQuestion} [y/n] ");
                response = Console.ReadKey(false).Key;   
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return response == ConsoleKey.Y;
        }

        private static void DoExerciseOneComparison(IList<int> numberArray, int comparableInt)
        {
            var valuesOverComparisonPoint = numberArray.Where(x => x > comparableInt).ToList();
            var valuesUnderComparisonPoint = numberArray.Where(x => x < comparableInt).ToList();
            var valuesTheSameAsComparisonPoint = numberArray.Where(x => x == comparableInt).ToList();
            
            Console.WriteLine($"[{string.Join(", ", valuesOverComparisonPoint)}] -->  (total of {valuesOverComparisonPoint.Count}) are greater than {comparableInt}");
            Console.WriteLine($"[{string.Join(", ", valuesUnderComparisonPoint)}] -->  (total of {valuesUnderComparisonPoint.Count}) are less than {comparableInt}");
            Console.WriteLine($"[{string.Join(", ", valuesTheSameAsComparisonPoint)}] -->  (total of {valuesTheSameAsComparisonPoint.Count}) are the same as {comparableInt}");

        }
    }
}
