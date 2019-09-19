using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Focus Player")]
public class FocusPlayerAction : PluggableAction {

    public float TurnSpeed = 10f;

    public override void Act(StateController controller) {
        Focus(controller);
    }

    private void Focus(StateController controller) {
        NavMeshAgent agent = controller.Agent;
        if (!agent.isStopped) {
            agent.destination = controller.transform.position;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }

        Quaternion rotation = Quaternion.LookRotation(
            (controller.PlayerGameObject.transform.position - controller.transform.position).normalized);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, rotation, Time.deltaTime * TurnSpeed);
    }
}
