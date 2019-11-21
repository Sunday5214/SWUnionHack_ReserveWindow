using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Union_ReserveWindow.Core.Models
{
    public class LoginModel
    {
        [JsonProperty("identity")]
        public string Identity
        {
            get;
            set;
        }
    }
}
