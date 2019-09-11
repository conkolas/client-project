using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Chase Player")]
public class ChasePlayerAction : PluggableAction {

    public override void Act(StateController controller) {
        Chase(controller);
    }

    private void Chase(StateController controller) {
        NavMeshAgent agent = controller.Agent;
        agent.destination = controller.PlayerGameObject.transform.position;
        agent.Resume();
    }
}

