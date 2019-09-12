using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Focus Player")]
public class FocusPlayerAction : PluggableAction {

    public float StopDistance;

    public override void Act(StateController controller) {
        Focus(controller);
    }

    private void Focus(StateController controller) {
        NavMeshAgent agent = controller.Agent;
        if (agent.remainingDistance < StopDistance) {
            agent.velocity = Vector3.zero;
            agent.Stop();
        }

        Quaternion rotation = Quaternion.LookRotation(
            (controller.PlayerGameObject.transform.position - controller.transform.position).normalized);
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, Time.deltaTime);
    }
}
