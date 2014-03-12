using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    internal interface IOpenDialogCriteria
	{
        bool ShouldOpen(FeedbackData data);
	}
}

