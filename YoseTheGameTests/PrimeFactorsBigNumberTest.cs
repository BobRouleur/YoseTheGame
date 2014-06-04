using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using YoseTheGame.Controllers;
using YoseTheGame.Models;

namespace YoseTheGameTests
{
    [TestFixture]
    public class PrimeFactorsBigNumberTest
    {
        private BigNumberResponse response = null;

        [SetUp]
        public void ThisModel()
        {
            PrimeFactorsModel model = new PrimeFactorsModel();
            response = (BigNumberResponse)model.Decompose("1000001");
        }

        [Test]
        public void ReturnsSpecifiedNumber()
        {
            Assert.That(response.number, Is.EqualTo(1000001));
        }

        [Test]
        public void ReturnsValidDecomposition()
        {
            Assert.That(response.error, Is.EqualTo("too big number (>1e6)"));
        }
    }
}
