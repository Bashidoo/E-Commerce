using E_Comemrce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class MyDB
    {
        [JsonPropertyName("users")]
        public List<CardInfo> AllUsersFromDB { get; set; } = new List<CardInfo>();


    }
}
