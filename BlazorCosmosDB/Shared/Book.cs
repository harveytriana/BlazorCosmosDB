// ******************************
// Blog BlazorSpread
// @__harveyt__
// ******************************
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorCosmosDB.Shared
{
    public class Book
    {
        // CosmosDB requires id in container 
        // CosmosDB uses Newtonsoft
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public string ISBN { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        // ** PartitionKey: automated setting the server country 
        public string Partition { get; set; }

        public override string ToString() => $"{Title}, {Author}";
    }
}
