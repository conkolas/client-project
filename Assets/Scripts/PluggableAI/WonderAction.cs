using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable AI/Actions/Wonder")]
public class WonderAction : PluggableAction {
    public int MaxTimeToDestination = 10;
    public int MinWaypointsUntilSit = 2;
    public int MaxWaypointsUntilSit = 8;
    public float MinSittingTime = 1f;
    public float MaxSittingTime = 5f;

    private bool _isSitting;
    private int _waypointsFromLastSitting = 0;
    private float _sittingTime = 0f;
    private float _currentSittingTime = 0f;
    private float _curentWaypointTime = 0f;

    public override void Act(StateController controller) {
        Wonder(controller);
    }

    private void Wonder(StateController controller) {
        NavMeshAgent agent = controller.Agent;

        ContinueWonder(controller, agent);
    }

    private bool DecideToSit() {
        if (!_isSitting && _waypointsFromLastSitting >= Random.Range(MinWaypointsUntilSit, MaxWaypointsUntilSit)) {
            _isSitting = true;
            _sittingTime = 0;
            _waypointsFromLastSitting = 0;
            _currentSittingTime = Random.Range(MinSittingTime, MaxSittingTime);
            return true;
        }

        if (_isSitting && _sittingTime < _currentSittingTime) {
            return true;
        }

        _isSitting = false;
        return false;
    }

    private void DoSitting(StateController controller, NavMeshAgent agent) {
        _sittingTime += Time.deltaTime;
        agent.velocity = Vector3.zero;
        agent.Stop();
    }

    private void ContinueWonder(StateController controller, NavMeshAgent agent) {
        _curentWaypointTime += Time.deltaTime;

        agent.destination = controller.Waypoints[controller.NextWaypoint];
        agent.Resume();

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending || _curentWaypointTime > MaxTimeToDestination) {
            controller.SetNextWaypoint((controller.NextWaypoint + Random.Range(1, controller.Waypoints.Count)) % controller.Waypoints.Count);
            _curentWaypointTime = 0;
            _waypointsFromLastSitting++;
        }
    }
}
