using Xunit;
using System.Threading.Tasks;

namespace Retards.DAL.API.Tests
{
    public class client_test
    {
        [Fact]
        public void GetNombreCreationsCompte()
        {
            // Arrange
            var client = new Client();

            // Act
            var result = client.GetNombreCreationsCompte( new Periode_DTO());

            // Assert
            Assert.NotNull(result);
            
        }
    }
}