using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrud.Models
{
    public class CarModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }
        public string Empname
        {
            get;
            set;
        }
        public string Empemail
        {
            get;
            set;
        }
        public string Phoneno
        {
            get;
            set;
        }
        public string state
        {
            get;
            set;
        }
    }
}
