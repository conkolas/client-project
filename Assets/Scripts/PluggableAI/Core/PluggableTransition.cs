using System;

[Serializable]
public class PluggableTransition {
    public PluggableDecision Decision;
    public PluggableState TrueState;
    public PluggableState FalseState;
}
