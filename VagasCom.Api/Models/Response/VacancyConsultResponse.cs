using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VagasCom.Api.Models.Response
{
    public class VacancyPersonApplicationResponse
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("profissao")]
        public string Profession { get; set; }
        [JsonPropertyName("localizacao")]
        public string Location { get; set; }
        [JsonPropertyName("nivel")]
        public int Level { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }

    }
}
