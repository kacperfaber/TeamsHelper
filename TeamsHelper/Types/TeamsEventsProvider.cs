using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class TeamsEventsProvider : ITeamsEventsProvider
    {
        public TeamsApi.TeamsApi TeamsApi;

        public Task<List<TeamsEvent>> ProvideAsync(DateTime day)
        {
            throw new NotImplementedException();
        }
    }
}