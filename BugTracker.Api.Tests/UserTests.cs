using BugTracker.Api.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BugTracker.Api.Tests
{
    public class UserTests
    {
        private const string ValidUsername = "testuser";
        private const string ValidEmail = "test@example.com";
        private const string ValidPasswordHash = "hashedpassword";
        private const string ValidFirstName = "Test";
        private const string ValidLastName = "User";
        private const string ValidSessionId = "session123";

        private const string UsernameMinLength = "3";
        private const string UsernameMaxLength = "50";
        private const string UsernameRequiredErrorMessage = "Username is required";
        private const string UsernameLengthErrorMessage = "Username must be between 3 and 50 characters";
        private const string EmailRequiredErrorMessage = "Email is required";
        private const string EmailFormatErrorMessage = "Please enter a valid email address";
        private const string PasswordErrorMessage = "Password is required";
        private const string FirstNameErrorMessage = "First name is required";
        private const string LastNameErrorMessage = "Last name is required";
        private const string SessionIdErrorMessage = "Session ID is required";
        private const string EmailMaxLengthErrorMessage = "Email cannot exceed 100 characters";
        private const string FirstNameMaxLengthErrorMessage = "First name cannot exceed 50 characters";
        private const string LastNameMaxLengthErrorMessage = "Last name cannot exceed 50 characters";
        private const string SessionExpirationRequiredErrorMessage = "Session expiration date is required";
        private const string LastLoginDateRequiredErrorMessage = "Last login date is required";

        private User CreateUserWithDefaults()
        {
            return new User
            {
                Username = ValidUsername,
                Email = ValidEmail,
                PasswordHash = ValidPasswordHash,
                FirstName = ValidFirstName,
                LastName = ValidLastName,
                SessionId = ValidSessionId,
                IsActive = true,
                LastLoginDate = DateTime.UtcNow,
                SessionExpiration = DateTime.UtcNow.AddHours(1)
            };
        }

        [Fact]
        public void User_ShouldHaveEmptyStringDefaults()
        {
            // Arrange
            var user = new User();

            // Assert
            Assert.Equal(string.Empty, user.Username);
            Assert.Equal(string.Empty, user.Email);
            Assert.Equal(string.Empty, user.PasswordHash);
            Assert.Equal(string.Empty, user.FirstName);
            Assert.Equal(string.Empty, user.LastName);
            Assert.False(user.IsActive, "IsActive should be false by default");
            Assert.Equal(DateTime.MinValue, user.LastLoginDate);
            Assert.Equal(string.Empty, user.SessionId);
            Assert.Equal(DateTime.MinValue, user.SessionExpiration);
            Assert.NotNull(user.Projects);
            Assert.NotNull(user.AssignedBugs);
            Assert.NotNull(user.ReportedBugs);
            Assert.NotNull(user.Comments);
            Assert.NotNull(user.Attachments);
        }

        [Fact]
        public void User_ShouldAllowSettingIsActive()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            user.IsActive = true;
            Assert.True(user.IsActive, "IsActive should be true after setting to true");

            user.IsActive = false;
            Assert.False(user.IsActive, "IsActive should be false after setting to false");
        }

        [Fact]
        public void User_ShouldHaveNavigationProperties()
        {
            // Arrange
            var user = CreateUserWithDefaults();

            // Act & Assert
            Assert.NotNull(user.Projects);
            Assert.NotNull(user.AssignedBugs);
            Assert.NotNull(user.ReportedBugs);
            Assert.NotNull(user.Comments);
            Assert.NotNull(user.Attachments);
        }

        [Fact]
        public void User_ShouldFailValidationWhenRequiredFieldsAreEmpty()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            user.Username = string.Empty;
            user.Email = string.Empty;
            user.PasswordHash = string.Empty;
            user.FirstName = string.Empty;
            user.LastName = string.Empty;
            user.SessionId = string.Empty;
            user.LastLoginDate = DateTime.MinValue;
            user.SessionExpiration = DateTime.MinValue;

            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "Validation should fail for missing required fields");

            Assert.Contains(validationResults, r => r.ErrorMessage == UsernameRequiredErrorMessage);
            Assert.Contains(validationResults, r => r.ErrorMessage == EmailRequiredErrorMessage);
            Assert.Contains(validationResults, r => r.ErrorMessage == PasswordErrorMessage);
            Assert.Contains(validationResults, r => r.ErrorMessage == FirstNameErrorMessage);
            Assert.Contains(validationResults, r => r.ErrorMessage == LastNameErrorMessage);
            Assert.Contains(validationResults, r => r.ErrorMessage == SessionIdErrorMessage);
        }

        [Fact]
        public void User_ShouldValidateUsernameLength()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Test username too short (2 characters)
            user.Username = new string('a', 2);
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, $"Validation should fail for username shorter than {UsernameMinLength} characters");
            Assert.Contains(validationResults, r => r.ErrorMessage == UsernameLengthErrorMessage);

            // Test username too long (51 characters)
            user.Username = new string('a', 51);
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, $"Validation should fail for username longer than {UsernameMaxLength} characters");
            Assert.Contains(validationResults, r => r.ErrorMessage == UsernameLengthErrorMessage);

            // Test valid username (12 characters)
            user.Username = new string('a', 12);
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, $"Validation should pass for username between {UsernameMinLength} and {UsernameMaxLength} characters");
            Assert.True(validationResults.Count == 0, "No validation errors should be present for valid username");
        }

        [Fact]
        public void User_ShouldValidateEmailFormat()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Test invalid email format
            user.Email = "invalid-email";
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "Validation should fail for invalid email format");
            Assert.Contains(validationResults, r => r.ErrorMessage == EmailFormatErrorMessage);

            // Test valid email format
            user.Email = "valid.email@example.com";
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "Validation should pass for valid email format");
            Assert.True(validationResults.Count == 0, "No validation errors should be present for valid email");
        }

        [Fact]
        public void User_ShouldValidateSessionExpiration()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var now = DateTime.UtcNow;
            user.SessionExpiration = now.AddSeconds(-1); // Expired 1 second ago

            // Act
            var isExpired = user.IsSessionExpired;

            // Assert
            Assert.True(isExpired, $"Session should be expired when SessionExpiration is {1} second in the past");
            Assert.True(user.SessionExpiration < now, "SessionExpiration should be in the past");

            // Test edge case: SessionExpiration exactly now
            user.SessionExpiration = now;
            isExpired = user.IsSessionExpired;

            // Assert
            Assert.True(isExpired, "Session should be expired when SessionExpiration is exactly now");

            // Test future expiration
            user.SessionExpiration = now.AddSeconds(1);
            isExpired = user.IsSessionExpired;

            // Assert
            Assert.False(isExpired, $"Session should not be expired when SessionExpiration is {1} second in the future");
        }

        [Fact]
        public void User_ShouldValidateSessionNotExpired()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var now = DateTime.UtcNow;
            user.SessionExpiration = now.AddMinutes(1); // Expires in 1 minute

            // Act
            var isExpired = user.IsSessionExpired;

            // Assert
            Assert.False(isExpired, $"Session should not be expired when SessionExpiration is {1} minute in the future");
            Assert.True(user.SessionExpiration > now, "SessionExpiration should be in the future");

            // Test edge case: SessionExpiration exactly 1 minute in the future
            user.SessionExpiration = now.AddMinutes(1);
            isExpired = user.IsSessionExpired;

            // Assert
            Assert.False(isExpired, "Session should not be expired when SessionExpiration is exactly 1 minute in the future");

            // Test far future expiration
            user.SessionExpiration = now.AddHours(1);
            isExpired = user.IsSessionExpired;

            // Assert
            Assert.False(isExpired, $"Session should not be expired when SessionExpiration is {1} hour in the future");
        }

        [Fact]
        public void User_ShouldFailValidationWhenStringFieldMaxLengthsExceeded()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Test email max length (101 characters)
            user.Email = new string('a', 101);
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "Email length validation should fail for long strings");
            Assert.Contains(validationResults, r => r.ErrorMessage == EmailMaxLengthErrorMessage);

            // Test first name max length (51 characters)
            user.FirstName = new string('a', 51);
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "First name length validation should fail for long strings");
            Assert.Contains(validationResults, r => r.ErrorMessage == FirstNameMaxLengthErrorMessage);

            // Test last name max length (51 characters)
            user.LastName = new string('a', 51);
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "Last name length validation should fail for long strings");
            Assert.Contains(validationResults, r => r.ErrorMessage == LastNameMaxLengthErrorMessage);
        }

        [Fact]
        public void User_ShouldNotValidateDateTimeFields()
        {
            // Arrange
            var user = CreateUserWithDefaults();
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Test required validation
            user.SessionExpiration = DateTime.MinValue;
            user.LastLoginDate = DateTime.MinValue;
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "DateTime fields should be valid even with DateTime.MinValue");
            Assert.True(validationResults.Count == 0, "No validation errors should be present for DateTime.MinValue");

            // Test valid DateTime values
            user.LastLoginDate = DateTime.UtcNow;
            user.SessionExpiration = DateTime.UtcNow.AddHours(1);
            validationResults.Clear();
            isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "Validation should pass for valid DateTime values");
            Assert.True(validationResults.Count == 0, "No validation errors should be present for valid DateTime values");
        }        
    }
}
