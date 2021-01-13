namespace Teslalab.Shared
{
    public enum VideoPrivacy
    {
        Public = 1, // available for everyone
        Unlisted = 2,// available through URL
        Private = 3 // only for the admin, cannot be seen.
    }

    public enum Category
    {
        Education = 1,
        Sport = 2,
        Space = 3,
        Entertainment = 4,
        Music = 5
    }
}