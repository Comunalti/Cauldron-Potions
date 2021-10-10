using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CombatSystem
{ 
    public abstract class Creature : MonoBehaviour
    {
        public float creatureMaxHealth = 0;
        public float creatureMinHealth = 0;
        public float creatureCurrentHealth = 0;
        public float defense;
        public float stunChance;
        public float 
        public bool stunnedLastFrame;

        public delegate void HealthChangedEventHandler();
        public event HealthChangedEventHandler HealthChangedEvent = () => {};

        public delegate void CreatureDiedEventHandler();
        public event CreatureDiedEventHandler CreatureDiedEvent = () => {};

        private List<List<Action>> _queueActionList = new List<List<Action>>();

        public IEnumerable StepActionQueue()
        {
            var actionList = _queueActionList.First();
            foreach (var action in actionList)
            {
                yield return new WaitForSeconds(1);
                action.Invoke();
            }
            yield break;
        }
        
        public void Damage(float dmg)
        {
            creatureCurrentHealth -= dmg;
            if (creatureCurrentHealth<=creatureMinHealth)
            {
                Kill();
            }
            HealthChangedEvent.Invoke();
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

        public void QueueEffect(List<Action>  action)
        {
            for (int i = 0; i < action.Count; i++)
            {
                
            }
        }

        public void AddPrecision(float speed)
        {
            
        }

        public void RemoveSpeed(float speedReduction)
        {
            throw new NotImplementedException();
        }

        public void AddSpeed(float speed)
        {
            throw new NotImplementedException();
        }

        public void AddEvadeChange(float evadePercent)
        {
            throw new NotImplementedException();
        }
    }
}