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
    }
}