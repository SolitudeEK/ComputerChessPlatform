namespace Management
{
    public interface IManagement
    {
        public void UploadEngine(string name, string path);
        public string DownloadEngine(string name);
        public void ApproveEngine(string name);
        public List<string> GetEngines();
    }
}