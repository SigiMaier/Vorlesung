using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Names
{
    class Sample3_AddMeaningfulContext
    {
        private void PrintGuessStatistics(char candidate, int count)
        {
            string number;
            string verb;
            string pluralModifier;

            if (count == 0)
            {
                number = "no";
                verb = "are";
                pluralModifier = "s";
            }
            else if (count == 1)
            {
                number = "1";
                verb = "is";
                pluralModifier = " ";
            }
            else
            {
                number = count.ToString();
                verb = "are";
                pluralModifier = "s";
            }

            string guessMessage = string.Format(
                "There {0} {1} {2} {3}", verb, number, candidate, pluralModifier);

            Console.WriteLine(guessMessage);
        }

        // The function name provides only öpart of the context, the algorithm provides the rest
        // When reading through the function, there are three variables: name, verb and pluralModifier that are part of
        // "guess statistics" message. Unfortunately, the context must be inferred

        // The function is a bit too long and the variables are used throughout.
        // To split the function into smaller pieces a class GuessStatisticsMessage needs to be created and the three variables
        // become fields of this class ==> clear context for the variables and the context improvements allows the algorithm to be 
        // much clearer

    }


    public class GuesStatitsicsMessage
    {
        private string number;
        private string verb;
        private string pluralModifier;

        public string Make(char candidate, int count)
        {
            this.CreatePluralDependentMessageParts(count);
            return string.Format("There {0} {1} {2}{3}", this.verb, this.number, candidate, this.pluralModifier);
        }

        private void CreatePluralDependentMessageParts(int count)
        {
            if (count == 0)
            {
                this.ThereAreNoLetters();
            }
            else if (count == 1)
            {
                this.ThereIsOneLetter();
            }
            else
            {
                this.ThereAreManyLetters(count);
            }
        }

        private void ThereAreNoLetters()
        {
            this.number = "no";
            this.verb = "are";
            this.pluralModifier = "s";
        }

        private void ThereIsOneLetter()
        {
            this.number = "1";
            this.verb = "is";
            this.pluralModifier = "";
        }

        private void ThereAreManyLetters(int count)
        {
            this.number = count.ToString();
            this.verb = "are";
            this.pluralModifier = "s";
        }
    }
}
