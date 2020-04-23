using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VagasCom.Domain.Models.Request
{
    public class PeopleInsertRequest
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("profissao")]
        public string Profession { get; set; }
        [JsonPropertyName("localizacao")]
        public string Location { get; set; }
        [JsonPropertyName("nivel")]
        public int Level { get; set; }
    }
}
