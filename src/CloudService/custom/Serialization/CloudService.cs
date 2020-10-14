﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    public partial class CloudService
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string ResourceGroupName
        { 
            get {
                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Compute/cloudServices/(?<cloudServiceName>[^/]+)$").Match(this.Id);
                if (!_match.Success) {
                    return null;
                }
                return _match.Groups["resourceGroupName"].Value;
            }
        }
    }

    public partial interface ICloudService
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ResourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; }
    }
}
