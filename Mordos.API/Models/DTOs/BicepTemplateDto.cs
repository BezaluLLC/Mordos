using System.ComponentModel.DataAnnotations;

namespace Mordos.API.Models.DTOs;

/// <summary>
/// Request model for creating a new Bicep template
/// </summary>
public class CreateBicepTemplateRequest
{
    /// <summary>
    /// Display name of the template
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of what this template deploys
    /// </summary>
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The actual Bicep template content
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Version of the template
    /// </summary>
    [StringLength(20)]
    public string Version { get; set; } = "1.0.0";

    /// <summary>
    /// Comma-separated tags for categorization
    /// </summary>
    [StringLength(200)]
    public string Tags { get; set; } = string.Empty;

    /// <summary>
    /// Author of the template
    /// </summary>
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;
}

/// <summary>
/// Request model for updating a Bicep template
/// </summary>
public class UpdateBicepTemplateRequest
{
    /// <summary>
    /// Display name of the template
    /// </summary>
    [StringLength(100, MinimumLength = 1)]
    public string? Name { get; set; }

    /// <summary>
    /// Description of what this template deploys
    /// </summary>
    [StringLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// The actual Bicep template content
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Version of the template
    /// </summary>
    [StringLength(20)]
    public string? Version { get; set; }

    /// <summary>
    /// Comma-separated tags for categorization
    /// </summary>
    [StringLength(200)]
    public string? Tags { get; set; }

    /// <summary>
    /// Author of the template
    /// </summary>
    [StringLength(100)]
    public string? Author { get; set; }
}

/// <summary>
/// Response model for Bicep template operations
/// </summary>
public class BicepTemplateResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsValidated { get; set; }
    public string ValidationMessage { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static BicepTemplateResponse FromEntity(BicepTemplate entity)
    {
        return new BicepTemplateResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Content = entity.Content,
            Version = entity.Version,
            Tags = entity.Tags,
            Author = entity.Author,
            IsValidated = entity.IsValidated,
            ValidationMessage = entity.ValidationMessage,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}