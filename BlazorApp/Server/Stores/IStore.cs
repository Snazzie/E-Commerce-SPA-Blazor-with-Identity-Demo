using Blazor.Shared;
using System.Collections.Generic;

namespace Blazor.Server.Stores
{
    public interface IStore<T>
    {
        IEnumerable<T> Get(IEnumerable<string> skus);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(int pageIndex, int pageSize);
        int TotalPages(int pageSize);
    }
}