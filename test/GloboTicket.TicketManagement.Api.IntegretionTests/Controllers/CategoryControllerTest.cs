using System.Text.Json;
using GloboTicket.TicketManagement.Api.IntegrationTests.Base;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GloboTicket.TicketManagement.Api.IntegrationTests.Controllers;

public class CategoryControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public CategoryControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ReturnsSuccessResult()
    {
        var client = _factory.GetAnonymousClient();

        var response = await client.GetAsync("/api/category/all");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);

        Assert.IsType<List<CategoryListVm>>(result);
        Assert.NotEmpty(result);
        
    }
}