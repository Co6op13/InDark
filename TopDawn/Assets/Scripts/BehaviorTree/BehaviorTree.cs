using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        private Node root = null;

        protected void Start()
        {
            root = SetupTree();
        }

        private void Update()
        {
            if (root != null)
            {
                root.Evalute();
            }
        }
        protected abstract Node SetupTree();
    }
}