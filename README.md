# Ubannest Events

Ubannest Events ist eine Webanwendung, mit der Benutzer Veranstaltungen entdecken, erstellen und sich dafür anmelden können.  
Das Projekt wurde mit ASP.NET Core MVC entwickelt und nutzt Identity für Authentifizierung und Autorisierung.

## ✨ Funktionen

- 🎭 Dynamischer Hero-Bereich
- 📅 Veranstaltungen von heute und kommenden Tagen
- 🔥 Meistgesehene Veranstaltungen
- 📈 Besucherzähler pro Veranstaltung
- 💬 Kommentarfunktion pro Event
- ⭐ Favoritenfunktion für Veranstaltungen
- 👤 Benutzerprofil mit Bearbeitungsmöglichkeiten:
  - ✏️ Name ändern
  - 🔐 Passwort ändern
  - 📧 E-Mail-Adresse ändern
- 🔑 Authentifizierung mit ASP.NET Identity (Admin / Benutzer)
- 📷 Bilder-Upload für jedes Event
- 🧭 Responsive Navigation & Benutzerfreundliches Design
- 🛠️ Admin-Bereich zur Verwaltung von Kategorien & Events

---

## 📸 Screenshots

### 🏠 Startseite (Öffentlicher Bereich)
![Startseite](Assets/images/HomePage.jpeg)

### 📄 Veranstaltungsdetails
- Öffentliche Ansicht:
  ![Event Detail](Assets/images/Eventdetails.jpeg)
- Authentifizierter Benutzer:
  ![Event Detail Mit User Authentificated](Assets/images/Eventdetails2.jpeg)

---

### 🔐 Authentifizierung (Benutzerbereich)

- 🔑 Login-Seite:
  ![Login](Assets/images/LogIn.jpeg)

- 📝 Registrierung (Register):
  ![Register](Assets/images/Register.jpeg)

- 👤 Benutzerprofil:
  ![Benutzerprofil](Assets/images/Bildschirmfoto_13-5-2025_143225_localhost.jpeg)

---

### 👨‍💼 Admin-Bereich

- Übersicht:
  ![Admin Panel](Assets/images/AdminPanel.jpeg)

- Kategorienverwaltung:
  ![Admin Panel Category View](Assets/images/AdminPanelCategory.jpeg)

- Veranstaltungenverwaltung:
  ![Admin Panel Event View](Assets/images/AdminPanelEvent.jpeg)




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




1. **Projekt klonen**
   ```bash
   git clone https://github.com/dein-benutzername/ubannest-events.git
   cd ubannest-events
