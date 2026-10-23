namespace TheWorld.GameMechanics;

/*
 * PlayerBuilder has strategies and CreatureBuilder doesn't. Why does that fit what a creature is?
 * Why does that fit what a creature is?
 * 
 * A strategy is for determining particular characteristics but is unnecessary for a creature
 * because all of them come from an archetype and therefore their numbers are already decided.
 */


public record CreatureBuilder
{
    private string _name = "Creature";
    private HealthPoints _healthPoints = HealthPoints.Create(1);
    private AbilityScore _abilities = AbilityScore.Create(10, 10, 10, 10, 10, 10)!;
    private int _experienceReward = 0;
    
    private CreatureBuilder() { }

    public static CreatureBuilder FromName(string name) => new() { _name = ValidateName(name) };
    
    public CreatureBuilder WithHealthPoints(HealthPoints hp) => this with { _healthPoints = hp };
    public CreatureBuilder WithAbilities(AbilityScore abilities) => this with { _abilities = abilities };
    public CreatureBuilder WithExperienceReward(int experienceReward) =>
        this with { _experienceReward = experienceReward };

    public Creature Build() => 
        Creature.Create(_name, _healthPoints, _abilities, _experienceReward);

    
    
    private static string ValidateName(string name) =>
        name switch
        {
            var n when string.IsNullOrWhiteSpace(n) => "Creature",
            _ => name.Trim()
        };
}