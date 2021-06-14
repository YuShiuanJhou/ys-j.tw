using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class JobDAO
    {
        private MongoClient mc;
        private IMongoDatabase db;
        private IMongoCollection<Job> collection;
        public JobDAO()
        {
            mc = new MongoClient("mongodb://admin:password@127.0.0.1:27017/admin");
            db = mc.GetDatabase("companies104");
            collection = db.GetCollection<Job>("jobs");
        }

        public List<Job> GetAll()
        {
            return collection.AsQueryable().ToList();
        }

        public List<Job> GetAllByCode(string code)
        {
            return collection.AsQueryable().Where(x=>x.code==code).ToList();
        }


        public Job GetById(string Id)
        {
            return collection.Find(x => x.Id == Id).FirstOrDefault();
        }


        public bool Insert(Job entity)
        {
            return collection.InsertOneAsync(entity).IsCompleted;
        }

        public Job Update(Job entity)
        {
            var options = new FindOneAndReplaceOptions<Job>
            {
                ReturnDocument = ReturnDocument.After
            };

            return collection.FindOneAndReplace<Job>(u => u.Id == entity.Id, entity, options);
        }

        public bool DeleteById(string Id)
        {
            return collection.DeleteOne(u => u.Id == Id).IsAcknowledged;
        }



    }
}
