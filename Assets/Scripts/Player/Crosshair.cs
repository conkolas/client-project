using System.Collections;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public IntegerVariable FocusedPetID;
    public IntegerVariable HoveredPetID;
    public PetInfoPanel PetInfoPanel;
    public float ActiveDistance = 2f;
    public float LooseFocusDelay = 2f;

    private Ray _ray;
    private RaycastHit _hoverHit;
    private RaycastHit _focusHit;
    private Camera _camera;
    private Animator _animator;

    private bool _hoverAiming;
    private Pet _hoverPet;
    private GameObject _currentHoverTarget;

    private void Start() {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if (PetInfoPanel.IsOpen) return;

        _ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        _hoverAiming = Physics.Raycast(_ray, out _hoverHit, ActiveDistance, LayerMask.GetMask("PetPointer"));
        _animator.SetBool("Aiming", _hoverAiming);

        _currentHoverTarget = _hoverAiming ? _hoverHit.transform.gameObject : null;
        if (_hoverAiming) {
            _hoverPet = _currentHoverTarget.GetComponentInParent<Pet>();

            if (_hoverPet != null) {
                HoveredPetID.SetValue(_hoverPet.ID);
            } else {
                HoveredPetID.SetValue(0);
            }
        } else {
            HoveredPetID.SetValue(0);
        }
    }
}
