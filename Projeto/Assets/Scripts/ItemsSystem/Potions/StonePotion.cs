using System;
using System.Collections;
using System.Collections.Generic;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class StonePotion : Potion
    {
        public float dmg;
        public float stunChance;
        public float rounds;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
    
            creature.Damage(dmg);
            creature.AddStunChance(stunChance);

            List<Action> actionList = new List<Action>();
            for (int i = 0; i < rounds-1; i++)
            {
                actionList.Add(() =>
                {
                   if (creature.stunnedLastFrame)
                   {
                       creature.AddStunChance(stunChance);
                   } 
                });
            }
            
            creature.QueueEffect(actionList);
            
            yield break;
        }
    }
}