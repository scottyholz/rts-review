﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RtsReview
{
    class Program
    {
        private static readonly List<string> ValidCodeExerciseOptions = new List<string>{"1", "2", "3"};

        static void Main(string[] args)
        {
            Console.WriteLine("Hello RTS Code Reviewers!\n");
            var runApplication = true;

            do
            {
                RunExercisePrompts();
                 runApplication = YesNoPromptResponse("Do you want to run another exercise?");

            } while (runApplication); 

            Console.WriteLine("Thank you for checking out my code! Hope you enjoyed it. Press any key to end.");
            Console.ResetColor();
            var ending = Console.ReadKey(false);
        }

        private static void RunExercisePrompts()
        {
            Console.WriteLine("\nWhich of the three Code Exercises would you like to do?  Please enter the exercise number.");

            var exerciseOption = Console.ReadLine();

            if (ValidCodeExerciseOptions.All(x => !x.Equals(exerciseOption)))
            {
                ParameterValidationMessage(ValidCodeExerciseOptions, exerciseOption);
            }

            switch (exerciseOption)
            {
                case "1":
                    PerformExerciseOne();
                    break;
                case "2":
                    PerformExerciseTwo();
                    break;
                case "3":
                    PerformExerciseThree();
                    break;
                default:
                    ParameterValidationMessage(ValidCodeExerciseOptions, exerciseOption);
                    break;
            }
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
            var userArrayInput = Console.ReadLine()?.Trim() ?? "";
            var userArrayStringCount = userArrayInput.Length;
            if (userArrayStringCount == 0)
            {
                Console.WriteLine("hmm... it appears no parameter was entered. Please input a valid array for exercise one");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }

            if (!userArrayInput[0].Equals('[') || !userArrayInput[userArrayStringCount - 1].Equals(']'))
            {
                Console.WriteLine("hmm... it appears your input did either did not start or finish with a bracket -- [  ] ");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse)
                {
                    PerformExerciseOne();
                    return;
                }
                Environment.Exit(-1);
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
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse)
                {
                    PerformExerciseOne();
                    return;
                }
                Environment.Exit(-1);
            }
        }

        private static void PerformExerciseTwo()
        {
            Console.WriteLine("You chose Exercise #2 --> Rotate the characters in a string by a given input and have the overflow appear at the beginning. \n");

            Console.WriteLine("Please enter the string value you would like rotated.\n");
            var stringToRotate = Console.ReadLine()?.Trim() ?? "";
            if (String.IsNullOrEmpty(stringToRotate))
            {
                Console.WriteLine($"hmm.. there doesn't appear to be an entered string -- '{stringToRotate}' -- is the recorded value.\n");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseTwo();
                else Environment.Exit(-1);
            }

            Console.WriteLine("\nPlease enter the number you would like to rotate this by (must be a valid integer)");

            var rotateNumberString = Console.ReadLine()?.Trim() ?? "";


            if (Int32.TryParse(rotateNumberString, out int rotateNumber))
            {
                if (rotateNumber < 0)
                {
                    Console.WriteLine($"hmm.. the number you entered -- '{rotateNumberString}' -- is appears to be less than 0.\n");
                    Console.WriteLine($"This number must be greater than or equal to 0.");

                    var yesNoPromptResponse = YesNoPromptResponse("Do you want to make this number positive and continue?");
                    var positiveRotateNumber = rotateNumber * -1;
                    if (yesNoPromptResponse) RotateStringAndPrint(stringToRotate, positiveRotateNumber);
                    else Environment.Exit(-1);
                    return;
                }
                if (rotateNumber > stringToRotate.Length)
                {
                    Console.WriteLine($"hmm.. the number you entered -- '{rotateNumberString}' -- is longer than the amount of characters in the string.\n");
                    Console.WriteLine($"The max number that can be entered is {stringToRotate.Length}");
                    var yesNoPromptResponse = YesNoPromptResponse();
                    if (yesNoPromptResponse) PerformExerciseTwo();
                    else Environment.Exit(-1);
                } 

                RotateStringAndPrint(stringToRotate, rotateNumber);

            }
            else
            {
                Console.WriteLine($"hmm.. we weren't able to parse -- '{rotateNumberString}' -- into an integer\n");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseTwo();
                else Environment.Exit(-1);
            }
        }

        private static void PerformExerciseThree()
        {

            Console.WriteLine("You chose Exercise #3 --> If you could change 1 thing about your favorite framework/language/platform (pick one), what would it be?\n\n");


            Console.WriteLine("If I could change one thing about about C#/.Net, it would be the ease of writing referentially transparent code.\n");
            Console.WriteLine("When I say 'Referentially Transparent', I am referring to the use of pure functions and immutable objects.  While this is possible in C#/.Net, it isn't necessarily intuitive, and can be confusing.\n");
            Console.WriteLine("This may, in part, be due to OOP framework in general, but after working in Functional Programming languages I have a deep appreciation for the simplistic set up and intrinsic readability.\n\n");

        }

        private static bool YesNoPromptResponse(string yesNoQuestion = "Do you want to retry this exercise?")
        {
            ConsoleKey response;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{yesNoQuestion} [y/n] ");
                response = Console.ReadKey(false).Key;   
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            Console.ResetColor();
            return response == ConsoleKey.Y;
        }

        private static void DoExerciseOneComparison(IList<int> numberArray, int comparableInt)
        {
            var valuesOverComparisonPoint = numberArray.Where(x => x > comparableInt).ToList();
            var valuesUnderComparisonPoint = numberArray.Where(x => x < comparableInt).ToList();
            var valuesTheSameAsComparisonPoint = numberArray.Where(x => x == comparableInt).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{string.Join(", ", valuesOverComparisonPoint)}] -->  (total of {valuesOverComparisonPoint.Count}) are greater than {comparableInt}");
            Console.WriteLine($"[{string.Join(", ", valuesUnderComparisonPoint)}] -->  (total of {valuesUnderComparisonPoint.Count}) are less than {comparableInt}");
            Console.WriteLine($"[{string.Join(", ", valuesTheSameAsComparisonPoint)}] -->  (total of {valuesTheSameAsComparisonPoint.Count}) are the same as {comparableInt}\n\n");
            Console.ResetColor();
        }

        private static void RotateStringAndPrint(string stringToRotate, int rotateNumber)
        {
            var endOfStringToRotate = stringToRotate.Substring(stringToRotate.Length - rotateNumber);
            var beginningOfStringToRotate = stringToRotate.Substring(0, stringToRotate.Length - rotateNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nThe rotated string is '{endOfStringToRotate}{beginningOfStringToRotate}'\n\n");
            Console.ResetColor();
        }

    }
}
