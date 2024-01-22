namespace CBTSystem.Infrastructure.Authentication;
public class JwtSettings
{
    public string Secret{get;init;}=null!;
    public int ExpiryMinutes{get;init;}
    public string Audience{get;init;}=null!;
    public string Issuer{get;init;}=null!;

    public const string SectionName="JwtSettings";
}