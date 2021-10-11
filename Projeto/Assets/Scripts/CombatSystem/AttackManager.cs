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
            return !EnemyMoving && !EnemyAttacking && !EnemyReturning;
        }

        private bool InPlacePlayer()
        {
            return !PlayerMoving && !PlayerAttacking && !PlayerReturning;
        }

        public bool playerTime;
        
        private void Update()
        {
            if (Enemy is null)
            {
                CreateNewEnemy();
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
                    (PlayerAttack());
                }
                else
                {
                    (EnemyAttack());
                }
            }

            if (EnemyAttacked || PlayerAttacked)
            {
                if (playerTime)
                {
                    (MovePlayerBack());
                }
                else
                {
                    (MoveEnemyBack());
                }
            }

            if (EnemyFinishedMovingPart2 || PlayerFinishedMovingPart2)
            {
                if (playerTime)
                {
                    (PlayerRest());
                }
                else
                {
                    (EnemyRest());
                }
            }
        }

        private void MoveEnemy()
        {
            throw new NotImplementedException();
        }

        private void MovePlayer()
        {
            throw new NotImplementedException();
        }


        private void CreateNewEnemy()
        {
            throw new NotImplementedException();
        }

        
        
        
        
        

        public Creature targetCreature;
        public Creature currentCreature;

        
        
        
        
        
        
        
        
        
        
        public void OnEnable()
        {
            StartCoroutine(delayAttacks());
        }

        public IEnumerator delayAttacks()
        {
            yield return new WaitForSeconds(4);
            StartAttack();
        }
        
        
        
        [ContextMenu("StartAttack")]

        public void StartAttack()
        {
            targetCreature.UpdateAfterAttack();
            currentCreature.UpdateBeforeAttack();
            TweenAttack();
        }

        [ContextMenu("TweenAtcck")]
        public void TweenAttack()
        {
            currentCreature.transform.DOMove(currentCreature.attackPosition, 1f).SetEase(Ease.InExpo).OnStepComplete(
                () =>
                {
                    Attack();
                    currentCreature.transform.DOMove(currentCreature.defensePosition, 1f).SetDelay(1.5f).SetEase(Ease.InExpo).OnStepComplete(
                        () =>
                        {
                            if (!(targetCreature is null) && !(currentCreature is null))
                            {
                                StartCoroutine(DelayChange());
                            }
                            
                        });
                });
        }

        private IEnumerator DelayChange()
        {
            yield return new WaitForSeconds(.5f);
            ChangeAttacker();
        }
        
        [ContextMenu("Attack")]
        public void Attack()
        {
            currentCreature.transform.DOShakePosition(1f,0.3f).OnComplete(()=>
            {
                StartCoroutine(DealDmg());
            });
            
        }

        public IEnumerator DealDmg()
        {
            print("first part");
            yield return new WaitUntil(()=> !(targetCreature is null) && !(currentCreature is null));
            print("dmg");
            targetCreature.Damage(currentCreature.AttackDmg());
        }
        
        [ContextMenu("ChangeAttacker")]
        public void ChangeAttacker()
        {
            var current = currentCreature;
            var target = targetCreature;

            currentCreature = target;
            targetCreature = current;
            
            currentCreature.transform.DOShakePosition(0.5f,0.1f).OnComplete(() =>
            {
                StartAttack();
            });
        }

        public void AddNewEnemy(GameObject nextEnemy)
        {
            print("fsudfhuasfyhusdfhu");
            if ( targetCreature is Player)
            {
                currentCreature = nextEnemy.GetComponent<Creature>();
            }
            else if (currentCreature is Player)
            {
                targetCreature = nextEnemy.GetComponent<Creature>();
            }
        }
    }
}