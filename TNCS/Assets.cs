namespace TNCS
{

    public class Asset
    {
        public string Id { get; }
        public string Name { get; }
        public byte Decimals { get; }

        public string IdOrNull => Id == "TN" ? null : Id;
        
        private readonly decimal _scale;

        public Asset(string id, string name, byte decimals)
        {
            Id = id;
            Name = name;
            Decimals = decimals;                        
            _scale = new decimal(1, 0, 0, false, decimals);
        }

        public long AmountToLong(decimal amount)
        {            
            return decimal.ToInt64(amount / _scale);
        }
        
        public decimal LongToAmount(long value)
        {            
            return value * _scale;
        }

        public static long AmountToLong(byte digits, decimal amount)
        {
            var scale = new decimal(1, 0, 0, false, digits);
            return decimal.ToInt64(amount / scale);
        }

        public static long PriceToLong(Asset amountAsset, Asset priceAsset, decimal price)
        {
            var decimals =  8 - amountAsset.Decimals + priceAsset.Decimals;
            var scale = new decimal(1, 0, 0, false, (byte) decimals);
            return decimal.ToInt64(price / scale);
        }
        
        public static decimal LongToPrice(Asset amountAsset, Asset priceAsset, long price)
        {
            var decimals =  8 - amountAsset.Decimals + priceAsset.Decimals;
            var scale = new decimal(1, 0, 0, false, (byte) decimals);
            return price * scale;
        }
    }

    public static class Assets
    {
        public static readonly Asset WAVES = new Asset("EzwaF58ssALcUCZ9FbyeD1GTSteoZAQZEDTqBAXHfq8y", "Waves", 8);
        public static readonly Asset TN = new Asset("TN", "TN", 8);
        public static readonly Asset SSYS = new Asset("7tC2ZukogadhvHUdKQyWJ2cbk6T1viTCFJMgevVeTY1Y", "SuperSistem",0);
        public static readonly Asset NATA = new Asset("79jWQxTiV925jubY2c48vwJqVN2z1hU3rXX8uqdhuQnY", "NATA", 2);
        public static readonly Asset SCOM = new Asset("bqs5DvxtTTN3kPQV95q4vjKFSRBcXEsFPuZgvhYkZC5", "SCommunity", 2);


        public static Asset GetById(string assetId, Node node)
        {
            return node.GetAsset(assetId);
        }
    }
}