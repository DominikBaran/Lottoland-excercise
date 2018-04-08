using System.Collections.Generic;
using System;
using System.Linq;

namespace Lottoland.Data
{
    public static class TestUsers
    {
        public static readonly List<KeyValuePair<string, string>> TestUser = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Jan","van Dam"),
            new KeyValuePair<string, string>("Chack","Norris"),
            new KeyValuePair<string, string>("Klark","n Kent"),
            new KeyValuePair<string, string>("John","Daw"),
            new KeyValuePair<string, string>("Bat","Man"),
            new KeyValuePair<string, string>("Tim","Los"),
            new KeyValuePair<string, string>("Dave","o Core"),
            new KeyValuePair<string, string>("Pay","Pal"),
            new KeyValuePair<string, string>("Lazy","Cat"),
            new KeyValuePair<string, string>("Jack","&amp; Johnes"),
        };

        public static Random rnd = new Random();

        public static List<KeyValuePair<string, string>> GetRandomUsers(int numberOfUsers)
        {
            // if number of users is higher than all users in the list - then return all available users
            numberOfUsers = numberOfUsers > TestUser.Count ? TestUser.Count : numberOfUsers;
            return TestUser.OrderBy(item => rnd.Next()).Take(numberOfUsers).ToList();
        }

        public static List<KeyValuePair<string, string>> GetUnregisteredUsers(List<KeyValuePair<string, string>> registeredUsers)
        {
            return TestUser.Except(registeredUsers).ToList();
        }
    }
}