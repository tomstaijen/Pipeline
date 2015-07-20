using Microsoft.Web.Deployment;

namespace WebDeploy
{
    public interface IWebDeployManager
    {
        /// <summary>
        /// Deploys the content of a website
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <returns>DeploymentChangeSummary.</returns>
        DeploymentChangeSummary Deploy(PublishSettings settings);
    }
}