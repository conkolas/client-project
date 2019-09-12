using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Focus Player")]
public class FocusPlayerAction : PluggableAction {

    public float FollowRotation = 10f;

    public override void Act(StateController controller) {
        Focus(controller);
    }

    private void Focus(StateController controller) {
        NavMeshAgent agent = controller.Agent;
        if (agent.remainingDistance < 2f) {
            agent.velocity = Vector3.zero;
            agent.updatePosition = false;
            agent.Stop();
        }

        Quaternion rotation = Quaternion.LookRotation(controller.PlayerGameObject.transform.position - controller.transform.position);
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, Time.deltaTime * FollowRotation);
    }
}
