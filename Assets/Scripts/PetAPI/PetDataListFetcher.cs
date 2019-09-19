using System;
using System.Collections;
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

public class PetDataListFetcher : MonoBehaviour {
    public string PostCode = "69351";
    public PetSpecies Species = PetSpecies.DOG;
    public SearchRanges Range = SearchRanges.TWENTY_FIVE;

    [Space(10)]
    public int StartNumber = 1;
    public int EndNumber = 10;

    [Space(10)]
    [Header("Response")]

    [SerializeField]
    private PetDataList _petDataList;
    public PetDataList PetDataList => _petDataList;

    private PetDataListResponse _currentPetDataListResponse;

    private Action _onErrorHandler;
    private Action _onSuccessHandler;

    public void Fetch(Action onSuccessHandler = null, Action onErrorHandler = null) {
        _onErrorHandler = onErrorHandler;
        _onSuccessHandler = onSuccessHandler;
        StartCoroutine(RequestRoutine(0, GetRequestUrl(), PetListResponseCallback));
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
    private static IEnumerator RequestRoutine(int index, string url, Action<int, string> callback = null) {
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                callback?.Invoke(index, request.downloadHandler.text);
            }
        }
    }

    private static IEnumerator RequestTexture(int index, string url, Action<int, Texture2D> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                if (texture != null) {
                    callback?.Invoke(index, texture);
                }
            }
        }
    }

    /*
     * Fetches pet list data
     * More info about specifc pet is fetch using detailsUrl
     */
    private void PetListResponseCallback(int index, string response) {
        _currentPetDataListResponse = JsonConvert.DeserializeObject<PetDataListResponse>(response);

        _petDataList.TotalPets = _currentPetDataListResponse.TotalPets;
        _petDataList.ReturnedExactMatches = _currentPetDataListResponse.ReturnedExactMatches;
        _petDataList.Pets = new PetData[_currentPetDataListResponse.ReturnedExactMatches];
        _petDataList.PhotoTextures = new Texture2D[_currentPetDataListResponse.ReturnedExactMatches];

        if (_currentPetDataListResponse.PetsData == null || _currentPetDataListResponse.PetsData.Length == 0) {
            _onErrorHandler?.Invoke();
            return;
        }

        for (var i = 0; i < _currentPetDataListResponse.PetsData.Length; i++) {
            var pet = _currentPetDataListResponse.PetsData[i];
            if (pet.DetailsUrl.Length <= 0) continue;

            StartCoroutine(RequestTexture(i, pet.PhotoUrl, PetPhotoResponseCallback));
            StartCoroutine(RequestRoutine(i, pet.DetailsUrl, PetResponseCallback));
        }
    }

    /*
     * Deserializes pet specific information and adds to result list
     */
    private void PetResponseCallback(int index, string response) {
        PetResponse petRepsonse = JsonConvert.DeserializeObject<PetResponse>(response);
        _petDataList.Pets[index] = petRepsonse.PetData;

        if (IsFetchCompleted()) {
            _onSuccessHandler?.Invoke();
        }
    }

    private void PetPhotoResponseCallback(int index, Texture2D texture) {
        _petDataList.PhotoTextures[index] = texture;

        if (IsFetchCompleted()) {
            _onSuccessHandler?.Invoke();
        }
    }

    private bool IsFetchCompleted() {
        bool isPetsCompleted = true;
        bool isPhotosCompleted = true;

        for (int i = 0; i < _petDataList.Pets.Length; i++) {
            if (_petDataList.Pets[i] == null) {
                isPetsCompleted = false;
            }

            if (_petDataList.PhotoTextures[i] == null) {
                isPhotosCompleted = false;
            }
        }

        return isPhotosCompleted && isPetsCompleted;
    }
}
