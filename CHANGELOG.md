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
- Model enhancements
  - Data annotations for enums
  - Navigation properties for relationships
  - Status enum improvements
  - Project status validation
- Database structure
  - BugTrackerDbContext for database operations
  - Entity relationships configuration
  - Database configuration
- Testing infrastructure
  - Unit test project setup
  - Database connection tests
  - xUnit test framework configuration
- API configuration
  - Database connection with Npgsql
  - CORS policy setup
  - Improved service organization
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
- BaseResponse warnings
  - Initialized Errors property
  - Added Message initialization
  - Initialized Timestamp
  - Handled null message cases
- Database configuration warnings
  - Updated connection string to use environment variable
  - Fixed entity relationship configurations
  - Improved navigation property naming
  - Fixed cascading behavior
- Status enum usage
  - Updated Project.cs to use Status.Fixed
  - Fixed status validation
  - Improved status transitions

### Security
- No security-related changes yet

[Unreleased]: https://github.com/LouisJoly/Bug_Tracker/compare/v0.1.0...HEAD
