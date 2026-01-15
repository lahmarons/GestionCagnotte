using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CagnotteParticipative.UI;
using CagnotteParticipative.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuration du HttpClient avec l'URL de votre API
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7293") // Remplacez par l'URL de votre API
});

// Enregistrement du service
builder.Services.AddScoped<CagnotteService>();

await builder.Build().RunAsync();using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CagnotteParticipative.UI;
using CagnotteParticipative.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuration du HttpClient avec l'URL de votre API
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7293") // Remplacez par l'URL de votre API
});

// Enregistrement du service
builder.Services.AddScoped<CagnotteService>();

await builder.Build().RunAsync();