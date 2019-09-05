using Newtonsoft.Json;

public class PetResponse {
    [JsonProperty("pet")]
    public PetData PetData;
}