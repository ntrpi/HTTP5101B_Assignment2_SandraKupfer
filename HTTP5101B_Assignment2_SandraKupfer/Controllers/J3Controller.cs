using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace HTTP5101B_Assignment2_SandraKupfer.Controllers
{
    public class J3Controller: ApiController
    {
        /*
        https://cemc.math.uwaterloo.ca/contests/computing/2017/stage%201/juniorEF.pdf
        Problem J3: Exactly Electrical

        You live in Grid City, which is composed of integer-numbered streets which run east-west (parallel
        to the x-axis) and integer-numbered avenues which run north-south (parallel to the y-axis). The
        streets and avenues have infinite length, and there is a street for every integer y-coordinate and
        an avenue for every x-coordinate. All intersections are labelled by their integer coordinates: for
        example, avenue 7 and street -3 intersect at (7,-3).

        You drive a special electric car which uses up one unit of electrical charge moving between adjacent
        intersections: that is, moving either north or south to the next street, or moving east or west to the
        next avenue). Until your battery runs out, at each intersection, your car can turn left, turn right,
        go straight through, or make a U-turn. You may visit the same intersection multiple times on the
        same trip.

        Suppose you know your starting intersection, your destination intersection and the number of units
        of electrical charge in your battery. Determine whether you can travel from the starting intersection
        to the destination intersection using the charge available to you in such a way that your battery is
        empty when you reach your destination.

        Input Specification
        The input consists of three lines. The first line contains a followed by b, indicating the starting
        coordinate (a, b) (−1000 ≤ a ≤ 1000; −1000 ≤ b ≤ 1000).
        The second line contains c followed by d, indicating the destination coordinate (c, d) (−1000 ≤
        c ≤ 1000; −1000 ≤ d ≤ 1000).
        The third line contains an integer t (0 ≤ t ≤ 10 000) indicating the initial number of units of
        electrical charge of your battery.

        For 3 of the 15 available marks, 0 ≤ a, b, c, d ≤ 2.
        For an additional 3 of the 15 marks available, t ≤ 8.

        Output Specification
        Output Y if it is possible to move from the starting coordinate to the destination coordinate using
        exactly t units of electrical charge. Otherwise output N.

        Sample Input 1
        3 4
        3 3
        3

        Output for Sample Input 1
        Y

        Explanation for Output for Sample Input 1
        One possibility is to travel from (3, 4) to (4, 4) to (4, 3) to (3, 3).

        Sample Input 2
        10 2
        10 4
        5

        Output for Sample Input 2
        N

        Explanation for Output for Sample Input 2
        It is possible to get from (10, 2) to (10, 4) using exactly 2 units of electricity, by going north 2
        units.
        It is also possible to travel using 4 units of electricity as in the following sequence:
        (10, 2) → (10, 3) → (11, 3) → (11, 4) → (10, 4).
        It is also possible to travel using 5 units of electricity from (10, 2) to (11, 4) by the following
        sequence:
        (10, 2) → (10, 3) → (11, 3) → (12, 3) → (12, 4) → (11, 4).
        It is not possible to move via any path of length 5 from (10, 2) to (10, 4), however.
        */

        /// <summary>
        /// Determine whether it is possible to get from one point to the next 
        /// using the exact number of electricity units given.
        /// </summary>
        /// <param name="x1">x coordinate of first point</param>
        /// <param name="y1">y coordinate of first point</param>
        /// <param name="x2">x coordinate of second point</param>
        /// <param name="y2">y coordinate of second point</param>
        /// <param name="electricity">units of electricity</param>
        /// <returns>Y indicates yes, N indicates no.</returns>
        [HttpGet]
        [Route( "api/J3/ExactlyElectrical/{x1}/{y1}/{x2}/{y2}/{electricity}" )]
        public string ExactlyElectrical( int x1, int y1, int x2, int y2, int electricity )
        {
            // Calculate the distance to travel along the x-axis.
            int xDiff = Math.Abs( x2 - x1 );

            // Calculate the distance to travel along the y-axis.
            int yDiff = Math.Abs( y2 - y1 );

            // Calculate the distance between the 2 points.
            int minRequiredTravel = xDiff + yDiff;

            // Find the amount of electricity left over after traveling from the first point to the second.
            int leftoverElectricity = electricity - minRequiredTravel;
            bool isEnoughElectricity = leftoverElectricity >= 0;
            if( !isEnoughElectricity ) {
                return "N";
            }

            // After traveling to the second point, any route away from that point will have to be traversed 
            // in reverse to return to the second point. So we know that if we want to return to the second
            // point, the amount of leftover electricity must be divisible by 2.
            bool isCorrectLeftoverElectricity = leftoverElectricity % 2 == 0;
            if( isEnoughElectricity && isCorrectLeftoverElectricity ) {
                return "Y";
            } else {
                return "N";
            }
        }
    }
}
