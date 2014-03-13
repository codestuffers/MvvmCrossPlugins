using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;
using FluentAssertions;
using NUnit.Framework;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Tests.OpenCriteria
{
    [TestFixture()]
    public class RequiredOpensCriteriaTests
    {
        [Test]
        public void ShouldOpen_ShouldBeTrue_IfOpenCountIsGreaterThanRequiredCount()
        {
            var testObject = new RequiredOpensCriteria(3);
            testObject.ShouldOpen(new FeedbackData { TimesAppHasStarted = 3 }).Should().BeTrue();
        }

        [Test]
        public void ShouldOpen_ShouldBeFalse_IfOpenCountIsLessThanRequiredCount()
        {
            var testObject = new RequiredOpensCriteria(3);
            testObject.ShouldOpen(new FeedbackData {TimesAppHasStarted = 2}).Should().BeFalse();
        }
    }
}

