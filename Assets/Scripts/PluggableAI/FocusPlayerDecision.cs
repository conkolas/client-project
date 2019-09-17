using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Focus Player")]
public class FocusPlayerDecision : PluggableDecision {
    public float FocusDistance = 2f;

    public override bool Decide(StateController controller) {
        bool arrivedAndFocused = controller.Agent.remainingDistance < FocusDistance;
        return arrivedAndFocused;
    }
}
