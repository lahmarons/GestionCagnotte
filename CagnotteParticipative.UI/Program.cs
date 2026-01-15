using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CagnotteParticipative.UI;
using CagnotteParticipative.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuration du HttpClient pour pointer vers l'API backend
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7293/") // URL de votre API
});

// Enregistrement du service CagnotteService
builder.Services.AddScoped<CagnotteService>();

await builder.Build().RunAsync();
