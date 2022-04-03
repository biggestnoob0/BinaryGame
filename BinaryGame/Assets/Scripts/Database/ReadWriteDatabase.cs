using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        public static void ChangeDocument(string collectionName, string idLabel, string idValue, string labelOfUpdate, string valueUpdate)
        {
            var collection = Connection.database.GetCollection<BsonDocument>(collectionName);
            if (collection != null)
            {
                var filter = Builders<BsonDocument>.Filter.Eq(idLabel, idValue);
                var update = Builders<BsonDocument>.Update.Set(labelOfUpdate, valueUpdate);
                try
                {
                    collection.UpdateOne(filter, update);
                }
                catch (Exception)
                {
                    Debug.Log("document change failed");
                }
            }
        }
        public static string FindIdByElementInCollection(string collectionName, string label, string value)
        {
            var collection = Connection.database.GetCollection<BsonDocument>(collectionName);
            if(collection != null)
            {
                var filter = Builders<BsonDocument>.Filter.Eq(label, value);
                var document = collection.Find(filter);
                if(document != null)
                {
                    string id = JSONValueFinder.findValue(document.ToJson(), "_id");
                    return id;
                }
                return "";
            }
            return "";
        }
        public static string FindDocumentByElement(string collectionName, string label, string value)
        {
            var collection = Connection.database.GetCollection<BsonDocument>(collectionName);
            if (collection != null)
            {
                var filter = Builders<BsonDocument>.Filter.Eq(label, value);
                string document = collection.Find<BsonDocument>(filter).ToList().ToJson();
                if (document != null)
                {
                    return document;
                }
                return "";
            }
            return "";
        }
    }
}
