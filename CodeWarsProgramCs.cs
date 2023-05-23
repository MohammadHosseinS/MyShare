using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security;

namespace CodeWars
{
    internal class Program
    {
        //https://www.codewars.com/kata/60576b180aef19001bce494d

        static void Main(string[] args)
        {

            /*var adsfalkj = 10 * *32;
            Console.WriteLine();
            return;*/
        startEntering:
            Console.WriteLine("Enter height");
            var height = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter width");
            var width = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter resolution");
            var resolution = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Calculating...");
            Thread.Sleep(100);

            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Number of blacks on the board are : {0}", Checker.CheckNumberOfBlacks(height, width, resolution));
            sw.Stop();
            Console.WriteLine("Total time ellapsed: {0}", sw.ElapsedMilliseconds);
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Go Again?");
            Console.WriteLine("Press Y for yes and N for no");

            var key = Console.ReadKey().KeyChar;
            if (key == 'y' || key == 'Y')
            {
                Console.WriteLine();
                goto startEntering;
            }
            else if (key == 'n' || key == 'N')
                Environment.Exit(0);
            else
            {
                Console.WriteLine("Ok then. bye!");
                Environment.Exit(0);
            }

        }
    }

    internal class Checker
    {

        public static BigInteger CheckNumberOfBlacks(BigInteger height, BigInteger width, BigInteger resolution)
        {




            BigInteger oneLineInWhiteFirst = 0;
            BigInteger oneLineInBlackFirst = 0;



            BigInteger kol = (BigInteger)width / (BigInteger)resolution;
            BigInteger baghi = (BigInteger)width % (BigInteger)resolution;

            if (kol == 0 || (kol == 1 && baghi == 0))
                oneLineInWhiteFirst = 0;
            else
            {
                var aa = kol / 2;
                oneLineInWhiteFirst += aa * (BigInteger)resolution;

                /*if (kol % 2 != 0)
                    oneLineInWhiteFirst += (int)resolution;*/

                if (kol % 2 != 0) // در خطی که اولش سفید است، اگر کل فرد بود، باقیمانده سیاه می شود
                    oneLineInWhiteFirst += baghi;

                /*oneLineInWhiteFirst += ((kol / 2) * (int)resolution);
                if (kol % 2 != 0)
                    oneLineInWhiteFirst += baghi;*/
            }


            if (kol == 0 || kol == 1)
                oneLineInBlackFirst = (BigInteger)width;
            else
            {
                var aa = kol / 2;
                oneLineInBlackFirst += aa * (BigInteger)resolution;

                if (kol % 2 != 0) // در خطی که اولش سیاه است، اگر کل فرد بود به این معناست که آن یک دانه ای که باعث فرد شدن شده است، سیاه است
                    oneLineInBlackFirst += (BigInteger)resolution;

                if (kol % 2 == 0) // در خطی که اولش سیاه است، اگر کل زوج بود، باقیمانده سیاه می شود
                    oneLineInBlackFirst += baghi;

            }


            BigInteger currentLine;
            BigInteger blacks = 0;

            for (currentLine = 1; currentLine <= (BigInteger)height/*(int)resolution*/; currentLine++)
            {
                bool isWhiteFirst;

                BigInteger tmpCurrentLine = currentLine;

                while (tmpCurrentLine % (BigInteger)resolution != 0)
                {
                    tmpCurrentLine++;
                }

                BigInteger currentCycle = tmpCurrentLine;



                if ((currentCycle / (BigInteger)resolution) % 2 == 0)
                    blacks += oneLineInBlackFirst;

                if ((currentCycle / (BigInteger)resolution) % 2 != 0)
                    blacks += oneLineInWhiteFirst;
            }



            return blacks;


        }


        /*public static long CheckNumberOfBlacks(long height, long width, long resolution)
        {




            long oneLineInWhiteFirst = 0;
            long oneLineInBlackFirst = 0;



            long kol = (long)width / (long)resolution;
            long baghi = (long)width % (long)resolution;

            if (kol == 0 || (kol == 1 && baghi == 0))
                oneLineInWhiteFirst = 0;
            else
            {
                var aa = kol / 2;
                oneLineInWhiteFirst += aa * (long)resolution;

                *//*if (kol % 2 != 0)
                    oneLineInWhiteFirst += (int)resolution;*//*

                if (kol % 2 != 0) // در خطی که اولش سفید است، اگر کل فرد بود، باقیمانده سیاه می شود
                    oneLineInWhiteFirst += baghi;

                *//*oneLineInWhiteFirst += ((kol / 2) * (int)resolution);
                if (kol % 2 != 0)
                    oneLineInWhiteFirst += baghi;*//*
            }


            if (kol == 0 || kol == 1)
                oneLineInBlackFirst = (long)width;
            else
            {
                var aa = kol / 2;
                oneLineInBlackFirst += aa * (long)resolution;

                if (kol % 2 != 0) // در خطی که اولش سیاه است، اگر کل فرد بود به این معناست که آن یک دانه ای که باعث فرد شدن شده است، سیاه است
                    oneLineInBlackFirst += (long)resolution;

                if (kol % 2 == 0) // در خطی که اولش سیاه است، اگر کل زوج بود، باقیمانده سیاه می شود
                    oneLineInBlackFirst += baghi;

            }


            long currentLine;
            long blacks = 0;

            for (currentLine = 1; currentLine <= (long)height*//*(int)resolution*//*; currentLine++)
            {
                bool isWhiteFirst;

                long tmpCurrentLine = currentLine;

                while (tmpCurrentLine % (long)resolution != 0)
                {
                    tmpCurrentLine++;
                }

                long currentCycle = tmpCurrentLine;



                if ((currentCycle / (long)resolution) % 2 == 0)
                    blacks += oneLineInBlackFirst;

                if ((currentCycle / (long)resolution) % 2 != 0)
                    blacks += oneLineInWhiteFirst;
            }



            return blacks;


        }*/
    }
}