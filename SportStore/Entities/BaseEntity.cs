using System;

namespace SportStore.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        protected BaseEntity()
        {
        }
    }
}
