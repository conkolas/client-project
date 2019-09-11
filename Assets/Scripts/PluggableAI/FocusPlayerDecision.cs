using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Focus Player")]
public class FocusPlayerDecision : PluggableDecision {
    public override bool Decide(StateController controller) {
        float distance = (controller.transform.position - controller.PlayerGameObject.transform.position)
            .magnitude;
        bool arrivedAndFocused = distance < 2f && controller.FocusPetID == controller.Pet.ID;
        controller.Agent.destination = controller.PlayerGameObject.transform.position;

        return arrivedAndFocused;
    }
}
