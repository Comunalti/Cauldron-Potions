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
        
        private void CreateNewEnemy()
        {
            var nextEnemy = Instantiate(Prefabs.GetRandom(),spawnPosition,Quaternion.identity);
            //BattleManager.Instance.AddCreatureToFight(nextEnemy.GetComponent<Creature>());
            
            nextEnemy.transform.DOMove(stopPosition,walkDuration).OnComplete(() =>
            {
                AttackManager.Instance.AddNewEnemy(nextEnemy);

                //StartCoroutine(BattleManager.Instance.Fight());
            });
        }

        private IEnumerator NextEnemy()
        {
            yield return new WaitForSeconds(1);
            CreateNewEnemy();
        }

        public void CreateNew()
        {
            StartCoroutine(NextEnemy());
        }
    }
}