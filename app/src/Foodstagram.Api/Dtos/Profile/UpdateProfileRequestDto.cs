namespace Foodstagram.Api.Dtos.Profile;

public sealed class UpdateProfileRequestDto
{
    public string DisplayName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
}
