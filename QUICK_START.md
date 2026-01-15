# ?? Guide de Démarrage Rapide - Interface UI

## ? Démarrage en 3 étapes

### 1?? Lancer l'application

Ouvrez un terminal dans le dossier `CagnotteParticipativeExam` :

```bash
dotnet run
```

Vous devriez voir quelque chose comme :
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7292
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5042
```

### 2?? Ouvrir l'interface

Ouvrez votre navigateur et allez à :

```
https://localhost:7292
```

ou

```
http://localhost:5042
```

### 3?? Commencer à utiliser l'interface

L'interface s'ouvre automatiquement ! ??

## ?? Scénario de démonstration rapide

### Créer des données de test (5 minutes)

#### Étape 1 : Créer une entreprise
1. Cliquez sur **"Entreprises"** dans le menu
2. Cliquez sur **"Nouvelle Entreprise"**
3. Remplissez :
   - Nom : `Tech Solutions`
   - Adresse : `10 Rue de la Technologie, 75001 Paris`
4. Cliquez sur **"Enregistrer"**

#### Étape 2 : Créer des participants
1. Cliquez sur **"Participants"** dans le menu
2. Créez 3 participants :

   **Participant 1:**
   - Nom : `Dupont`
   - Prénom : `Jean`
   - Email : `jean.dupont@techsolutions.fr`

   **Participant 2:**
   - Nom : `Martin`
   - Prénom : `Marie`
   - Email : `marie.martin@techsolutions.fr`

   **Participant 3:**
   - Nom : `Bernard`
   - Prénom : `Pierre`
   - Email : `pierre.bernard@techsolutions.fr`

#### Étape 3 : Créer une cagnotte
1. Cliquez sur **"Cagnottes"**
2. Cliquez sur **"Nouvelle Cagnotte"**
3. Remplissez :
   - Nom : `Cadeau départ Sophie`
   - Description : `Cagnotte pour le cadeau de départ à la retraite de Sophie, notre directrice bien-aimée`
   - Objectif : `500`
   - Entreprise : Sélectionnez `Tech Solutions`
   - Date de début : (aujourd'hui)
   - Date de fin : (dans 1 mois)
4. Cliquez sur **"Enregistrer"**

#### Étape 4 : Ajouter des participations
1. Cliquez sur **"Participations"**
2. Ajoutez 3 participations :

   **Participation 1:**
   - Cagnotte : `Cadeau départ Sophie`
   - Participant : `Jean Dupont`
   - Montant : `50`
   - Date : (aujourd'hui)

   **Participation 2:**
   - Cagnotte : `Cadeau départ Sophie`
   - Participant : `Marie Martin`
   - Montant : `75`
   - Date : (aujourd'hui)

   **Participation 3:**
   - Cagnotte : `Cadeau départ Sophie`
   - Participant : `Pierre Bernard`
   - Montant : `100`
   - Date : (aujourd'hui)

#### Étape 5 : Visualiser le résultat
1. Retournez sur **"Cagnottes"**
2. Vous verrez :
   - ? Barre de progression : **45%** (225€ / 500€)
   - ? 3 participants
   - ? Statut : **Active**

## ?? Aperçu des fonctionnalités

### ?? Page Cagnottes
![Cagnottes](docs/cagnottes-view.png)
- Vue en cartes colorées
- Progression visuelle avec barre de pourcentage
- Statut actif/terminé avec badge
- Informations de dates et participants
- Boutons Modifier/Supprimer

### ?? Page Entreprises
- Liste des entreprises avec adresses
- Nombre de cagnottes associées
- Création/Suppression rapide

### ?? Page Participants
- Cartes avec informations de contact
- Total des contributions par participant
- Nombre de participations
- Modification/Suppression

### ?? Page Participations
- Tableau détaillé de toutes les contributions
- Filtrage et visualisation claire
- Modification/Suppression des participations

## ?? Navigation

Le menu principal contient 4 sections :

```
???????????????????????????????????????????
? ?? Cagnottes Participatives             ?
???????????????????????????????????????????
? ?? Cagnottes  ?? Entreprises            ?
? ?? Participants  ?? Participations      ?
???????????????????????????????????????????
```

Cliquez sur n'importe quelle section pour naviguer instantanément.

## ?? Configuration de l'API

### Vérifier le port de l'application

Si votre application tourne sur un port différent, vous devez modifier l'URL de l'API.

**Fichier à modifier :** `CagnotteParticipativeExam/wwwroot/js/api.js`

```javascript
// Configuration de l'API
const API_BASE_URL = 'https://localhost:7292/api'; // Changez le port si nécessaire
```

### Vérifier la connexion à la base de données

**Fichier :** `CagnotteParticipativeExam/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CagnotteParticipativeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

Les migrations sont appliquées automatiquement au démarrage ! ?

## ?? Ressources d'aide

### Documentation complète
- **Guide utilisateur détaillé :** `https://localhost:7292/guide.html`
- **API Swagger :** `https://localhost:7292/swagger`

### Support technique
- Ouvrez la **Console développeur** (F12) pour voir les logs
- Vérifiez les messages d'erreur dans l'onglet **Console**
- Les opérations sont loguées avec des émojis pour faciliter le débogage :
  ```
  ?? Chargement des données...
  ? Succès !
  ? Erreur détectée
  ?? Rendu de l'interface
  ```

## ?? Dépannage rapide

### Problème : L'interface ne charge pas
**Solution :**
```bash
# Vérifiez que l'application tourne
dotnet run

# Ouvrez le navigateur à l'URL correcte
https://localhost:7292
```

### Problème : Erreur "Cannot connect to API"
**Solution :**
1. Vérifiez que l'API est lancée (regardez la console)
2. Vérifiez l'URL dans `wwwroot/js/api.js`
3. Ouvrez F12 > Console pour voir l'erreur exacte

### Problème : Base de données vide
**Solution :**
C'est normal au premier démarrage ! Suivez le scénario de démonstration ci-dessus pour créer des données.

### Problème : Erreur de migration
**Solution :**
```bash
# Les migrations sont automatiques, mais si problème :
dotnet ef database drop --project Cagnotte.Data
dotnet run
# Les migrations seront recréées automatiquement
```

## ?? Besoin d'aide ?

1. **Consultez le guide complet :** `https://localhost:7292/guide.html`
2. **Testez l'API avec Swagger :** `https://localhost:7292/swagger`
3. **Vérifiez la console développeur (F12)**

## ? Profitez de votre application !

Votre interface de gestion des cagnottes participatives est maintenant prête à l'emploi ! ??

---

**Temps total de mise en route : ~5 minutes** ??
