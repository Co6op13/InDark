using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PoolMono<T> where T : MonoBehaviour
{
    private string tag;
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;
    public string Tag { get => prefab.name; set => tag = prefab.name; }

    public PoolMono( T prefab, int count, Transform conteiner)
    {
        this.prefab = prefab;
        this.container = container;

        this.Createpool(count);
    }

    private void Createpool(int count)
    {
        this.pool = new List<T>();
        for( int i =0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObjetc = Object.Instantiate(this.prefab, this.container);
        createdObjetc.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObjetc);
        return createdObjetc;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement ()
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
        {
            return this.CreateObject(true);
        }

        throw new System.Exception($"There is no free elements of this type {typeof(T)}");
    }
}
