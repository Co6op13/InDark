using UnityEngine;


public interface IProjectile
{
    void SetVariable(float speed, int damage, float range, Vector2 destination, TagsVariable tagTarget);

    string GetName();
}

