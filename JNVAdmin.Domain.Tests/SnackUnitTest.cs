using FluentAssertions;
using JNVAdmin.Domain.Entities;
using System;
using Xunit;

namespace JNVAdmin.Domain.Tests
{
    public class SnackUnitTest
    {
        [Fact(DisplayName = "Create Snack OK")]
        public void CreateSnack_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Snack("Snack Name", "admin", "tester");
            action.Should().NotThrow<JNVAdmin.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
