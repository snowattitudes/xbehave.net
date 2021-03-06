﻿// <copyright file="IStepTest.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Execution
{
    using Xunit.Abstractions;

    public interface IStepTest : ITest
    {
        string ScenarioName { get; }

        int ScenarioNumber { get; }

        int StepNumber { get; }

        string StepName { get; }
    }
}
