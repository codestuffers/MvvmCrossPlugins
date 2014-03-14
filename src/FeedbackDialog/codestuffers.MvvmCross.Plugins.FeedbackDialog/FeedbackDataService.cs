using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.File;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Handles loading and saving of feedback dialog data
    /// </summary>
    internal class FeedbackDataService : IFeedbackDataService
    {
        private const string DataFileName = "codestuffers.feedbackData.json";
        private readonly IMvxFileStore _fileStore;
        private readonly IMvxJsonConverter _jsonConverter;

        /// <summary>
        /// Creates a new instance of the FeedbackDataService
        /// </summary>
        /// <param name="fileStore">File store that will be used to interact with data</param>
        /// <param name="jsonConverter">Converter used to serialize and deserialize json</param>
        public FeedbackDataService(IMvxFileStore fileStore, IMvxJsonConverter jsonConverter)
        {
            _fileStore = fileStore;
            _jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Gets the data from the file system
        /// </summary>
        /// <returns>An instance of the saved data, or a new instance if none had been saved</returns>
        public FeedbackData GetData()
        {
            string feedbackDataBuffer;

            return _fileStore.TryReadTextFile(DataFileName, out feedbackDataBuffer) ?
                _jsonConverter.DeserializeObject<FeedbackData>(feedbackDataBuffer) :
                new FeedbackData();
        }

        /// <summary>
        /// Saves the data to the file system.
        /// </summary>
        /// <param name="feedbackData">Data that should be saved</param>
        public void SaveData(FeedbackData feedbackData)
        {
            _fileStore.WriteFile(DataFileName, _jsonConverter.SerializeObject(feedbackData));
        }
    }
}