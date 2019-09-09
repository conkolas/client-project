using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Wonder")]
public class WonderAction : PluggableAction {
    public int MaxTimeToDestination = 10;

    private float _curentWaypointTime = 0f;

    public override void Act(StateController controller) {
        Wonder(controller);
    }

    private void Wonder(StateController controller) {
        _curentWaypointTime += Time.deltaTime;
        NavMeshAgent agent = controller.Agent;
        agent.destination = controller.Waypoints[controller.NextWaypoint];
        agent.Resume();

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending || _curentWaypointTime > MaxTimeToDestination) {
            controller.SetNextWaypoint((controller.NextWaypoint + Random.Range(1, controller.Waypoints.Count)) % controller.Waypoints.Count);
            _curentWaypointTime = 0;
        }
    }
}
