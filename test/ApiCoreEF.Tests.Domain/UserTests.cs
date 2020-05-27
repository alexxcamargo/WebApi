using ApiCoreEF.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiCoreEF.Tests.Domain
{
    public class UserTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNametIsInvalid()
        {
            var user = new User(Guid.NewGuid(), "", "alex", "alex@gmail.com", "123456");
            Assert.False(user.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenNametIsValid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alex@gmail.com", "123456");
            Assert.True(user.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenLogintIsInvalid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "", "alex@gmail.com", "123456");
            Assert.False(user.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenLogintIsValid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alex@gmail.com", "123456");
            Assert.True(user.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenEmailtIsInvalid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alexgmail.com", "123456");
            Assert.False(user.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenEmailtIsValid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alex@gmail.com", "123456");
            Assert.True(user.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenSenhatIsInvalid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alexgmail.com", "");
            Assert.False(user.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenSenhaIsValid()
        {
            var user = new User(Guid.NewGuid(), "Alex Camargo", "alex", "alex@gmail.com", "123456");
            Assert.True(user.IsValid());
        }

    }
}
