# ?? Cagnotte Participative - Guide de Démarrage

## ?? Prérequis

- .NET 8 SDK
- SQL Server LocalDB ou SQL Server
- Visual Studio 2022 ou VS Code

## ?? Démarrage rapide

### Option 1 : Script PowerShell (Recommandé)

```powershell
.\Start-Applications.ps1
```

### Option 2 : Manuel

#### 1. Démarrer l'API Backend

```powershell
cd CagnotteParticipativeExam
dotnet run
```

L'API sera disponible sur : `https://localhost:7293`

#### 2. Démarrer le Frontend Blazor

Ouvrez un nouveau terminal PowerShell :

```powershell
cd CagnotteParticipative.UI
dotnet run
```

Le frontend sera disponible sur : `https://localhost:5001` ou `http://localhost:5000`

## ?? Tester l'application

### 1. Créer une cagnotte

1. Ouvrez `https://localhost:5001` dans votre navigateur
2. Cliquez sur **"Créer une cagnotte"**
3. Remplissez le formulaire :
   - **Titre** : Ex: "Cadeau pour Marie"
   - **Description** : Ex: "Pour son anniversaire"
   - **Montant objectif** : Ex: 500€
   - **Date limite** : Sélectionnez une date future
   - **Organisateur** : Votre nom
4. Cliquez sur **"Créer la cagnotte"**

### 2. Voir la liste des cagnottes

- La page d'accueil affiche toutes les cagnottes
- Vous verrez :
  - Le titre et la description
  - La progression (barre de progression)
  - Le montant collecté vs objectif
  - L'organisateur
  - La date limite
  - Le statut (Active/Terminée)

### 3. Contribuer à une cagnotte

1. Cliquez sur **"Voir les détails"** d'une cagnotte
2. Remplissez le formulaire de contribution :
   - **Votre nom** : Ex: "Jean Dupont"
   - **Montant** : Ex: 20€
   - **Message** : Ex: "Bon anniversaire Marie !"
3. Cliquez sur **"Contribuer maintenant"**
4. La page se rafraîchit automatiquement avec la nouvelle contribution

### 4. Voir les contributions

Sur la page de détails d'une cagnotte, le panneau de droite affiche :
- Le nombre total de contributions
- La liste des contributeurs
- Les montants
- Les messages
- Les dates et heures

## ?? Structure du projet

```
cagnotte-master/
??? CagnotteParticipativeExam/    # API Backend (.NET 8)
?   ??? Controllers/               # Contrôleurs API
?   ??? Program.cs                 # Configuration de l'API
?   ??? appsettings.json          # Configuration de la base de données
?
??? Cagnotte.Domain/              # Entités métier
??? Cagnotte.Data/                # Accès aux données (EF Core)
??? Cagnotte.Services/            # Logique métier
?
??? CagnotteParticipative.UI/     # Frontend Blazor WebAssembly
    ??? Models/                    # DTOs
    ??? Services/                  # Services HTTP
    ??? Pages/                     # Pages Blazor
    ?   ??? Home.razor            # Liste des cagnottes
    ?   ??? CreateCagnotte.razor  # Création de cagnotte
    ?   ??? CagnotteDetails.razor # Détails et contributions
    ??? Shared/                    # Composants partagés
```

## ?? Fonctionnalités

### ? CRUD Complet

- **Create** : Créer une nouvelle cagnotte
- **Read** : Voir la liste et les détails des cagnottes
- **Update** : Contribuer à une cagnotte (mise à jour du montant)
- **Delete** : (Non implémenté dans cette version)

### ?? Fonctionnalités supplémentaires

- Barre de progression visuelle (couleur selon le pourcentage)
- Liste des contributions en temps réel
- Messages personnalisés pour chaque contribution
- Design responsive (fonctionne sur mobile, tablette, desktop)
- Animations et effets hover sur les cartes
- Gestion des erreurs

## ??? Technologies utilisées

### Backend
- **ASP.NET Core 8** - Framework web
- **Entity Framework Core** - ORM
- **SQL Server** - Base de données
- **AutoMapper** - Mapping d'objets
- **Swagger** - Documentation API

### Frontend
- **Blazor WebAssembly** - Framework SPA
- **Bootstrap 5** - Framework CSS
- **Bootstrap Icons** - Icônes
- **HttpClient** - Communication avec l'API

## ?? API Endpoints

### Cagnottes
- `GET /api/cagnottes` - Liste des cagnottes
- `GET /api/cagnottes/{id}` - Détails d'une cagnotte
- `POST /api/cagnottes` - Créer une cagnotte

### Participations
- `GET /api/cagnottes/{id}/participations` - Contributions d'une cagnotte
- `POST /api/cagnottes/{id}/participations` - Ajouter une contribution

## ?? Configuration

### Base de données

La connexion à la base de données est configurée dans `CagnotteParticipativeExam/appsettings.json` :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CagnotteParticipativeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### CORS

L'API est configurée pour accepter les requêtes depuis :
- `https://localhost:5001`
- `http://localhost:5000`
- `https://localhost:7001`

## ? Dépannage

### L'API ne démarre pas

1. Vérifiez que SQL Server LocalDB est installé
2. Exécutez les migrations : `dotnet ef database update`
3. Vérifiez le port 7293 n'est pas déjà utilisé

### Le frontend ne se connecte pas à l'API

1. Vérifiez que l'API est bien démarrée sur `https://localhost:7293`
2. Vérifiez la configuration CORS dans `Program.cs` de l'API
3. Ouvrez la console du navigateur (F12) pour voir les erreurs

### Erreurs CORS

Si vous voyez des erreurs CORS dans la console :
1. Vérifiez que la politique CORS est activée dans l'API
2. Assurez-vous que l'URL du frontend est dans la liste des origines autorisées

## ?? Support

Pour toute question ou problème, consultez :
- La documentation Blazor : https://blazor.net
- La documentation ASP.NET Core : https://docs.microsoft.com/aspnet/core

---

**Bon test ! ??**
