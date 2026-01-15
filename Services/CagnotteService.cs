using CagnotteParticipative.UI.Models;
using System.Net.Http.Json;

namespace CagnotteParticipative.UI.Services;

public class CagnotteService
{
    private readonly HttpClient _httpClient;

    public CagnotteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Récupérer toutes les cagnottes
    public async Task<List<CagnotteDto>> GetAllCagnottesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<CagnotteDto>>("api/cagnottes") 
               ?? new List<CagnotteDto>();
    }

    // Récupérer une cagnotte par ID
    public async Task<CagnotteDto?> GetCagnotteByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<CagnotteDto>($"api/cagnottes/{id}");
    }

    // Créer une nouvelle cagnotte
    public async Task<CagnotteDto?> CreateCagnotteAsync(CreateCagnotteRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/cagnottes", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CagnotteDto>();
    }

    // Récupérer les contributions d'une cagnotte
    public async Task<List<ContributionDto>> GetContributionsAsync(int cagnotteId)
    {
        return await _httpClient.GetFromJsonAsync<List<ContributionDto>>($"api/cagnottes/{cagnotteId}/contributions") 
               ?? new List<ContributionDto>();
    }

    // Ajouter une contribution
    public async Task<ContributionDto?> AddContributionAsync(int cagnotteId, CreateContributionRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/cagnottes/{cagnotteId}/contributions", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ContributionDto>();
    }
}