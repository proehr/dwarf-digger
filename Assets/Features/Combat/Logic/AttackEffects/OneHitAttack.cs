namespace Features.Combat.Logic.AttackEffects
{
    public class OneHitAttack : AttackEffect
    {
        public override void Apply(AbstractCombatParticipant victim, AbstractCombatParticipant attacker)
        {
            victim.ReceiveDamage(victim.currentHealthStats.Health);
        }
    }
}