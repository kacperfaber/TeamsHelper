using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface ITeamsEventsProvider
    {
        Task<List<TeamsEvent>> ProvideAsync(DateTime day);
    }
}