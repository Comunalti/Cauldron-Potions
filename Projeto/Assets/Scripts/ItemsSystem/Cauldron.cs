using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PotionSystem;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace ItemsSystem
{
    public class Cauldron : MonoBehaviourSingleton<Cauldron>
    {
        public List<PotionSystem.Ingredient> cauldronItems = new List<PotionSystem.Ingredient>();
        public Vector3 spawnPosition;
        public Vector2 direction = new Vector2(-1,1);
        public float force;
        public int makedPotions;

        public ParticleSystem FailParticleSystem;

        public ParticleSystem GoodParticleSystem;
        // public GameObject goodPrefab;
        // public GameObject badPrefab;

        public Transform squashTransform;
        protected override void SingletonStarted()
        {
            //squashTransform = GetComponent<Transform>();
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
            print("limpou");
            cauldronItems = new List<PotionSystem.Ingredient>();
        }
        
        [ContextMenu("tween")]
        private void TweenSquash()
        {
            var a =squashTransform.DOScale(Vector3.one/2,0.5f).SetEase(Ease.InQuad).SetLoops(2,LoopType.Yoyo);//.OnComplete()
            a.OnStepComplete(() => { a.SetEase(Ease.InBounce); });
        }
        
        [ContextMenu("Prepare")]
        public IEnumerator PreparePotion()
        {
            var potionResult = PotionManager.Instance.GetPotionResult(cauldronItems.ToArray());
            print($"potion result is {potionResult}");
            if (potionResult is null)
            {
                FailParticleSystem.Play();
                var quaternion = squashTransform.rotation;
                squashTransform.DOShakeRotation(0.8f, 15);
                squashTransform.rotation = quaternion ;
                print("falhou");
                Reset();
            }
            else
            {
                //sucess
                GoodParticleSystem.Play();
                print("sucesso");
                var gameObjectClone = potionResult.GetInstance(spawnPosition);
                ThrowItem(gameObjectClone);
                makedPotions += 1;
                Reset();
            }
            yield break;
        }

        public void ThrowItem(GameObject gameObject)
        {
            print("teaadasd");
            var a = gameObject.GetComponent<Rigidbody2D>();
            var scale = squashTransform.localScale;
            squashTransform.DOShakeScale(0.8f, 0.5f);
            squashTransform.localScale = scale;
            a.AddForce(direction*force,ForceMode2D.Force);
        } 
        
        public void OnCollisionEnter2D(Collision2D other)
        {
            var a = other.gameObject.GetComponent<Ingredient>();
            Debug.Log(a);
            if (a is null)
            {
                Debug.Log("asdafhjsfdhjsdfhjhj");
                ThrowItem(other.gameObject);
            }
            else
            {
                Insert(a);
            }
        }
        
        
    }
}