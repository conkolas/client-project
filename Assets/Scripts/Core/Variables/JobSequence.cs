using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobSequence<T> : ScriptableObject {
    public abstract void StartJob(T source);
}
