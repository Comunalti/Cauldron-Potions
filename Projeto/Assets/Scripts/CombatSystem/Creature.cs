using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CombatSystem
{ 
    public abstract class Creature : MonoBehaviour
    {
        public float creatureMaxHealth = 0;
        public float creatureMinHealth = 0;
        public float creatureCurrentHealth = 0;
        public new Transform transform;
        public Animator animator;
        
        public float defense;
        public float stunChance;
        public float critChance;
        public float evadePercent;
        private float currentAttack;
        private float baseAttack;
        private float critMultiplier;

        
        public float strength;
        public float speed;
        public bool stunnedLastFrame;

        public delegate void HealthChangedEventHandler();
        public event HealthChangedEventHandler HealthChangedEvent = () => {};

        public delegate void CreatureDiedEventHandler();
        public event CreatureDiedEventHandler CreatureDiedEvent = () => {};

        private List<List<Action>> _queueActionList = new List<List<Action>>();
        public Vector3 attackPosition;
        public Vector3 defensePosition;

        private void Start()
        {
            transform = GetComponent<Transform>();
            animator = GetComponent<Animator>();
        }

        private List<Action> GetLastList()
        {
            var first = _queueActionList.First();
            _queueActionList.Remove(first);
            return first;
        }

        private void AddElementAt(int index, Action element)
        {
            if (index>=_queueActionList.Count)
            {
                _queueActionList.Add(new List<Action>());
                AddElementAt(index,element);
            }
            else
            {
                _queueActionList[index].Add(element);
            }
        }

        public IEnumerable StepActionQueue()
        {
            var actionList = GetLastList();
            foreach (var action in actionList)
            {
                yield return new WaitForSeconds(1);
                action.Invoke();
            }
            yield break;
        }

        public void StartMovement(Creature otherCreature)
        {
            var myTween = transform.DOMove(otherCreature.transform.position,animationDuration()).SetEase(Ease.InExpo).SetDelay(0.5f).SetLoops(2,LoopType.Yoyo);
            myTween.OnStepComplete(
                () =>
                {
                    Attack(otherCreature);
                    myTween.SetEase(Ease.OutQuad).SetDelay(0f).OnComplete(()=>FinishMoveAttack(otherCreature));
                });
        }

        private float animationDuration()
        {
            return 10 / speed;
        }

        private void FinishMoveAttack(Creature otherCreature)
        {
            otherCreature.StartMovement(this);
        }

        private void Attack(Creature otherCreature)
        {
            otherCreature.Damage(strength);
        }

        public void Damage(float dmg)
        {
            var hpToRemove = Mathf.Max((dmg - defense) * (Random.Range(0f,1f)<evadePercent?0f:1f),0) ;
            RemoveHP(hpToRemove);
        }

        protected virtual void Kill()
        {
            CreatureDiedEvent.Invoke();
        }

        public void Heal(float healed)
        {
            creatureCurrentHealth += healed;
            if (creatureCurrentHealth>=creatureMaxHealth)
            {
                creatureCurrentHealth = creatureMaxHealth;
            }
            HealthChangedEvent.Invoke();
        }

        public void AddMaxHealth(float addHealthQuantity)
        {
            creatureMaxHealth += addHealthQuantity;
            creatureCurrentHealth += addHealthQuantity;
        }

        public void AddDefense(float defenseValue)
        {
            defense += defenseValue;
        }

        public void AddStunChance(float stunChance)
        {
            this.stunChance = stunChance;
        }

        public void QueueEffect(List<Action>  actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                AddElementAt(i,actions[i]);
            }
        }

        public void AddPrecision(float precisionChance)
        {
            critChance += precisionChance;
        }

        public void RemoveSpeed(float speedReduction)
        {
            speed =- speedReduction;
            if (speed< 0)
            {
                speed = 0;
            }
        }

        public void AddSpeed(float speed)
        {
            this.speed += speed;
        }

        public void AddEvadeChange(float evadePercent)
        {
            this.evadePercent += evadePercent;
            if (evadePercent>=100f)
            {
                this.evadePercent = 100f;
            }
        }

        public void DeathAnimation()
        {
            animator.Play("Death");
        }
        
        public float AttackDmg()
        {
            return (baseAttack + currentAttack) + critMultiplier * ((Random.Range(0, 100) < critChance) ? 1f : 0f) * (baseAttack + currentAttack);
        }

        private void RemoveHP(float value)
        {
            creatureCurrentHealth -= value;
            if (creatureCurrentHealth<=creatureMinHealth)
            {
                Kill();
            }
            HealthChangedEvent.Invoke();
        }

        public void UpdateAfterAttack()
        {
            
        }

        public void UpdateBeforeAttack()
        {
            
        }
    }
}