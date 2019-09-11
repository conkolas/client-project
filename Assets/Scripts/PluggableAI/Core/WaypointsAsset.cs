using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable AI/Waypoint asset")]
public class WaypointsAsset : ScriptableObject {
    public List<Vector3> Waypoints;
}
