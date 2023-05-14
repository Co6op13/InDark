using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private TagsVariable tagTarget;
    [SerializeField] private int damage;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRangeDistance;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform target;
    private bool isAttacked = false;


    private float DelaySecond { get => 1 / rateOfFire; }

    public void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            Shooting();
            Invoke("CancelAttack", DelaySecond);
        }

    }

    private void Shooting()
    {
        var projectile = PoolProjectile.Instance.GetFromPool(projectilePrefab.GetName());
        projectile.transform.position = firepoint.position;
        projectile.SetVariable(projectileSpeed, damage, projectileRangeDistance,
            (target.position - firepoint.position).normalized, tagTarget);
        projectile.gameObject.SetActive(true);
    }

    private void CancelAttack()
    {
        isAttacked = false;
    }
}
