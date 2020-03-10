# Notes Permackathon

## Financial.DAL -> SQLite
Je pense que les options DB sont directement injectées dans le Startup.cs de l'API.

### Considérations
SQLite ne supporte pas les champs entité de type:
- Decimal - Utiliser double à la place
- DateTimeOffset
- TimeSpan
- UInt64

TODO: Check que ces types ne sont pas utilisés dans les entités.

### Dépendances
Ajouter ces NuGets au projet Financial.DAL:
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite

### Créer la DB initiale
Je vais essayer d'utiliser des migrations depuis le projet Financial.DAL.

Modifier d'abord FinancialContext.cs et remplacer l'endroit où il y a UseSqlServer:

```cs
optionsBuilder.UseSqlite(@"Data Source=financial.db;");
```

Ouvrir la console package manager avec Fiancial.DAL de sélectionné comme projet en cours.
Bien s'assurer que "Default project" est sur Financial.DAL sur le dessus de la console. Package source peut rester sur "All".

Lancer la commande:
```
Add-Migration Initial
```
Puis:
```
Update-Database
```
Il devrait avoir créé le fichier `Permackathon.Financial.DAL/financial.db`.

Si on l'ouvre avec DB Browser il affiche bien les deux tables.

Pour l'instant je n'ai pas trouvé de meilleur moyen que de déplacer le fichier .db manuellement à la racine de Permackathon.RestAPI.

Ce sera beaucoup plus simple de travailler comme ça en cas de déploiement aussi, avec la DB à la racine du déploiement.

### Modifications de l'API
Pour l'instant dans Startup.cs on ajoute un DBContext SQL Server.

Je pense qu'on peut juste le commenter et utiliser ça pour qu'il utilise la DB SQLite (qui est toujours indiquée dans FinancialContext.cs):
```
services.AddDbContext<FinancialContext>();
```

Remettre l'API comme projet de démarrage et lancer IISExpress, tester un endpoint, ça devrait fonctionner.

### Améliorations possibles
- Le chemin du fichier .db pourrait être un paramètre de configuration dans appsettings.json qui est ensuite passé au constructeur du DBContext dans Startup.cs.
- Il s'agit de réfléchir si on souhaite commit le fichier .db dans le repo - Habituellement on évite de le faire en le plaçant dans le .gitignore et on commit un fichier nu renommé (comme financial.db.initial).