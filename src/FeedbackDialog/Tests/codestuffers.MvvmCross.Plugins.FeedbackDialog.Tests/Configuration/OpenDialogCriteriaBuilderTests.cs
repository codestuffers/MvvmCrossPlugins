using System;
using System.Linq;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;
using FluentAssertions;
using NUnit.Framework;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Tests.Configuration
{
    [TestFixture]
    internal class OpenDialogCriteriaBuilderTests
    {
        [Test]
        public void NumberOfOpens_AddsCriteriaWithValue()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            testObject.NumberOfOpens(3);

            testObject.OpenDialogCriteria.OfType<RequiredOpensCriteria>().Should().HaveCount(1);
            testObject.OpenDialogCriteria.OfType<RequiredOpensCriteria>()
                    .First()
                    .ShowDialogAfterOpens.Should()
                    .Be(3);
        }

        [Test]
        public void NumberOfOpens_ReturnsBuilder()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            var builder = testObject.NumberOfOpens(3);
            builder.Should().Be(testObject);
        }
        
        [Test]
        public void TimeUsed_AddsCriteriaWithValue()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            testObject.TimeUsed(TimeSpan.FromHours(3));

            testObject.OpenDialogCriteria.OfType<TimeUsedCriteria>().Should().HaveCount(1);
            testObject.OpenDialogCriteria.OfType<TimeUsedCriteria>()
                    .First()
                    .TimesOpen.Should()
                    .Be(TimeSpan.FromHours(3));
        }

        [Test]
        public void TimeUsed_ReturnsBuilder()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            var builder = testObject.TimeUsed(TimeSpan.FromHours(3));
            builder.Should().Be(testObject);
        }

        [Test]
        public void AndAfterNumberOfOpens_AddsCriteriaWithValue()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            testObject.AndAfterNumberOfOpens(3);

            testObject.OpenDialogCriteria.OfType<RequiredOpensCriteria>().Should().HaveCount(1);
            testObject.OpenDialogCriteria.OfType<RequiredOpensCriteria>()
                    .First()
                    .ShowDialogAfterOpens.Should()
                    .Be(3);
        }

        [Test]
        public void AndAfterTimeUsed_AddsCriteriaWithValue()
        {
            var testObject = new OpenDialogCriteriaBuilder();
            testObject.AndAfterTimeUsed(TimeSpan.FromHours(3));

            testObject.OpenDialogCriteria.OfType<TimeUsedCriteria>().Should().HaveCount(1);
            testObject.OpenDialogCriteria.OfType<TimeUsedCriteria>()
                    .First()
                    .TimesOpen.Should()
                    .Be(TimeSpan.FromHours(3));
        }
    }
}
