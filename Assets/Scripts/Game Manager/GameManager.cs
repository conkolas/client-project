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
    public GameObject Crosshair;
    public FirstPersonController PlayerController;
    public Animator FinalStepAnimator;

    private bool _activeWorld;
    private bool _activeEscape;

    public void SetIsActiveWorld(bool state) {
        _activeWorld = state;
        if (!state) {
            Crosshair.SetActive(false);
            FocusedPetID.SetValue(0);
            HoveredPetID.SetValue(0);
            PlayerController.LockPlayer();
        } else {
            PlayerController.UnlockPlayer();;
            Crosshair.SetActive(true);
            RestartButton.SetActive(false);
        }
    }

    public void OnGameEnd() {
        PlayerController.LockPlayer();
        FinalStepAnimator.SetBool("Active", true);
    }

    public void CloseFinalScreen() {
        FinalStepAnimator.SetBool("Active", false);
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
