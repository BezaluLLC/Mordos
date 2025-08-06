using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace Mordos.API.Models;

/// <summary>
/// Represents a Bicep template for Azure resource deployment
/// </summary>
public class BicepTemplate : ITableEntity
{
    /// <summary>
    /// Unique identifier for the template
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Display name of the template
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of what this template deploys
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The actual Bicep template content
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Version of the template
    /// </summary>
    public string Version { get; set; } = "1.0.0";

    /// <summary>
    /// Tags for categorization and filtering
    /// </summary>
    public string Tags { get; set; } = string.Empty;

    /// <summary>
    /// Author of the template
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Whether the template has been validated
    /// </summary>
    public bool IsValidated { get; set; } = false;

    /// <summary>
    /// Validation results or error messages
    /// </summary>
    public string ValidationMessage { get; set; } = string.Empty;

    /// <summary>
    /// When the template was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When the template was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // ITableEntity implementation
    public string PartitionKey { get; set; } = "BicepTemplate";
    public string RowKey { get; set; } = string.Empty;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public BicepTemplate()
    {
        RowKey = Id;
    }

    public BicepTemplate(string id)
    {
        Id = id;
        RowKey = id;
    }
}