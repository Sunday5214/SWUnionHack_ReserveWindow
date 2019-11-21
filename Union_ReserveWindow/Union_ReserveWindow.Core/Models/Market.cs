using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Union_ReserveWindow.Core.Models
{
    public class Markets
    {
        [JsonProperty("markets")]
        public List<Market> MarketList
        {
            get;
            set;
        }
    }

    public class Market
    {
        [JsonProperty("market_id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("location")]
        public string Location
        {
            get;
            set;
        }

        [JsonProperty("tel_num")]
        public string Tell
        {
            get;
            set;
        }

        [JsonIgnore]
        public string Image
        {
            get;
            set;
        }
    }
}
