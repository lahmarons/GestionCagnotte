# ?? DÉMARRAGE RAPIDE - 3 ÉTAPES SIMPLES

## ? MÉTHODE ULTRA-RAPIDE (Recommandée)

### 1?? Double-cliquez sur ce fichier :
```
Demarrer-Applications.bat
```

### 2?? Attendez 10 secondes

### 3?? Ouvrez votre navigateur sur :
```
https://localhost:7144
```

**C'EST TOUT ! ?**

---

## ?? CE QUE VOUS ALLEZ VOIR

### ? CORRECT - Sur `https://localhost:7144` :

```
??????????????????????????????????????????
? ?? Cagnotte Participative              ?
?                                        ?
? ?? Cagnottes Participatives  [Créer]  ?
?                                        ?
? ?? Aucune cagnotte disponible...      ?
?    [Créer la première cagnotte]       ?
??????????????????????????????????????????
```

### ? INCORRECT - Sur `https://localhost:7293` :

```
??????????????????????????????????????????
? Swagger UI                             ?
? Cagnotte API v1                        ?
?                                        ?
? ? Cagnottes                           ?
?   GET /api/cagnottes                  ?
?   POST /api/cagnottes                 ?
??????????????????????????????????????????
```

---

## ?? RÈGLE D'OR

| Vous voulez voir | Allez sur |
|-----------------|-----------|
| **Frontend Blazor** (Interface utilisateur) | `https://localhost:7144` |
| **API Swagger** (Documentation API) | `https://localhost:7293` |

---

## ?? SI ÇA NE MARCHE PAS

### Vérification rapide :

1. **Ouvrez le Gestionnaire des tâches** (Ctrl + Shift + Échap)
2. Cherchez **2 processus "dotnet.exe"**
   - ? Si vous en voyez 2 : Bon signe !
   - ? Si vous en voyez 0 ou 1 : Relancez `Demarrer-Applications.bat`

3. **Vérifiez l'URL dans le navigateur**
   - ? `https://localhost:7144` ? Correct
   - ? `https://localhost:7293` ? Mauvais port !

4. **Appuyez sur F12 dans le navigateur**
   - Allez dans l'onglet "Console"
   - Cherchez des erreurs en rouge
   - Si vous voyez "Failed to fetch" ? L'API n'est pas démarrée

---

## ?? AIDE DÉTAILLÉE

Si vous rencontrez des problèmes, consultez ces fichiers :

1. **AIDE-FRONTEND-PAS-AFFICHE.md** ? Guide de dépannage complet
2. **DEMARRAGE-GUIDE.md** ? Instructions détaillées
3. **README-FRONTEND.md** ? Documentation complète

---

## ?? VIDÉO DE DÉMARRAGE (Texte)

```
ÉTAPE 1 : Double-clic sur "Demarrer-Applications.bat"
          ?
ÉTAPE 2 : Deux fenêtres noires s'ouvrent
          Terminal 1 : "API Backend"
          Terminal 2 : "Frontend Blazor"
          ?
ÉTAPE 3 : Attendre 10 secondes
          ?
ÉTAPE 4 : Ouvrir navigateur
          ?
ÉTAPE 5 : Taper "https://localhost:7144"
          ?
ÉTAPE 6 : Appuyer sur Entrée
          ?
RÉSULTAT : Vous voyez "?? Cagnottes Participatives"
           ? SUCCESS !
```

---

## ?? TESTER L'APPLICATION

### 1. Créer une cagnotte

1. Cliquez sur **"Créer une cagnotte"**
2. Remplissez :
   - Titre : "Test"
   - Description : "Ma première cagnotte"
   - Montant : 100
   - Date : (Une date future)
   - Organisateur : Votre nom
3. Cliquez **"Créer la cagnotte"**

### 2. Ajouter une contribution

1. Sur la page de détails, remplissez :
   - Nom : "Testeur"
   - Montant : 20
   - Message : "Test contribution"
2. Cliquez **"Contribuer maintenant"**

### 3. Voir le résultat

- ? Barre de progression : 20%
- ? Contribution visible à droite
- ? Montant collecté : 20€ / 100€

---

## ? FAQ RAPIDE

### Q: Je vois Swagger, pas le frontend
**R:** Vous êtes sur le mauvais port. Allez sur `https://localhost:7144`

### Q: "This site can't be reached"
**R:** Le frontend n'est pas démarré. Relancez `Demarrer-Applications.bat`

### Q: Page blanche qui charge
**R:** Appuyez sur F12, regardez la Console, vous verrez l'erreur

### Q: "Certificate error"
**R:** Exécutez dans PowerShell (en admin) :
```powershell
dotnet dev-certs https --trust
```

---

**?? Vous êtes prêt ! Bonne chance ! ??**
