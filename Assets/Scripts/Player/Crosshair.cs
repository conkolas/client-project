using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public IntegerVariable FocusedPetID;
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
        _lastCheckTime += Time.deltaTime;
        if (_lastCheckTime < 0.1f) return;
        _lastCheckTime = 0;

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
    }

    private void OnMouseClick() {
        if (_currentClickTarget == null) return;

        Pet pet = _currentClickTarget.GetComponent<Pet>();
        if (pet != null) {
            FocusedPetID.SetValue(pet.ID);
        }
    }
}
