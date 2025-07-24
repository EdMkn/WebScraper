# 📚 WebScraper - Scraping de produits multi-pages avec export et SQLite (C#)

> Un projet en C# pour scrapper les données de produits depuis un site e-commerce (ex: books.toscrape.com), paginer les résultats, les sauvegarder dans une base de données SQLite, et les exporter en JSON.

---

## ✨ Fonctionnalités

- 🔍 Scraping de produits (titre, prix, disponibilité, image, lien)
- 🔁 Scraping **multi-pages** automatique (`/page-x.html`)
- 🧠 Parser HTML basé sur **HtmlAgilityPack**
- 🌐 Requêtes HTTP via **HttpClient**
- 🗃️ Stockage local dans une base **SQLite** avec **Entity Framework Core**
- 📤 Export des résultats en **JSON** et **CSV**
- 🔧 Architecture claire (Services, Interfaces, Injection de dépendances)
- 🧾 Logging coloré via `LoggerService`
- 🧪 Prêt pour les tests unitaires et l’extension

---

## 🏗️ Structure du projet

WebScraper/

├── Models/ # Définition des entités (ex: Product)

├── Services/ # ScraperService, HttpClientService

├── Parsers/ # HtmlParser pour analyser le HTML

├── Data/ # ScraperDbContext pour EF Core + SQLite

├── Interfaces/ # Interfaces pour services + Logger

├── Utils/ # LoggerService avec niveaux de logs

├── Program.cs # Point d'entrée, configuration DI

├── scraper.db # Base de données locale SQLite

├── products.json # Export JSON

## 🛠️ Technologies utilisées

- [.NET 7+](https://dotnet.microsoft.com/)
- [HtmlAgilityPack](https://html-agility-pack.net/)
- [Entity Framework Core (SQLite)](https://learn.microsoft.com/en-us/ef/core/)
- [Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)
- (optionnel) [Playwright](https://playwright.dev/dotnet) si scraping JS

---

## 🚀 Lancer le projet

### 1. Cloner

```bash
git clone https://github.com/ton-projet/WebScraper.git
cd WebScraper
```

### 2. Restorer et compiler

```bash
dotnet restore
dotnet build
```

### 3. Lancer le Scraping (10 pages par défaut)

```bash
dotnet run
```

## 📤 Export automatique

Après exécution :

- products_all.json → Export lisible

## Configuration

🔧 Configuration
Tu peux changer :

- Le nombre de pages à scrapper

- L’URL de base (https://books.toscrape.com/catalogue)

- Les XPath utilisés dans HtmlParser.cs
