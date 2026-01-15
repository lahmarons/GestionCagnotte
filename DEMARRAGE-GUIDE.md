# ?? Instructions pour Démarrer et Tester l'Application

## ?? IMPORTANT - PORTS À UTILISER

- **API Backend** : `https://localhost:7293`
- **Frontend Blazor** : `https://localhost:7144` ou `http://localhost:5207`

## ?? Étapes de Démarrage

### 1?? Démarrer l'API Backend

Ouvrez un **PowerShell** et exécutez :

```powershell
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam"
dotnet run
```

**Attendez de voir** :
```
Now listening on: https://localhost:7293
Application started. Press Ctrl+C to shut down.
```

? L'API est prête ! Laissez cette fenêtre ouverte.

### 2?? Démarrer le Frontend Blazor

Ouvrez un **NOUVEAU PowerShell** et exécutez :

```powershell
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI"
dotnet run
```

**Attendez de voir** :
```
Now listening on: https://localhost:7144
Now listening on: http://localhost:5207
Application started. Press Ctrl+C to shut down.
```

? Le frontend est prêt ! Laissez cette fenêtre ouverte également.

### 3?? Ouvrir l'Application dans le Navigateur

Ouvrez votre navigateur et allez sur :

?? **https://localhost:7144**

OU

?? **http://localhost:5207**

## ?? Vérification

### Si vous voyez Swagger au lieu du frontend :

? Vous êtes sur : `https://localhost:7293` (c'est l'API)
? Allez sur : `https://localhost:7144` (c'est le frontend)

### Si vous voyez une erreur de connexion :

1. **Vérifiez que les deux serveurs sont démarrés**
   - Terminal 1 : API sur port 7293
   - Terminal 2 : Frontend sur port 7144

2. **Vérifiez dans la console du navigateur (F12)**
   - Cherchez des erreurs CORS
   - Cherchez des erreurs de connexion

3. **Redémarrez les deux applications**
   - Arrêtez (Ctrl+C) dans les deux terminaux
   - Redémarrez d'abord l'API, puis le frontend

## ?? Test de l'Application

### Scénario 1 : Créer une Cagnotte

1. Sur `https://localhost:7144`, cliquez **"Créer une cagnotte"**
2. Remplissez :
   - Titre : "Cadeau pour Marie"
   - Description : "Pour son anniversaire"
   - Montant : 500
   - Date limite : (une date future)
   - Organisateur : Votre nom
3. Cliquez **"Créer la cagnotte"**
4. ? Vous êtes redirigé vers la page de détails

### Scénario 2 : Ajouter une Contribution

1. Sur la page de détails, remplissez :
   - Nom : "Jean Dupont"
   - Montant : 50
   - Message : "Bon anniversaire !"
2. Cliquez **"Contribuer maintenant"**
3. ? La barre de progression passe à 10%
4. ? Vous voyez la contribution dans la liste à droite

### Scénario 3 : Voir la Liste

1. Cliquez sur le logo ou "Accueil"
2. ? Vous voyez toutes les cagnottes créées
3. ? Chaque carte montre la progression

## ?? Dépannage

### Erreur "Failed to fetch"

**Cause** : Le frontend ne peut pas communiquer avec l'API

**Solution** :
1. Vérifiez que l'API est démarrée sur `https://localhost:7293`
2. Ouvrez `https://localhost:7293/swagger` pour confirmer
3. Vérifiez la configuration CORS dans `CagnotteParticipativeExam/Program.cs`

### Page blanche ou "Loading..."

**Cause** : Erreur JavaScript dans le frontend

**Solution** :
1. Ouvrez la console du navigateur (F12)
2. Regardez les erreurs en rouge
3. Vérifiez que tous les fichiers sont compilés

### "Cannot access database"

**Cause** : SQL Server LocalDB n'est pas démarré

**Solution** :
```powershell
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam"
dotnet ef database update
```

## ?? URLs Importantes

| Service | URL | Description |
|---------|-----|-------------|
| **Frontend Blazor** | https://localhost:7144 | Interface utilisateur |
| **API Swagger** | https://localhost:7293 | Documentation API |
| **API Health** | https://localhost:7293/api/cagnottes | Test API |

## ? Checklist de Démarrage

- [ ] Terminal 1 : API démarrée sur port 7293
- [ ] Terminal 2 : Frontend démarré sur port 7144
- [ ] Navigateur ouvert sur https://localhost:7144
- [ ] Page d'accueil visible (pas Swagger)
- [ ] Peut créer une cagnotte
- [ ] Peut ajouter une contribution
- [ ] Voit la liste des cagnottes

## ?? Tout fonctionne !

Si vous voyez :
- ? La page d'accueil avec "?? Cagnottes Participatives"
- ? Le bouton "Créer une cagnotte"
- ? Le design Bootstrap avec les cartes

**Félicitations ! L'application fonctionne correctement !**

---

**Besoin d'aide ?**
- Vérifiez les logs dans les terminaux
- Ouvrez la console du navigateur (F12)
- Relisez ce guide étape par étape
