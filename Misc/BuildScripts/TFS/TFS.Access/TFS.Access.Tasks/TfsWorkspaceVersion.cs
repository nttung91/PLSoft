
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;

namespace TFS.Access.Tasks
{
    public class TfsWorkspaceVersion : Task
    {

        /// <summary>Path to local working copy.</summary>
        [Required]
        public string LocalPath
        {
            get; set;
        }

        private int _changeset;
        /// <summary>
        /// The latest changeset ID in the local path
        /// </summary>
        [Output]
        public int Changeset
        {
            get { return _changeset; }
        }
        

        protected void GetServices(out Workspace workspace, out VersionControlServer versionControlServer)
        {
            var workstation = Workstation.Current;
            Log.LogMessage(MessageImportance.Normal, "workstation name: " + workstation.Name);
            var workspaceInfo = workstation.GetLocalWorkspaceInfo(LocalPath);            
            var serverCollectionUrl = workspaceInfo.ServerUri;
            Log.LogMessage(MessageImportance.Normal, "serverCollectionUrl: " + serverCollectionUrl);

            var uri = new Uri(GetVDirUrl(serverCollectionUrl));
            Log.LogMessage(MessageImportance.Normal, "serverUrl: " + uri);

            TfsConfigurationServer configurationServer =
                TfsConfigurationServerFactory.GetConfigurationServer(uri);

            // Get the catalog of team project collections
            ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(
                new[] { CatalogResourceTypes.ProjectCollection },
                false, CatalogQueryOptions.None);

            workspace = null;
            versionControlServer = null;

            // List the team project collections
            foreach (CatalogNode collectionNode in collectionNodes)
            {
                // Use the InstanceId property to get the team project collection
                Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                if (collectionId == workspaceInfo.ServerGuid)
                {
                    TfsTeamProjectCollection teamProjectCollection =
                        configurationServer.GetTeamProjectCollection(collectionId);

                    versionControlServer = teamProjectCollection.GetService<VersionControlServer>();

                    workspace = workspaceInfo.GetWorkspace(teamProjectCollection);
                    Log.LogMessage(MessageImportance.Normal, "found workspace for collectionId: " + collectionId);
                    break;
                }
            }

            if (workspace == null)
            {
                Log.LogError("No workspace found.");
            }

            if (versionControlServer == null)
            {
                Log.LogError("No VersionControlServer found.");
            }
        }

        private string GetVDirUrl(Uri serverCollectionUrl)
        {
            var vDir = serverCollectionUrl.LocalPath;
            if (vDir.StartsWith("/"))
            {
                vDir = vDir.Substring(1, vDir.Length - 1);
            }
            if (vDir.IndexOf("/") > 0)
            {
                vDir = vDir.Substring(0, vDir.IndexOf("/"));
            }

            string url = serverCollectionUrl.Scheme + "://" + serverCollectionUrl.Host + ":" + serverCollectionUrl.Port + "/" +
                         vDir;
            return url;
        }        

        public override bool Execute()
        {
            Workspace workspace;
            VersionControlServer versionControlServer;
            GetServices(out workspace, out versionControlServer);

            if (workspace == null || versionControlServer == null)
            {
                return false;
            }            

            VersionSpec spec = new WorkspaceVersionSpec(workspace);            
            IEnumerable history = versionControlServer.QueryHistory(LocalPath, spec, 0, RecursionType.Full, null, null, null, 1, false, false);
            IEnumerator historyEnumerator = history.GetEnumerator();
            if (historyEnumerator.MoveNext())
            {
                Log.LogMessage(MessageImportance.Normal, "Found history entry");
                var cs = historyEnumerator.Current as Changeset;
                Log.LogMessage(MessageImportance.Normal, "changeset id: " + cs.ChangesetId);
                _changeset = cs.ChangesetId;
            }


            return true;
        }
    }
}
