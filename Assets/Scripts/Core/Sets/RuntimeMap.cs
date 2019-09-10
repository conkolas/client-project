using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeMap<T> : ScriptableObject where T : ScriptableObject
{
    public Dictionary<Type, T> Map = new Dictionary<Type, T>();

    public void Add(Type type, T item)
    {
        Map.Add(type, item);
    }

    public void Remove(Type type)
    {
        if (Map.ContainsKey(type))
            Map.Remove(type);
    }

    public void Remove(T item)
    {
        if (Map.ContainsValue(item)) {
            Dictionary<Type, T>.Enumerator mapIterator =  Map.GetEnumerator();

            while (mapIterator.MoveNext())
                if (mapIterator.Current.Value == item)
                    Map.Remove(mapIterator.Current.Key);
            
			mapIterator.Dispose();
        }
    }

    public void Reset()
    {
        Dictionary<Type, T>.Enumerator mapIterator = Map.GetEnumerator();
        while (mapIterator.MoveNext())
            Destroy(mapIterator.Current.Value);

        mapIterator.Dispose();

        Map.Clear();
    }
}
