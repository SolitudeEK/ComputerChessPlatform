using Moq;
using StorageManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Test
{
    [TestFixture]
    public class ManagementTests
    {
        private Mock<IEngineStorage> mockStorage;
        private Mock<IEngineStorageAvl> mockStorage2;
        private IManagement management;

        [SetUp]
        public void Setup()
        {
            mockStorage = new Mock<IEngineStorage>();
            mockStorage2 = new Mock<IEngineStorageAvl>();
            management = new Management(mockStorage.Object, mockStorage2.Object);
        }

        [Test]
        public void ApproveEngine_ExistingEngine_InvokesAddAndRemoveEngine()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Setup the mock storage
            mockStorage.Setup(s => s.GetEnginePath(engineName)).Returns(enginePath);

            // Act
            management.ApproveEngine(engineName);

            // Assert
            mockStorage2.Verify(s => s.AddEngine(engineName, enginePath), Times.Once);
            mockStorage.Verify(s => s.RemoveEngine(engineName), Times.Once);
        }

        [Test]
        public void DownloadEngine_ExistingEngine_ReturnsEnginePath()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Setup the mock storage
            mockStorage.Setup(s => s.GetEnginePath(engineName)).Returns(enginePath);

            // Act
            string result = management.DownloadEngine(engineName);

            // Assert
            Assert.AreEqual(enginePath, result);
        }

        [Test]
        public void UploadEngine_AddsEngineToStorage()
        {
            // Arrange
            const string engineName = "Engine1";
            const string enginePath = "C:\\Engines\\Engine1";

            // Act
            management.UploadEngine(engineName, enginePath);

            // Assert
            mockStorage.Verify(s => s.AddEngine(engineName, enginePath), Times.Once);
        }

        [Test]
        public void GetEngines_ReturnsEnginesFromStorage()
        {
            // Arrange
            Dictionary<string, string> expectedEngines = new Dictionary<string, string>
            {
                { "Engine1", "C:\\Engines\\Engine1" },
                { "Engine2", "C:\\Engines\\Engine2" },
                { "Engine3", "C:\\Engines\\Engine3" }
            };

            // Setup the mock storage
            mockStorage.Setup(s => s.GetEngines()).Returns(expectedEngines);

            // Act
            List<string> result = management.GetEngines();

            // Assert
            CollectionAssert.AreEquivalent(expectedEngines.Keys, result);
        }

        [Test]
        public void GetEnginesInUse_ReturnsEnginesFromStorage2()
        {
            // Arrange
            Dictionary<string, string> expectedEngines = new Dictionary<string, string>
            {
                { "Engine1", "C:\\Engines\\Engine1" },
                { "Engine2", "C:\\Engines\\Engine2" },
                { "Engine3", "C:\\Engines\\Engine3" }
            };

            // Setup the mock storage2
            mockStorage2.Setup(s => s.GetEngines()).Returns(expectedEngines);

            // Act
            List<string> result = management.GetEnginesInUse();

            // Assert
            CollectionAssert.AreEquivalent(expectedEngines.Keys, result);
        }
    }
}
