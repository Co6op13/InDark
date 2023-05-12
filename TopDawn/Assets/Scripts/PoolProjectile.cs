using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PoolProjectile : ObjectPooler
{
    #region Singleton
    public static PoolProjectile Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion;

}
