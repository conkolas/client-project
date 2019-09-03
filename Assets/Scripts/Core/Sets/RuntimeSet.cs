using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject where T : MonoBehaviour
{
    public List<T> Items = new List<T>();

    public virtual void Add(T item)
    {
        if (!Items.Contains(item))
            Items.Add(item);
    }

    public virtual void Remove(T item)
    {
        if (Items.Contains(item))
            Items.Remove(item);
    }

    public virtual void Reset() {
		Items.ForEach((item) => Destroy(item));
        Items.Clear();
    }
}
