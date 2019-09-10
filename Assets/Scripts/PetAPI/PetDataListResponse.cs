using Newtonsoft.Json;

public class PetDataListResponse {
    [JsonProperty("total_pets")]
    public int TotalPets;

    [JsonProperty("returned_exact_matches")]
    public int ReturnedExactMatches;

    [JsonProperty("pets")]
    public PetData[] PetsData;
}