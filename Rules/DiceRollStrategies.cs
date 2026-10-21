using TheWorld.GameMechanics;

namespace TheWorld.Rules;

public static class DiceRollStrategies
{
    public static int Default(Random rng, Dice dice) => dice.Roll(rng);


    public static int Advantage(Random rng, Dice dice) =>
        Enumerable.Range(0, 2)
            .Select(_ => dice.Roll(rng))
            .Max();
    
    public static int HighestOfThreeRolls(Random rng, Dice dice) =>
        Enumerable.Range(0, 3)
            .Select(_ => dice.Roll(rng))
            .Max();


    public static DiceRollStrategy ClampRoll(int minRoll = 8, int maxRoll = 18, DiceRollStrategy? strategy = null) =>
        (rng, dice) =>
            dice.Roll(rng, strategy ?? HighestOfThreeRolls) switch
            {
                var roll when roll < minRoll =>
                    ClampRoll(minRoll, maxRoll, strategy)(rng, dice),
                var roll when roll > maxRoll =>
                    ClampRoll(minRoll, maxRoll, strategy)(rng, dice),
                var roll => roll
            };

    // infinite recursion is the monster hiding inside this function 
}


