using System.Collections;
using CombatSystem;
using DG.Tweening;
using PotionSystem;
using UnityEngine;

namespace ItemsSystem
{
    public abstract class Potion : Draggable
    {
        public PotionManager potionManager;
        
        public delegate void ActivationEventHandler(Potion potion, Creature creature);

        public event ActivationEventHandler ActivationEvent;

        //public string name;

        protected abstract IEnumerator MainEffect(Creature creature);
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var creature = other.gameObject.GetComponent<Creature>();
            if (creature is null)
            {
                
            }
            else
            {
                ActivationEvent?.Invoke(this,creature);
                StartCoroutine(MainEffect(creature));
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Transform>().DOScale(Vector3.zero, 0.5f).OnComplete(() => { Destroy(gameObject); });
            }
        }
    }
}