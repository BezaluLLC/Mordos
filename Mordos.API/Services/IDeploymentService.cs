using Mordos.API.Models;
using Mordos.API.Models.DTOs;

namespace Mordos.API.Services;

/// <summary>
/// Service for managing deployments
/// </summary>
public interface IDeploymentService
{
    /// <summary>
    /// Get all deployments with optional filtering
    /// </summary>
    Task<IEnumerable<DeploymentResponse>> GetAllDeploymentsAsync(string? templateIdFilter = null, DeploymentStatus? statusFilter = null);

    /// <summary>
    /// Get a specific deployment by ID
    /// </summary>
    Task<DeploymentResponse?> GetDeploymentByIdAsync(string id);

    /// <summary>
    /// Create a new deployment
    /// </summary>
    Task<DeploymentResponse> CreateDeploymentAsync(CreateDeploymentRequest request);

    /// <summary>
    /// Update an existing deployment
    /// </summary>
    Task<DeploymentResponse?> UpdateDeploymentAsync(string id, UpdateDeploymentRequest request);

    /// <summary>
    /// Delete a deployment
    /// </summary>
    Task<bool> DeleteDeploymentAsync(string id);

    /// <summary>
    /// Start a deployment (change status to InProgress)
    /// </summary>
    Task<bool> StartDeploymentAsync(string id);

    /// <summary>
    /// Get deployments by template ID
    /// </summary>
    Task<IEnumerable<DeploymentResponse>> GetDeploymentsByTemplateIdAsync(string templateId);
}