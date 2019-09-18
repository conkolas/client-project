using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
    public IntegerVariable FocusedPetID;
    public IntegerVariable HoveredPetID;
    public GameEvent OnGameStart;
    public GameObject RestartButton;
    public FirstPersonController PlayerController;

    private bool _activeWorld;
    private bool _activeEscape;

    public void SetIsActiveWorld(bool state) {
        _activeWorld = state;
        if (!state) {
            PlayerController.LockPlayer();
        } else {
            PlayerController.UnlockPlayer();;
            RestartButton.SetActive(false);
        }
    }

    private void Start()
    {
        FocusedPetID.SetValue(0);
        HoveredPetID.SetValue(0);
        OnGameStart.Raise();
        RestartButton.SetActive(false);
    }

    private void Update() {
        if (!_activeWorld) return;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            _activeEscape = !RestartButton.activeSelf;

            if (_activeEscape) {
                PlayerController.LockPlayer();
            } else {
                PlayerController.UnlockPlayer();
            }
            RestartButton.SetActive(_activeEscape);
        }
    }
}
