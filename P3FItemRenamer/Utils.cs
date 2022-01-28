using Onova;
using Onova.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    class Utils
    {
        public static async void CheckForUpdates()
        {
            using (var manager = new UpdateManager(
                new GithubPackageResolver("AnimatedSwine37", "P3FItemRenamer", "*.zip"),
                new ZipPackageExtractor()))
            {
                var result = await manager.CheckForUpdatesAsync();
                if (result.CanUpdate)
                {
                    bool doUpdate = UserInterface.GetBool("A new version of P3F Item Renamer is available. Would you like to update now?");
                    if (!doUpdate)
                        return;
                    // Prepare an update by downloading and extracting the package
                    // (supports progress reporting and cancellation)
                    await manager.PrepareUpdateAsync(result.LastVersion);

                    // Launch an executable that will apply the update
                    // (can be instructed to restart the application afterwards)
                    manager.LaunchUpdater(result.LastVersion);

                    // Terminate the running application so that the updater can overwrite files
                    Environment.Exit(0);

                }
            }
        }
    }
}
