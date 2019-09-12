using UnityEngine;

public class Crosshair : MonoBehaviour {
    public IntegerVariable FocusedPetID;
    public IntegerVariable HoveredPetID;
    public PetInfoPanel PetInfoPanel;
    public float ActiveDistance = 2f;

    private Ray _ray;
    private RaycastHit _hit;
    private Camera _camera;
    private Animator _animator;

    private bool _aiming;
    private float _lastCheckTime;
    private GameObject _currentClickTarget;

    private void Start() {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if (PetInfoPanel.IsOpen) return;

        SetPointerTarget();

        if (Input.GetMouseButtonDown(0)) {
            OnMouseClick();
        }
    }

    private void SetPointerTarget() {
        _ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        _aiming = Physics.Raycast(_ray, out _hit, ActiveDistance, LayerMask.GetMask("PetPointer"));
        _animator.SetBool("Aiming", _aiming);

        _currentClickTarget = _aiming ? _hit.transform.gameObject : null;
        if (_aiming) {
            Pet pet = _currentClickTarget.GetComponent<Pet>();
            if (pet != null) {
                HoveredPetID.SetValue(pet.ID);
            } else {
                HoveredPetID.SetValue(0);
            }
        } else {
            HoveredPetID.SetValue(0);
        }
    }

    private void OnMouseClick() {
        if (_currentClickTarget == null) return;

        Pet pet = _currentClickTarget.GetComponent<Pet>();
        if (pet != null) {
            FocusedPetID.SetValue(pet.ID);
        }
    }
}
