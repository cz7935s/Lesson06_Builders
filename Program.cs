using TheWorld.GameMechanics;
using TheWorld.Display;
using TheWorld.GameMechanics.StockEntities;
using TheWorld.Rules;
using static TheWorld.Rules.DiceRollStrategies;

//*this is the one Random Number Generator for the whole program. we inject it everywhere a roll happens. 
Random rng = new();

// The party.  Bree is the wizard;  Tamsin is the fighter.
var bree = StockPlayers.Bree;
var tamsin = StockPlayers.Tamsin;

// What they're up against.
var goblin = Creature.Create("Goblin", 7, 7, 8, 14, 10, 10, 8, 8, 50);

bree.ShowSheet();
tamsin.ShowSheet();
goblin.ShowSheet();

Console.WriteLine($"Tamsin swings at the goblin:  {tamsin.AttackBonus:+0;-0;+0} to hit, against AC {goblin.ArmorClass}.");
Console.WriteLine($"The goblin swings back:  {goblin.AttackBonus:+0;-0;+0} to hit, against AC {tamsin.ArmorClass}.");

PlayerBuilder.FromName("Hardcore").WithAbilities(rng).Build().ShowSheet();
PlayerBuilder.FromName("Lucky")
    .WithAbilities(rng, Dice.D6 with { Count = 3 }, HighestOfThreeRolls)
    .Build().ShowSheet();
    
    /*
     *
     * Step 5's last line -- AbilityScore.Roll skips the 3-to-18 check. Whose job is that check now?
       Which character would you rather play -- Hardcore or Lucky? There's no right answer, but think about what you'd lose by always playing Lucky.
       The call that builds a strength of 1 -- can you write a WithAbilities call that would produce a score of 1?
       *
    */
    
    PlayerBuilder.FromName("hi").WithAbilities(rng, Dice.D6, Default).Build().ShowSheet();

