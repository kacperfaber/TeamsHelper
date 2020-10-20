using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface ITeamsEventsProvider
    {
        Task<List<TeamsEvent>> ProvideAsync(DateTime day);
    }
}