using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable AI/State")]
public class PluggableState : ScriptableObject {
    public PluggableAction[] Actions;

    public void UpdateState(StateController controller) {
        DoActions(controller);
    }

    private void DoActions(StateController controller) {
        foreach (var action in Actions) {
            action.Act(controller);
        }
    }
}
