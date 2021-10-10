using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PotionSystem;
using Unity.Collections;
using UnityEngine;

namespace ItemsSystem
{
    public class Cauldron : MonoBehaviourSingleton<Cauldron>
    {
        public List<PotionSystem.Ingredient> cauldronItems = new List<PotionSystem.Ingredient>();
        public Vector2 spawnPosition;
        public float force;

        // public GameObject goodPrefab;
        // public GameObject badPrefab;

        private Transform _transform;
        protected override void SingletonStarted()
        {
            _transform = GetComponent<Transform>();
        }

        public void Insert(Ingredient ingredient)
        {
            cauldronItems.Add(ingredient.profile);
            Destroy(ingredient.gameObject);
            TweenSquash();
            if (cauldronItems.Count>=2)
            {
                StartCoroutine(PreparePotion());
            }
        }
        
        
        [ContextMenu("reset")]
        private void Reset()
        {
            print("terminou");
            cauldronItems = new List<PotionSystem.Ingredient>();
        }
        
        [ContextMenu("tween")]
        private void TweenSquash()
        {
            var a =_transform.DOScale(Vector3.one/2,0.5f).SetEase(Ease.InQuad).SetLoops(2,LoopType.Yoyo);//.OnComplete()
            a.OnStepComplete(() => { a.SetEase(Ease.InBounce); });
        }
        
        [ContextMenu("Prepare")]
        public IEnumerator PreparePotion()
        {
            var potionResult = PotionManager.Instance.GetPotionResult(cauldronItems.ToArray());
            print($"potion result is {potionResult}");
            if (potionResult is null)
            {
                //fail
                Reset();
            }
            else
            {
                //sucess
                var gameObjectClone = potionResult.GetInstance(spawnPosition);
                ThrowItem(gameObjectClone);
            }
            yield break;
        }

        public void ThrowItem(GameObject gameObject)
        {
            var a = gameObject.GetComponent<Rigidbody2D>();
            a.AddForce(new Vector2(Random.Range(-1f,1f),1)*force,ForceMode2D.Force);
        } 
        
        public void OnCollisionEnter2D(Collision2D other)
        {
            var a = other.gameObject.GetComponent<Ingredient>();
            if (a is null)
            {
                ThrowItem(other.gameObject);
            }
            else
            {
                Insert(a);
            }
        }
        
        
    }
}