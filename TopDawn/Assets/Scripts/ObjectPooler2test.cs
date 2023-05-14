using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ObjectPooler2test<T>: MonoBehaviour where T: MonoBehaviour
{
    [System.Serializable, ExecuteAlways]
    public class Pool<P> where P : MonoBehaviour
    {
        private string tag;
        public P prefab;
        public int size;
        public bool autoExpand = false;

        [SerializeField] public string Tag { get => prefab.name; set => tag = prefab.name; }
    }


    [SerializeField] protected Transform container;
    public List<Pool<T>> pools;
    [SerializeField] public Dictionary<string, List<T>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, List<T>>();

        foreach (Pool<T> pool in pools)
        {
            List<T> objectPool = new List<T>();

            for (int i = 0; i < pool.size; i++)
            {
                var newObject = CreateObject(pool.prefab);
                objectPool.Add(newObject);
            }
            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    private T CreateObject(T prefab, bool isActiveByDefault = false)
    {
        var createdObjetc = Object.Instantiate(prefab, container);
        createdObjetc.gameObject.SetActive(isActiveByDefault);
        //poolDictionary[prefab.name].Add(createdObjetc);

        return createdObjetc;
    }

    private bool HasFreeElement(string tag, out T element)
    {
        element = null;
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag = " + tag + " doesn't exist!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return false;
        }

        foreach (var obj in poolDictionary[tag])
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                element = obj;
                return true;
            }
        }        
        return false;
    }

    public T GetFromPool(string tag, bool isActiveByDefault = false)
    {
        if (HasFreeElement(tag, out var element))
            return element;

        foreach (var p in pools)
        {
            if ((p.Tag == tag) && (p.autoExpand))
            {

                var newElement = CreateObject(p.prefab, isActiveByDefault);
                poolDictionary[tag].Add(newElement);
                return newElement;
            }
        }

        throw new System.Exception($"There is no free elements of this type {tag}");       
    }


}
