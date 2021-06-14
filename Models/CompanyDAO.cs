using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class CompanyDAO
    {
        private MongoClient mc;
        private IMongoDatabase db;
        private IMongoCollection<Company> collection;
        public CompanyDAO()
        {

            mc = new MongoClient("mongodb://admin:password@127.0.0.1:27017/admin");
            db = mc.GetDatabase("companies104");
            collection = db.GetCollection<Company>("companies");
        }

        public List<Company> GetAll()
        {
            return collection.AsQueryable().ToList();
        }

        public Company GetById(string Id)
        {
            return collection.Find(x => x.Id == Id).FirstOrDefault();
        }


        public bool Insert(Company entity)
        {
            return collection.InsertOneAsync(entity).IsCompleted;
        }

        public Company Update(Company entity)
        {
            var options = new FindOneAndReplaceOptions<Company>
            {
                ReturnDocument = ReturnDocument.After
            };

            return collection.FindOneAndReplace<Company>(u => u.Id == entity.Id, entity, options);
        }

        public bool DeleteById(string Id)
        {
            return collection.DeleteOne(u => u.Id == Id).IsAcknowledged;
        }



    }
}
