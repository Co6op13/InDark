
internal interface IHP
{
    public int CurrentHP { get; }
    public int MaxHP { get; }
    public void SetMaxHP(int hp);
    public void TakesDamage(int damage, DamageType damageType);
    public void TakesHeal(int heal);
}