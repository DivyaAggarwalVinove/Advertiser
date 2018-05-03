using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertiser
{
    public interface IDataStore<T>
    {
        Task<ItemDetails> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> SendInformation(CustomerDetail customerDetail, int id);
    }
}