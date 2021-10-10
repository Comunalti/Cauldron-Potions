using System.Collections.Generic;
using UnityEngine;

namespace CombatSystem
{
    public class EnemySpawner
    {
        public List<GameObject> Prefabs = new List<GameObject>();
        //public 
        public void CreateNewEnemy()
        {
            var nextEnemy = Prefabs.GetRandom();
            
        }
    }
}