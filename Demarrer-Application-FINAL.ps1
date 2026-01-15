# ========================================
# Script de Démarrage Cagnotte Participative
# ========================================

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  DEMARRAGE CAGNOTTE PARTICIPATIVE" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Définir le répertoire de travail
$workspaceRoot = "C:\Users\lahma\OneDrive\Bureau\cagnotte-master"
Set-Location $workspaceRoot

# Étape 1 : Arrêter tous les processus dotnet et IIS Express
Write-Host "[1/5] Arrêt de tous les processus en cours..." -ForegroundColor Yellow
Get-Process -Name "dotnet", "iisexpress" -ErrorAction SilentlyContinue | Stop-Process -Force
Start-Sleep -Seconds 2
Write-Host "      ? Processus arrêtés" -ForegroundColor Green
Write-Host ""

# Étape 2 : Nettoyer les projets
Write-Host "[2/5] Nettoyage des projets..." -ForegroundColor Yellow
Set-Location "$workspaceRoot\CagnotteParticipativeExam"
dotnet clean --verbosity quiet
Set-Location "$workspaceRoot\CagnotteParticipative.UI"
dotnet clean --verbosity quiet
Write-Host "      ? Projets nettoyés" -ForegroundColor Green
Write-Host ""

# Étape 3 : Compilation des projets
Write-Host "[3/5] Compilation des projets..." -ForegroundColor Yellow
Set-Location "$workspaceRoot\CagnotteParticipativeExam"
dotnet build --verbosity quiet
Set-Location "$workspaceRoot\CagnotteParticipative.UI"
dotnet build --verbosity quiet
Write-Host "      ? Projets compilés" -ForegroundColor Green
Write-Host ""

# Étape 4 : Démarrer l'API Backend
Write-Host "[4/5] Démarrage de l'API Backend..." -ForegroundColor Yellow
Set-Location "$workspaceRoot\CagnotteParticipativeExam"
$apiJob = Start-Job -ScriptBlock {
    Set-Location "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam"
    dotnet run --no-build
}
Start-Sleep -Seconds 5
Write-Host "      ? API Backend démarrée sur https://localhost:7293" -ForegroundColor Green
Write-Host ""

# Étape 5 : Démarrer le Frontend Blazor
Write-Host "[5/5] Démarrage du Frontend Blazor..." -ForegroundColor Yellow
Set-Location "$workspaceRoot\CagnotteParticipative.UI"
$uiJob = Start-Job -ScriptBlock {
    Set-Location "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI"
    dotnet run --no-build
}
Start-Sleep -Seconds 5
Write-Host "      ? Frontend Blazor démarré sur https://localhost:7144" -ForegroundColor Green
Write-Host ""

# Afficher les informations
Write-Host "========================================" -ForegroundColor Green
Write-Host "  ? APPLICATIONS DEMARREES !" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""
Write-Host "?? URLs des applications:" -ForegroundColor Yellow
Write-Host "   API Backend:  " -NoNewline -ForegroundColor White
Write-Host "https://localhost:7293" -ForegroundColor Cyan
Write-Host "   Frontend:     " -NoNewline -ForegroundColor White
Write-Host "https://localhost:7144" -ForegroundColor Green
Write-Host ""
Write-Host "?? Ouvrez votre navigateur sur:" -ForegroundColor Yellow
Write-Host "   https://localhost:7144" -ForegroundColor Green -BackgroundColor DarkGreen
Write-Host ""

# Ouvrir automatiquement le navigateur
Write-Host "?? Ouverture automatique du navigateur dans 3 secondes..." -ForegroundColor Yellow
Start-Sleep -Seconds 3
Start-Process "https://localhost:7144"

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "??  IMPORTANT:" -ForegroundColor Yellow
Write-Host "   - L'API tourne sur le port 7293 (Swagger)" -ForegroundColor White
Write-Host "   - Le Frontend tourne sur le port 7144 (Interface)" -ForegroundColor White
Write-Host "   - NE FERMEZ PAS cette fenêtre !" -ForegroundColor Red
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Pour arrêter les applications, appuyez sur Ctrl+C" -ForegroundColor Yellow
Write-Host ""

# Attendre l'interruption de l'utilisateur
try {
    Write-Host "Applications en cours d'exécution... (Ctrl+C pour arrêter)" -ForegroundColor Green
    while ($true) {
        Start-Sleep -Seconds 1
    }
}
finally {
    Write-Host ""
    Write-Host "Arrêt des applications..." -ForegroundColor Yellow
    Stop-Job -Job $apiJob, $uiJob -ErrorAction SilentlyContinue
    Remove-Job -Job $apiJob, $uiJob -ErrorAction SilentlyContinue
    Get-Process -Name "dotnet" -ErrorAction SilentlyContinue | Stop-Process -Force
    Write-Host "Applications arrêtées." -ForegroundColor Red
}
