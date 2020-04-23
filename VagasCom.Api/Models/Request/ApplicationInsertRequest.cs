using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VagasCom.Api.Models.Request
{
    public class ApplicationInsertRequest
    {
        [JsonPropertyName("id_vaga")]
        public int VacancyId { get; set; }
        [JsonPropertyName("id_pessoa")]
        public int PersonId { get; set; }
    }
}
