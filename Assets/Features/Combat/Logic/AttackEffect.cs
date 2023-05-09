namespace Features.Combat.Logic
{
    public abstract class AttackEffect
    {
        public abstract void Apply(AbstractCombatParticipant victim, AbstractCombatParticipant attacker);
    }

}
