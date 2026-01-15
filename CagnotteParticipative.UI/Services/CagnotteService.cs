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
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<CagnotteDto>>("api/cagnottes");
            return result ?? new List<CagnotteDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur GetAllCagnottesAsync: {ex.Message}");
            return new List<CagnotteDto>();
        }
    }

    // Récupérer une cagnotte par ID
    public async Task<CagnotteDto?> GetCagnotteByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<CagnotteDto>($"api/cagnottes/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur GetCagnotteByIdAsync: {ex.Message}");
            return null;
        }
    }

    // Créer une nouvelle cagnotte
    public async Task<CagnotteDto?> CreateCagnotteAsync(CreateCagnotteRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/cagnottes", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CagnotteDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur CreateCagnotteAsync: {ex.Message}");
            throw;
        }
    }

    // Récupérer les contributions d'une cagnotte
    public async Task<List<ContributionDto>> GetContributionsAsync(int cagnotteId)
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<ContributionDto>>($"api/cagnottes/{cagnotteId}/participations");
            return result ?? new List<ContributionDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur GetContributionsAsync: {ex.Message}");
            return new List<ContributionDto>();
        }
    }

    // Ajouter une contribution
    public async Task<ContributionDto?> AddContributionAsync(int cagnotteId, CreateContributionRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/cagnottes/{cagnotteId}/participations", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContributionDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur AddContributionAsync: {ex.Message}");
            throw;
        }
    }
}
