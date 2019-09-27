using Blazor.Shared;
using System.Collections.Generic;

namespace Blazor.Server.Stores
{
    public interface IStore<T>
    {
        IEnumerable<T> GetAll();
    }
}