using System;
using System.Collections.Generic;
using System.Text;

namespace ND1
{
    class ND
    {


        static void Main()
        {

            bool CheckIfNum;
            string num;
            int RangeA = -9;
            int RangeB = 9;


            //type number, repeat if it is not number
            do
            {
                Console.Write("Choose number from -9 to 9 (homework works fully from -999 to 999): ");
                num = Convert.ToString(Console.ReadLine());
                CheckIfNum = check(num);
                Console.WriteLine("Is it number? " + CheckIfNum);
            }
            while (CheckIfNum == false);
            Console.Write("What number we got, not yet converted to INT: ");
            Console.WriteLine(num);

            //Convert to INT
            int NUM = Convert.ToInt32(num);
            Console.WriteLine("Converted string num to INT num: " + NUM);

            //check if number is in Range from -9 to 9, static range, not asked to make own range.
            string Range = InRange(NUM, RangeA, RangeB);
            Console.WriteLine(Range);

            //number length
            Console.Write("Typed number length with or w/t -: ");
            int length = num.Length;
            Console.WriteLine(length);

            //INT to TEXT -9 9 with switch, realised that not effective, but works and adds one more row if in range
            if (length == 1 || (length == 2 && NUM < 0))
            {
                string Units9 = ChangeNumberToText(NUM);
                Console.Write("Typed number expression in string (used switch, function ChangeNumberToText): ");
                Console.WriteLine(Units9);
            }

            //INT to TEXT from -999 to 999
            string numberToText = ChangeNumberToTextwithLists(length, NUM);
            Console.Write("Typed number expression in string (used Lists and function ChangeNumberToTextwithLists): ");
            Console.WriteLine(numberToText);





        }

        //FUNCTIONS
        //function to check if typed number
        static bool check(string num)
        {
            int output;
            if (int.TryParse(num, out output))
                return true;
            return false;
        }

        //function to check if number is in RangeA RangeB range
        static string InRange(int NUM, int RangeA, int RangeB)
        {
            if (RangeA < NUM && NUM < RangeB)
                return ($"Choosen number is in range from {RangeA} to {RangeB}");
            else return ($"Choosen number IS NOT in range from {RangeA} to {RangeB}");
        }

        //function with switch for INT to STRING from -9 to 9
        static string ChangeNumberToText(int NUM)
        {
            switch (NUM)
            {
                case 0:
                    return "nulis";
                case 1:
                    return "vienas";
                case 2:
                    return "du";
                case 3:
                    return "trys";
                case 4:
                    return "keturi";
                case 5:
                    return "penki";
                case 6:
                    return "sesi";
                case 7:
                    return "septyni";
                case 8:
                    return "astuoni";
                case 9:
                    return "devyni";
                case -1:
                    return "minus vienas";
                case -2:
                    return "minus du";
                case -3:
                    return "minus trys";
                case -4:
                    return "minus keturi";
                case -5:
                    return "minus penki";
                case -6:
                    return "minus sesi";
                case -7:
                    return "minus septyni";
                case -8:
                    return "minus astuoni";
                case -9:
                    return "minus devyni";
                default:
                    return "negali buti sio varianto, niekad nebus isvestas";
            }
        }



        static string ChangeNumberToTextwithLists(int length, int NUM)
        {
            List<string> minus = new List<string>() { "minus", "" };
            List<string> Units = new List<string>() { "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni" };
            List<string> TensUnits = new List<string>() {"vienuolika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika"};
            List<string> Tens = new List<string>() { "desimt", "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt" };
            List<string> Hundreds = new List<string>() { "simtas", "du simtai", "trys simtai", "keturi simtai", "penki simtai", "sesi simtai", "septyni simtai", "astuoni simtai", "devyni simtai" };


            //-9 9
            if (NUM < 10 && NUM >= 0)
            {
                return Units[NUM];
            }
            else if (NUM < 0 && NUM > -10)
            {
                return minus[0] + " " + Units[-NUM];
            }
            //-90 -80 ... 80 90
            else if (length == 2 && (NUM % 10 == 0) && NUM > 0)
            {
                return Tens[(NUM / 10) - 1];
            }
            else if (length == 3 && (NUM % 10 == 0) && NUM < 0)
            {
                return minus[0] + " " + Tens[(-NUM / 10) - 1];
            }
            //-19 -18 ... 18 19
            else if (NUM > 10 && NUM < 20)
            {
                return (TensUnits[(NUM % 10) - 1]);
            }
            else if (NUM < -10 && NUM > -20)
            {
                return (minus[0] + " " + TensUnits[(-NUM % 10) - 1]);
            }
            //-99 .. -21 ... 21 .. 99
            else if (NUM > 20 && NUM < 100)
            {
                return (Tens[(NUM / 10) - 1] + " " + Units[NUM % 10]);
            }
            else if (NUM < -20 && NUM > -100)
            {
                return (minus[0] + " " + Tens[(-NUM / 10) - 1] + " " + Units[-NUM % 10]);
            }
            //-900 -800 ... 800 900
            else if (length == 3 && (NUM % 100 == 0))
            {
                return (Hundreds[(NUM / 100) - 1]);
            }
            else if (length == 4 && (NUM % 100 == 0) && NUM < 0)
            {
                return (minus[0] + " " + Hundreds[(-NUM / 100) - 1]);
            }
            //-909 -908 ... 908 909
            else if (NUM > 100 && NUM < 1000 && (NUM % 100 < 10))
            {
                return (Hundreds[(NUM / 100) - 1] + " " + Units[NUM % 10]);
            }
            else if (NUM < -100 && NUM > -1000 && (-NUM % 100 < 10))
            {
                return (minus[0] + " " + Hundreds[(-NUM / 100) - 1] + " " + Units[-NUM % 10]);
            }
            //-919 -918 ... 918 919
            else if (NUM > 100 && NUM < 1000 && (NUM % 100 < 20) && (NUM % 100 > 10))
            {
                return (Hundreds[(NUM / 100) - 1] + " " + TensUnits[(NUM % 100) - 11]);
            }
            else if (NUM < -100 && NUM > -1000 && (-NUM % 100 < 20) && (-NUM % 100 > 10))
            {
                return (minus[0] + " " + Hundreds[(-NUM / 100) - 1] + " " + TensUnits[(-NUM % 100) - 11]);
            }
            //-990 -980 ... 980 990
            else if (length == 3 && (NUM % 10 == 0) && NUM >= 110)
            {
                return (Hundreds[(NUM / 100) - 1] + " " + Tens[((NUM % 100)/10) - 1]);
            }
            else if (length == 4 && (NUM % 10 == 0) && -NUM >= 110)
            {
                return minus[0] + " " + Hundreds[(-NUM / 100) - 1] + " " + Tens[((-NUM % 100)/10) - 1];
            }
            //-999 -998 ... 998 999
            else if (NUM > 100 && NUM < 1000)
            {
                return (Hundreds[(NUM / 100) - 1] + " " + Tens[((NUM % 100) / 10) - 1] + " " + Units[NUM % 10]);
            }
            else if (NUM < -100 && NUM > -1000)
            {
                return (minus[0] + " " + Hundreds[(-NUM / 100) - 1] + " " + Tens[((-NUM % 100) / 10) - 1] + " " + Units[-NUM % 10]);
            }
            else
            { return "Homework finished with numbers from -999 to 999, rerun program with numbers in range!"; }
        }
    }
}
