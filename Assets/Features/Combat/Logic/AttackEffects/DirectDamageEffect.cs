namespace Features.Combat.Logic.AttackEffects
{
    public class DirectDamageEffect : AttackEffect
    {
        private readonly int amount;
        
        public DirectDamageEffect (int amount)
        {
            this.amount = amount;
        }
        public override void Apply(AbstractCombatParticipant victim, AbstractCombatParticipant attacker)
        {
            victim.ReceiveDamage(amount);
        }
    }

}
