﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class BootStrapTest
	{
		[Test]
		public void FluentAssertionsAreWorking()
		{
			"Fluent".Should().Be("Fluent");
		}
	}
}
