# Professional Bug Tracker

[![Development Status](https://img.shields.io/badge/Development-Active-brightgreen)](https://github.com/LouisJoly/Bug_Tracker)

A robust bug tracking system built with modern technologies to showcase professional development skills for a Game Programmer portfolio.

## 📋 Roadmap

- [x] Initial project setup
- [ ] Backend API implementation
- [ ] Database schema design
- [ ] User authentication system
- [ ] Frontend UI development
- [ ] Bug tracking features
- [ ] Project management features
- [ ] GDPR compliance implementation
- [ ] Testing and deployment
- [ ] Documentation completion

## 🚀 Features

- User Authentication & Authorization
- Project Management
- Bug Tracking & Management
- Status & Priority Tracking
- GDPR Compliance
- Responsive Design

## 🛠️ Tech Stack

- **Backend**: C# with ASP.NET Core
- **Frontend**: React (TypeScript)
- **Database**: PostgreSQL
- **UI Framework**: Material-UI

## 📁 Project Structure

```
BugTracker.Api/
├── Controllers/
│   └── BaseController.cs
├── Models/
│   ├── BaseEntity.cs
│   ├── BaseResponse.cs
│   └── User.cs
├── Properties/
│   └── launchSettings.json
├── BugTracker.Api.csproj
├── appsettings.json
├── appsettings.Development.json
└── BugTracker.Api.http
```

## 📱 Architecture

The application follows a strict MVC (Model-View-Controller) architecture pattern:

- **Models**: Data structures and business logic
- **Views**: React components for UI
- **Controllers**: ASP.NET Core API endpoints

## 🔐 Security Features

- ASP.NET Core Identity for authentication
- Password hashing using BCrypt
- GDPR compliance features:
  - User consent management
  - Data access rights
  - Data deletion capabilities
- Protection against:
  - SQL injection
  - XSS attacks
  - CSRF attacks

## 📊 Database Structure

- Users table with minimal personal data
- Projects table
- Bugs table with status and priority
- Status tracking
- Priority levels
- User-Project relationships

## 🎨 User Interface

- Modern, professional design
- Intuitive bug management interface
- Responsive layout for all devices
- Material-UI components for consistency

## 📝 Documentation

- API documentation
- Setup instructions
- Database schema
- Security guidelines
- GDPR compliance documentation

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- Node.js 18+
- PostgreSQL 15+
- Git


## 📝 License

MIT License - see LICENSE file for details

## 🙏 Acknowledgments

- Thanks to the .NET Core team
- Thanks to the React community
