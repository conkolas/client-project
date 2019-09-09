using System.Collections.Generic;
using UnityEngine;

public class PetAvatarManager : MonoBehaviour {

    public PetList PetList;
    public PetAvatar PetAvatar;
    public Vector3 AvatarOffset = new Vector3(0, 0.5f, 0);

    private bool _isRunning;
    private List<PetAvatar> _avatars;
    private Vector3 _currentPetScaleOffset;

    private Transform _cameraTransform;

    public void Initialize() {
        _isRunning = true;
        _avatars = new List<PetAvatar>();
        _cameraTransform = Camera.main.transform;

        foreach (var pet in PetList.Pets) {
            PetAvatar avatar = Instantiate(PetAvatar, pet.transform.position, pet.transform.rotation, transform);
            avatar.SetName(pet.Name);
            avatar.SetPhoto(pet.Photo);
            _avatars.Add(avatar);
        }
    }

    private void Update() {
        if (!_isRunning) return;

        for (int i = 0; i < _avatars.Count; i++) {
            _currentPetScaleOffset.y = PetList.Pets[i].transform.localScale.y / 2f;
            _avatars[i].transform.localPosition = PetList.Pets[i].transform.position + AvatarOffset + _currentPetScaleOffset;
            _avatars[i].transform.rotation = Quaternion.LookRotation(_avatars[i].transform.position - _cameraTransform.position);
        }
    }
}
