using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SitDownInteraction : MonoBehaviour {
    public float PointerDistance = 5f;
    public PetInfoPanel InfoPanel;
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
            LayerMask.GetMask("SitButton"))) {
            _avatar.SetSitButtonHover(true);
            _hover = true;
        } else {
            _avatar.SetSitButtonHover(false);
            _hover = false;
        }

        if (Input.GetMouseButtonDown(0) && _hover) {
        }
    }
}