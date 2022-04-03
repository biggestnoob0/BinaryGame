using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Database
{
    internal class ReadWriteDatabase
    {
        public static void AddToCollection(string collection, string[] data)
        {
            if (Connection.database != null)
            {
                IMongoCollection<BsonDocument> collectionConnection;
                try
                {
                    collectionConnection = Connection.database.GetCollection<BsonDocument>(collection);
                }
                catch
                {
                    return;
                }
                BsonDocument entry = new BsonDocument();
                for (int i = 0; i < data.Length; i++)
                {
                    entry.AddRange(BsonDocument.Parse(data[i]));
                }
                collectionConnection.InsertOne(entry);
            }
        }
        public static string ReadCollection(string collection)
        {
            if (Connection.database != null)
            {
                IMongoCollection<BsonDocument> collectionConnection;
                try
                {
                    collectionConnection = Connection.database.GetCollection<BsonDocument>(collection);
                }
                catch
                {
                    return null;
                }
                collectionConnection = Connection.database.GetCollection<BsonDocument>(collection);


                string documents = collectionConnection.Find<BsonDocument>(new BsonDocument()).ToList().ToJson();

                return documents;
            }
            return null;
        }
    }
}
