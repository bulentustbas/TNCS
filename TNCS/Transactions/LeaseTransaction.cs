using System.Collections.Generic;
using System.IO;

namespace TNCS
{
    public class LeaseTransaction : Transaction
    {
        public string Recipient { get; }
        public decimal Amount { get; }
        public decimal Fee { get; }

        public LeaseTransaction(byte[] senderPublicKey, string recipient, decimal amount, decimal fee = 0.02m) : 
            base(senderPublicKey)
        {
            Recipient = recipient;
            Amount = amount;
            Fee = fee;
        }

        public override byte[] GetBody()
        {
            
            using(var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(TransactionType.Lease);
                writer.Write(SenderPublicKey);
                writer.Write(Recipient.FromBase58());
                writer.WriteLong(Assets.TN.AmountToLong(Amount));
                writer.WriteLong(Assets.TN.AmountToLong(Fee));
                writer.WriteLong(Timestamp.ToLong());
                return stream.ToArray();
            }
        }

        public override Dictionary<string, object> GetJson()
        {
            return new Dictionary<string, object> {
                {"type", TransactionType.Lease },
                {"senderPublicKey", SenderPublicKey.ToBase58()},                
                {"recipient", Recipient},
                {"amount", Assets.TN.AmountToLong(Amount)},
                {"fee", Assets.TN.AmountToLong(Fee)},
                {"timestamp", Timestamp.ToLong()}                
            };        
        }

        protected override bool SupportsProofs()
        {
            return false;
        }
    }
}