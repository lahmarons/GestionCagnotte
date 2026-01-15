# Script pour démarrer API + Frontend
Write-Host "?? Démarrage de Cagnotte Participative" -ForegroundColor Cyan
Write-Host "======================================" -ForegroundColor Cyan
Write-Host ""

# Démarrer l'API
Write-Host "[1/2] Démarrage de l'API Backend..." -ForegroundColor Yellow
$apiPath = Join-Path $PSScriptRoot "CagnotteParticipativeExam"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$apiPath'; Write-Host 'API Backend - Port 7293' -ForegroundColor Green; dotnet run"

# Attendre
Write-Host "[2/2] Attente de 5 secondes..." -ForegroundColor Yellow
Start-Sleep -Seconds 5

# Démarrer le Frontend
Write-Host "[2/2] Démarrage du Frontend Blazor..." -ForegroundColor Yellow
$uiPath = Join-Path $PSScriptRoot "CagnotteParticipative.UI"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$uiPath'; Write-Host 'Frontend Blazor - Port 7144' -ForegroundColor Green; dotnet run"

Write-Host ""
Write-Host "? Applications démarrées !" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "?? URLs importantes:" -ForegroundColor Yellow
Write-Host "   Frontend: " -NoNewline; Write-Host "https://localhost:7144" -ForegroundColor Cyan
Write-Host "   API:      " -NoNewline; Write-Host "https://localhost:7293" -ForegroundColor Cyan
Write-Host ""
Write-Host "?? Ouvrez votre navigateur sur:" -ForegroundColor Yellow
Write-Host "   https://localhost:7144" -ForegroundColor Green
Write-Host ""
Write-Host "Appuyez sur une touche pour continuer..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
