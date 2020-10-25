using System;

namespace TeamsHelper.WebApp
{
    public interface ICancelledAnnotateGenerator
    {
        string Generate(DateTime dateTime);
    }
}