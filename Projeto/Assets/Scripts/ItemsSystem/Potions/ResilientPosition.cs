﻿using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class ResilientPosition : Potion
    {
        public float addHealthQuantity = 25;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.AddMaxHealth(addHealthQuantity);
            yield break;
        }
    }
}