using Blazor.Extensions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public class EventsService : IEventService
    {
        public EventsService()
        {
        }


        public event Action CartUpdated;

        public void NotifyCartUpdated() => CartUpdated?.Invoke();

    }

    public interface IEventService
    {
        void NotifyCartUpdated();
        event Action CartUpdated;
    }
}
