using Application.Interfaces;
using System;

namespace Application.Services
{
    public class DiceService : IDiceService
    {
        private readonly Random rnd;

        public DiceService()
        {
            rnd = new Random();
        }

        public int Roll()
        {
            return rnd.Next(1,7);
        }
    }
}