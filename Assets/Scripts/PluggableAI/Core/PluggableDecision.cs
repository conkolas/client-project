using UnityEngine;

public abstract class PluggableDecision : ScriptableObject {
    public abstract bool Decide(StateController controller);
}
