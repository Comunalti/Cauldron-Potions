using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class AttackFlatPotion : Potion
    {
        public float attackFlatBonus = 10;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.AddAttack(attackFlatBonus);
            yield break;
        }
    }
}