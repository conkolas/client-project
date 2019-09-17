using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Chase Player")]
public class ChasePlayerDecision : PluggableDecision
{
    public override bool Decide(StateController controller) {
        return controller.HoverPetID == controller.Pet.ID;
    }
}
