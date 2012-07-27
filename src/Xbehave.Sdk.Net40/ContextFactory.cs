﻿// <copyright file="ContextFactory.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xbehave.Sdk.Infrastructure;
    using Xunit.Sdk;

    public partial class ContextFactory
    {
        public IEnumerable<Context> CreateContexts(IMethodInfo method, IEnumerable<Type> genericTypes, IEnumerable<object> args, IEnumerable<Step> steps)
        {
            var sharedContext = new List<Step>();
            var pendingYield = false;
            foreach (var step in steps)
            {
                if (step.InIsolation)
                {
                    yield return new Context(method, genericTypes, args, sharedContext.ToList().Concat(step));
                    pendingYield = false;
                }
                else
                {
                    sharedContext.Add(step);
                    pendingYield = true;
                }
            }

            if (pendingYield)
            {
                yield return new Context(method, genericTypes, args, sharedContext);
            }
        }
    }
}