namespace SentosApiLibrary.Abstracts
{
    public interface IConfig
    {
        public string GetApiUrl();

        public string GetApiKey();

        public string GetApiSecret();

        public bool IsTestMode { get; }

        public string TestStoragePath { get; }
    }
}
