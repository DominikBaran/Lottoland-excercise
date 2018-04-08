using System;
using System.Linq;

namespace Lottoland.Data
{
    public static class RandomValuesGenerator
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringNoNumbers(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomNumberFromRange(int start, int end)
        {
            return random.Next(start, end); 
        }

        public static string GenerateRandomEmailAddress()
        {
            return $"{RandomString(10)}@{RandomString(5)}.{RandomStringNoNumbers(3)}";
        }
    }
}