# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Initial project setup with basic structure
- Development status badge
- Project roadmap
- README documentation
- Git ignore file
- Changelog template
- Backend API initial setup
  - Base entity model with audit fields
  - API startup configuration
  - Project structure documentation
- API configuration
  - Project configuration (csproj)
  - App settings (json)
  - Development environment settings
- Core models
  - BaseResponse for API responses
  - User model for authentication
  - Model validation and audit fields
- Bug tracking models
  - Bug model with core properties
  - BugAttachment for file attachments
  - BugComment for issue discussions
  - Priority enum for issue severity
  - Project model for organization
  - Status enum for issue states
- Database structure
  - BugTrackerDbContext for database operations
  - Entity relationships configuration
  - Database configuration
- API documentation
  - HTTP request documentation
  - Request/response examples
  - Authentication examples
- API controllers
  - BaseController with common functionality
  - Error handling
  - Response formatting
  - Authentication middleware
- Development tools
  - Launch settings configuration
  - Development server settings
  - HTTPS development certificate
  - Environment-specific configurations

### Changed
- Updated repository description
- Restructured README sections
- Added development status indicator

### Removed
- Duplicate features section

### Fixed
- README formatting issues

### Security
- No security-related changes yet

[Unreleased]: https://github.com/LouisJoly/Bug_Tracker/compare/v0.1.0...HEAD
