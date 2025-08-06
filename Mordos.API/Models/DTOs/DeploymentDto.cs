using System.ComponentModel.DataAnnotations;

namespace Mordos.API.Models.DTOs;

/// <summary>
/// Request model for creating a new deployment
/// </summary>
public class CreateDeploymentRequest
{
    /// <summary>
    /// Reference to the Bicep template to deploy
    /// </summary>
    [Required]
    public string TemplateId { get; set; } = string.Empty;

    /// <summary>
    /// Name for this deployment
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Target Azure subscription ID
    /// </summary>
    [Required]
    public string TargetSubscriptionId { get; set; } = string.Empty;

    /// <summary>
    /// Target resource group name
    /// </summary>
    [Required]
    [StringLength(90, MinimumLength = 1)]
    public string TargetResourceGroup { get; set; } = string.Empty;

    /// <summary>
    /// Azure region for deployment
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string TargetRegion { get; set; } = string.Empty;

    /// <summary>
    /// JSON string of deployment parameters
    /// </summary>
    public string Parameters { get; set; } = "{}";

    /// <summary>
    /// User or service initiating the deployment
    /// </summary>
    [StringLength(100)]
    public string InitiatedBy { get; set; } = string.Empty;
}

/// <summary>
/// Request model for updating a deployment
/// </summary>
public class UpdateDeploymentRequest
{
    /// <summary>
    /// Update the deployment status
    /// </summary>
    public DeploymentStatus? Status { get; set; }

    /// <summary>
    /// Update deployment outputs
    /// </summary>
    public string? Outputs { get; set; }

    /// <summary>
    /// Update error messages
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Update deployment logs
    /// </summary>
    public string? Logs { get; set; }

    /// <summary>
    /// Update Azure deployment ID
    /// </summary>
    public string? AzureDeploymentId { get; set; }
}

/// <summary>
/// Response model for deployment operations
/// </summary>
public class DeploymentResponse
{
    public string Id { get; set; } = string.Empty;
    public string TemplateId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DeploymentStatus Status { get; set; }
    public string TargetSubscriptionId { get; set; } = string.Empty;
    public string TargetResourceGroup { get; set; } = string.Empty;
    public string TargetRegion { get; set; } = string.Empty;
    public string Parameters { get; set; } = string.Empty;
    public string Outputs { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string Logs { get; set; } = string.Empty;
    public string AzureDeploymentId { get; set; } = string.Empty;
    public string InitiatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public static DeploymentResponse FromEntity(Deployment entity)
    {
        return new DeploymentResponse
        {
            Id = entity.Id,
            TemplateId = entity.TemplateId,
            Name = entity.Name,
            Status = entity.Status,
            TargetSubscriptionId = entity.TargetSubscriptionId,
            TargetResourceGroup = entity.TargetResourceGroup,
            TargetRegion = entity.TargetRegion,
            Parameters = entity.Parameters,
            Outputs = entity.Outputs,
            ErrorMessage = entity.ErrorMessage,
            Logs = entity.Logs,
            AzureDeploymentId = entity.AzureDeploymentId,
            InitiatedBy = entity.InitiatedBy,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            StartedAt = entity.StartedAt,
            CompletedAt = entity.CompletedAt
        };
    }
}