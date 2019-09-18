using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPhotoHoverDetector : MonoBehaviour {
    public float PointerDistance = 5f;
    private PetInfoPanel _infoPanel;
    private Camera _camera;
    private bool _hover;
    private PetAvatar _avatar;
    private RaycastHit _hit;

    void Start() {
        _avatar = GetComponentInParent<PetAvatar>();
        _camera = Camera.main;
        _infoPanel = GameObject.FindGameObjectWithTag("InfoPanel").GetComponent<PetInfoPanel>();
    }

    void Update() {
        if (!_avatar.Hovered) return;

        if(Physics.Raycast (_camera.transform.position, _camera.transform.forward, out _hit, PointerDistance, LayerMask.GetMask("PetPhoto"))) {
            _avatar.SetPhotoHover(true);
            _hover = true;
        } else {
            _avatar.SetPhotoHover(false);
            _hover = false;
        }

        if (Input.GetMouseButtonDown(0) && _hover) {
            _infoPanel.OpenPanel(_avatar.Pet.ID);
        }
    }
}
