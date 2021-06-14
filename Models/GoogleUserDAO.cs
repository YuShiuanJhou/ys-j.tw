using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class GoogleUserDAO
    {
        private MongoClient mc;
        private IMongoDatabase db;
        private IMongoCollection<GoogleUser> collection;
        public GoogleUserDAO()
        {
            mc = new MongoClient("mongodb://admin:password@127.0.0.1:27017/admin");


            db = mc.GetDatabase("website");
            collection = db.GetCollection<GoogleUser>("googleusers");
        }

        public List<GoogleUser> GetAll()
        {
            return collection.AsQueryable().ToList();
        }

        public GoogleUser GetById(string Id)
        {
            return collection.Find(x => x.Id == Id).FirstOrDefault();
        }
        public GoogleUser GetByUId(string uId)
        {
            return collection.Find(x => x.uId == uId).FirstOrDefault();
        }



        public bool Insert(GoogleUser entity)
        {
            return collection.InsertOneAsync(entity).IsCompleted;
        }

        public GoogleUser Update(GoogleUser entity)
        {
            var options = new FindOneAndReplaceOptions<GoogleUser>
            {
                ReturnDocument = ReturnDocument.After
            };

            return collection.FindOneAndReplace<GoogleUser>(u => u.Id == entity.Id, entity, options);
        }

        public bool DeleteById(string Id)
        {
            return collection.DeleteOne(u => u.Id == Id).IsAcknowledged;
        }
        public bool DeleteByUId(string uId)
        {
            return collection.DeleteOne(u => u.uId == uId).IsAcknowledged;
        }


    }
}
