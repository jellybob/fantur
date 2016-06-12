using System;

namespace Fantur.Core
{
    public class Component
    {
        public Guid Guid;

        public Component()
        {
            this.Guid = Guid.NewGuid();
        }

        public Component(Guid guid)
        {
            this.Guid = guid;
        }
    }
}