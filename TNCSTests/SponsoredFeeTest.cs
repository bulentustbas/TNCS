using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TNCS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TNCSTests
{
    [TestClass]
    public class SponsoredFeeTest
    {
        [TestInitialize]
        public void Init()
        {
            Http.Tracing = true;
        }

        [TestMethod]
        public void TestSponsoredFeeTransaction()
        {
            var node = new Node();                             
           
            Asset asset = Assets.GetById("3xEkwjCavAq9hKdi5awW1Mb931TtrneMeM6F8RKHUogY", node);
            var minimalFeeInAssets = 0.0001m;
            string transaction = node.SponsoredFeeForAsset(Accounts.Alice, asset, minimalFeeInAssets);
            Assert.IsNotNull(transaction);

        }
    }
}
