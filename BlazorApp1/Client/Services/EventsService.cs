using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class EventsService
    {

        public event Action CartUpdated;

        public void NotifyCartUpdated() => CartUpdated?.Invoke();

    }
}
