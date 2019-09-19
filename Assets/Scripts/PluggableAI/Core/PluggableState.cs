using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable AI/State")]
public class PluggableState : ScriptableObject {
    public PluggableAction[] Actions;
    public PluggableTransition[] Transitions;

    public void UpdateState(StateController controller) {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller) {
        if (Actions.Length == 0) return;

        foreach (var action in Actions) {
            action.Act(controller);
        }
    }

    private void CheckTransitions(StateController controller) {
        if (Transitions.Length == 0) return;

        foreach (var transition in Transitions) {
            bool transitionDecision = transition.Decision.Decide(controller);
            controller.ChangeState(transitionDecision ? transition.TrueState : transition.FalseState);
        }
    }
}
