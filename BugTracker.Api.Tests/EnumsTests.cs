using BugTracker.Api.Models;
using Xunit;
using System;
using System.Linq;

namespace BugTracker.Api.Tests
{
    public class EnumsTests
    {
        [Fact]
        public void Priority_Values_ShouldBeValid()
        {
            var priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
            var priorityMapping = new[]
            {
                (Priority.Low, 1),
                (Priority.Medium, 2),
                (Priority.High, 3),
                (Priority.Critical, 4)
            };

            // Verify that all values are present and correct
            foreach (var (priority, expectedValue) in priorityMapping)
            {
                Assert.Equal(expectedValue, (int)priority);
            }

            // Verify that values are unique
            var values = priorities.Select(p => (int)p).ToArray();
            Assert.Equal(values.Length, values.Distinct().Count());

            // Verify that values are in ascending order
            Assert.True(values.SequenceEqual(values.OrderBy(v => v)));
        }

        [Fact]
        public void Status_Values_ShouldBeValid()
        {
            var statuses = Enum.GetValues(typeof(Status)).Cast<Status>();
            var statusMapping = new[]
            {
                (Status.Planning, 1),
                (Status.InProgress, 2),
                (Status.Fixed, 3),
                (Status.Reopened, 4),
                (Status.Completed, 5),
                (Status.OnHold, 6),
                (Status.Cancelled, 7),
                (Status.Closed, 8)
            };

            // Verify that all values are present and correct
            foreach (var (status, expectedValue) in statusMapping)
            {
                Assert.Equal(expectedValue, (int)status);
            }

            // Verify that values are unique
            var values = statuses.Select(s => (int)s).ToArray();
            Assert.Equal(values.Length, values.Distinct().Count());

            // Verify that values are in ascending order
            Assert.True(values.SequenceEqual(values.OrderBy(v => v)));

            // Verify that names are valid
            foreach (var status in statuses)
            {
                Assert.NotEqual(string.Empty, status.ToString());
            }
        }

        [Fact]
        public void Priority_Values_ShouldBeConsecutive()
        {
            var priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
            var values = priorities.Select(p => (int)p).OrderBy(v => v).ToList();
            
            for (int i = 0; i < values.Count - 1; i++)
            {
                Assert.Equal(values[i] + 1, values[i + 1]);
            }
        }

        [Fact]
        public void Status_Values_ShouldBeConsecutive()
        {
            var statuses = Enum.GetValues(typeof(Status)).Cast<Status>();
            var values = statuses.Select(s => (int)s).OrderBy(v => v).ToList();
            
            for (int i = 0; i < values.Count - 1; i++)
            {
                Assert.Equal(values[i] + 1, values[i + 1]);
            }
        }
    }
}
