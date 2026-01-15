# ========================================
# SOLUTION ULTIME - FRONTEND QUI NE S'AFFICHE PAS
# ========================================

## LE PROBLÈME
Vous voyez Swagger au lieu du Frontend Blazor !

## LA CAUSE
Les deux applications utilisent les MÊMES PORTS !

## LA SOLUTION EN 3 ÉTAPES

### ÉTAPE 1 : Ouvrir PowerShell EN TANT QU'ADMINISTRATEUR

1. Clic droit sur le menu Démarrer
2. Choisir "Terminal (Admin)" ou "PowerShell (Admin)"

### ÉTAPE 2 : Exécuter cette commande

```powershell
# Copier-coller cette commande complète :
cd "C:\Users\lahma\OneDrive\Bureau\cagnotte-master"; Get-Process -Name dotnet,iisexpress -ErrorAction SilentlyContinue | Stop-Process -Force; Start-Sleep 2; Start-Process powershell -ArgumentList "-NoExit -Command cd 'C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam'; dotnet run"; Start-Sleep 5; Start-Process powershell -ArgumentList "-NoExit -Command cd 'C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI'; dotnet run"; Start-Sleep 8; Start-Process "https://localhost:7144"
```

### ÉTAPE 3 : Attendre 15 secondes

Trois fenêtres vont s'ouvrir :
1. Terminal API (port 7293)
2. Terminal Frontend (port 7144)  
3. Navigateur sur https://localhost:7144

---

## SI ÇA NE MARCHE TOUJOURS PAS

### Vérification Manuelle

#### Terminal 1 - API
```powershell
cd C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipativeExam
dotnet run --urls "https://localhost:7293"
```

ATTENDEZ de voir : "Now listening on: https://localhost:7293"

#### Terminal 2 - Frontend (NOUVEAU TERMINAL)
```powershell
cd C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI
dotnet run --urls "https://localhost:7144"
```

ATTENDEZ de voir : "Now listening on: https://localhost:7144"

#### Navigateur
Ouvrir : https://localhost:7144

---

## DIFFÉRENCE ENTRE LES DEUX PAGES

### ? SI VOUS VOYEZ ÇA = API (MAUVAIS)
```
Swagger UI
CagnotteParticipativeExam 1.0

Cagnotte
  GET /api/Cagnotte
  POST /api/Cagnotte
```

? Vous êtes sur https://localhost:7293 (API)
? ALLEZ SUR https://localhost:7144 !

### ? SI VOUS VOYEZ ÇA = FRONTEND (BON)
```
[SIDEBAR]          [CONTENU]
?? Cagnotte        ?? Cagnottes Participatives
Participative
                   [Créer une cagnotte]
?? Accueil
                   ?? Aucune cagnotte disponible
? Créer cagnotte
```

? PARFAIT ! Vous êtes au bon endroit !

---

## TABLEAU DES PORTS

| Port  | Application | URL |
|-------|-------------|-----|
| 7293  | API (Swagger) | https://localhost:7293 |
| 7144  | Frontend (Blazor) | https://localhost:7144 |

**RÈGLE D'OR** : Pour voir le FRONTEND, allez sur 7144, PAS 7293 !

---

## DERNIÈRE SOLUTION - SI RIEN NE FONCTIONNE

### Supprimer et Recréer le Frontend

```powershell
# 1. Aller dans le dossier
cd C:\Users\lahma\OneDrive\Bureau\cagnotte-master\CagnotteParticipative.UI

# 2. Nettoyer complètement
dotnet clean
Remove-Item -Recurse -Force bin,obj -ErrorAction SilentlyContinue

# 3. Restaurer les packages
dotnet restore

# 4. Compiler
dotnet build

# 5. Lancer avec port explicite
dotnet run --urls "https://localhost:7144;http://localhost:5207"
```

Puis ouvrir : https://localhost:7144

---

## AIDE VISUELLE

Quand vous tapez l'URL dans le navigateur :

```
[Barre d'adresse du navigateur]
??????????????????????????????????
? https://localhost:7144         ? ? BON (Frontend)
??????????????????????????????????

[Barre d'adresse du navigateur]
??????????????????????????????????
? https://localhost:7293         ? ? MAUVAIS (API)
??????????????????????????????????
```

---

## CHECKLIST FINALE

Avant de dire "ça ne marche pas", vérifiez :

- [ ] Deux fenêtres PowerShell ouvertes (API + Frontend)
- [ ] Terminal 1 affiche "Now listening on: https://localhost:7293"
- [ ] Terminal 2 affiche "Now listening on: https://localhost:7144"
- [ ] Navigateur ouvert sur https://localhost:7144 (PAS 7293)
- [ ] Vous voyez "Cagnottes Participatives" et NON "Swagger UI"

---

## CONTACTS EN CAS D'ÉCHEC

Si VRAIMENT rien ne fonctionne :

1. Faites une capture d'écran de ce que vous voyez
2. Copiez les messages d'erreur dans les terminaux
3. Appuyez sur F12 dans le navigateur, allez dans Console, copiez les erreurs
4. Partagez ces informations

---

**ESSAYEZ LA COMMANDE UNIQUE DE L'ÉTAPE 2 EN PREMIER !**
