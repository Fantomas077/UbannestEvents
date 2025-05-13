# Ubannest Events

Ubannest Events ist eine Webanwendung, mit der Benutzer Veranstaltungen entdecken, erstellen und sich dafür anmelden können.  
Das Projekt wurde mit ASP.NET Core MVC entwickelt und nutzt Identity für Authentifizierung und Autorisierung.

## ✨ Funktionen
- 🎭 Dynamischer Hero-Bereich
- 📅 Veranstaltungen von heute und kommenden Tagen
- 🔥 Meistgesehene Veranstaltungen
- 📈 Besucherzähler pro Veranstaltung
- 💬 Kommentarfunktion für jede Veranstaltung
- 👥 Authentifizierung mit ASP.NET Identity (Admin / Benutzer)
- 📷 Bilder-Upload und Anzeige für jedes Event
- 🧭 Benutzerfreundliche Navigation mit responsive Menü

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
  ![Login](Assets/images/Login.jpeg)

- 📝 Registrierung (Register):
  ![Register](Assets/images/Register.jpeg)

- 👤 Benutzerprofil:
  ![Benutzerprofil](Assets/images/UserProfile.jpeg)

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
