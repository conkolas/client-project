using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInteractionMenu : MonoBehaviour {

    public Animator Animator;

    public void OpenMenu() {
        Debug.Log("OpenMenu");
        Animator.SetBool("Active", true);
    }

    public void CloseMenu() {
        Animator.SetBool("Active", false);
    }
}
