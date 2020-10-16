using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101B_Assignment2_SandraKupfer.Controllers
{
    public class J2Controller: ApiController
    {
        private class OutputStringCreator
        {
            // These static strings ensure that the minimum amount of garbage is being 
            // generated every time an output string is constructed.
            private static readonly string outputPrefix = "There are ";
            private static readonly string outputSuffix = " total ways to get the sum ";
            private static readonly string outputSingular = "There is 1 total way to get the sum ";
            private static readonly string outputPeriod = ".";
            private static readonly string errorString = "Invalid input.";

            /// <summary>
            /// Construct and/or return an output string with the correct grammar to
            /// describe how many ways there are to get the given sum.
            /// </summary>
            /// <param name="numWays">A positive integer indicating the number of ways, or -1, indicating invalid input.</param>
            /// <param name="target">A positive integer indicating the sum.</param>
            /// <returns>If the input is valid, a string describing the number of ways to get the sum. Otherwise, an error string.</returns>
            public static string getOutputString( int numWays, int target )
            {
                if( numWays == -1 ) {
                    return errorString;

                } else if( numWays == 1 ) {
                    return outputSingular + target + outputPeriod;

                } else {
                    return outputPrefix + numWays + outputSuffix + target + outputPeriod;
                }
            }
        }

        /// <summary>
        /// Calculate and return the number of ways 10 can be rolled given the number of sides for each die.
        /// </summary>
        /// <param name="m">A positive integer indicating the number of sides of first die.</param>
        /// <param name="n">A positive integer indicating the number of sides of second die.</param>
        /// <returns>If the input is valid, the number of ways 10 can be rolled, otherwise an error message.</returns>
        [HttpGet]
        [Route( "api/J2/DiceGame/{m}/{n}" )]
        public string DiceGame( int m, int n )
        {
            return DiceGame2( m, n, 10 );
        }

        /// <summary>
        /// Calculate and return the number of ways the target can be rolled given the number of sides for each die.
        /// The typical way to solve this problem is coded in the function DiceGameN2, found below. While
        /// that function gives the correct answer, it has a complexity of O(n^2).
        /// The solution in this function has O(1) complexity and consists of just a few comparisons and arithmetic
        /// operations, making it significantly more efficient.
        /// </summary>
        /// <param name="m">Number of sides of first die.</param>
        /// <param name="n">Number of sides of second die.</param>
        /// <param name="target">The number to roll.</param>
        /// <returns>If the input is valid, the number of ways the target can be rolled, otherwise an error message.</returns>
        [HttpGet]
        [Route( "api/J2/DiceGame2/{m}/{n}/{target}" )]
        public string DiceGame2( int m, int n, int target )
        {
            int totalSides = m + n;
            bool isNoWay = totalSides < target; // The sides must add up to at least the target.
            bool isInvalidInput = totalSides < 2 || target < 2;

            int maxWays = target - 1; 
            int numWays;
            if( isInvalidInput ) {
                numWays = -1;

            } else if( isNoWay ) {
                numWays = 0;

            } else {
                // The number of ways is limited by the smaller number of sides.
                numWays = Math.Min( m, n );

                // I'm not sure how to explain it, but if both m and n are less than the target,
                // it works out that if you add them together and subtract (target - 1) you get the right number.
                numWays = Math.Min( numWays, totalSides - maxWays );

                // No matter what, the number of ways can never be more than target - 1.
                numWays = Math.Min( numWays, maxWays );
            }

            return OutputStringCreator.getOutputString( numWays, target );
        }

        /// <summary>
        /// Calculate and return the number of ways the target can be rolled given the number of sides for each die.
        /// </summary>
        /// <param name="m">A positive integer indicating the number of sides of first die.</param>
        /// <param name="n">A positive integer indicating the number of sides of second die.</param>
        /// <param name="target">A positive integer indicating the number to roll.</param>
        /// <returns>If the input is valid, the number of ways the target can be rolled, otherwise an error message.</returns>
        [HttpGet]
        [Route( "api/J2/DiceGameN2/{m}/{n}/{target}" )]
        public string DiceGameN2( int m, int n, int target )
        {
            // Check every side of m against every side of n. If the sides add up to the 
            // target, increment the count.
            int numWays = 0;
            for( int i = 1; i <= m; i++ ) {
                for( int j = 1; j <= n; j++ ) {
                    if( i + j == target ) {
                        numWays++;
                    }
                }
            }

            return OutputStringCreator.getOutputString( numWays, target );
        }
    }
}
