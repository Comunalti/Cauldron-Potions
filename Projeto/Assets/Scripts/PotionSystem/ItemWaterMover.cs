using System;
using UnityEngine;

namespace PotionSystem
{
    public class ItemWaterMover: MonoBehaviour
    {
        public Transform transform;
        public Vector3 direction = new Vector3(0,-3,0);
        public Rigidbody2D rigidbody2D;
        private void Start()
        {
            transform = GetComponent<Transform>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = 0;
        }

        private void OnMouseDown()
        {
            Destroy(this);
        }

        private void Update()
        {
            transform.position = transform.position + direction * Time.deltaTime;
        }
    }
}