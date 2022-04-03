using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Database
{
    internal class DBCollectionAndElements
    {
        string currentCollection = "";
        List<string> currentElements = new List<string>();
        public DBCollectionAndElements SetToUser()
        {
            currentCollection = "User";
            return this;
        }
    }
}
