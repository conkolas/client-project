using UnityEngine;

public abstract class PluggableAction : ScriptableObject {
    public abstract void Act(StateController controller);
}
