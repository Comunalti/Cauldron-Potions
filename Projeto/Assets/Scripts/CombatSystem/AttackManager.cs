using DG.Tweening;
using UnityEngine;

namespace CombatSystem
{
    public class AttackManager : MonoBehaviourSingleton<AttackManager>
    {
        public Creature targetCreature;
        public Creature currentCreature;

        public void StartAttack()
        {
            targetCreature.UpdateAfterAttack();
            currentCreature.UpdateBeforeAttack();
            TweenAttack();
        }

        public void TweenAttack()
        {
            currentCreature.transform.DOMove(currentCreature.attackPosition, 1f).SetEase(Ease.InExpo).OnStepComplete(
                () =>
                {
                    Attack();
                    currentCreature.transform.DOMove(currentCreature.defensePosition, 1f).SetDelay(1.5f).SetEase(Ease.InExpo).OnStepComplete(
                        () =>
                        {
                            ChangeAttacker();
                        });
                });
        }

        [ContextMenu("socorro")]
        public void Attack()
        {
            currentCreature.transform.DOShakePosition(1f).OnComplete(()=>
            {
                targetCreature.Damage(currentCreature.AttackDmg());
            });
            
        }

        public void ChangeAttacker()
        {
            var current = currentCreature;
            var target = targetCreature;

            currentCreature = target;
            targetCreature = current;
            
            currentCreature.transform.DOShakePosition(0.5f).OnComplete(() =>
            {
                StartAttack();
            });
        }
    }
}