using System;
using System.Collections.Generic;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string[] lines = File.ReadAllLines("C:/Users/gluck/source/repos/Balkezesek/balkezesek.csv");

            List<BaseballPlayer> baseballPlayersList = new List<BaseballPlayer>();

            for (int i = 1; i < lines.Length; i++)
            {
                BaseballPlayer baseballPlayer = new BaseballPlayer(lines[i]);

                baseballPlayersList.Add(baseballPlayer);
            }           

            Console.WriteLine("3. feladat:");
            numberOfLines(baseballPlayersList);

            Console.WriteLine("4. feladat:");
            nameHeightLastPlayedInOct99(baseballPlayersList);

            Console.WriteLine("5. feladat:");

           averageWeightOfPlayersPlayedInYear(baseballPlayersList, yearQuery(baseballPlayersList));
        }

        private static void averageWeightOfPlayersPlayedInYear(List<BaseballPlayer> baseballPlayersList, DateTime queriedDate)
        {
            Console.WriteLine("6. feladat:");
            double averageWeightDividend = 0;
            int averageWeightDivisor = 0;
            
            foreach (var baseballPlayer in baseballPlayersList)
            {
                if (queriedDate.Year == baseballPlayer.elso.Year || queriedDate.Year == baseballPlayer.utolso.Year || (queriedDate.Year > baseballPlayer.elso.Year && queriedDate.Year < baseballPlayer.utolso.Year))
                {
                    averageWeightDividend += baseballPlayer.suly;
                    averageWeightDivisor++;
                }
            }

            Console.WriteLine(string.Format("{0:0.00}", averageWeightDividend/averageWeightDivisor) + " font");
        }

        private static DateTime yearQuery(List<BaseballPlayer> baseballPlayersList)
        {
            DateTime lowerTreshold = new DateTime(1990,01,01);
            DateTime upperTreshold = new DateTime(1999,12,31);
            bool queriedDateIsCorrect;
            DateTime queriedDate;

            do
            {
                Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot: ");
                queriedDate = Convert.ToDateTime(Console.ReadLine() + ",01,01");
                
                if (!(queriedDate >= lowerTreshold && queriedDate < upperTreshold))
                {
                    Console.WriteLine("Hibás adat!");
                    queriedDateIsCorrect = false;
                }
                else
                {
                    queriedDateIsCorrect = true;
                }
                

            } while (!queriedDateIsCorrect);

            return queriedDate;
        }

        private static void nameHeightLastPlayedInOct99(List<BaseballPlayer> baseballPlayersList)
        {
            DateTime dateBeginning = new DateTime(1999,10,01);
            DateTime dateEnd = new DateTime(1999,10,31);
            foreach (var baseballPlayer in baseballPlayersList)
            {
                if (baseballPlayer.utolso > dateBeginning && baseballPlayer.utolso < dateEnd)
                {
                    Console.WriteLine(baseballPlayer.nev + ", " + String.Format("{0:0.0}",baseballPlayer.magassag*2.54) + " cm");
                }
            }
        }

        private static void numberOfLines(List<BaseballPlayer> baseballPlayersList)
        {
             Console.WriteLine(baseballPlayersList.Count);
        }
    }
}
