namespace TheWorld.GameMechanics.StockEntities;

public static class StockCreatures
{
    public static Creature Goblin =>
        CreatureBuilder.FromName("Goblin")
            .WithHealthPoints(HealthPoints.Create(7))
            .WithAbilities(AbilityScore.Create(8, 14, 10, 10, 8, 8)!)
            .WithExperienceReward(50)
            .Build();
    
    public static Creature Boss =>
        CreatureBuilder.FromName("Boss")
            .WithHealthPoints(HealthPoints.Create(1000))
            .WithAbilities(AbilityScore.Create(18, 5, 5, 5, 18, 18)!)
            .WithExperienceReward(500)
            .Build();
    
    public static Creature Zombie =>
        CreatureBuilder.FromName("Zombie")
            .WithHealthPoints(HealthPoints.Create(20))
            .WithAbilities(AbilityScore.Create(10, 10, 10, 17, 9, 18)!)
            .WithExperienceReward(65)
            .Build();
}