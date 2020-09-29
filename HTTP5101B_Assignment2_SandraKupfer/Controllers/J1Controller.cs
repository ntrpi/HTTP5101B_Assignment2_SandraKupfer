using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101B_Assignment2_SandraKupfer.Controllers
{
    public class J1Controller : ApiController
    {
        private class CalorieCalculator
        {
            private static readonly int[] burgerCalories = { 461, 431, 420, 0 };
            private static readonly int[] drinkCalories = { 130, 160, 118, 0 };
            private static readonly int[] sideCalories = { 100, 57, 70, 0 };
            private static readonly int[] dessertCalories = { 167, 266, 75, 0 };
            /// <summary>
            /// Given the integers representing the meal, calculate the total calories.
            /// </summary>
            /// <param name="burger">Integer value between 1 and 4.</param>
            /// <param name="drink">Integer value between 1 and 4.</param>
            /// <param name="side">Integer value between 1 and 4.</param>
            /// <param name="dessert">Integer value between 1 and 4.</param>
            /// <returns>If input is valid, the total calories are returned. Otherwise it returns -1.</returns>
            public static int getCalories(int burger, int drink, int side, int dessert)
            {
                if (burger >= 1 || burger <= 4
                    || drink >= 1 || drink <= 4
                    || side >= 1 || side <= 4
                    || dessert >= 1 || side <= 4)
                {
                    return burgerCalories[burger - 1]
                    + drinkCalories[drink - 1]
                    + sideCalories[side - 1]
                    + dessertCalories[dessert - 1];
                } else
                {
                    return -1;
                }
            }
        }

        private class OutputStringCreator
        {
            private static readonly string outputStringPrefix = "Your total calorie count is ";
            private static readonly string errorString = "Invalid input. Your calorie count could not be calculated.";

            public static string getOutputString( int calories )
            {
                if( calories == -1 )
                {
                    return errorString;
                } else
                {
                    return outputStringPrefix + calories.ToString();
                }
            }
        }

        /// <summary>
        /// Calculate the total calories and return the total in a message.
        /// </summary>
        /// <param name="burger">Integer value between 1 and 4.</param>
        /// <param name="drink">Integer value between 1 and 4.</param>
        /// <param name="side">Integer value between 1 and 4.</param>
        /// <param name="dessert">Integer value between 1 and 4.</param>
        /// <returns>If the input is valid, a string with the total calories. Otherwise, an error message.</returns>
        [Route("api/Ji/Menu/burger/drink/side/dessert")]
        public string Get(int burger, int drink, int side, int dessert)
        {
            return OutputStringCreator.getOutputString(CalorieCalculator.getCalories(burger, drink, side, dessert));
        }
    }
}
