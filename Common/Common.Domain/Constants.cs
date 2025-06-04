namespace Common.Domain;

public static class Constants
{
    public static class Resources
    {
        public const int MinSizeInBytes = 1024; // 1 (KB)
        public const int MaxSizeInBytes = 1024 * 1024; // 1 (MB)

        public const int MinNameLength = 2;
        public const int MaxNameLength = 50;

        public const int MinDescriptionLength = 2;
        public const int MaxDescriptionLength = 50;

        public const string ErrorContentOrPathRequired = "Either resource content or a path must be provided.";
        public const string ErrorBothContentAndPath = "Resource cannot have both content and a path specified.";
        public const string ErrorInvalidPathCharacters = "Resource path contains invalid characters or is not a valid relative path.";
        public const string ErrorInvalidPathUri = "Resource path is not a valid URI.";
        public const string ErrorUnsupportedExtension = "The resource type {0} does not support {1} extension.";
    }

    public static class Category
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 40;

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 200;
    }

    public static class Craftsman
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 150;

        public const int DescriptionMinLength = 3;
        public const int DescriptionMaxLength = 1000;

        public const int LocationMinLength = 4;
        public const int LocationMaxLength = 100;

        public const string ErrorEmptyUserId = "UserId cannot be empty.";
    }

    public static class Feedback
    {
        public const int RatingMin = 1;
        public const int RatingMax = 10;

        public const string ErrorEmptyContent = "Feedback content cannot be empty.";
        public const string ErrorEmptyWriterId = "WriterId cannot be empty.";
    }

    public static class Project
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 150;

        public const int DescriptionMinLength = 2;
        public const int DescriptionMaxLength = 5000;

        public const int DurationMinWeeks = 1;
        public const int DurationMaxWeeks = 36;
    }

    public static class Tag
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 10;
    }
}