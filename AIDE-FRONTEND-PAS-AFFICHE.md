# ?? GUIDE DE RÉSOLUTION - Frontend ne s'affiche pas

## ? PROBLÈME : Vous voyez Swagger au lieu du Frontend Blazor

### ?? Diagnostic Rapide

**Question 1 :** Sur quelle URL êtes-vous ?
- ? `https://localhost:7293` ? C'est l'API (Swagger)
- ? `https://localhost:7144` ? C'est le Frontend Blazor

**Question 2 :** Combien de terminaux avez-vous ouverts ?
- ? 1 seul terminal ? Il manque un terminal
- ? 2 terminaux ? Correct !

---

## ?? SOLUTION ÉTAPE PAR ÉTAPE

### ÉTAPE 1 : Arrêter tous les processus

Dans PowerShell **en tant qu'administrateur** :

```powershell
# Arrêter tous les processus dotnet
Get-Process -Name dotnet -ErrorAction SilentlyContinue | Stop-Process -Force

# Vérifier qu'ils sont arrêtés
Get-Process -Name dotnet -ErrorAction SilentlyContinue
```

Si aucun résultat, c'est bon ! ?

---

### ÉTAPE 2 : Démarrer l'API Backend

**Ouvrez PowerShell #1** et exécutez :

```powershell
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam"
dotnet run
```

**? Attendez de voir exactement ceci :**

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7293
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5185
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

**?? NE FERMEZ PAS CE TERMINAL !**

---

### ÉTAPE 3 : Vérifier que l'API fonctionne

Ouvrez votre navigateur et allez sur :

?? **https://localhost:7293**

Vous DEVEZ voir la page Swagger avec :
- ? Titre : "Swagger UI"
- ? "Cagnotte API v1"
- ? Liste des endpoints : `/api/cagnottes`, `/api/entreprises`, etc.

Si vous voyez ça, l'API fonctionne ! ?

---

### ÉTAPE 4 : Démarrer le Frontend Blazor

**Ouvrez un NOUVEAU PowerShell #2** (SANS fermer le premier) et exécutez :

```powershell
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI"
dotnet run
```

**? Attendez de voir exactement ceci :**

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7144
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5207
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

**?? NE FERMEZ PAS CE TERMINAL NON PLUS !**

---

### ÉTAPE 5 : Ouvrir le Frontend

Ouvrez un **NOUVEL ONGLET** dans votre navigateur et allez sur :

?? **https://localhost:7144**

OU

?? **http://localhost:5207**

---

## ? CE QUE VOUS DEVEZ VOIR

### Sur `https://localhost:7144` :

```
???????????????????????????????????????????????
? ?? Cagnotte Participative                   ?
? [?] Menu                                    ?
???????????????????????????????????????????????
? ?? Accueil                                  ?
? ? Créer une cagnotte                       ?
???????????????????????????????????????????????

  ?? Cagnottes Participatives    [Créer une cagnotte]

  ?? Aucune cagnotte disponible pour le moment.
     [Créer la première cagnotte]
```

### ? Ce que vous NE devez PAS voir :

- "Swagger UI"
- "Cagnotte API v1"
- Liste d'endpoints `/api/...`

---

## ?? DÉPANNAGE

### Problème 1 : "This site can't be reached"

**Cause** : Le frontend n'est pas démarré

**Solution** :
1. Vérifiez que le Terminal #2 est bien ouvert
2. Vérifiez qu'il affiche "Now listening on: https://localhost:7144"
3. Redémarrez le frontend :
   ```powershell
   cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI"
   dotnet run
   ```

---

### Problème 2 : Page blanche qui charge indéfiniment

**Cause** : L'API n'est pas accessible

**Solution** :
1. Ouvrez la console du navigateur (F12)
2. Regardez l'onglet "Console"
3. Cherchez des erreurs rouges
4. Si vous voyez "Failed to fetch" ou erreur CORS :
   - Vérifiez que l'API est démarrée (Terminal #1)
   - Allez sur `https://localhost:7293` pour confirmer

---

### Problème 3 : "Certificate error" ou "Not secure"

**Cause** : Certificat HTTPS de développement non approuvé

**Solution** :

```powershell
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Puis redémarrez les deux applications.

---

### Problème 4 : Je vois encore Swagger !

**Vérifiez dans la barre d'adresse du navigateur :**

```
? https://localhost:7293     ? API (Swagger)
? https://localhost:7293/api  ? API
? http://localhost:5185       ? API

? https://localhost:7144      ? FRONTEND !
? http://localhost:5207       ? FRONTEND !
```

**Vous DEVEZ aller sur le port 7144 ou 5207, PAS 7293 !**

---

## ?? CHECKLIST FINALE

Avant de dire "ça ne marche pas", vérifiez :

- [ ] **Terminal 1** : API démarrée et affiche "Now listening on: https://localhost:7293"
- [ ] **Terminal 2** : Frontend démarré et affiche "Now listening on: https://localhost:7144"
- [ ] **Navigateur** : URL est `https://localhost:7144` (PAS 7293)
- [ ] **Page** : Vous voyez "?? Cagnottes Participatives" (PAS "Swagger UI")
- [ ] **Console navigateur (F12)** : Pas d'erreurs rouges

---

## ?? CAPTURE D'ÉCRAN ATTENDUE

Vous devriez voir quelque chose comme :

```
?????????????????????????????????????????????????
?  SIDEBAR                    MAIN CONTENT      ?
?  ?????????????????          ???????????????? ?
?  ? ?? Cagnotte   ?          ?              ? ?
?  ? Participative ?          ?  ?? Cagnottes? ?
?  ?????????????????          ?  Participat. ? ?
?  ? ?? Accueil    ?          ?              ? ?
?  ? ? Créer      ?          ?  [Créer...]  ? ?
?  ?????????????????          ?              ? ?
?                             ?  ?? Aucune   ? ?
?                             ?  cagnotte... ? ?
?                             ???????????????? ?
?????????????????????????????????????????????????
```

---

## ?? AIDE SUPPLÉMENTAIRE

### Vérifier les logs

**Dans Terminal #1 (API)** :
- Cherchez "Application started"
- Pas d'erreurs rouges

**Dans Terminal #2 (Frontend)** :
- Cherchez "Application started"
- Pas d'erreurs rouges

### Tester l'API directement

```powershell
# Dans un nouveau PowerShell
curl https://localhost:7293/api/cagnottes
```

Si ça retourne `[]` (tableau vide), l'API fonctionne ! ?

---

## ?? RÉCAPITULATIF DES PORTS

| Service | Port HTTPS | Port HTTP | Description |
|---------|------------|-----------|-------------|
| **API Backend** | 7293 | 5185 | Swagger, Endpoints API |
| **Frontend Blazor** | 7144 | 5207 | Interface utilisateur |

**RÈGLE D'OR** : 
- Pour voir **Swagger** ? `https://localhost:7293`
- Pour voir le **Frontend** ? `https://localhost:7144`

---

## ? SUCCÈS !

Si vous voyez :
- ? "?? Cagnottes Participatives" en haut
- ? Sidebar avec "Accueil" et "Créer une cagnotte"
- ? Bouton bleu "Créer une cagnotte"
- ? Message "Aucune cagnotte disponible"

**?? FÉLICITATIONS ! Votre frontend fonctionne !**

Vous pouvez maintenant :
1. Cliquer sur "Créer une cagnotte"
2. Remplir le formulaire
3. Tester l'application complète

---

**Besoin d'aide ?**
1. Vérifiez que les 2 terminaux sont ouverts
2. Vérifiez l'URL dans le navigateur (7144, pas 7293)
3. Appuyez sur F12 pour voir les erreurs
4. Relisez ce guide étape par étape
