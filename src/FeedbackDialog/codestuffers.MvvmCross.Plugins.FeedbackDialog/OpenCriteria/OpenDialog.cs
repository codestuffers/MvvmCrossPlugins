using codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    public static class OpenDialog
    {
        public static IOpenDialogCriteriaBuilder After
        {
            get
            {
                return new OpenDialogCriteriaBuilder();
            }
        }
    }
}
