namespace SnakesAndLadders
{
    using System;

    public class Dice: IDice
    {
        private readonly Random _random=new Random();

        public int RollDice()
        {
            return _random.Next(1, 6);
        }
    }
}