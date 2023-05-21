using CasualSlasher.Characters;

namespace CasualSlasher.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public Character InitStats(Character character, StatsConfig config)
        {
            character.InitStats(config);
            return character;
        }
    }
}
