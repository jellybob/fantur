namespace Fantur.Core.Components
{
    public class NamedEntity : Component
    {
        public string Name;

        public NamedEntity(string name) : base(ComponentTypes.Name)
        {
            Name = name;
        }
    }
}