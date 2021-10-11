using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace CombatSystem
{
    public class AttackManager : MonoBehaviourSingleton<AttackManager>
    {
<<<<<<< HEAD
        public Creature Enemy;
        public Creature Player;

        private bool EnemyMoving;
        private bool EnemyAttacking;
        private bool EnemyReturning;
        
        private bool LastEnemyMoving;
        private bool LastEnemyAttacking;
        private bool LastEnemyReturning;
        
        
        private bool PlayerMoving;
        private bool PlayerAttacking;
        private bool PlayerReturning;
        
        private bool LastPlayerMoving;
        private bool LastPlayerAttacking;
        private bool LastPlayerReturning;
        
        private bool InPlaceEnemy()
        {
            return (!EnemyMoving && !EnemyAttacking && !EnemyReturning) && EnemyBackToRest;
        }

        private bool InPlacePlayer()
        {
            return (!PlayerMoving && !PlayerAttacking && !PlayerReturning) && EnemyBackToRest;
        }

        public bool playerTime;

        private bool EnemyFinishedMovingPart1;
        private bool EnemyAttacked;
        private bool EnemyFinishedMovingPart2;
        private bool EnemyBackToRest;
        
        
        private bool PlayerFinishedMovingPart1;
        private bool PlayerAttacked;
        private bool PlayerFinishedMovingPart2;
        private bool PlayerBackToRest;
        
        private void Update()
        {
            if (Enemy is null)
            {
                CreateNewEnemy();
                return;
            }

            if (InPlaceEnemy() && InPlacePlayer())
            {
                if (playerTime)
                {
                    MovePlayer();
                }
                else
                {
                    MoveEnemy();
                }
            }

            if (EnemyFinishedMovingPart1 || PlayerFinishedMovingPart1 )
            {
                if (playerTime)
                {
                    EnemyFinishedMovingPart1 = false;
                    PlayerAttack();
                }
                else
                {
                    PlayerFinishedMovingPart1 = false;
                    EnemyAttack();
                }
            }

            if (EnemyAttacked || PlayerAttacked)
            {
                if (playerTime)
                {
                    PlayerAttacked = false;
                    MovePlayerBack();
                }
                else
                {
                    EnemyAttacked = false;
                    MoveEnemyBack();
                }
            }

            if (EnemyFinishedMovingPart2 || PlayerFinishedMovingPart2)
            {
                if (playerTime)
                {
                    PlayerFinishedMovingPart2 = false;
                    PlayerRest();
                }
                else
                {
                    EnemyFinishedMovingPart2 = false;
                   EnemyRest();
                }
            }
        }

        private void EnemyRest()
        {
            EnemyBackToRest = true;
            playerTime = true;
        }

        private void PlayerRest()
        {
            PlayerBackToRest = true;
            playerTime = false;
        }

        private void MoveEnemyBack()
        {
            Enemy.transform.DOMove(Enemy.defensePosition, 1f).OnComplete(() => { EnemyFinishedMovingPart2 = true;});
        }

        private void MovePlayerBack()
=======
        public Creature targetCreature;
        public Creature currentCreature;

        public void OnEnable()
>>>>>>> ea3f8b4a4b5b246b2ba26276e54eff8a8b8631fc
        {
            Player.transform.DOMove(Player.defensePosition, 1f).OnComplete(() => { PlayerFinishedMovingPart2 = true;});
        }

        private void EnemyAttack()
        {
            EnemyAttacked = true;

            Player.Damage(Enemy.AttackDmg());
        }

        private void PlayerAttack()
        {
            PlayerAttacked = true;

            Enemy.Damage(Player.AttackDmg());
        }

        private void MoveEnemy()
        {
            Enemy.transform.DOMove(Enemy.attackPosition, 1f).OnComplete(() => { EnemyFinishedMovingPart1 = true;});
        }

        private void MovePlayer()
        {
            Player.transform.DOMove(Player.attackPosition, 1f).OnComplete(() => { PlayerFinishedMovingPart1 = true;});
        }


        private void CreateNewEnemy()
        {
            EnemySpawner.Instance.CreateNew();
        }

        public void MakeEnemyWalk()
        {
            EnemyMoving = true;
            Enemy.transform.DOMove(Enemy.defensePosition, 1f).OnComplete(() => { EnemyMoving = false; });
        }
        
        
        
        
        //
        //
        // public Creature targetCreature;
        // public Creature currentCreature;
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        // public void OnEnable()
        // {
        //     StartCoroutine(delayAttacks());
        // }
        //
        // public IEnumerator delayAttacks()
        // {
        //     yield return new WaitForSeconds(4);
        //     StartAttack();
        // }
        //
        //
        //
        // [ContextMenu("StartAttack")]
        //
        // public void StartAttack()
        // {
        //     targetCreature.UpdateAfterAttack();
        //     currentCreature.UpdateBeforeAttack();
        //     TweenAttack();
        // }
        //
        // [ContextMenu("TweenAtcck")]
        // public void TweenAttack()
        // {
        //     currentCreature.transform.DOMove(currentCreature.attackPosition, 1f).SetEase(Ease.InExpo).OnStepComplete(
        //         () =>
        //         {
        //             Attack();
        //             currentCreature.transform.DOMove(currentCreature.defensePosition, 1f).SetDelay(1.5f).SetEase(Ease.InExpo).OnStepComplete(
        //                 () =>
        //                 {
        //                     if (!(targetCreature is null) && !(currentCreature is null))
        //                     {
        //                         StartCoroutine(DelayChange());
        //                     }
        //                     
        //                 });
        //         });
        // }
        //
        // private IEnumerator DelayChange()
        // {
        //     yield return new WaitForSeconds(.5f);
        //     ChangeAttacker();
        // }
        //
        // [ContextMenu("Attack")]
        // public void Attack()
        // {
        //     currentCreature.transform.DOShakePosition(1f,0.3f).OnComplete(()=>
        //     {
        //         StartCoroutine(DealDmg());
        //     });
        //     
        // }
        //
        // public IEnumerator DealDmg()
        // {
        //     print("first part");
        //     yield return new WaitUntil(()=> !(targetCreature is null) && !(currentCreature is null));
        //     print("dmg");
        //     targetCreature.Damage(currentCreature.AttackDmg());
        // }
        //
        // [ContextMenu("ChangeAttacker")]
        // public void ChangeAttacker()
        // {
        //     var current = currentCreature;
        //     var target = targetCreature;
        //
        //     currentCreature = target;
        //     targetCreature = current;
        //     
        //     currentCreature.transform.DOShakePosition(0.5f,0.1f).OnComplete(() =>
        //     {
        //         StartAttack();
        //     });
        // }
        //
        // public void AddNewEnemy(GameObject nextEnemy)
        // {
        //     print("fsudfhuasfyhusdfhu");
        //     if ( targetCreature is Player)
        //     {
        //         currentCreature = nextEnemy.GetComponent<Creature>();
        //     }
        //     else if (currentCreature is Player)
        //     {
        //         targetCreature = nextEnemy.GetComponent<Creature>();
        //     }
        // }
        
    }
}