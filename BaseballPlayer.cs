using System;

namespace Balkezesek
{
    internal class BaseballPlayer
    {
        public string nev { get; set; }
        public DateTime elso { get; set; }
        public DateTime utolso { get; set; }
        public double suly { get; set; }
        public double magassag { get; set; }

        public BaseballPlayer(string line)
        {
            string[] lineSplitted = line.Split(";");
            string[] elsoDateSplitted = lineSplitted[1].Split("-");
            string[] utolsoDateSplitted = lineSplitted[2].Split("-");

            nev = lineSplitted[0];
            elso = new DateTime(Convert.ToInt32(elsoDateSplitted[0]), Convert.ToInt32(elsoDateSplitted[1]), Convert.ToInt32(elsoDateSplitted[2]));
            utolso = new DateTime(Convert.ToInt32(utolsoDateSplitted[0]), Convert.ToInt32(utolsoDateSplitted[1]), Convert.ToInt32(utolsoDateSplitted[2]));
            suly = Convert.ToDouble(lineSplitted[3]);
            magassag = Convert.ToDouble(lineSplitted[4]);
        }
    }
}