﻿using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class SpeedPotion : Potion
    {
        public float speed = 2;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddSpeed(speed);
            yield break;
        }
    }
}