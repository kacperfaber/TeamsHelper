using System;
using System.Collections.Generic;
using System.Linq;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class SynchronizationGenerator : ISynchronizationGenerator
    {
        public ISynchronizationEventsGenerator EventsGenerator;

        public SynchronizationGenerator(ISynchronizationEventsGenerator eventsGenerator)
        {
            EventsGenerator = eventsGenerator;
        }

        public Synchronization Generate(HelperResult result, User user)
        {
            return new Synchronization
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UserId = user.Id,
                Events = EventsGenerator.Generate(result).ToList()
            };
        }
    }
}