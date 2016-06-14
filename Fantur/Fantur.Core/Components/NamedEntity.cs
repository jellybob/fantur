namespace Fantur.Core.Components
{
    public class NamedEntity : Component
    {
        public string Name;

        public NamedEntity() : base(ComponentTypes.Name)
        {
        }
    }
}