using System;
using System.Collections.Generic;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration
{
    class OpenDialogCriteriaBuilder : IOpenDialogCriteriaBuilder, IOpenDialogAfterTimeUsedCrtieriaBuilder, IOpenDialogAfterNumberOfOpensCriteriaBuilder, IFinishOpenDialogCriteriaBuilder
    {
        internal List<IOpenDialogCriteria> OpenDialogCriteria { get; set; } 

        public OpenDialogCriteriaBuilder()
        {
            OpenDialogCriteria = new List<IOpenDialogCriteria>();
        }

        public IOpenDialogAfterNumberOfOpensCriteriaBuilder NumberOfOpens(int openCount)
        {
            AndAfterNumberOfOpens(openCount);
            return this;
        }

        public IOpenDialogAfterTimeUsedCrtieriaBuilder TimeUsed(TimeSpan timeUsed)
        {
            AndAfterTimeUsed(timeUsed);
            return this;
        }

        public IFinishOpenDialogCriteriaBuilder AndAfterNumberOfOpens(int openCount)
        {
            OpenDialogCriteria.Add(new RequiredOpensCriteria(openCount));
            return this;
        }

        public IFinishOpenDialogCriteriaBuilder AndAfterTimeUsed(TimeSpan timeUsed)
        {
            OpenDialogCriteria.Add(new TimeUsedCriteria(timeUsed));
            return this;
        }
    }
}