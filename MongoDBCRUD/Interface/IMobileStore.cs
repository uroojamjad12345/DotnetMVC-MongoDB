using MongoDB.Driver;
using MongoDBCRUD.Models;

namespace MongoDBCRUD.Interface
{
    public interface IMobileStore
    {
        IMongoCollection<MobileDeviceEntity> mobiledevicecollection { get; }
        IEnumerable<MobileDeviceEntity> GetAllMobileDevices();
        MobileDeviceEntity GetMobileDeviceDetails(string Name);
        void Create(MobileDeviceEntity mobiledeviceData);
        void Update(string _id,MobileDeviceEntity mobiledeviceData);
        void Delete(string Name);

    }
}
