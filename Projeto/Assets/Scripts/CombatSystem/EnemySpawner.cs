using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace CombatSystem
{
    public class EnemySpawner : MonoBehaviourSingleton<EnemySpawner>
    {
        public List<GameObject> Prefabs = new List<GameObject>();
        public Vector3 spawnPosition;
        public Vector3 stopPosition;
        public float walkDuration;
        
        public void CreateNewEnemy()
        {
            var nextEnemy = Instantiate(Prefabs.GetRandom(),spawnPosition,Quaternion.identity);
            BattleManager.Instance.AddCreatureToFight(nextEnemy.GetComponent<Creature>());
            
            nextEnemy.transform.DOMove(stopPosition,walkDuration).OnComplete(() => { StartCoroutine(BattleManager.Instance.Fight()); });
        }

        public IEnumerator NextEnemy()
        {
            yield return new WaitForSeconds(1);
        }
    }
}