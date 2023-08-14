// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.AdminApi.Features.Applications;
using EdFi.Ods.AdminApi.Features.AuthorizationStrategies;
using EdFi.Ods.AdminApi.Infrastructure.ClaimSetEditor;
using Swashbuckle.AspNetCore.Annotations;

namespace EdFi.Ods.AdminApi.Features.ClaimSets;

[SwaggerSchema(Title = "ClaimSet")]
public class ClaimSetModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsSystemReserved { get; set; }
    public List<SimpleApplicationModel> Applications { get; set; } = new();
}

[SwaggerSchema(Title = "ClaimSetWithResources")]
public class ClaimSetDetailsModel : ClaimSetModel
{
    public List<ClaimSetResourceClaimModel> ResourceClaims { get; set; } = new();
}

[SwaggerSchema(Title = "ClaimSetResourceClaim")]
public class ClaimSetResourceClaimModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool Create { get; set; }
    public bool Read { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public AuthorizationStrategyClaimSetModel?[] DefaultAuthStrategiesForCRUD { get; set; }
    public AuthorizationStrategyClaimSetModel?[] AuthStrategyOverridesForCRUD { get; set; }

    [SwaggerSchema(Description = "Children are collection of ResourceClaim")]
    public List<ClaimSetResourceClaimModel> Children { get; set; }
    public ClaimSetResourceClaimModel()
    {
        Children = new List<ClaimSetResourceClaimModel>();
        DefaultAuthStrategiesForCRUD = Array.Empty<AuthorizationStrategyClaimSetModel>();
        AuthStrategyOverridesForCRUD = Array.Empty<AuthorizationStrategyClaimSetModel>();
    }
}

[SwaggerSchema(Title = "ResourceClaimActionModel")]
public class ResourceClaimActionModel
{
    public bool Create { get; set; }
    public bool Read { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
}

[SwaggerSchema(Title = "ResourceClaimModel")]
public class ResourceClaimModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    public string? ParentName { get; set; }

    [SwaggerSchema(Description = "Children are collection of SimpleResourceClaimModel")]
    public List<ResourceClaimModel> Children { get; set; }
    public ResourceClaimModel()
    {
        Children = new List<ResourceClaimModel>();
    }
}

[SwaggerSchema(Title = "AuthorizationStrategy")]
public class AuthorizationStrategyClaimSetModel : AuthorizationStrategyModel
{
    public bool IsInheritedFromParent { get; set; }
}

public class EditClaimSetModel : IEditClaimSetModel
{
    public string? ClaimSetName { get; set; }

    public int ClaimSetId { get; set; }
}

public class UpdateResourcesOnClaimSetModel : IUpdateResourcesOnClaimSetModel
{
    public int ClaimSetId { get; set; }

    public List<ResourceClaim>? ResourceClaims { get; set; } = new List<ResourceClaim>();
}

public class DeleteClaimSetModel : IDeleteClaimSetModel
{
    public string? Name { get; set; }

    public int Id { get; set; }
}

public interface IResourceClaimOnClaimSetRequest
{
    int ClaimSetId { get; }
    int ResourceClaimId { get; }
    public ResourceClaimActionModel ResourceClaimActions { get; }
}
