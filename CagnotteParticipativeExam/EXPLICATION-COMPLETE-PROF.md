# ?? EXPLICATION DÉTAILLÉE DU PROJET - PRÉSENTATION PROFESSEUR

## ?? PRÉSENTATION GÉNÉRALE DU PROJET

### **Nom du Projet**
**"Application de Gestion de Cagnottes Participatives"**

### **Contexte Métier**
Il s'agit d'une application permettant aux **entreprises** de gérer des **cagnottes participatives** pour leurs employés. Par exemple :
- Cagnotte pour un cadeau de départ d'un collègue
- Cagnotte pour l'organisation d'événements d'entreprise
- Cagnotte solidaire pour un collègue en difficulté

### **Objectif Technique**
Développer une **API REST complète** avec une **architecture en couches** respectant les **bonnes pratiques du développement .NET moderne**.

---

## ??? ARCHITECTURE DU PROJET

### **Vue d'ensemble de l'Architecture**

Le projet suit une **architecture en 4 couches** (Clean Architecture) :

```
???????????????????????????????????
?     CagnotteParticipativeExam   ?  ? Couche Présentation (API)
?         (Web API)               ?
???????????????????????????????????
?      Cagnotte.Services          ?  ? Couche Services (Logique Métier)
???????????????????????????????????
?       Cagnotte.Data             ?  ? Couche Accès aux Données
???????????????????????????????????
?      Cagnotte.Domain            ?  ? Couche Domaine (Entités)
???????????????????????????????????
```

---

## ?? DÉTAIL DES COUCHES

### **1. COUCHE DOMAINE (Cagnotte.Domain)**

#### **Rôle**
Contient la **logique métier pure** et les **entités** de l'application.

#### **Composants Principaux**

##### **A. Entités Métier**
- **`Cagnotte`** : Représente une cagnotte avec titre, description, objectif financier
- **`Entreprise`** : Représente une entreprise (raison sociale, adresse, email)
- **`Participant`** : Représente un employé qui peut participer aux cagnottes
- **`Participation`** : Représente une contribution d'un participant à une cagnotte

##### **B. Relations entre Entités**
```
Entreprise (1) ??????? (N) Cagnotte
    ?
    ?
Participant (N) ??????? (N) Cagnotte
         ?                   ?
         ???? Participation ???
```

##### **C. Propriétés Calculées (Business Logic)**
Dans l'entité `Cagnotte`, j'ai implémenté des **propriétés métier** :

```csharp
[NotMapped]
public decimal MontantCollecte  // Calcule automatiquement la somme des participations

[NotMapped]
public decimal PourcentageAtteint  // Calcule le pourcentage de l'objectif atteint

[NotMapped]
public bool EstEnCours  // Indique si la cagnotte est encore active

[NotMapped]
public int JoursRestants  // Calcule le nombre de jours restants
```

##### **D. DTOs (Data Transfer Objects)**
Les DTOs permettent de **séparer le modèle interne** des **données échangées** avec l'extérieur :
- `CreateCagnotteDto` : Pour créer une cagnotte
- `UpdateCagnotteDto` : Pour modifier une cagnotte
- `CagnotteDto` : Pour retourner les données d'une cagnotte

##### **E. Enums**
- `TypeCagnotte` : Définit les différents types de cagnottes (Cadeau, Événement, Solidarité, etc.)

---

### **2. COUCHE ACCÈS AUX DONNÉES (Cagnotte.Data)**

#### **Rôle**
Gère la **persistance des données** et l'**accès à la base de données**.

#### **Technologies utilisées**
- **Entity Framework Core** : ORM (Object-Relational Mapping)
- **SQL Server** : Base de données relationnelle
- **Pattern Repository** : Abstraction de l'accès aux données

#### **Composants Principaux**

##### **A. DbContext (AppDbContext)**
```csharp
public class AppDbContext : DbContext
{
    public DbSet<Cagnotte> Cagnottes { get; set; }
    public DbSet<Entreprise> Entreprises { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Participation> Participations { get; set; }
}
```

##### **B. Configuration des Relations**
```csharp
// Configuration clé composite pour Participation
modelBuilder.Entity<Participation>()
    .HasKey(p => new { p.CagnotteId, p.ParticipantId });

// Configuration des relations avec DeleteBehavior.Restrict
// (évite la suppression en cascade accidentelle)
```

##### **C. Repositories (Pattern Repository)**
Chaque entité a son repository avec **interface** :
- `ICagnotteRepository` / `CagnotteRepository`
- `IEntrepriseRepository` / `EntrepriseRepository`
- `IParticipantRepository` / `ParticipantRepository`
- `IParticipationRepository` / `ParticipationRepository`

**Avantages du pattern Repository** :
- **Abstraction** : Le code métier ne dépend pas directement d'Entity Framework
- **Testabilité** : On peut facilement mocker les repositories pour les tests
- **Maintenabilité** : Changement de technologie d'accès aux données facilité

##### **D. Migrations Entity Framework**
Les migrations permettent de **versioner la base de données** :
```csharp
// Migration automatique au démarrage de l'application
context.Database.Migrate();
```

---

### **3. COUCHE SERVICES (Cagnotte.Services)**

#### **Rôle**
Contient la **logique métier applicative** et **orchestre** les opérations.

#### **Pattern utilisé : Service Layer**

#### **Composants Principaux**

##### **A. Services Métier**
Chaque entité a son service avec **interface** :
- `ICagnotteService` / `CagnotteService`
- `IEntrepriseService` / `EntrepriseService`
- `IParticipantService` / `ParticipantService`
- `IParticipationService` / `ParticipationService`

##### **B. Responsabilités des Services**
```csharp
public class CagnotteService : ICagnotteService
{
    // 1. Validation métier
    public async Task<CagnotteDto> CreateAsync(CreateCagnotteDto dto)
    {
        // Vérifier que l'entreprise existe
        var entreprise = await _entrepriseRepo.GetByIdAsync(dto.EntrepriseId);
        if (entreprise == null)
            throw new InvalidOperationException("L'entreprise n'existe pas");
    }
    
    // 2. Orchestration des repositories
    // 3. Mapping entre DTOs et Entités
    // 4. Gestion des erreurs métier
}
```

##### **C. AutoMapper**
Utilisation d'**AutoMapper** pour le mapping automatique entre :
- **Entités** ? **DTOs**
- **DTOs de création** ? **Entités**
- **DTOs de mise à jour** ? **Entités**

**Avantage** : Évite le code répétitif de mapping manuel.

---

### **4. COUCHE PRÉSENTATION (CagnotteParticipativeExam)**

#### **Rôle**
Expose les fonctionnalités via une **API REST** et gère les **requêtes HTTP**.

#### **Technologies utilisées**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** : Documentation automatique de l'API
- **Injection de dépendances** : Gestion des dépendances

#### **Composants Principaux**

##### **A. Controllers**
Chaque entité a son controller :
- `CagnotteController`
- `EntrepriseController`
- `ParticipantController`
- `ParticipationController`

##### **B. Structure d'un Controller**
```csharp
[Route("api/[controller]")]
[ApiController]
public class CagnotteController : ControllerBase
{
    private readonly ICagnotteService _service;
    
    // Injection de dépendances via le constructeur
    public CagnotteController(ICagnotteService service)
    {
        _service = service;
    }
    
    [HttpGet]           // GET /api/Cagnotte
    [HttpGet("{id}")]   // GET /api/Cagnotte/{id}
    [HttpPost]          // POST /api/Cagnotte
    [HttpPut("{id}")]   // PUT /api/Cagnotte/{id}
    [HttpDelete("{id}")]// DELETE /api/Cagnotte/{id}
}
```

##### **C. Gestion des Codes de Retour HTTP**
- **200 OK** : Succès
- **201 Created** : Ressource créée
- **400 Bad Request** : Erreur de validation
- **404 Not Found** : Ressource introuvable
- **204 No Content** : Suppression réussie

##### **D. Configuration dans Program.cs**
```csharp
// Configuration de l'injection de dépendances
builder.Services.AddScoped<ICagnotteService, CagnotteService>();
builder.Services.AddScoped<ICagnotteRepository, CagnotteRepository>();

// Configuration d'Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuration d'AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configuration de Swagger
builder.Services.AddSwaggerGen();
```

---

## ?? TECHNOLOGIES ET OUTILS UTILISÉS

### **Framework et Versions**
- **.NET 8** : Framework principal (version LTS - Long Term Support)
- **C# 12** : Langage de programmation (dernière version)
- **ASP.NET Core 8** : Framework web

### **Base de Données**
- **SQL Server** : SGBD relationnel
- **Entity Framework Core 8** : ORM pour l'accès aux données
- **Migrations EF** : Gestion de l'évolution du schéma de base

### **Documentation et Test**
- **Swagger/OpenAPI** : Documentation automatique de l'API
- **Swagger UI** : Interface graphique pour tester l'API

### **Outils de Développement**
- **AutoMapper** : Mapping automatique entre objets
- **Data Annotations** : Validation des données
- **Dependency Injection** : Inversion de contrôle native ASP.NET Core

---

## ??? PATTERNS ET PRINCIPES ARCHITECTURAUX

### **1. Clean Architecture**
L'application respecte les principes de la **Clean Architecture** :
- **Séparation des responsabilités**
- **Inversion des dépendances**
- **Indépendance des frameworks**

### **2. SOLID Principles**

#### **S - Single Responsibility Principle**
Chaque classe a **une seule responsabilité** :
- Controllers ? Gestion HTTP
- Services ? Logique métier
- Repositories ? Accès aux données

#### **O - Open/Closed Principle**
Code **ouvert à l'extension**, **fermé à la modification** via les interfaces.

#### **L - Liskov Substitution Principle**
Les implémentations sont **substituables** par leurs interfaces.

#### **I - Interface Segregation Principle**
Interfaces **spécifiques** plutôt qu'une interface générale.

#### **D - Dependency Inversion Principle**
Dépendance sur les **abstractions** (interfaces), pas les implémentations.

### **3. Repository Pattern**
**Abstraction de la couche d'accès aux données** :
```csharp
public interface ICagnotteRepository
{
    Task<IEnumerable<Cagnotte>> GetAllAsync();
    Task<Cagnotte?> GetByIdAsync(int id);
    Task<Cagnotte> AddAsync(Cagnotte entity);
    Task<Cagnotte?> UpdateAsync(int id, Cagnotte entity);
    Task<bool> DeleteAsync(int id);
}
```

### **4. Service Layer Pattern**
**Encapsulation de la logique métier** dans une couche dédiée.

### **5. DTO Pattern**
**Séparation** entre le modèle de domaine et les données échangées.

---

## ??? MODÈLE DE DONNÉES

### **Diagramme Entité-Relation**
```
???????????????????         ???????????????????
?   ENTREPRISE    ?         ?    CAGNOTTE     ?
???????????????????    1:N  ???????????????????
? EntrepriseId(PK)??????????? CagnotteId (PK) ?
? RaisonSociale   ?         ? Titre           ?
? Description     ?         ? Description     ?
? Email           ?         ? MontantCible    ?
???????????????????         ? DateFin         ?
                            ? Type            ?
                            ? EntrepriseId(FK)?
                            ???????????????????
                                     ?
                                     ? 1:N
                                     ?
???????????????????         ???????????????????
?  PARTICIPANT    ?         ? PARTICIPATION   ?
???????????????????    1:N  ???????????????????
?ParticipantId(PK)???????????CagnotteId (PK)  ?
? Nom             ?         ?ParticipantId(PK)?
? Prenom          ?         ? Montant         ?
? MailParticipant ?         ?DateParticipation?
???????????????????         ???????????????????
```

### **Contraintes et Relations**
- **Clé composite** : `Participation(CagnotteId, ParticipantId)`
- **DeleteBehavior.Restrict** : Empêche la suppression en cascade
- **Validation par Data Annotations** : Validation côté serveur

---

## ?? API REST - ENDPOINTS

### **Structure des URLs**
```
BASE_URL: https://localhost:7292/api

Entreprises:
??? GET    /api/Entreprise           # Liste toutes les entreprises
??? GET    /api/Entreprise/{id}      # Détails d'une entreprise
??? POST   /api/Entreprise           # Créer une entreprise
??? DELETE /api/Entreprise/{id}      # Supprimer une entreprise

Cagnottes:
??? GET    /api/Cagnotte             # Liste toutes les cagnottes
??? GET    /api/Cagnotte/{id}        # Détails d'une cagnotte
??? POST   /api/Cagnotte             # Créer une cagnotte
??? PUT    /api/Cagnotte/{id}        # Modifier une cagnotte
??? DELETE /api/Cagnotte/{id}        # Supprimer une cagnotte

Participants:
??? GET    /api/Participant          # Liste tous les participants
??? GET    /api/Participant/{id}     # Détails d'un participant
??? POST   /api/Participant          # Créer un participant
??? PUT    /api/Participant/{id}     # Modifier un participant
??? DELETE /api/Participant/{id}     # Supprimer un participant

Participations:
??? GET    /api/Participation                    # Toutes les participations
??? GET    /api/Participation/{cagId}/{partId}  # Une participation spécifique
??? GET    /api/Participation/cagnotte/{id}     # Participations d'une cagnotte
??? GET    /api/Participation/participant/{id}  # Participations d'un participant
??? POST   /api/Participation                   # Créer une participation
??? PUT    /api/Participation/{cagId}/{partId}  # Modifier une participation
??? DELETE /api/Participation/{cagId}/{partId}  # Supprimer une participation
```

### **Formats de Données**

#### **Exemple de création de cagnotte**
```json
POST /api/Cagnotte
{
  "titre": "Cadeau départ Jean",
  "description": "Cagnotte pour le cadeau de départ de Jean qui part à la retraite",
  "montantCible": 500.00,
  "dateFin": "2024-12-31",
  "type": "Cadeau",
  "entrepriseId": 1
}
```

#### **Exemple de réponse**
```json
{
  "cagnotteId": 1,
  "titre": "Cadeau départ Jean",
  "description": "Cagnotte pour le cadeau de départ de Jean qui part à la retraite",
  "montantCible": 500.00,
  "montantCollecte": 0.00,
  "pourcentageAtteint": 0.0,
  "dateFin": "2024-12-31T00:00:00",
  "estEnCours": true,
  "joursRestants": 365,
  "type": "Cadeau",
  "entrepriseId": 1,
  "entrepriseRaisonSociale": "Tech Solutions SARL"
}
```

---

## ?? CONFIGURATION ET DÉPLOIEMENT

### **Configuration de l'Application**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=CagnotteDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### **Injection de Dépendances**
```csharp
// Configuration dans Program.cs
builder.Services.AddScoped<ICagnotteRepository, CagnotteRepository>();
builder.Services.AddScoped<ICagnotteService, CagnotteService>();
```

### **Migrations Automatiques**
```csharp
// Application automatique des migrations au démarrage
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}
```

---

## ?? AVANTAGES DE CETTE ARCHITECTURE

### **1. Maintenabilité**
- **Séparation claire** des responsabilités
- **Code modulaire** et organisé
- **Facilité de modification** d'une couche sans impacter les autres

### **2. Testabilité**
- **Interfaces** permettent le mocking pour les tests unitaires
- **Injection de dépendances** facilite l'isolation des composants
- **Logique métier** séparée de la logique d'accès aux données

### **3. Évolutivité**
- **Ajout de nouvelles fonctionnalités** facilité
- **Changement de technologie** possible (ex: changer de SGBD)
- **Scalabilité horizontale** possible

### **4. Réutilisabilité**
- **Services métier** réutilisables dans d'autres contextes
- **Repositories** indépendants de l'interface utilisateur
- **DTOs** facilitent l'intégration avec d'autres systèmes

---

## ?? BONNES PRATIQUES IMPLÉMENTÉES

### **1. Validation des Données**
```csharp
[Required(ErrorMessage = "Le titre est obligatoire")]
[StringLength(200, MinimumLength = 3)]
public string Titre { get; set; }
```

### **2. Gestion des Erreurs**
```csharp
public async Task<ActionResult<CagnotteDto>> GetById(int id)
{
    var cagnotte = await _service.GetByIdAsync(id);
    
    if (cagnotte == null)
        return NotFound($"Cagnotte avec l'ID {id} introuvable");
        
    return Ok(cagnotte);
}
```

### **3. Async/Await**
Toutes les opérations de base de données sont **asynchrones** pour éviter le blocage des threads.

### **4. Documentation API**
```csharp
/// <summary>
/// Récupère toutes les cagnottes
/// </summary>
[HttpGet]
public async Task<ActionResult<IEnumerable<CagnotteDto>>> GetAll()
```

---

## ?? MOTS-CLÉS TECHNIQUES POUR LA PRÉSENTATION

### **Architecture**
- Clean Architecture
- Layered Architecture
- Separation of Concerns
- Dependency Inversion
- SOLID Principles

### **Patterns**
- Repository Pattern
- Service Layer Pattern
- DTO Pattern (Data Transfer Object)
- Dependency Injection Pattern

### **Technologies .NET**
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- Swagger/OpenAPI
- Data Annotations

### **Concepts Base de Données**
- ORM (Object-Relational Mapping)
- Code First Approach
- Migrations Entity Framework
- Clé composite
- Relations One-to-Many / Many-to-Many

### **API REST**
- RESTful API
- HTTP Verbs (GET, POST, PUT, DELETE)
- Status Codes HTTP
- JSON Serialization/Deserialization

---

## ?? SCRIPT DE PRÉSENTATION (5 MINUTES)

### **Introduction (30 secondes)**
*"J'ai développé une API REST pour la gestion de cagnottes participatives en utilisant .NET 8 et une architecture en couches respectant les principes de Clean Architecture."*

### **Architecture (2 minutes)**
*"L'application est structurée en 4 couches distinctes :*
- *La couche Domain contient les entités métier et la logique business*
- *La couche Data gère la persistance avec Entity Framework Core et le pattern Repository*
- *La couche Services encapsule la logique applicative*
- *La couche API expose les fonctionnalités via des controllers REST"*

### **Démonstration (2 minutes)**
*"Voici la documentation Swagger qui présente l'API complète avec ses endpoints CRUD pour chaque entité..."*

### **Technologies (30 secondes)**
*"J'ai utilisé les dernières technologies Microsoft : .NET 8, Entity Framework Core avec SQL Server, et AutoMapper pour le mapping objet-relationnel."*

---

## ? POINTS FORTS À MENTIONNER

1. **Architecture moderne** suivant les bonnes pratiques .NET
2. **Séparation des responsabilités** claire et maintenable
3. **API REST complète** avec documentation automatique
4. **Gestion des relations complexes** (clé composite)
5. **Validation des données** robuste
6. **Migrations automatiques** de base de données
7. **Code asynchrone** pour les performances
8. **Injection de dépendances** native ASP.NET Core

---

**?? VOUS ÊTES PRÊT POUR VOTRE PRÉSENTATION ! ??**

*Ce document contient tous les éléments techniques et le vocabulaire nécessaire pour expliquer votre projet de manière professionnelle et complète.*