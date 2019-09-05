using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public enum PetSpecies {
    DOG,
    CAT
}

public enum SearchRanges {
    TWENTY_FIVE = 25,
    FIFTY = 50,
    HUNDRED = 100,
    HUNDRED_FIFTY = 150,
    TWO_HUNDREDS = 200
}

public class PetListFetcher : MonoBehaviour {
    public string PostCode = "69351";
    public PetSpecies Species = PetSpecies.DOG;
    public SearchRanges Range = SearchRanges.TWENTY_FIVE;

    [Space(10)]
    public int StartNumber = 1;
    public int EndNumber = 10;

    [Space(10)]
    [Header("Response")]

    [SerializeField]
    private PetList _petList;
    public PetList PetList => _petList;

    private PetListResponse _currentPetListResponse;

    private Action _onErrorHandler;
    private Action _onSuccessHandler;

    private void Awake() {
        _petList = ScriptableObject.CreateInstance<PetList>();
    }

    public void Fetch(Action onSuccessHandler = null, Action onErrorHandler = null) {
        _onErrorHandler = onErrorHandler;
        _onSuccessHandler = onSuccessHandler;
        StartCoroutine(RequestRoutine(GetRequestUrl(), PetListResponseCallback));
    }

    /*
     * Returns formatted url from public parameters
     */
    private string GetRequestUrl() {
        return
            "https://theshelterpetproject.org/wp-content/themes/shelter-pet-project/pet-search/php/" +
            "fetch-pets.php?v=2.5&output=json" +
            $"&city_or_zip={PostCode}" +
            $"&geo_range={(int) Range}" +
            $"&species={Species}" +
            $"&start_number={StartNumber}" +
            $"&end_number={EndNumber}";
    }

    /*
     * Sends GET request to provided url and calls a callback action with a response string
     */
    private IEnumerator RequestRoutine(string url, Action<string> callback = null) {
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();

            if (callback != null) {
                callback(request.downloadHandler.text);
            }
        }
    }

    /*
     * Fetches pet list data
     * More info about specifc pet is fetch using detailsUrl
     */
    private void PetListResponseCallback(string response) {
        _currentPetListResponse = JsonConvert.DeserializeObject<PetListResponse>(response);

        _petList.Pets = new List<PetData>();
        _petList.TotalPets = _currentPetListResponse.TotalPets;
        _petList.ReturnedExactMatches = _currentPetListResponse.ReturnedExactMatches;

        if (_currentPetListResponse.PetsData == null || _currentPetListResponse.PetsData.Length == 0) {
            _onErrorHandler?.Invoke();
            return;
        }

        for (int i = 0; i < _currentPetListResponse.PetsData.Length; i++) {
            if (_currentPetListResponse.PetsData[i].DetailsUrl.Length > 0) {
                StartCoroutine(RequestRoutine(_currentPetListResponse.PetsData[i].DetailsUrl, PetResponseCallback));
            }
        }
    }

    /*
     * Deserializes pet specific information and adds to result list
     */
    private void PetResponseCallback(string response) {
        PetResponse petRepsonse = JsonConvert.DeserializeObject<PetResponse>(response);
        _petList.Pets.Add(petRepsonse.PetData);

        if (_petList.Pets.Count == _currentPetListResponse.PetsData.Length) {
            _onSuccessHandler?.Invoke();
        }
    }
}
