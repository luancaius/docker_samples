using System;

namespace Random
{
    public class Service : IService
    {
        public int RandomNumber(int value1=0, int value2=100)
        {
            System.Random random = new System.Random();  
            return random.Next(value1, value2);
        }
    }
}