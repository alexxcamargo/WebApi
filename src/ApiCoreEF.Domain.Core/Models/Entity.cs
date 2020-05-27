using FluentValidation;
using FluentValidation.Results;
using System;

namespace ApiCoreEF.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Guid Id { get; protected set; }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }

        public Entity()
        {
            ValidationResult = new ValidationResult();
        }     
    }
}
