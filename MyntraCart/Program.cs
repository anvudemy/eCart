using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraCart
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Hello World");

             int N = 7;
            int B = 1;
            int G = 2;
            double[,,] dp = new double[N+1,B+1,G+1];
            double[] prices = new double[N+1];
            double[] lowPrices = new double[N+1];
            prices[1] = 1500; lowPrices[1] = 1200;
            prices[2] = 1200; lowPrices[2] = 1000;
            prices[3] = 500; lowPrices[3] = 450;
            prices[4]=150; lowPrices[4]=100;
            prices[5]=150; lowPrices[5]=50;
            prices[6] = 100;lowPrices[6] = 50;
            prices[7] = 80;lowPrices[7] = 50;

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    for (int k = 0; k < dp.GetLength(2); k++)
                        dp[i,j,k] = Int32.MaxValue;// assigned to any high value
                }
            }
            dp[0,0,0] = 0;
            dp[0,B,G] = 0;


             int[,,] parentValuesB = new int[N + 1,B+1,G+1];

             int[,,] parentValuesG = new int[N + 1, B + 1, G + 1];
            for (int i = 1; i <= N; i++)
            {
                for (int b = 0; b <= B; b++)
                {
                    for (int g = 0; g <= G; g++)
                    {
                         int bVal, gVal;
                        if (b == 0 && g == 0)
                        {
                            if (G >= 1)
                            {
                                if (dp[i - 1,B,G] + (lowPrices[i]) <
                                   dp[i - 1,B,G - 1])
                                {
                                    dp[i,b,g] = dp[i - 1,B,G] + (lowPrices[i]);
                                    bVal = B;
                                    gVal = G;

                                }
                                else
                                {
                                    dp[i,b,g] = dp[i - 1,B,G - 1];
                                    bVal = B;
                                    gVal = G - 1;
                                }
                            }
                            else
                            {
                                dp[i,b,g] = dp[i - 1,B,G] + (lowPrices[i]);
                                bVal = B;
                                gVal = G;
                            }
                        }
                        else
                        {
                            if (g == 0)
                            {
                                if (dp[i - 1,b - 1,g] + prices[i] <
                                   dp[i - 1,b,g] + (lowPrices[i]))
                                {
                                    dp[i,b,g] = dp[i - 1,b - 1,g] + prices[i];
                                    bVal = b - 1;
                                    gVal = g;
                                }
                                else
                                {
                                    dp[i,b,g] = dp[i - 1,b,g] + (lowPrices[i]);
                                    bVal = b;
                                    gVal = g;
                                }
                            }
                            else
                            {
                                if (dp[i - 1,b,g - 1] <
                                    dp[i - 1,b,g] + (lowPrices[i]))
                                {
                                    dp[i,b,g] = dp[i - 1,b,g - 1];
                                    bVal = b;
                                    gVal = g - 1;
                                }
                                else
                                {
                                    dp[i,b,g] = dp[i - 1,b,g] + (lowPrices[i]);
                                    bVal = b;
                                    gVal = g;
                                }
                            }
                        }
                        parentValuesB[i,b,g] = bVal;
                        parentValuesG[i,b,g] = gVal;
                        //Console.WriteLine(parentValuesB[i,b,g]);
                    }
                }
            }


            int b1 = B, g1 = G, b2, g2;

            for (int j = N; j > 0; j--)
            {
                b2 = parentValuesB[j,b1,g1];
                g2 = parentValuesG[j,b1,g1];
                // actual price considered for the product
                 double finalPriceToBePaid = dp[j,b1,g1] -
                                                  dp[j - 1,b2,g2];
                b1 = b2;
                g1 = g2;

                Console.WriteLine(finalPriceToBePaid);
            }


            //   for(int i = 1; i <= N; i++) {
            //for(int b = 0; b <= B; b++) {
            //for(int g = 0; g <= G; g++) {

            //  Console.WriteLine(parentValues[i][b][g]);
            //}}}




        }
    }




}
