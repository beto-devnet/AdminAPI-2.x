﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.AdminApp.Management.ClaimSetEditor
{
    public class SharingModel
    {
        public string Title { get; set; }
        public SharingTemplate Template { get; set; }
    }

    public class SharingTemplate
    {
        public SharingClaimSet[] ClaimSets { get; set; }
    }

    public class SharingClaimSet
    {
        public string Name { get; set; }
        public List<JObject> ResourceClaims { get; set; }
    }
}