﻿// <copyright file="SkippedStackSpecs.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave.Samples
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Xbehave;

    public class SkippedStackSpecs
    {
        [Scenario]
        public void Push()
        {
            var target = default(Stack<int>);
            var element = default(int);

            "Given an element"
                .Given(() =>
                {
                    element = 11;
                    target = new Stack<int>();
                });

            "when pushing the element"
                .When(() => target.Push(element));

            "then the target should not be empty"
                .ThenSkip(() => target.Should().NotBeEmpty());

            "then the target peek should be the element"
                .ThenSkip(() => target.Peek().Should().Be(element));
        }
    }
}