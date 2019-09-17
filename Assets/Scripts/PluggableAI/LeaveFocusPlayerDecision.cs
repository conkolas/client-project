using UnityEngine;

[CreateAssetMenu (menuName = "Pluggable AI/Decisions/Leave Focus Player")]
public class LeaveFocusPlayerDecision : PluggableDecision {
    public float LeaveFocusDistance = 2f;

    public override bool Decide(StateController controller) {
        if (!((controller.PlayerGameObject.transform.position - controller.transform.position)
              .magnitude > LeaveFocusDistance)) return false;

        return true;
    }
}
