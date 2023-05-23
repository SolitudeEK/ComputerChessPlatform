using StorageManager;

namespace Management.Test
{
    [TestFixture]
    public class EngineStorageTests
    {
        private const string TestFilePath = "test.json";
        private EngineStorage engineStorage;

        [SetUp]
        public void Setup()
        {
            // Create a test file
            File.WriteAllText(TestFilePath, "{}");

            // Initialize the EngineStorage instance with the test file path
            engineStorage = new EngineStorage(TestFilePath);
        }

        [TearDown]
        public void Cleanup()
        {
            // Delete the test file
            File.Delete(TestFilePath);
        }

        [Test]
        public void GetEnginePath_ExistingEngine_ReturnsPath()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Add a test engine to the storage
            engineStorage.AddEngine(engineName, enginePath);

            // Act
            string result = engineStorage.GetEnginePath(engineName);

            // Assert
            Assert.AreEqual(enginePath, result);
        }

        [Test]
        public void GetEnginePath_NonExistingEngine_ReturnsNull()
        {
            // Arrange
            const string engineName = "Engine1";

            // Act
            string result = engineStorage.GetEnginePath(engineName);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetEngines_ReturnsAllEngines()
        {
            // Arrange
            Dictionary<string, string> expectedEngines = new Dictionary<string, string>
            {
                { "Engine1", "C:\\Engines\\Engine1" },
                { "Engine2", "C:\\Engines\\Engine2" },
                { "Engine3", "C:\\Engines\\Engine3" }
            };

            // Add test engines to the storage
            foreach (var engine in expectedEngines)
            {
                engineStorage.AddEngine(engine.Key, engine.Value);
            }

            // Act
            Dictionary<string, string> result = engineStorage.GetEngines();

            // Assert
            CollectionAssert.AreEquivalent(expectedEngines, result);
        }

        [Test]
        public void AddEngine_EngineAddedSuccessfully()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Act
            engineStorage.AddEngine(engineName, enginePath);

            // Assert
            string storedPath = engineStorage.GetEnginePath(engineName);
            Assert.AreEqual(enginePath, storedPath);
        }

        [Test]
        public void RemoveEngine_EngineRemovedSuccessfully()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Add a test engine to the storage
            engineStorage.AddEngine(engineName, enginePath);

            // Act
            engineStorage.RemoveEngine(engineName);

            // Assert
            string storedPath = engineStorage.GetEnginePath(engineName);
            Assert.IsNull(storedPath);
        }
    }
}