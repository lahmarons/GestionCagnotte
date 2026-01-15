# Script pour lancer l'API et le frontend Blazor

Write-Host "=====================================" -ForegroundColor Cyan
Write-Host " Démarrage de Cagnotte Participative" -ForegroundColor Cyan
Write-Host "=====================================" -ForegroundColor Cyan
Write-Host ""

# Démarrer l'API en arrière-plan
Write-Host "Démarrage de l'API backend..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$(Get-Location)\CagnotteParticipativeExam'; dotnet run"

# Attendre que l'API démarre
Start-Sleep -Seconds 3

# Démarrer le frontend Blazor
Write-Host "Démarrage du frontend Blazor..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$(Get-Location)\CagnotteParticipative.UI'; dotnet run"

Write-Host ""
Write-Host "=====================================" -ForegroundColor Green
Write-Host " Applications démarrées !" -ForegroundColor Green
Write-Host "=====================================" -ForegroundColor Green
Write-Host ""
Write-Host "API Backend: https://localhost:7293" -ForegroundColor Cyan
Write-Host "Frontend Blazor: https://localhost:5001" -ForegroundColor Cyan
Write-Host ""
Write-Host "Appuyez sur une touche pour quitter..." -ForegroundColor Yellow
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
