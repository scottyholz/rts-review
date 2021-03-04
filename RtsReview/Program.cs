using System;
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
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }

            if (!userArrayInput[0].Equals('[') || !userArrayInput[userArrayStringCount - 1].Equals(']'))
            {
                Console.WriteLine("hmm... it appears your input did either did not start or finish with a bracket -- [  ] ");
                var yesNoPromptResponse = YesNoPromptResponse();
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
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseOne();
                else Environment.Exit(-1);
            }
        }

        private static void PerformExerciseTwo()
        {
            Console.WriteLine("You chose Exercise #2 --> Rotate the characters in a string by a given input and have the overflow appear at the beginning. \n");

            Console.WriteLine("Please enter the string value you would like rotated. \n ");
            var stringToRotate = Console.ReadLine();
            if (String.IsNullOrEmpty(stringToRotate))
            {
                Console.WriteLine($"hmm.. there doesn't appear to be an entered string -- '{stringToRotate}' -- is the recorded value.");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseTwo();
                else Environment.Exit(-1);
            }

            Console.WriteLine("\nPlease enter the number you would like to rotate this by (must be a valid integer)");

            var rotateNumberString = Console.ReadLine();


            if (Int32.TryParse(rotateNumberString, out int rotateNumber))
            {
                if (rotateNumber > stringToRotate.Length)
                {
                    Console.WriteLine($"hmm.. the number you entered -- '{rotateNumberString}' -- is longer than the amount of characters in the string.");
                    Console.WriteLine($"The max number that can be entered is {rotateNumberString.Length}");
                    var yesNoPromptResponse = YesNoPromptResponse();
                    if (yesNoPromptResponse) PerformExerciseTwo();
                    else Environment.Exit(-1);
                } else if (rotateNumber == stringToRotate.Length)
                {
                    Console.WriteLine($"The rotated string is '{stringToRotate}'");
                }
                else
                {
                    var endOfStringToRotate = stringToRotate.Substring(stringToRotate.Length - rotateNumber); 
                    var beginningOfStringToRotate = stringToRotate.Substring(0, stringToRotate.Length - rotateNumber);
                    Console.WriteLine($"The rotated string is '{endOfStringToRotate}{beginningOfStringToRotate}");
                }

            }
            else
            {
                Console.WriteLine($"hmm.. we weren't able to parse -- '{rotateNumberString}' -- into an integer");
                var yesNoPromptResponse = YesNoPromptResponse();
                if (yesNoPromptResponse) PerformExerciseTwo();
                else Environment.Exit(-1);
            }
        }

        private static void PerformExerciseThree()
        {
            Console.WriteLine("You chose Exercise #3 --> If you could change 1 thing about your favorite framework/language/platform (pick one), what would it be?");

            Console.WriteLine(
                "I think this is a hard question... to choose one... one simple thing is switch statements (I even ran into this TODAY when doing these exercises");
            Console.WriteLine("Switch statements can be frustrating because they are limited in their comparison.  I'd like a feature similar to elixir's cond do, where conditions themselves are tested");
            Console.WriteLine("for truthyness, in the order they are presented.  I guess I see how it could introduce latent bugs, but think the looseness would work if used correctly.");


            Console.WriteLine("\n");
            Console.WriteLine("I think I have a somewhat unique perspective on C# / .Net because of the order I learned my programming languages. The first programming language I used / worked in a production level environment");
            Console.WriteLine("was functional.  Transitioning from Functional -> OOP  rather than OOP -> functional is, from what I've gathered, somewhat unique.  I the idea of pure functions ");
            Console.WriteLine(" - of referentially transparent code - to be super cool / useful / easy to follow.  you always know the 'state' of the data because you know what is returned");


            Console.WriteLine("To wrap up this thought process... it would be nice to have a combination of these things.  Using C# as a strictly typed language, I could easily set /validate what each function was doing");
            Console.WriteLine("which is an issue I now have going back to functional programming");
        }

        private static bool YesNoPromptResponse(string yesNoQuestion = "Do you want to retry this exercise?")
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
