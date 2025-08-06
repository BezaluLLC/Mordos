using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace Mordos.API.Models;

/// <summary>
/// Represents a deployment of a Bicep template to Azure
/// </summary>
public class Deployment : ITableEntity
{
    /// <summary>
    /// Unique identifier for the deployment
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Reference to the Bicep template being deployed
    /// </summary>
    [Required]
    public string TemplateId { get; set; } = string.Empty;

    /// <summary>
    /// Name for this deployment
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the deployment
    /// </summary>
    public DeploymentStatus Status { get; set; } = DeploymentStatus.Pending;

    /// <summary>
    /// Target Azure subscription ID
    /// </summary>
    [Required]
    public string TargetSubscriptionId { get; set; } = string.Empty;

    /// <summary>
    /// Target resource group name
    /// </summary>
    [Required]
    public string TargetResourceGroup { get; set; } = string.Empty;

    /// <summary>
    /// Azure region for deployment
    /// </summary>
    [Required]
    public string TargetRegion { get; set; } = string.Empty;

    /// <summary>
    /// JSON string of deployment parameters
    /// </summary>
    public string Parameters { get; set; } = "{}";

    /// <summary>
    /// Deployment output results
    /// </summary>
    public string Outputs { get; set; } = string.Empty;

    /// <summary>
    /// Error messages if deployment failed
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;

    /// <summary>
    /// Deployment logs and details
    /// </summary>
    public string Logs { get; set; } = string.Empty;

    /// <summary>
    /// Azure deployment operation ID
    /// </summary>
    public string AzureDeploymentId { get; set; } = string.Empty;

    /// <summary>
    /// User or service that initiated the deployment
    /// </summary>
    public string InitiatedBy { get; set; } = string.Empty;

    /// <summary>
    /// When the deployment was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When the deployment was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When the deployment was started
    /// </summary>
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// When the deployment completed (success or failure)
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    // ITableEntity implementation
    public string PartitionKey { get; set; } = "Deployment";
    public string RowKey { get; set; } = string.Empty;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public Deployment()
    {
        RowKey = Id;
    }

    public Deployment(string id)
    {
        Id = id;
        RowKey = id;
    }
}

/// <summary>
/// Status of a deployment
/// </summary>
public enum DeploymentStatus
{
    Pending,
    InProgress,
    Succeeded,
    Failed,
    Cancelled
}