using Newtonsoft.Json;

public class PetListResponse {
    [JsonProperty("total_pets")]
    public int TotalPets;

    [JsonProperty("returned_exact_matches")]
    public int ReturnedExactMatches;

    [JsonProperty("pets")]
    public Pet[] Pets;
}