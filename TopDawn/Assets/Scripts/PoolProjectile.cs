using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PoolProjectile : ObjectPooler2test<Projectile>
{
    #region Singleton
    public static PoolProjectile Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion;

}
