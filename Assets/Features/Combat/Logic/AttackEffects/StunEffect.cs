using Features.Combat.Logic.CombatUnits;

namespace Features.Combat.Logic.AttackEffects
{
    public class StunEffect : AttackEffect
    {
        private readonly float stunTime;

        public StunEffect(float stunTime)
        {
            this.stunTime = stunTime;
        }

        public override void Apply(AbstractCombatParticipant victim, AbstractCombatParticipant attacker)
        {
            victim.ApplyAttackCooldown(stunTime);
            if (victim as MovingCombatParticipant)
            {
                ((MovingCombatParticipant)victim).ApplyMovementCooldown(stunTime);
            }
        }
    }
}