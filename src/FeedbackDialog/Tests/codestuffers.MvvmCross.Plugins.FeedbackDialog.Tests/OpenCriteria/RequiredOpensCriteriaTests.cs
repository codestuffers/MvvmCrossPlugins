using System;
using NUnit.Framework;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;
using FluentAssertions;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Tests
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
    }
}

