using FluentAssertions;
using JNVAdmin.Domain.Entities;
using System;
using Xunit;

namespace JNVAdmin.Domain.Tests
{
    public class ScheduleUnitTest
    {
        [Fact(DisplayName = "Create Schedule OK")]
        public void CreateSchedule_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Schedule(Guid.NewGuid(), "Schedule Name", DateTime.Now, 0, 0, 0, 0, 0);
            action.Should().NotThrow<JNVAdmin.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
