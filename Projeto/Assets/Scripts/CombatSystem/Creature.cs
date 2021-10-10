using UnityEngine;

namespace CombatSystem
{ 
    public abstract class Creature : MonoBehaviour
    {
        public float creatureMaxHealth = 0;
        public float creatureMinHealth = 0;
        public float creatureCurrentHealth = 0;

        public delegate void HealthChangedEventHandler();
        public event HealthChangedEventHandler HealthChangedEvent = () => {};

        public delegate void CreatureDiedEventHandler();
        public event CreatureDiedEventHandler CreatureDiedEvent = () => {};
    
    
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
    }
}