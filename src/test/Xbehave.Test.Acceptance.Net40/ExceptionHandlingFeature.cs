﻿// <copyright file="ExceptionHandlingFeature.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave.Test.Acceptance
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xbehave.Test.Acceptance.Infrastructure;
    using Xunit;
    using Xunit.Sdk;

    // In order to prevent infinite loops in test runners
    // As a developer
    // I want an exception thrown when creating steps from a scenario to be handled as a test failure
    public static class ExceptionHandlingFeature
    {
        [Scenario]
        public static void ExecutingAScenarioWithInvalidExamples()
        {
            var feature = default(Type);
            var exception = default(Exception);
            var results = default(MethodResult[]);

            "Given a feature with a scenario with invalid examples"
                .Given(() => feature = typeof(FeatureWithAScenarioWithInvalidExamples));

            "When the test runner runs the feature"
                .When(() => exception = Record.Exception(() => results = TestRunner.Run(feature).ToArray()));

            "Then no exception should be thrown"
                .Then(() => exception.Should().BeNull());

            "And the results should not be empty"
                .And(() => results.Should().NotBeEmpty());

            "And the results should be failures"
                .And(() => results.Should().ContainItemsAssignableTo<FailedResult>());
        }

        [Scenario]
        public static void ExecutingAScenarioDefinitionWhichThrowsAnException()
        {
            var feature = default(Type);
            var exception = default(Exception);
            var results = default(MethodResult[]);

            "Given a feature with a scenario definition which throws an exception"
                .Given(() => feature = typeof(FeatureWithAScenarioDefinitionWhichThrowsAnException));

            "When the test runner runs the feature"
                .When(() => exception = Record.Exception(() => results = TestRunner.Run(feature).ToArray()));

            "Then no exception should be thrown"
                .Then(() => exception.Should().BeNull());

            "And the results should not be empty"
                .And(() => results.Should().NotBeEmpty());

            "And the results should be failures"
                .And(() => results.Should().ContainItemsAssignableTo<FailedResult>());
        }

        private static class FeatureWithAScenarioWithInvalidExamples
        {
            [Scenario]
            [Example("a")]
            public static void Scenario(int i)
            {
            }
        }

        private static class FeatureWithAScenarioDefinitionWhichThrowsAnException
        {
            [Scenario]
            public static void Scenario()
            {
                throw new InvalidOperationException();
            }
        }
    }
}
