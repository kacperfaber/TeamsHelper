﻿using System;
using System.Linq;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class DisplayNameIsNotTakenValidator : IDisplayNameIsNotTakenValidator
    {
        public HelperContext HelperContext;

        public DisplayNameIsNotTakenValidator(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public Task<bool> ValidateAsync(string displayName)
        {
            return Task.FromResult(true);
        }
    }
}