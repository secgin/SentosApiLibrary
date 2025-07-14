using System.Text.Json;

namespace SentosApiLibrary.MockApi
{
    public class JsonDataStore<T> where T : class
    {
        private readonly string _filePath;
        private List<T> _items;

        public JsonDataStore(string filePath)
        {
            _filePath = filePath;

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            }

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                _items = new List<T>();
            }
        }

        public List<T> GetAll() => _items;

        public T? Find(Func<T, bool> predicate)
        {
            return _items.FirstOrDefault(predicate);
        }

        public List<T> FindAll(Func<T, bool> predicate)
        {
            return _items.Where(predicate).ToList();
        }

        public void Add(T item)
        {
            _items.Add(item);
            Save();
        }

        public void ReplaceAll(List<T> items)
        {
            _items = items;
            Save();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }

}
