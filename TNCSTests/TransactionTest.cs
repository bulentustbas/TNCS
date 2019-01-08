using System;
using System.IO;
using System.Text;
using TNCS;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryObject = System.Collections.Generic.Dictionary<string, object>;
using System.Collections.Generic;

namespace TNCSTests
{
    [TestClass]
    public class TransactionTest
    {
        private static readonly decimal AMOUNT = 105m;
        private static readonly decimal FEE = 0.02m;

        private static readonly JsonSerializer serializer = new JsonSerializer();
        
        public TestContext TestContext { get; set; }
        

        [TestMethod]
        public void SmokeTest()
        {
            // change privatekey
            var account = PrivateKeyAccount.CreateFromPrivateKey("CMLwxbMZJMztyTJ6Zkos66cgU7DybfFJfyJtTVpme54t", AddressEncoding.MainNet);
            var recipient = "3JySFi8GBmrZM2hg4wADKx6GTJ6gNoMz2vT";
            var asset = Assets.TN;
            var transactionId = "TransactionTransactionTransactio";

            var recipients = new List<MassTransferItem>
            {
                new MassTransferItem(recipient, AMOUNT),
                new MassTransferItem(recipient, AMOUNT)
            };

            Dump("alias", new AliasTransaction(account.PublicKey, "daphnie", AddressEncoding.TestNet, FEE));
            Dump("burn", new BurnTransaction(account.PublicKey, asset, AMOUNT, FEE));
            Dump("issue", new IssueTransaction(account.PublicKey, "Pure Gold", "Gold backed asset", AMOUNT, 8, true, FEE));
            Dump("reissue", new ReissueTransaction(account.PublicKey, asset, AMOUNT, false, FEE));
            Dump("lease", new LeaseTransaction(account.PublicKey, recipient, AMOUNT, FEE));
            Dump("lease cancel", new CancelLeasingTransaction(account.PublicKey, transactionId, FEE));
            Dump("xfer", new TransferTransaction(account.PublicKey, recipient, asset, AMOUNT, "Shut up & take my money"));
            Dump("massxfer", new MassTransferTransaction(account.PublicKey, asset, recipients, "Shut up & take my money", FEE));
        }

        private void Dump(String header, Transaction transaction)
        {
            TestContext.WriteLine("*** " + header + " ***");

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            serializer.Serialize(sw, transaction);
            var json = sb.ToString();
            TestContext.WriteLine("Transaction data: " + json);

            TestContext.WriteLine("");
        }
    }
}

