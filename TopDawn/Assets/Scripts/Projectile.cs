using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public  class Projectile: MonoBehaviour, IProjectile 
{
    [SerializeField] private float speed;
    [SerializeField] private DamageType damageType;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Rigidbody2D rb;
    private TagsVariable tagTarget;
    private Vector2 start;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("LifeRouting");
    }
    public void SetVariable(float speed, int damage, float range, Vector2 direction, TagsVariable tagTarget)
    {
        this.speed = speed;
        this.damage = damage;
        this.range = range;
        this.direction = direction;
        this.tagTarget = tagTarget;
        
    }

    private void OnEnable()
    {
        start = transform.position;
        StartCoroutine(CheckDistance());
        rb.AddForce(direction * speed);
    }

    private void OnDisable()
    {
        StopCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        yield return new WaitUntil(() => Vector2.Distance(start, transform.position) > range);

        this.Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public String GetName()
    {
        return gameObject.name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.GetComponent<IHP>());
        
        if (collision.gameObject.tag == tagTarget.ToString() && collision.transform.TryGetComponent(out IHP hp))        
        {
            hp.TakesDamage(damage, damageType);
            Debug.Log("hit" + collision.gameObject.name);
            Deactivate();
        }
    }
}
