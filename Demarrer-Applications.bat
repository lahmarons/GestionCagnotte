@echo off
echo =====================================
echo   DEMARRAGE CAGNOTTE PARTICIPATIVE
echo =====================================
echo.

echo [1/2] Demarrage de l'API Backend...
start "API Backend" cmd /k "cd /d %~dp0CagnotteParticipativeExam && dotnet run"

echo [2/2] Attente de 5 secondes...
timeout /t 5 /nobreak > nul

echo [2/2] Demarrage du Frontend Blazor...
start "Frontend Blazor" cmd /k "cd /d %~dp0CagnotteParticipative.UI && dotnet run"

echo.
echo =====================================
echo   APPLICATIONS DEMARREES !
echo =====================================
echo.
echo API Backend:      https://localhost:7293
echo Frontend Blazor:  https://localhost:7144
echo.
echo Ouvrez votre navigateur sur:
echo     https://localhost:7144
echo.
echo Appuyez sur une touche pour quitter...
pause > nul
