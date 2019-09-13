using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PetInfoPanel : MonoBehaviour {
    [Header("Data")]
    public PetList PetList;

    public FirstPersonController Controller;
    public IntegerVariable HoveredPetID;

    [Header("UI Elements")]
    public TextMeshProUGUI PetName;
    public TextMeshProUGUI PetBreed;
    public TextMeshProUGUI PetAge;
    public TextMeshProUGUI PetColor;
    public TextMeshProUGUI PetSize;
    public TextMeshProUGUI PetDescription;
    public Image PetPhoto;

    private Animator _animator;
    public bool IsOpen => _animator != null && _animator.GetBool("Active");

    public void OpenPanel() {
        _animator.SetBool("Active", true);
        Controller.LockPlayer();
    }

    public void ClosePanel() {
        _animator.SetBool("Active", false);
        Controller.UnlockPlayer();
    }

    private void Start() {
        _animator = GetComponent<Animator>();
        Controller.UnlockPlayer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && HoveredPetID != 0 && !_animator.GetBool("Active")) {
            Initialize(GetPetByID(HoveredPetID));
            OpenPanel();
        }
    }

    private void Initialize(Pet pet) {
        PetName.text = pet.Name;
        PetBreed.text = pet.Breed;
        PetAge.text = pet.Age;
        PetColor.text = pet.Color;
        PetSize.text = pet.Size;
        PetDescription.text = pet.Description;
        PetPhoto.sprite = Sprite.Create(pet.Photo, new Rect(0, 0, pet.Photo.width, pet.Photo.height), Vector2.zero);
    }

    private Pet GetPetByID(IntegerVariable petID) {
        Pet result = null;
        foreach (var pet in PetList.Pets) {
            if (pet.ID == petID) {
                result = pet;
            }
        }

        return result;
    }
}
