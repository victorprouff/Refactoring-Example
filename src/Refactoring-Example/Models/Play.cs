namespace Refactoring_Example.Models
{
    public class Play
    {
        public Play(string id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public string Id { get; }
        public string Name { get; }
        public string Type { get; }
    }
}