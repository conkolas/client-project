using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PetAvatar : MonoBehaviour {

    public Image PhotoIcon;
    public IntegerVariable HoveredPetID;
    public IntegerVariable FocusedPetID;
    public UnityEvent OnHover;
    public float DelayAfterInteraction = 2f;

    private Animator _animator;
    private Pet _pet;
    public Pet Pet => _pet;
    public bool Hovered => _animator != null && _animator.GetBool("Hover");
    private bool _blockedInteraction;

    public void Initialize(Pet pet) {
        _pet = pet;
        _blockedInteraction = false;
    }

    public void SetPhoto(Texture2D texture) {
        PhotoIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        UpdateHover();
    }

    private void UpdateHover() {
        if (_blockedInteraction) {
            _animator.SetBool("Hover", false);
            return;
        }

        if (Hovered != (_pet.ID == HoveredPetID)) {
            _animator.SetBool("Hover", _pet.ID == HoveredPetID);
            if (_pet.ID == HoveredPetID) {
                OnHover?.Invoke();
            }
        }
    }

    public void LooseHover() { StartCoroutine(LooseFocusRoutine()); }

    private IEnumerator LooseFocusRoutine() {
        _blockedInteraction = true;
        yield return new WaitForSeconds(DelayAfterInteraction);
        _blockedInteraction = false;
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
