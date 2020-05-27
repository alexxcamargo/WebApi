using ApiCoreEF.Domain.Core.Models;
using FluentValidation;
using System;

namespace ApiCoreEF.Domain.User
{
    public class User : Entity<User>
    {
        public string Nome { get; private set ; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public User()
        {

        }

        public User(Guid id, string nome, string login, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Email = email;
            Senha = senha;
        }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidateLogin();
            ValidateEmail();
            ValidateSenha();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome precisa ser fornecido")
                .Length(2, 100).WithMessage("O Nome precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateLogin()
        {
            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("O Login precisa ser fornecido")
                .Length(2, 10).WithMessage("O Login precisa ter entre 2 e 10 caracteres");
        }

        private void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O Email precisa ser fornecido")
                .Length(2, 50).WithMessage("O Email precisa ter entre 2 e 50 caracteres")
                .EmailAddress().WithMessage("E-mail inválido");
        }

        private void ValidateSenha()
        {
            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O Senha precisa ser fornecido")
                .Length(4, 50).WithMessage("O Senha precisa ter entre 4 e 50 caracteres");
        }

    }
}
