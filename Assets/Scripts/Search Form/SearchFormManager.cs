using System.Collections;
using System.Collections.Generic;
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
    public PetListFetcher PetListFetcher;

    public void Search() {
        EmptySearchMessage.gameObject.active = false;
        PetListFetcher.PostCode = PostalCodeInput.text;

        switch (RadiusDropdown.value) {
            case 0:
                PetListFetcher.Range = SearchRanges.TWENTY_FIVE;
                break;
            case 1:
                PetListFetcher.Range = SearchRanges.FIFTY;
                break;
            case 2:
                PetListFetcher.Range = SearchRanges.HUNDRED;
                break;
            case 3:
                PetListFetcher.Range = SearchRanges.HUNDRED_FIFTY;
                break;
            case 4:
                PetListFetcher.Range = SearchRanges.TWO_HUNDREDS;
                break;
        }

        if (DogToggle.isOn && !CatToggle.isOn) {
            PetListFetcher.Species = PetSpecies.DOG;
        } else {
            PetListFetcher.Species = PetSpecies.CAT;
        }

        PetListFetcher.Fetch(OnEmptyHandler);
    }

    public void Validate() {
        SearchButton.interactable = PostalCodeInput.text.Length > 4;
    }

    private void OnEmptyHandler() {
        EmptySearchMessage.gameObject.active = true;
    }
}
