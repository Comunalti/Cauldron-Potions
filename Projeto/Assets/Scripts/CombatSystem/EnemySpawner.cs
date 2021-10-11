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
        
        public RectTransform barra;
        
        private void CreateNewEnemy()
        {
            print("criando novo inimigo");
            var nextEnemy = Instantiate(Prefabs.GetRandom(),spawnPosition,Quaternion.identity);
            var enemy = nextEnemy.GetComponent<Enemy>();
            enemy.barra = barra;
            AttackManager.Instance.Enemy = nextEnemy.GetComponent<Creature>();
            AttackManager.Instance.MakeEnemyWalk();
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