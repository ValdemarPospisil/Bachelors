using Xunit;
using Moq;
using GoodAccess.CLI.Storage;

namespace GoodAccess.CLI.Tests
{
    public class CliStorageTests
    {
        [Fact]
        public void SavePreferences_ShouldStoreCorrectData()
        {
            // Arrange
            var mockProtector = new Mock<IDataProtectionProvider>();
            var storage = new CliStorage(mockProtector.Object);
            var prefs = new CliPreferences { LastUser = "test@example.com" };

            // Act
            storage.SavePreferences(prefs);

            // Assert
            // Ověření, že data byla předána k šifrování a následně uložena
            mockProtector.Verify(p => p.Protect(It.IsAny<byte[]>()), Times.Once);
        }
    }
}
