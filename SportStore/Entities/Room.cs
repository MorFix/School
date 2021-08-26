using System;

namespace SportStore.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }

        public Room(string name, Guid id) : base(id)
        {
            Name = name;
        }
    }
}