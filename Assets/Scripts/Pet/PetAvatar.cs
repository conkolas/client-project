using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetAvatar : MonoBehaviour {

    public Image PhotoIcon;
    public IntegerVariable HoveredPetID;
    public IntegerVariable FocusedPetID;

    private Animator _animator;
    private Pet _pet;
    public Pet Pet => _pet;
    public bool Hovered => _animator != null && _animator.GetBool("Hover");

    public void Initialize(Pet pet) {
        _pet = pet;
    }

    public void SetPhoto(Texture2D texture) {
        PhotoIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        _animator.SetBool("Hover", _pet.ID == HoveredPetID);
    }

    public void SetPhotoHover(bool state) {
        _animator.SetBool("PhotoHover", state);
    }

    public void SetSitButtonHover(bool state) {
        _animator.SetBool("SitButtonHover", state);
    }

    public void SetJumpButtonHover(bool state) {
        _animator.SetBool("JumpButtonHover", state);
    }

    public void SetPetButtonHover(bool state) {
        _animator.SetBool("PetButtonHover", state);
    }


}
