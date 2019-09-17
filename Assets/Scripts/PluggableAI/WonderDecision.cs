using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Wonder")]
public class WonderDecision : PluggableDecision {
    public override bool Decide(StateController controller) {
        return controller.FocusPetID != controller.Pet.ID && controller.HoverPetID != controller.Pet.ID;
    }
}