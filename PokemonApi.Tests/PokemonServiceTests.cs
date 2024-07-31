using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using System.Net;
using System.Threading;
using PokemonApi.Services;
using System.Linq;

public class PokemonServiceTests
{
    [Fact]
    public async Task GetHiddenAbilities_ReturnsHiddenAbilities()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                It.IsAny<HttpRequestMessage>(),
                It.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"abilities\":[{\"ability\":{\"name\":\"hidden-ability\",\"is_hidden\":true}}]}")
            });

        var httpClient = new HttpClient(handlerMock.Object);
        var service = new PokemonService(httpClient);

        var abilities = await service.GetHiddenAbilities("pikachu");

        Assert.Single(abilities);
        Assert.Equal("hidden-ability", abilities.FirstOrDefault());
    }
}