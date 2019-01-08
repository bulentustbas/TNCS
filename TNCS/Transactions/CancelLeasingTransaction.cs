using System.Collections.Generic;
using System.IO;

namespace TNCS
{
    public class CancelLeasingTransaction : Transaction
    {
        public string TransactionId { get; }
        public decimal Fee { get; }

        public CancelLeasingTransaction(byte[] senderPublicKey, string transactionId, decimal fee = 0.02m) : 
            base(senderPublicKey)
        {
            TransactionId = transactionId;
            Fee = fee;
        }

        public override byte[] GetBody()
        {
            using(var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(TransactionType.LeaseCancel);
                writer.Write(SenderPublicKey);
                writer.WriteLong(Assets.TN.AmountToLong(Fee));
                writer.WriteLong(Timestamp.ToLong());
                writer.Write(TransactionId.FromBase58());
                return stream.ToArray();
            }            
        }

        public override Dictionary<string, object> GetJson()
        {
            return new Dictionary<string, object>
            {
                {"type", TransactionType.LeaseCancel},
                {"senderPublicKey", SenderPublicKey.ToBase58()},
                {"leaseId", TransactionId},
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