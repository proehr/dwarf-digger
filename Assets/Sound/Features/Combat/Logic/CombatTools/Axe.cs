using Features.Combat.Logic.AttackEffects;
using UnityEngine;

namespace Features.Combat.Logic.CombatTools
{
    public class Axe : CombatTool
    {
        protected internal override void ApplyAttackEffects(AbstractCombatParticipant target)
        {
            target.ReceiveAttack(user, new DirectDamageEffect(user.currentAttackStats.AttackDamage));
        }
    }
}