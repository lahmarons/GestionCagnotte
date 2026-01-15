# ?? Interface UI - Cagnottes Participatives

## ? Configuration terminée !

Votre interface utilisateur pour la gestion des cagnottes participatives est maintenant **complètement opérationnelle** ! ??

## ?? Structure du projet

```
CagnotteParticipativeExam/
??? wwwroot/                    # Fichiers de l'interface UI
?   ??? index.html             # ? Page principale
?   ??? guide.html             # ? Guide utilisateur complet
?   ??? welcome.html           # ? Page d'accueil
?   ??? css/
?   ?   ??? style.css         # ? Styles modernes et responsifs
?   ??? js/
?       ??? api.js            # ? Service API (appels REST)
?       ??? app.js            # ? Logique de l'application
?       ??? test-api.js       # ? Tests de l'API
??? Controllers/               # Contrôleurs API
?   ??? CagnotteController.cs
?   ??? EntrepriseController.cs
?   ??? ParticipantController.cs
?   ??? ParticipationController.cs
??? Program.cs                 # ? Configuration (CORS + fichiers statiques)
??? appsettings.json          # ? Configuration de la base de données
```

## ?? Comment lancer l'application

### Option 1 : Ligne de commande
```bash
cd CagnotteParticipativeExam
dotnet run
```

### Option 2 : Visual Studio
1. Ouvrir la solution dans Visual Studio
2. Appuyer sur **F5** ou cliquer sur **Démarrer**

### Option 3 : Visual Studio Code
1. Ouvrir le dossier dans VS Code
2. Appuyer sur **F5** ou utiliser le terminal :
   ```bash
   dotnet run
   ```

## ?? URLs d'accès

Une fois l'application lancée, vous pouvez accéder à :

| Service | URL | Description |
|---------|-----|-------------|
| **Interface UI principale** | `https://localhost:7292` | Interface web complète |
| **API Swagger** | `https://localhost:7292/swagger` | Documentation et test de l'API |
| **Guide utilisateur** | `https://localhost:7292/guide.html` | Guide détaillé |

## ? Fonctionnalités disponibles

### ?? Gestion des Cagnottes
- ? Créer, modifier, supprimer des cagnottes
- ? Visualiser la progression en temps réel
- ? Voir les participants et montants collectés
- ? Statut actif/terminé automatique

### ?? Gestion des Entreprises
- ? Créer et supprimer des entreprises
- ? Associer des cagnottes aux entreprises
- ? Voir le nombre de cagnottes par entreprise

### ?? Gestion des Participants
- ? Créer, modifier, supprimer des participants
- ? Voir les contributions de chaque participant
- ? Gérer les informations de contact

### ?? Gestion des Participations
- ? Enregistrer les contributions
- ? Modifier et supprimer des participations
- ? Vue tableau détaillée

## ?? Caractéristiques de l'interface

### Design moderne
- ?? Interface responsive (mobile, tablette, desktop)
- ?? Palette de couleurs professionnelle
- ? Animations fluides
- ?? Barres de progression visuelles
- ?? Notifications toast

### Technologies
- **Frontend :** HTML5, CSS3, JavaScript (Vanilla)
- **Backend :** ASP.NET Core 8.0 Web API
- **Base de données :** SQL Server (LocalDB)
- **Architecture :** Clean Architecture (Domain, Data, Services)

## ?? Documentation

### Pour les utilisateurs
- **Guide de démarrage rapide :** `QUICK_START.md`
- **Guide UI complet :** `README_UI.md`
- **Guide intégré :** Accessible via `https://localhost:7292/guide.html`

### Pour les développeurs
- **API Swagger :** `https://localhost:7292/swagger`
- **Code source :** Consultez les fichiers dans `wwwroot/js/`

## ?? Configuration actuelle

### API
```javascript
// wwwroot/js/api.js
const API_BASE_URL = 'https://localhost:7292/api';
```

### CORS (Program.cs)
```csharp
// ? Activé pour permettre les appels depuis l'interface
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
```

### Fichiers statiques (Program.cs)
```csharp
// ? Configuré pour servir l'interface UI
app.UseDefaultFiles();
app.UseStaticFiles();
```

### Base de données
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CagnotteParticipativeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

? **Les migrations sont appliquées automatiquement au démarrage !**

## ?? Premiers pas recommandés

### 1. Lancer l'application
```bash
dotnet run
```

### 2. Ouvrir le navigateur
```
https://localhost:7292
```

### 3. Suivre le guide de démonstration
Consultez `QUICK_START.md` pour un scénario complet en 5 minutes.

### 4. Explorer les fonctionnalités
- Créez une entreprise
- Ajoutez des participants
- Créez une cagnotte
- Enregistrez des participations
- Visualisez la progression !

## ?? Aide et dépannage

### L'interface ne se charge pas
1. Vérifiez que l'application est lancée (`dotnet run`)
2. Vérifiez l'URL dans le navigateur
3. Consultez la console (F12) pour les erreurs

### Erreur de connexion à l'API
1. Vérifiez l'URL dans `wwwroot/js/api.js`
2. Vérifiez que le port correspond (7292)
3. Assurez-vous que CORS est activé

### Base de données
- ? Les migrations sont automatiques
- ? La base est créée au premier démarrage
- ? Pas de configuration manuelle nécessaire

## ?? Support

### Console développeur (F12)
Toutes les opérations sont loguées :
```javascript
?? Chargement des données...
? Succès ! 5 cagnottes chargées
?? Rendu de l'interface
? Erreur : [détails]
```

### Documentation
- **Guide intégré :** Dans l'application via le menu "Guide"
- **Swagger :** Pour tester l'API directement
- **README_UI.md :** Documentation complète de l'interface

## ?? C'est parti !

Votre application est **100% fonctionnelle** ! 

- ? API REST configurée
- ? Interface UI moderne et responsive
- ? Base de données avec migrations automatiques
- ? CORS activé
- ? Fichiers statiques servis
- ? Documentation complète

**Lancez `dotnet run` et profitez de votre application !** ??

---

### ?? Fichiers de documentation créés

1. **README_UI.md** - Documentation complète de l'interface
2. **QUICK_START.md** - Guide de démarrage rapide (5 minutes)
3. **INTEGRATION_SUMMARY.md** - Ce fichier récapitulatif

**Tout est prêt ! Bon développement ! ??**
