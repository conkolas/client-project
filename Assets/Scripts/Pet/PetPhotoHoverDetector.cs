using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPhotoHoverDetector : MonoBehaviour {
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
        if(Physics.Raycast (_camera.transform.position, _camera.transform.forward, out _hit, 100f, LayerMask.GetMask("PetPhoto"))) {
            _avatar.SetPhotoHover(true);
            _hover = true;
        } else {
            _avatar.SetPhotoHover(false);
            _hover = false;
        }

        if (Input.GetMouseButtonDown(0) && _hover) {
            InfoPanel.OpenPanel(_avatar.Pet.ID);
        }
    }
}
