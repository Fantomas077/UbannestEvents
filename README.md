# Ubannest Events

Ubannest Events ist eine Webanwendung, mit der Benutzer Veranstaltungen entdecken, erstellen und sich dafür anmelden können.  
Das Projekt wurde mit ASP.NET Core MVC entwickelt und nutzt Identity für Authentifizierung und Autorisierung.

## ✨ Funktionen

- Benutzerregistrierung und -anmeldung
- Veranstaltungen durchsuchen und nach Stichwörtern filtern
- Anmeldung und Abmeldung zu Veranstaltungen
- Verwaltung eigener Anmeldungen
- Veranstaltungsverwaltung für Administratoren (Erstellen, Bearbeiten, Löschen)
- Kategorisierung der Veranstaltungen
- Pagination und Suche
- AJAX-Interaktionen für bessere Benutzererfahrung
- Sichere Rollen- und Zugriffsverwaltung

## 🛠️ Technologien

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Identity
- Bootstrap 5
- MS SQL Server / SQLite (je nach Konfiguration)

## 🚀 Lokale Installation

### Voraussetzungen

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (Version 8.0 oder höher empfohlen)
- Visual Studio 2022 / 2025 (mit ASP.NET und Webentwicklung Workload)
- SQL Server Express oder SQLite

### Schritte


## 📅 Semaine 1 – Base du projet & Authentification
- [ ] Initialiser le projet ASP.NET Core MVC
- [ ] Créer les modèles : Event, Category, ApplicationUser
- [ ] Ajouter les champs : StartDate, EndDate, Views, ImageCoverName, etc.
- [ ] Mettre en place Entity Framework + Migrations + DB
- [ ] Intégrer ASP.NET Identity
- [ ] Créer les rôles : Admin, Organizer, User
- [ ] Ajouter des pages de Login/Register

## 🖼️ Semaine 2 – Admin Panel & BackOffice
- [ ] CRUD Catégories
- [ ] CRUD Événements
- [ ] Séparer les accès selon les rôles
- [ ] Ajouter l’upload d’image (ImageCover)
- [ ] Créer la page Create Event pour les organisateurs

## 🎨 Semaine 3 – Frontend & UX
- [ ] Intégrer la navbar personnalisée avec logo
- [ ] Créer la section Hero (avec CTA)
- [ ] Créer la page d’accueil – Heutige Events
- [ ] Créer la page d’accueil – Kommende Events
- [ ] Créer la page d’accueil – Meistgesehene Events
- [ ] Créer la page de détail de l’event

## 📊 Semaine 4 – Vue, Stats & Dynamique
- [ ] Ajouter le système de compteur de vues
- [ ] Afficher les events populaires triés par vues
- [ ] Ajouter une recherche (titre / catégorie / lieu)
- [ ] Ajouter des filtres dynamiques (date / catégorie)

## 🧪 Semaine 5 – Améliorations & Tests
- [ ] Ajouter une page À propos / contact
- [ ] Vérifier le responsive design
- [ ] Tester toutes les fonctionnalités
- [ ] Améliorer le design avec Bootstrap Icons, animations
- [ ] Ajouter une pagination ou un système de chargement

## 🚀 Semaine 6 – Déploiement & Présentation
- [ ] Finaliser le README (DE + EN)
- [ ] Déployer sur GitHub + documentation
- [ ] Déploiement sur Render / Azure (facultatif)
- [ ] Préparer une vidéo de démo ou une présentation


1. **Projekt klonen**
   ```bash
   git clone https://github.com/dein-benutzername/ubannest-events.git
   cd ubannest-events
