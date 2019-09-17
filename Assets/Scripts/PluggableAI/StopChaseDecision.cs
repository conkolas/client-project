using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Stop Chase")]
public class StopChaseDecision : PluggableDecision {
    public override bool Decide(StateController controller) {
        return controller.HoverPetID != controller.Pet.ID;
    }
}