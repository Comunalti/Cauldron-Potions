﻿using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class EletricPotion : Potion
    {
        public float dmg;
        public float stunChance;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.Damage(dmg);
            creature.AddStunChance(stunChance);
            
            yield break;
        }
    }
}