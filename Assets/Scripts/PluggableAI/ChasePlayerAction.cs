using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Chase Player")]
public class ChasePlayerAction : PluggableAction {
    public float TurnSpeed = 10f;
    public float StopDistance = 2.5f;
    public override void Act(StateController controller) {
        Chase(controller);
    }

    private void Chase(StateController controller) {
        NavMeshAgent agent = controller.Agent;

        ContinueChase(agent, controller);
        SitDownIfNeeded(agent, controller);
    }

    private void ContinueChase(NavMeshAgent agent, StateController controller) {
        if (!agent.isStopped) {
            agent.destination = controller.PlayerGameObject.transform.position;
            agent.Resume();
        }
    }

    private void SitDownIfNeeded(NavMeshAgent agent, StateController controller) {
        if (agent.remainingDistance < StopDistance) {
            if (!agent.isStopped) {
                agent.destination = controller.transform.position;
                agent.velocity = Vector3.zero;
                agent.Stop();
            }

            LookAtPlayer(controller);
        } else {
            agent.Resume();
        }
    }

    private void LookAtPlayer(StateController controller) {
        Quaternion rotation = Quaternion.LookRotation(
            (controller.PlayerGameObject.transform.position - controller.transform.position).normalized);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, rotation, Time.deltaTime * TurnSpeed);
    }
}

