using StorageManager;

namespace Management
{
    public class Management : IManagement
    {
        private IEngineStorage storage { get; set; }
        private IEngineStorageAvl storage2 { get; set; }
        public Management(IEngineStorage storage, IEngineStorageAvl storage2)
        {
            this.storage = storage;
            this.storage2 = storage2;
        }
        public void ApproveEngine(string name)
        {
            storage2.AddEngine(name, storage.GetEnginePath(name));
            storage.RemoveEngine(name);
        }

        public string DownloadEngine(string name)
            => storage.GetEnginePath(name);

        public void UploadEngine(string name, string path)
            => storage.AddEngine(name, path);
        public List<string> GetEngines()
            => storage.GetEngines().Keys.ToList();
    }
}
