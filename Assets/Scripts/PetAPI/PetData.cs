using System;
using Newtonsoft.Json;

[Serializable]
public class PetData {
    [JsonProperty("addr_city")] public string AddressCity;
    [JsonProperty("addr_line_1")] public string AddressLine1;
    [JsonProperty("addr_line_2")] public string AddressLine2;
    [JsonProperty("addr_postal_code")] public string AddressPostalCode;
    [JsonProperty("addr_state_code")] public string AddressState;
    [JsonProperty("addr_country_code")] public string AddressCountryCode;
    [JsonProperty("shelter_name")] public string ShelterName;
    [JsonProperty("species")] public string Species;
    [JsonProperty("sex")] public string Sex;
    [JsonProperty("primary_breed")] public string PrimaryBreed;
    [JsonProperty("secondary_breed")] public string SecondaryBreed;
    [JsonProperty("age")] public string Age;
    [JsonProperty("size")] public string Size;
    [JsonProperty("color")] public string Color;
    [JsonProperty("contact_person")] public string ContactPerson;
    [JsonProperty("description")] public string Description;
    [JsonProperty("pet_code")] public string PetCode;
    [JsonProperty("pet_id")] public int PetID;
    [JsonProperty("pet_name")] public string PetName;
    [JsonProperty("purebred")] public string Purebred;
    [JsonProperty("website_url")] public string WebsiteUrl;
    [JsonProperty("details_url")] public string DetailsUrl;
    [JsonProperty("images")] public ImageResponse[] Images;
}