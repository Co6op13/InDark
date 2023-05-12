using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] public float speed;
    [SerializeField] public int damage;
    [SerializeField] public float lifeTime;
    [SerializeField] public Vector2 direction;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("LifeRouting");
    }
    public void SetVariable(float speed, int damage, float lifeTime, Vector2 direction)
    {
        this.speed = speed;
        this.damage = damage;
        this.lifeTime = lifeTime;
        this.direction = direction;
    }

    private void OnEnable()
    {
        StartCoroutine("LifeRoutine");
        rb.AddForce(direction * speed);
    }

    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this.lifeTime);

        this.Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
