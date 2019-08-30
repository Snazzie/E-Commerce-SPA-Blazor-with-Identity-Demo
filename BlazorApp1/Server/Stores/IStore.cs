using Blazor.Shared;
using System.Collections.Generic;

namespace BlazorApp1.Server.Stores
{
    public interface IStore<T>
    {
        IEnumerable<T> GetAll();
    }
}