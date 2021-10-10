using System;
using System.Collections;
using System.Collections.Generic;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class RegenerationPotion : Potion
    {
        public float healedPercent;
        public int rounds;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            List<Action> actionList = new List<Action>();
            for (int i = 0; i < rounds; i++)
            {
                actionList.Add(() => { creature.Heal(creature.creatureMaxHealth * healedPercent);});
            }
            creature.QueueEffect(actionList);
            
            yield break;
        }
    }
}