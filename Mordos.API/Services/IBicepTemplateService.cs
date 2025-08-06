using Mordos.API.Models;
using Mordos.API.Models.DTOs;

namespace Mordos.API.Services;

/// <summary>
/// Service for managing Bicep templates
/// </summary>
public interface IBicepTemplateService
{
    /// <summary>
    /// Get all Bicep templates with optional filtering
    /// </summary>
    Task<IEnumerable<BicepTemplateResponse>> GetAllTemplatesAsync(string? nameFilter = null, string? tagFilter = null);

    /// <summary>
    /// Get a specific Bicep template by ID
    /// </summary>
    Task<BicepTemplateResponse?> GetTemplateByIdAsync(string id);

    /// <summary>
    /// Create a new Bicep template
    /// </summary>
    Task<BicepTemplateResponse> CreateTemplateAsync(CreateBicepTemplateRequest request);

    /// <summary>
    /// Update an existing Bicep template
    /// </summary>
    Task<BicepTemplateResponse?> UpdateTemplateAsync(string id, UpdateBicepTemplateRequest request);

    /// <summary>
    /// Delete a Bicep template
    /// </summary>
    Task<bool> DeleteTemplateAsync(string id);

    /// <summary>
    /// Validate a Bicep template
    /// </summary>
    Task<bool> ValidateTemplateAsync(string id);
}