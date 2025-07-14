using SentosApiLibrary.Abstracts;

namespace SentosApiLibrary
{
    public class Config(string apiUrl, string apiKey, string apiSecret) : IConfig
    {
        public bool IsTestMode { get; private set; } = false;

        public string TestStoragePath { get; private set; } = string.Empty;

        public void SetTestMode(bool isTestMode, string testStoragePath = "")
        {
            IsTestMode = isTestMode;
            TestStoragePath = testStoragePath;
        }

        public string GetApiKey() => apiKey;

        public string GetApiSecret() => apiSecret;        

        public string GetApiUrl() => apiUrl;
    }
}
