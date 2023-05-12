using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var particle = PoolProjectile.Instance.GetFromPool(prefab.name, Vector2.one, transform.rotation);
            particle.SetActive(true);
        }    
    }
}
