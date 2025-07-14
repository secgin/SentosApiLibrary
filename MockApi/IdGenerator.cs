using System.Text.Json;

namespace SentosApiLibrary.MockApi
{
    internal class IdGenerator
    {
        private Sequence _sequence;

        private readonly string _filePath;
        
        public IdGenerator(string storeRootPath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(storeRootPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(storeRootPath)!);
            }

            _filePath = Path.Combine(storeRootPath, "Sequence.json");
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _sequence = JsonSerializer.Deserialize<Sequence>(json) ?? new Sequence();
            }
            else
            {
                _sequence = new Sequence();
            }
        }

        public int GetNextProductId()
        {            
            _sequence.Product++;
            var json = JsonSerializer.Serialize(_sequence, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);

            return _sequence.Product;
        }
    }

    internal class Sequence
    {
        public int Product { get; set; } = 0;
    }
}
