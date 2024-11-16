using Conservation.WepAPI.Mapping;

public static class ProfileFactory
{
    private static readonly Type[] s_profiles = new[] {
        typeof(GeneralMapping),
    
    };

    public static Type[] CustomProfiles => s_profiles;
}