using Microsoft.AspNetCore.Mvc;
using MongoCrud.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrud.Repository
{

    public class StudentRepo
    {

        private readonly IMongoDatabase _database;
        public StudentRepo(IMongoDatabase mongoDatabase)
        {
            _database = mongoDatabase;
        }

        [HttpPost]
        public void insert(CarModel model)
        {
            var collection = _database.GetCollection<CarModel>("EmployeeDetails");
            collection.InsertOne(model);
        }

        public List<CarModel> Show()
        {
            var collection = _database.GetCollection<CarModel>("EmployeeDetails").Find(new BsonDocument()).ToList();
            return collection;
        }

        public CarModel search(string id)
        {
            var collection = _database.GetCollection<CarModel>("EmployeeDetails").Find(Builders<CarModel>.Filter.Eq("Id", ObjectId.Parse(id))).SingleOrDefault();
            return collection;
        }

        public void update(CarModel carModel)
        {
            var collection = _database.GetCollection<CarModel>("EmployeeDetails");
            var update = collection.FindOneAndUpdateAsync(Builders<CarModel>.Filter.Eq("Id", carModel.Id), 
            Builders<CarModel>.Update
            .Set("Empname", carModel.Empname)
            .Set("Empemail", carModel.Empemail)
            .Set("Phoneno", carModel.Phoneno)
            .Set("state", carModel.state));
        }

        public void Delete(string id) 
        {
            var collection = _database.GetCollection<CarModel>("EmployeeDetails");
            var DeleteRecored = collection.DeleteOneAsync(
            Builders<CarModel>.Filter.Eq("Id", id));
        }
    }
}
