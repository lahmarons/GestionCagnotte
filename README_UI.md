# Interface Utilisateur - Cagnottes Participatives

## ?? Vue d'ensemble

Cette application web fournit une interface utilisateur complète pour gérer les cagnottes participatives d'entreprise. L'interface est construite avec HTML5, CSS3 et JavaScript vanilla, et consomme l'API REST ASP.NET Core.

## ?? Démarrage rapide

### 1. Lancer l'application

```bash
cd CagnotteParticipativeExam
dotnet run
```

### 2. Accéder à l'interface

Ouvrez votre navigateur et allez à :
- **Interface principale** : `https://localhost:7292` ou `http://localhost:5042`
- **API Swagger** : `https://localhost:7292/swagger`
- **Guide utilisateur** : `https://localhost:7292/guide.html`

## ?? Fonctionnalités de l'interface

### ?? Gestion des Cagnottes
- ? Visualiser toutes les cagnottes sous forme de cartes
- ? Créer une nouvelle cagnotte avec :
  - Nom et description
  - Objectif financier
  - Dates de début et fin
  - Association à une entreprise
- ? Modifier les cagnottes existantes
- ? Supprimer une cagnotte
- ? Voir la progression en temps réel (pourcentage et montant collecté)
- ? Voir le nombre de participants et le statut (Active/Terminée)

### ?? Gestion des Entreprises
- ? Afficher toutes les entreprises
- ? Créer une nouvelle entreprise (nom + adresse)
- ? Voir le nombre de cagnottes par entreprise
- ? Supprimer une entreprise

### ?? Gestion des Participants
- ? Lister tous les participants
- ? Créer un nouveau participant (nom, prénom, email)
- ? Modifier les informations d'un participant
- ? Voir le nombre de participations et le montant total contribué
- ? Supprimer un participant

### ?? Gestion des Participations
- ? Voir toutes les participations dans un tableau
- ? Enregistrer une nouvelle participation :
  - Sélection de la cagnotte
  - Sélection du participant
  - Montant de la contribution
  - Date de participation
- ? Modifier une participation existante
- ? Supprimer une participation

## ?? Guide d'utilisation

### Premier démarrage (base de données vide)

1. **Créer une entreprise**
   - Cliquez sur "Entreprises" dans le menu
   - Cliquez sur "Nouvelle Entreprise"
   - Remplissez le nom et l'adresse
   - Cliquez sur "Enregistrer"

2. **Créer des participants**
   - Allez dans "Participants"
   - Cliquez sur "Nouveau Participant"
   - Remplissez les informations (nom, prénom, email)
   - Enregistrez

3. **Créer une cagnotte**
   - Allez dans "Cagnottes"
   - Cliquez sur "Nouvelle Cagnotte"
   - Remplissez les informations :
     - Nom : ex. "Cadeau départ Marie"
     - Description : ex. "Cagnotte pour le cadeau de départ de Marie"
     - Objectif : ex. 500€
     - Dates : choisissez une période
     - Entreprise : sélectionnez l'entreprise créée
   - Enregistrez

4. **Ajouter des participations**
   - Allez dans "Participations"
   - Cliquez sur "Nouvelle Participation"
   - Sélectionnez la cagnotte et le participant
   - Entrez le montant (ex. 20€)
   - Choisissez la date
   - Enregistrez

5. **Visualiser le résultat**
   - Retournez dans "Cagnottes"
   - Vous verrez la barre de progression mise à jour
   - Le montant collecté et le nombre de participants s'affichent

## ?? Structure de l'interface

### Fichiers principaux

```
CagnotteParticipativeExam/wwwroot/
??? index.html              # Page principale
??? guide.html              # Guide utilisateur détaillé
??? css/
?   ??? style.css          # Styles CSS personnalisés
??? js/
    ??? api.js             # Service API (appels fetch)
    ??? app.js             # Logique de l'application
```

### Navigation

L'interface est organisée en 4 sections principales accessibles via le menu :
- ?? **Cagnottes** : Vue en cartes avec progression visuelle
- ?? **Entreprises** : Vue en cartes
- ?? **Participants** : Vue en cartes
- ?? **Participations** : Vue en tableau

## ?? Configuration

### URL de l'API

L'URL de l'API est définie dans `wwwroot/js/api.js` :

```javascript
const API_BASE_URL = 'https://localhost:7292/api';
```

Si votre application tourne sur un autre port, modifiez cette valeur.

### CORS

Le CORS est configuré dans `Program.cs` pour accepter toutes les origines en développement :

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
```

## ?? Caractéristiques de l'interface

### Design moderne
- ?? Interface responsive (mobile, tablette, desktop)
- ?? Palette de couleurs professionnelle
- ? Animations fluides
- ?? Barres de progression visuelles
- ?? Notifications toast pour les actions

### Expérience utilisateur
- ? Chargement asynchrone des données
- ?? Mise à jour en temps réel après chaque action
- ? Validation des formulaires
- ? Gestion des erreurs avec messages clairs
- ?? Modales pour création/édition

## ??? Technologies utilisées

- **HTML5** : Structure sémantique
- **CSS3** : Styles modernes avec variables CSS
- **JavaScript (Vanilla)** : Pas de framework, code pur
- **Fetch API** : Appels HTTP vers l'API REST
- **Font Awesome** : Icônes
- **CSS Grid & Flexbox** : Layout responsive

## ?? Responsive Design

L'interface s'adapte automatiquement à tous les écrans :
- ?? Mobile : Navigation simplifiée, cartes empilées
- ?? Tablette : Grille à 2 colonnes
- ?? Desktop : Grille à 3+ colonnes selon la largeur

## ?? Débogage

### Console développeur

Toutes les opérations sont loguées dans la console (F12) :
- ?? Chargement des données
- ?? Sauvegarde/Modification
- ? Erreurs détaillées

### Messages de debug

```javascript
console.log('?? loadCagnottes() - Début');
console.log('? Cagnottes rechargées, nombre:', cagnottes.length);
```

## ?? Résolution de problèmes

### L'interface ne charge pas les données

1. Vérifiez que l'API est lancée : `dotnet run`
2. Ouvrez la console (F12) pour voir les erreurs
3. Vérifiez l'URL de l'API dans `js/api.js`
4. Vérifiez que CORS est activé dans `Program.cs`

### Erreur CORS

Si vous voyez une erreur CORS dans la console :
- Vérifiez que `app.UseCors("AllowAll")` est appelé dans `Program.cs`
- Vérifiez qu'il est placé AVANT `app.MapControllers()`

### Les données ne s'affichent pas après création

- Ouvrez la console (F12)
- Vérifiez les logs de débogage
- Vérifiez que le rechargement des données se fait bien

## ?? Ressources supplémentaires

- **Guide utilisateur complet** : Accessible via `https://localhost:7292/guide.html`
- **Documentation API** : Swagger à `https://localhost:7292/swagger`
- **Code source** : Consultez les fichiers dans `wwwroot/js/`

## ?? Améliorations possibles

Idées pour étendre l'interface :

1. **Filtres et recherche**
   - Filtrer les cagnottes par statut (active/terminée)
   - Rechercher par nom ou entreprise
   - Trier par date ou montant

2. **Statistiques**
   - Tableau de bord avec graphiques
   - Top contributeurs
   - Évolution dans le temps

3. **Fonctionnalités avancées**
   - Export en Excel/PDF
   - Notifications par email
   - Commentaires sur les cagnottes
   - Upload d'images

4. **Authentification**
   - Login/Register
   - Rôles et permissions
   - Profils utilisateurs

## ?? Notes

- ? L'interface utilise uniquement du JavaScript vanilla (pas de jQuery, React, etc.)
- ? Les migrations de base de données sont automatiques au démarrage
- ? Les fichiers statiques sont servis par ASP.NET Core
- ? Le design est optimisé pour tous les navigateurs modernes

---

**Bon développement ! ??**
