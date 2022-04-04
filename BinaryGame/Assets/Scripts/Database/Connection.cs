using Assets.Scripts.Encryption;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Database
{
    public class Connection
    {
        public static IMongoDatabase database;
        public static void Connect()
        {
            string username = "root";
            var test = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("");
            string password = StringEncryption.DecryptStringAndReverseFromBytes("qlxbvnpsvcfhrjjabdmw", "071062068060049051033042");
            string databaseName = "binarygame.zxbgp.mongodb.net";
            MongoClient connection = new MongoClient("mongodb+srv://" + username + ":" + password + "@" + databaseName + "/test");
            database = connection.GetDatabase("BinaryGame");
        }
    }
}
