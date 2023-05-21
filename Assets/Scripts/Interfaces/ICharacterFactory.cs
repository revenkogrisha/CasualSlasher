using CasualSlasher.Characters;

namespace CasualSlasher.Factories
{
    public interface ICharacterFactory
    {
        public Character InitStats(Character character, StatsConfig config);
    }
}
