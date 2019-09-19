using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchFormManager : MonoBehaviour {
    public TMP_InputField PostalCodeInput;
    public TMP_Dropdown RadiusDropdown;
    public Toggle DogToggle;
    public Toggle CatToggle;
    public Button SearchButton;
    public TMP_Text EmptySearchMessage;
    public PetDataListFetcher PetDataListFetcher;

    [Header("Pagination")]
    public int EndIndex = 10;
    public int StartIndex = 1;

    [Header("Events")]
    public GameEvent OnSearchError;
    public GameEvent OnSearchSuccess;

    private Animator _animator;

    private TMP_Text _searchButtonText;
    /*
     * Applies values to PetListFetch from search form fields and fetches new data
     */
    public void Search() {
        _searchButtonText = SearchButton.GetComponentInChildren<TMP_Text>();
        _searchButtonText.text = "Loading";
        SearchButton.interactable = false;
        EmptySearchMessage.gameObject.active = false;

        PetDataListFetcher.PostCode = PostalCodeInput.text;
        PetDataListFetcher.EndNumber = EndIndex;
        PetDataListFetcher.StartNumber = StartIndex;

        if (RadiusDropdown.value == 0)
            PetDataListFetcher.Range = SearchRanges.TWENTY_FIVE;
        else if (RadiusDropdown.value == 1) {
            PetDataListFetcher.Range = SearchRanges.FIFTY;
        } else if (RadiusDropdown.value == 2) {
            PetDataListFetcher.Range = SearchRanges.HUNDRED;
        } else if (RadiusDropdown.value == 3) {
            PetDataListFetcher.Range = SearchRanges.HUNDRED_FIFTY;
        } else if (RadiusDropdown.value == 4) {
            PetDataListFetcher.Range = SearchRanges.TWO_HUNDREDS;
        }

        if (DogToggle.isOn && !CatToggle.isOn) {
            PetDataListFetcher.Species = PetSpecies.DOG;
        } else {
            PetDataListFetcher.Species = PetSpecies.CAT;
        }

        PetDataListFetcher.Fetch(OnSuccessHandler, OnErrorHandler);
    }

    public void OpenLink() {
        int radius = 25;
        if (RadiusDropdown.value == 0)
            radius = 25;
        else if (RadiusDropdown.value == 1) {
            radius = 50;
        } else if (RadiusDropdown.value == 2) {
            radius = 150;
        } else if (RadiusDropdown.value == 3) {
            radius = 200;
        }

        string species = DogToggle.isOn && !CatToggle.isOn ? "dog" : "cat";
        string url =
            $"https://theshelterpetproject.org/pet-search/?zip={PetDataListFetcher.PostCode}&radius={radius}&species={species}&resultPage=1";
        Application.OpenURL(url);
    }

    public void ShowSearchForm() {
        _animator.SetBool("Active", true);
    }

    public void HideSearchForm() {
        _animator.SetBool("Active", false);
    }

    private void Start() { _animator = GetComponent<Animator>(); }

    /*
     * Toggles search button active when postal code is sufficient length
     */
    public void Validate() {
        SearchButton.interactable = PostalCodeInput.text.Length > 3;
    }

    private void OnSuccessHandler() {
        _searchButtonText.text = "Search";
        SearchButton.interactable = true;
        OnSearchSuccess.Raise();
    }

    private void OnErrorHandler() {
        _searchButtonText.text = "Search";
        SearchButton.interactable = true;
        OnSearchError.Raise();
    }
}
