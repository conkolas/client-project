using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    protected Stack<GameObject> m_FreeInstances = new Stack<GameObject>();
    protected Stack<Transform> m_FreeInstancesTransforms = new Stack<Transform>();

    protected GameObject m_Original;

    public ObjectPool(GameObject original, int initialSize)
    {
        m_Original = original;
        m_FreeInstances = new Stack<GameObject>(initialSize);
        m_FreeInstancesTransforms = new Stack<Transform>(initialSize);

        for (int i = 0; i < initialSize; ++i)
        {
            GameObject obj = Object.Instantiate(original);
            obj.SetActive(false);
            m_FreeInstances.Push(obj);
            m_FreeInstancesTransforms.Push(obj.transform);
        }
    }

    public GameObject Get()
    {
        return Get(Vector3.zero, Quaternion.identity);
    }

    public GameObject Get(Vector3 pos, Quaternion quat)
    {
        GameObject ret = m_FreeInstances.Count > 0 ? m_FreeInstances.Pop() : Object.Instantiate(m_Original);
        Transform trans = m_FreeInstancesTransforms.Count > 0 ? m_FreeInstancesTransforms.Pop() : Object.Instantiate(m_Original.transform);

        ret.SetActive(true);
        trans.position = pos;
        trans.rotation = quat;

        return ret;
    }

    public void Free(GameObject obj)
    {
        obj.transform.SetParent(null);
        obj.SetActive(false);
        m_FreeInstances.Push(obj);
        m_FreeInstancesTransforms.Push(obj.transform);
    }
}
