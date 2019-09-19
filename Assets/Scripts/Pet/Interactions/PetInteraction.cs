using UnityEngine;
using UnityEngine.Events;

public class PetInteraction : MonoBehaviour {
    public float PointerDistance = 5f;
    public UnityEvent OnClick;

    private Camera _camera;
    private bool _hover;
    private PetAvatar _avatar;
    private RaycastHit _hit;

    void Start() {
        _avatar = GetComponentInParent<PetAvatar>();
        _camera = Camera.main;
    }

    void Update() {
        if (!_avatar.Hovered) return;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, PointerDistance,
            LayerMask.GetMask("PetButton"))) {
            _avatar.SetPetButtonHover(true);
            _hover = true;
        } else {
            _avatar.SetPetButtonHover(false);
            _hover = false;
        }

        if (Input.GetMouseButtonDown(0) && _hover) {
            _avatar.Pet.PetAction();
            OnClick?.Invoke();
        }
    }
}