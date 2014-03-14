using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Cirrious.MvvmCross.Plugins.Email;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;
using codestuffers.MvvmCross.Plugins.UserInteraction;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Tests
{
    [TestFixture]
    public class MvxFeedbackDialogTests
    {
        private Mock<IMvxUserInteraction> _userInteraction;
        private Mock<IFeedbackDataService> _dataService;
        private Mock<IMvxComposeEmailTask> _emailTask;
        private Mock<IMvxWebBrowserTask> _webBrowser;
        private Mock<FeedbackData> _data;
        private FeedbackDialogConfiguration _configuration;
        private List<IOpenDialogCriteria> _criteria;
        private MvxFeedbackDialog _testObject;

        [SetUp]
        public void Setup()
        {
            _criteria = new List<IOpenDialogCriteria>();
            _data = new Mock<FeedbackData>();
            _data.SetupProperty(x => x.DialogWasShown);

            _userInteraction = new Mock<IMvxUserInteraction>();
            _dataService = new Mock<IFeedbackDataService>();
            _dataService.Setup(x => x.GetData()).Returns(() => _data.Object);

            _emailTask = new Mock<IMvxComposeEmailTask>();
            _webBrowser = new Mock<IMvxWebBrowserTask>();
            _configuration = new FeedbackDialogConfiguration {OpenCriteria = _criteria};

            _testObject = new MvxFeedbackDialog(_userInteraction.Object, 
                _dataService.Object, _emailTask.Object, _webBrowser.Object);
            _testObject.SetConfiguration(_configuration);
        }

        [Test]
        public void RecordAppStart_ShouldNotRecordAppStart_WhenDialogHasAlreadyBeenOpened()
        {
            _data.Setup(x => x.DialogWasShown).Returns(true);
            _testObject.RecordAppStart();
            _data.Verify(x => x.AppHasOpened(), Times.Never());
        }

        [Test]
        public void RecordAppStart_ShouldRecordAppStart_WhenDialogHasNotBeenOpened()
        {
            _data.Setup(x => x.DialogWasShown).Returns(false);
            _testObject.RecordAppStart();
            _data.Verify(x => x.AppHasOpened(), Times.Once());
        }

        [Test]
        public void RecordAppStart_ShouldMarkDialogAsOpened_WhenAllCriteriaIsTrue()
        {
            var criteria1 = new Mock<IOpenDialogCriteria>();
            criteria1.Setup(x => x.ShouldOpen(It.IsAny<FeedbackData>())).Returns(true);
            var criteria2 = new Mock<IOpenDialogCriteria>();
            criteria2.Setup(x => x.ShouldOpen(It.IsAny<FeedbackData>())).Returns(true);

            _criteria.Add(criteria1.Object);
            _criteria.Add(criteria2.Object);

            _data.SetupSet(x => x.DialogWasShown = true);
            _testObject.RecordAppStart();
            _data.VerifySet(x => x.DialogWasShown = true);
        }

        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public void RecordAppStart_ShouldNotMarkDialogAsOpened_WhenAnyCriteriaIsFalse(bool crit1, bool crit2)
        {
            var criteria1 = new Mock<IOpenDialogCriteria>();
            criteria1.Setup(x => x.ShouldOpen(It.IsAny<FeedbackData>())).Returns(crit1);
            var criteria2 = new Mock<IOpenDialogCriteria>();
            criteria2.Setup(x => x.ShouldOpen(It.IsAny<FeedbackData>())).Returns(crit2);

            _criteria.Add(criteria1.Object);
            _criteria.Add(criteria2.Object);

            _data.SetupSet(x => x.DialogWasShown = false);
            _testObject.RecordAppStart();
            _data.VerifySet(x => x.DialogWasShown = false);
        }

        [Test]
        public void RecordAppStart_ShouldNotMarkDialogAsOpened_WhenThereAreNoCriteria()
        {
            _data.SetupProperty(x => x.DialogWasShown, false);
            _testObject.RecordAppStart();
            _data.Object.DialogWasShown.Should().BeFalse();
        }

        [Test]
        public void RecordAppStart_ShouldSaveData_WhenDialogHasNotBeenOpened()
        {
            _data.Setup(x => x.DialogWasShown).Returns(false);
            _testObject.RecordAppStart();
            _dataService.Verify(x => x.SaveData(_data.Object), Times.Once());
        }

        [Test]
        public void RecordAppStart_ShouldOpenDialog_WhenAllCriteriaIsTrue()
        {
            var criteria1 = new Mock<IOpenDialogCriteria>();
            criteria1.Setup(x => x.ShouldOpen(It.IsAny<FeedbackData>())).Returns(true);
            _criteria.Add(criteria1.Object);

            _testObject.RecordAppStart();
            _userInteraction.Verify(x => x.ShowDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action>(), It.IsAny<Action>()));
        }
    }
}
