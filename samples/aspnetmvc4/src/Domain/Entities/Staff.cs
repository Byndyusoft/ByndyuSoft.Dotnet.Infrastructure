namespace Mvc4Sample.Domain.Entities
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class Staff : IEntity
    {
        [Obsolete("Only for NH", true)]
        public Staff()
        {
        }

        public Staff([NotNull] string name, int quantity)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;

            Quantity = quantity;

            CreatedAt = DateTime.UtcNow;
        }

        public Staff([NotNull] string name, int quantity, DateTime createdAt)
            : this(name, quantity)
        {
            CreatedAt = createdAt;
        }

        public virtual int Id { get; set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual DateTime CreatedAt { get; protected set; }

        public virtual int Quantity { get; protected set; }

        public virtual void SetName([NotNull] string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
        }

        public virtual void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}