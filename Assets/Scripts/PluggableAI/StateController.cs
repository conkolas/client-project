using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateController : MonoBehaviour {
    public PluggableState CurrentState;

    [Header("Waypoints")]
    public Transform PlayGroundTransform;
    public float WaypointRadius = 1;
    public float DisplayRadius = 1;
    public bool WaypointDebug = false;

    private bool _isActive = true;

    private NavMeshAgent _agent;
    public NavMeshAgent Agent => _agent;

    private WaypointsAsset _waypoints;
    public List<Vector3> Waypoints => _waypoints.Waypoints;

    private int _nextWaypoint = 0;
    public int NextWaypoint => _nextWaypoint;

    public void SetupAI(bool active) {
        _isActive = active;
        _agent.enabled = _isActive;
    }

    public void SetNextWaypoint(int waypoint) {
        _nextWaypoint = waypoint;
    }

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _waypoints = ScriptableObject.CreateInstance<WaypointsAsset>();
        _waypoints.Waypoints = PoissonDiscSampling.Generate3D(WaypointRadius,
            new Vector2(PlayGroundTransform.localScale.x, PlayGroundTransform.localScale.z));

        List<Vector3> navMeshWaypoints = new List<Vector3>();
        for (int i = 0; i < _waypoints.Waypoints.Count; i++) {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(_waypoints.Waypoints[i], out hit, 100f, NavMesh.AllAreas)) {
                navMeshWaypoints.Add(hit.position);
            }
        }

        _waypoints.Waypoints = navMeshWaypoints;
    }

    private void Update() {
        if (!_isActive) return;

        CurrentState.UpdateState(this);
    }

    private void OnDrawGizmos() {
        if (!WaypointDebug || (_waypoints == null || _waypoints.Waypoints == null)) return;

        foreach (Vector3 point in _waypoints.Waypoints) {
            Gizmos.DrawSphere(point, DisplayRadius);
        }
    }
}
