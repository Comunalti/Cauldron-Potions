// using System.Collections;
// using CombatSystem;
// using UnityEngine;
//
// namespace ItemsSystem.Potions
// {
//     public class FirePotion : Potion
//     {
//         public float dmg = 10;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             print("aoba");
//             //creature.Damage(dmg);
//             yield break;
//         }
//     }
//     
//     public class HealingPotion : Potion
//     {
//         public float healingPercent = 0.1f;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//             creature.Heal(creature.creatureMaxHealth*healingPercent);
//             yield break;
//         }
//     }
//     
//     public class ResilientPosition : Potion
//     {
//         public float addHealthQuantity = 0.1f;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//             creature.AddMaxHealth(addHealthQuantity);
//             yield break;
//         }
//     }
//     
//     public class EarthDefensePotion : Potion
//     {
//         public float defenseValue;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.AddDefense(defenseValue);
//             yield break;
//         }
//     }
//     
//     public class WaterDefensePotion : Potion
//     {
//         public float evadePercent;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.AddEvadeChange(evadePercent);
//             yield break;
//         }
//     }
//     
//     public class SpeedPotion : Potion
//     {
//         public float speed;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.AddSpeed(speed);
//             yield break;
//         }
//     }
//     
//     public class PrecisionPotion : Potion
//     {
//         public float speed;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.AddPrecision(speed);
//             yield break;
//         }
//     }
//     
//     public class RegenerationPotion : Potion
//     {
//         public float healedPercent;
//         public int rounds;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             for (int i = 0; i < rounds; i++)
//             {
//                 creature.QueueEffect(() => { creature.Heal(creature.creatureMaxHealth * healedPercent);});
//             }
//             
//             yield break;
//         }
//     }
//     
//     public class ExplosionPotion : Potion
//     {
//         public float dmg;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.Damage(dmg);
//             
//             yield break;
//         }
//     }
//
//     public class PoisonPotion : Potion
//     {
//         public float dmg;
//         public int rounds;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             for (int i = 0; i < rounds; i++)
//             {
//                 creature.QueueEffect(() => { creature.Damage(dmg);});
//             }
//             
//             yield break;
//         }
//     }
//
//     public class RottenPotion : Potion
//     {
//         public float dmg;
//         public float speedReduction;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.Damage(dmg);
//             creature.RemoveSpeed(speedReduction);
//             
//             yield break;
//         }
//     }
//     
//     public class EletricPotion : Potion
//     {
//         public float dmg;
//         public float stunChance;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.Damage(dmg);
//             creature.AddStunChance(stunChance);
//             
//             yield break;
//         }
//     }
//     
//     public class StonePotion : Potion
//     {
//         public float dmg;
//         public float stunChance;
//         public float rounds;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//     
//             creature.Damage(dmg);
//             creature.AddStunChance(stunChance);
//             for (int i = 0; i < rounds-1; i++)
//             {
//                 creature.QueueEffect(() =>
//                 {
//                     if (creature.stunnedLastFrame)
//                     {
//                         creature.AddStunChance(stunChance);
//                     }
//                 });
//             }
//             
//             yield break;
//         }
//     }
//
//     public class SlownessPotion: Potion
//     {
//         public float stunChance;
//         public float speedReduction;
//         protected override IEnumerator MainEffect(Creature creature)
//         {
//             yield return new WaitForSeconds(1);
//
//             creature.AddStunChance(stunChance);
//             creature.RemoveSpeed(speedReduction);
//             
//             yield break;
//
//         }
//     }
//     
// }
