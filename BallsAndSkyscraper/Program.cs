using System;

/*
 * There is a number of glass balls and a skyscraper.
 * If we throw a ball from the floor higher than a specific floor the ball will have broken.
 * 
 * Goal: Find out minimum count of throws in worst case to determine that specific floor
 * 
 * Solution using dynamic programming
 */

namespace BallsAndSkyscraper {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine("Usage: [balls] [floors]");
                Console.WriteLine("balls - integer number, floors - integer number");
                return;
            }
            int balls;
            int.TryParse(args[0], out balls);
            int floors;
            int.TryParse(args[1], out floors);
            if (balls == 0 || floors == 0) {
                Console.WriteLine("Both arguments must be integer numbers");
                return;
            }
            Console.WriteLine("Glass balls: " + balls);
            Console.WriteLine("Floors: " + floors);
            int catches = CalculateMinThrows(balls, floors);
            Console.WriteLine("Minimum count of throws in worst case: " + catches);
        }

        private static int CalculateMinThrows(int balls, int floors) {
            if (balls == 1 || floors == 1 || floors == 2) {
                return floors;
            }

            int[,] dp = new int[balls, floors + 1];
            for (int i = 1; i <= floors; i++) {
                dp[0, i] = i;
            }

            for (int ball = 1; ball < balls; ball++) {
                dp[ball, 1] = 1;
                dp[ball, 2] = 2;
                for (int maxFloor = 3; maxFloor <= floors; maxFloor++) {
                    int minFloor = floors;
                    for (int currentFloor = 1; currentFloor <= maxFloor; currentFloor++) {
                        int worstFloorIfBroken = dp[ball - 1, currentFloor - 1];
                        int worstFloorIfSaved = dp[ball, maxFloor - currentFloor];
                        int optimalFloor = Math.Max(worstFloorIfBroken, worstFloorIfSaved);
                        if (optimalFloor < minFloor) {
                            minFloor = optimalFloor;
                        }
                    }
                    dp[ball, maxFloor] = minFloor + 1;
                }
            }

            return dp[balls - 1, floors];
        }
    }
}