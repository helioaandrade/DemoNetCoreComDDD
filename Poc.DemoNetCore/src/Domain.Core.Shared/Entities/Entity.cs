using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.DemoNetCore.Domain.Core.Shared.Entities
{
    public abstract class Entity : ICloneable
    {
        protected Entity()
        {
        }

        public int Id { get; set; }

        [NotMapped]
        public bool IsValid => Validate();

        public object Clone()
        {
            return MemberwiseClone();
        }

        protected abstract bool Validate();

    }
}
