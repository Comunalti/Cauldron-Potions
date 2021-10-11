// using System.Collections;
// using System.Collections.Generic;
// using DG.Tweening;
// using Unity.Collections;
// using Unity.Mathematics;
// using UnityEngine;
//
// namespace CombatSystem
// {
//     public class BattleManager : MonoBehaviourSingleton<BattleManager>
//     {
//         public List<Creature> inGame = new List<Creature>();
//         public GameObject ParticleSystemPrefab;
//         public GameObject endMenu;
//
//         public Creature killCreature;
//
//         [ContextMenu("kill creature")]
//         public void aaaa()
//         {
//             CreatureDied(killCreature);
//         }
//         
//         public void CreatureDied(Creature creature)
//         {
//             creature.DeathAnimation();
//             StartCoroutine(PlayDeathParticles(creature));
//             if (creature is Player)
//             {
//                 EndGame();
//             }
//         }
//
//         private void EndGame()
//         {
//             var a = Instantiate(endMenu);
//             var rect = a.GetComponent<RectTransform>();
//             rect.DOScale(1, 2).SetEase(Ease.OutBounce).SetUpdate(true);
//             DOTween.To(() => Time.timeScale, (x) => Time.timeScale = x, 0, 5).SetUpdate(true);
//         }
//
//
//         private IEnumerator PlayDeathParticles(Creature creature)
//         {
//             var particleSystem = Instantiate(ParticleSystemPrefab, creature.transform.position, quaternion.identity);
//             particleSystem.GetComponent<ParticleSystem>().Play();
//             creature.transform.DOScale(Vector3.zero,  .8f).SetEase(Ease.InQuad).OnComplete(()=>Destroy(creature.gameObject));
//             
//             yield return new WaitForSeconds(3f);
//             Destroy(particleSystem);
//         }
//
//         
//         public void AddCreatureToFight(Creature nextEnemy)
//         {
//             inGame.Add(nextEnemy);
//         }
//
//         public IEnumerator Fight()
//         {
//             yield return new WaitForSeconds(1);
//             if (inGame[0].speed>inGame[1].speed)
//             {
//                 //inGame[0].;
//             }
//         }
//     }
// }