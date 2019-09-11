using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Leave Focus Player")]
public class LeaveFocusPlayerDecision : PluggableDecision {
    public float LeaveFocusDistance = 3f;

    public override bool Decide(StateController controller) {
        if ((controller.PlayerGameObject.transform.position - controller.transform.position)
            .magnitude > LeaveFocusDistance) {
            controller.FocusPetID.SetValue(0);
            return true;
        } else {
            return false;
        }
    }
}
