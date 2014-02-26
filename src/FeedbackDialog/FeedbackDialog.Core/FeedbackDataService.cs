using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.File;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    internal class FeedbackDataService : IFeedbackDataService
    {
        private const string DataFileName = "codestuffers.feedbackData.json";
        private readonly IMvxFileStore _fileStore;
        private readonly IMvxJsonConverter _jsonConverter;

        public FeedbackDataService(IMvxFileStore fileStore, IMvxJsonConverter jsonConverter)
        {
            _fileStore = fileStore;
            _jsonConverter = jsonConverter;
        }

        public FeedbackAction AppWasOpened(int maxNumberOfOpens)
        {
            var data = GetData();

            if (data.DialogWasShown)
            {
                return FeedbackAction.Nothing;
            }

            data.AppHasOpened();
            SaveData(data);

            return data.ShouldOpenDialog(maxNumberOfOpens) ? FeedbackAction.OpenDialog : FeedbackAction.Nothing;
        }

        public void DialogWasShown()
        {
            var data = GetData();
            data.DialogWasShown = true;
            SaveData(data);
        }

        public void ResetAppCount()
        {
            _fileStore.DeleteFile(DataFileName);
        }

        private IFeedbackData GetData()
        {
            string feedbackDataBuffer;

            return _fileStore.TryReadTextFile(DataFileName, out feedbackDataBuffer) ?
                _jsonConverter.DeserializeObject<FeedbackData>(feedbackDataBuffer) :
                new FeedbackData();
        }

        private void SaveData(IFeedbackData feedbackData)
        {
            _fileStore.WriteFile(DataFileName, _jsonConverter.SerializeObject(feedbackData));
        }
    }
}