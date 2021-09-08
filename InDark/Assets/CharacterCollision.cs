using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterCollision : MonoBehaviour
    {
        private CharacterData character;
        // Start is called before the first frame update
        void Start()
        {
            character = gameObject.GetComponent<CharacterData>();
        }

        // Update is called once per frame
        void Update()
        {
            OnCollisionWall();
        }

        private void OnCollisionWall()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, character.boxCollider2D.size, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit == character.boxCollider2D)
                    continue;

                ColliderDistance2D colliderDistance = hit.Distance(character.boxCollider2D);

                if (colliderDistance.isOverlapped)
                {
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                }
            }
        }
    }
}
