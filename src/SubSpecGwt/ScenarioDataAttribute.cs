﻿// <copyright file="ScenarioDataAttribute.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace SubSpec
{
    using Xunit.Extensions;

    /// <summary>
    /// Provides a data source for a scenario, with the data coming from inline values.
    /// This attribute is designed as a synonym of <see cref="Xunit.Extensions.InlineDataAttribute"/>,
    /// which is the most commonly used data attribute, but you can also use any type of attribute derived from
    /// <see cref="Xunit.Extensions.DataAttribute"/> to provide a data source for a scenario.
    /// E.g. <see cref="Xunit.Extensions.ClassDataAttribute"/>,
    /// <see cref="Xunit.Extensions.OleDbDataAttribute"/>,
    /// <see cref="Xunit.Extensions.SqlServerDataAttribute"/>,
    /// <see cref="Xunit.Extensions.ExcelDataAttribute"/> or
    /// <see cref="Xunit.Extensions.PropertyDataAttribute"/>.
    /// </summary>
    public class ScenarioDataAttribute : InlineDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioDataAttribute"/> class.
        /// This attribute is designed as a synonym of <see cref="Xunit.Extensions.InlineDataAttribute"/>,
        /// which is the most commonly used data attribute, but you can also use any type of attribute derived from
        /// <see cref="Xunit.Extensions.DataAttribute"/> to provide a data source for a scenario.
        /// E.g. <see cref="Xunit.Extensions.ClassDataAttribute"/>,
        /// <see cref="Xunit.Extensions.OleDbDataAttribute"/>,
        /// <see cref="Xunit.Extensions.SqlServerDataAttribute"/>,
        /// <see cref="Xunit.Extensions.ExcelDataAttribute"/> or
        /// <see cref="Xunit.Extensions.PropertyDataAttribute"/>.
        /// </summary>
        /// <param name="dataValues">The data values to pass to the scenario.</param>
        public ScenarioDataAttribute(params object[] dataValues)
            : base(dataValues)
        {
        }
    }
}
