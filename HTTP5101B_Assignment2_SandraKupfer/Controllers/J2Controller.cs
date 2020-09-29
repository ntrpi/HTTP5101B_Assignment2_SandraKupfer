using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101B_Assignment2_SandraKupfer.Controllers
{
    public class J2Controller : ApiController
    {
        private class OutputStringCreator
        {
            private static readonly string outputPrefix = "There are ";
            private static readonly string outputSuffix = " total ways to get the sum 10.";
            private static readonly string outputSingular = "There is 1 total way to get the sum 10.";
            private static readonly string errorString = "Invalid input.";

            public static string getOutputString( int numWays )
            {
                if( numWays == -1 ) {
                    return errorString;
                } else if (numWays == 1) {
                    return outputSingular;
                } else {
                    return outputPrefix + numWays.ToString() + outputSuffix;
                }
            }
        }

        /// <summary>
        /// Calculate and return the number of ways 10 can be rolled given the number of sides for each die.
        /// </summary>
        /// <param name="m">Number of sides of first die.</param>
        /// <param name="n">Number of sides of second die.</param>
        /// <returns>If the input is valid, the number of ways 10 can be rolled, otherwise an error message.</returns>
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string Get( int m, int n )
        {
            int numWays = 0;
            int sumSides = m + n;
            if(sumSides < 10) {
                if (sumSides >= 2)                 {
                    numWays = 0;
                } else {
                    numWays = -1;
                }
            } else if( m < 5 || n < 5 ) {
                numWays = Math.Min(m, n);
            } else {
                numWays = Math.Min(m + n - 9, 17);
            }
            return OutputStringCreator.getOutputString(numWays);
        }
    }
}
