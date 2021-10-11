﻿using System;
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