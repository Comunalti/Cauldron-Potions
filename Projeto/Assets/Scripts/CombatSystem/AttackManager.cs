using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Collections;
using UnityEngine;

namespace CombatSystem
{
    public class AttackManager : MonoBehaviourSingleton<AttackManager>
    {
        public Creature targetCreature;
        public Creature currentCreature;

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
                            StartCoroutine(DelayChange());
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
                targetCreature.Damage(currentCreature.AttackDmg());
            });
            
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
    }
}