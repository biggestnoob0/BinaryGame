using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Database
{
    internal class CommonDataGetter
    {
        /// <summary>
        /// returns users details, with 0 index being username and 1 index being passwords
        /// </summary>
        /// <param name="checkIfContains"></param>
        public static List<List<string>> GetUserDetails()
        {
            List<List<string>> details = new List<List<string>>();
            details[0] = JSONValueFinder.findValues(ReadWriteDatabase.ReadCollection(DBCollections.userCollection), "username");
            details[1] = JSONValueFinder.findValues(ReadWriteDatabase.ReadCollection(DBCollections.userCollection), "password");

            return details;
        }
        public static bool DoesUserDetailsContain(string usernameToCheck, string passwordToCheck)
        {
            List<List<string>> details = new List<List<string>>();
            details[0] = JSONValueFinder.findValues(ReadWriteDatabase.ReadCollection(DBCollections.userCollection), "username");
            details[1] = JSONValueFinder.findValues(ReadWriteDatabase.ReadCollection(DBCollections.userCollection), "password");

            if (usernameToCheck.Equals(string.Empty) || passwordToCheck.Equals(string.Empty))
            {
                return false;
            }
            if (details[0].Contains(usernameToCheck))
            {
                if (details[1].Contains(passwordToCheck))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
