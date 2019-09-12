using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetAvatar : MonoBehaviour {

    public TextMeshProUGUI NameLabel;
    public Image PhotoIcon;
    public IntegerVariable HoveredPetID;
    public IntegerVariable FocusedPetID;

    private Animator _animator;
    private Pet _pet;

    public void Initialize(Pet pet) {
        NameLabel.text = pet.Name;
        _pet = pet;
    }


    public void SetPhoto(Texture2D texture) {
        PhotoIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        _animator.SetBool("Hover", _pet.ID == FocusedPetID || _pet.ID == HoveredPetID);
    }
}
