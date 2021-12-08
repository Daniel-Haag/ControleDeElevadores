using Newtonsoft.Json;

namespace ControleDeElevadores.Models
{
    class ElevadorModel
    {
        [JsonProperty(PropertyName = "andar")]
        public int Andar { get; set; }
        [JsonProperty(PropertyName = "elevador")]
        public string Elevador { get; set; }
        [JsonProperty(PropertyName = "turno")]
        public string Turno { get; set; }
    }
}
