using System;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;
using FluentAssertions;
using NUnit.Framework;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Tests.OpenCriteria
{
    [TestFixture()]
    public class TimeUsedCriteriaTests
    {
        [Test]
        public void ShouldOpen_ReturnsTrue_WhenUsedLongerThanRequiredTime()
        {
            var testObject = new TimeUsedCriteria(TimeSpan.FromDays(3))
            {
                CurrentTime = () => new DateTime(2014, 5, 5, 12, 0, 0)
            };

            testObject.ShouldOpen(new FeedbackData {AppInstallDate = new DateTime(2014, 5, 2, 11, 59, 59)})
                .Should()
                .BeTrue();
        }

        [Test]
        public void ShouldOpen_ReturnsFalse_WhenUsedShorterThanRequiredTime()
        {
            var testObject = new TimeUsedCriteria(TimeSpan.FromDays(3))
            {
                CurrentTime = () => new DateTime(2014, 5, 5, 12, 0, 0)
            };

            testObject.ShouldOpen(new FeedbackData { AppInstallDate = new DateTime(2014, 5, 2, 12, 0, 1) })
                .Should()
                .BeFalse();
        }

        [Test]
        public void CurrentTime_ReturnsActualTime_WhenNotExplicitlySet()
        {
            var lowTime = DateTime.UtcNow;
            var testObject = new TimeUsedCriteria(TimeSpan.FromDays(1));
            testObject.CurrentTime() .Should().BeWithin(TimeSpan.FromSeconds(2)).After(lowTime);
        }
    }
}
