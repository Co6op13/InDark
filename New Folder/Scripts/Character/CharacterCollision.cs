using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Character
{
    public class CharacterCollision : MonoBehaviour
    {
        private BoxCollider2D boxCollider2D; 
        //private CharacterData character;

        void Start()
        {
            if(gameObject.GetComponent<BoxCollider2D>() != null )
                boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
           // character = gameObject.GetComponent<CharacterData>();
        }

        void Update()
        {
            OnCollisionWall();
        }

        private void OnCollisionWall()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider2D.size, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit == boxCollider2D)
                    continue;

                ColliderDistance2D colliderDistance = hit.Distance(boxCollider2D);

                if (colliderDistance.isOverlapped)
                {
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                }
            }
        }
    }
}
