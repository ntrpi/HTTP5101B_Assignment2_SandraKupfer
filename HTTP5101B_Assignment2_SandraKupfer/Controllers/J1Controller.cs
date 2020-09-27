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
        /*
        Here are the 3 burger choices:
        1 - Cheeseburger (461 Calories)
        2 - Fish Burger (431 Calories)
        3 - Veggie Burger (420 Calories)
        4 - no burger
        Here are the three drink choices:
        1 - Soft Drink (130 Calories)
        2 - Orange Juice (160 Calories)
        3 - Milk (118 Calories)
        4 - no drink
        Here are the 3 side order choices:
        1 - Fries (100 Calories)
        2 - Baked Potato (57 Calories)
        3 - Chef Salad (70 Calories)
        4 - no side order
        Here are the three dessert choices:
        1 - Apple Pie (167 Calories)
        2 - Sundae (266 Calories)
        3 - Fruit Cup (75 Calories)
        4 - No Dessert
        */
        static readonly int[] burgerCalories = { 461, 431, 420, 0 };
        static readonly int[] drinkCalories = { 130, 160, 118, 0 };
        static readonly int[] sideCalories = { 100, 57, 70, 0 };
        static readonly int[] dessertCalories = { 167, 266, 75, 0 };

        static readonly string outputStringPrefix = "Your total calorie count is ";
        static readonly string errorString = "Invalid input. Your calorie count could not be calculated.";

        /// <summary>
        /// Returns the total calories for the meal.
        /// </summary>
        /// <param name="burger">Integer value between 1 and 4.</param>
        /// <param name="drink">Integer value between 1 and 4.</param>
        /// <param name="side">Integer value between 1 and 4.</param>
        /// <param name="dessert">Integer value between 1 and 4.</param>
        /// <returns>A string with the total calorie count.</returns>
        [Route("api/Ji/Menu/burger/drink/side/dessert")]
        public string Get(int burger, int drink, int side, int dessert)
        {
            if (burger < 1 || burger > 4
                || drink < 1 || drink > 4
                || side < 1 || side > 4
                || dessert < 1 || side > 4) {

                return errorString;
            }

            int calories = burgerCalories[burger-1]
                + drinkCalories[drink-1]
                + sideCalories[side-1]
                + dessertCalories[dessert-1]; 

            return outputStringPrefix + calories.ToString();
        }
    }
}
