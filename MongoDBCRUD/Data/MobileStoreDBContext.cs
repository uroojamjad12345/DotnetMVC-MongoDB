using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBCRUD.Interface;
using MongoDBCRUD.Models;

namespace MongoDBCRUD.Data
{
    public class MobileStoreDBContext : IMobileStore
    {
        public readonly IMongoDatabase _db;

        public MobileStoreDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<MobileDeviceEntity> mobiledevicecollection => 
            _db.GetCollection<MobileDeviceEntity>("mobiledevice");

        public void Create(MobileDeviceEntity mobiledeviceData)
        {
            mobiledevicecollection.InsertOne(mobiledeviceData);

        }

        public void Delete(string Name)
        {
           var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c.Name, Name);
            mobiledevicecollection.DeleteOne(filter);
        }

        public IEnumerable<MobileDeviceEntity> GetAllMobileDevices()
        {
            return mobiledevicecollection.Find(a=>true).ToList();
        }

        public MobileDeviceEntity GetMobileDeviceDetails(string Name)
        {
            var mobileDeviceDetails = mobiledevicecollection.Find(a=>a.Name == Name).FirstOrDefault();
            return mobileDeviceDetails;
        }

        public void Update(string _id, MobileDeviceEntity mobiledeviceData)
        {
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c._id, _id);
            var update = Builders<MobileDeviceEntity>.Update
                .Set("Name", mobiledeviceData.Name)
                .Set("Company", mobiledeviceData.Company)
                .Set("Color", mobiledeviceData.Color)
                .Set("Cost", mobiledeviceData.Cost);

            mobiledevicecollection.UpdateOne(filter, update);
        }
    }
}
