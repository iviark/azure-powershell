using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InstallerChecks
{
    public class InstallerChecks
    {
        [CustomAction]
        public static ActionResult CheckForAzureRm(Session session)
        {
            List<string> AzureModules = new List<string> { "Azure.AnalysisServices", "Azure.Storage", "AzureRM", "AzureRM.AnalysisServices",
                "AzureRM.ApiManagement", "AzureRM.ApplicationInsights", "AzureRM.Automation", "AzureRM.Backup", "AzureRM.Batch", "AzureRM.Billing",
                "AzureRM.Cdn", "AzureRM.CognitiveServices", "AzureRM.Compute", "AzureRM.Compute.Experiments", "AzureRM.Consumption",
                "AzureRM.ContainerInstance", "AzureRM.ContainerRegistry", "AzureRM.DataFactories", "AzureRM.DataFactoryV2", "AzureRM.DataLakeAnalytics",
                "AzureRM.DataLakeStore", "AzureRM.DataMigration", "AzureRM.DevTestLabs", "AzureRM.Dns", "AzureRM.EventGrid", "AzureRM.EventHub",
                "AzureRM.HDInsight", "AzureRM.Insights", "AzureRM.IotHub", "AzureRM.KeyVault", "AzureRM.LogicApp", "AzureRM.MachineLearning",
                "AzureRM.MachineLearningCompute", "AzureRM.ManagementPartner", "AzureRM.Maps", "AzureRM.MarketplaceOrdering", "AzureRM.Media",
                "AzureRM.Network", "AzureRM.NotificationHubs", "AzureRM.OperationalInsights", "AzureRM.PolicyInsights", "AzureRM.PowerBIEmbedded",
                "AzureRM.profile", "AzureRM.RecoveryServices", "AzureRM.RecoveryServices.Backup", "AzureRM.RecoveryServices.SiteRecovery",
                "AzureRM.RedisCache", "AzureRM.Relay", "AzureRM.Reservations", "AzureRM.Resources", "AzureRM.Scheduler", "AzureRM.ServerManagement",
                "AzureRM.ServiceBus", "AzureRM.ServiceFabric", "AzureRM.SignalR", "AzureRM.SiteRecovery", "AzureRM.Sql", "AzureRM.Storage",
                "AzureRM.StreamAnalytics", "AzureRM.Subscription.Preview", "AzureRM.Tags", "AzureRM.TrafficManager", "AzureRM.UsageAggregates",
                "AzureRM.Websites", "AzureRM.Websites.Experiments"};

            session.Log("Begin CustomAction");
            var paths = Environment.GetEnvironmentVariable("PSModulePath").Split(';');
            foreach (var path in paths)
            {
                var modules = Directory.GetDirectories(path);
                foreach (var module in modules)
                {
                    var moduleName = module.Split('\\').LastOrDefault();
                    if (AzureModules.Any(x => x.Equals(moduleName, StringComparison.OrdinalIgnoreCase)))
                    {
                        session["CONTAINSAZURERM"] = "true";
                        return ActionResult.Success;
                    }
                }
            }
            session["CONTAINSAZURERM"] = "false";
            return ActionResult.Success;
        }
    }
}