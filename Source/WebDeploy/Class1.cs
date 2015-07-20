﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeploy
{
    public static class DeployUtils
    {
        public const string MSDeployHandler = "msdeploy.axd";
        public const int DefaultPort = 8172;


        public static string GetWmsvcUrl(string computerName, int port, string siteName)
        {
            if (!computerName.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                // Some examples of what we might expect here:
                // foo.com:443/MSDeploy/msdeploy.axd
                // foo.com/MSDeploy/msdeploy.axd
                // foo.com:443
                // foo.com

                computerName = DeployUtils.InsertPortIfNotSpecified(computerName, port);
                computerName = DeployUtils.AppendHandlerIfNotSpecified(computerName);

                if (!string.IsNullOrEmpty(siteName))
                {
                    //Site
                    computerName = string.Format("https://{0}?site={1}", computerName, siteName);
                }
                else
                {
                    //Root
                    computerName = string.Format("https://{0}", computerName);
                }
            }

            return computerName;
        }

        public static string AppendHandlerIfNotSpecified(string publishUrl)
        {
            if (!publishUrl.EndsWith(DeployUtils.MSDeployHandler, StringComparison.OrdinalIgnoreCase))
            {
                if (publishUrl.EndsWith("/"))
                {
                    publishUrl = publishUrl + DeployUtils.MSDeployHandler;
                }
                else
                {
                    publishUrl = publishUrl + "/" + DeployUtils.MSDeployHandler;
                }
            }

            return publishUrl;
        }

        public static string InsertPortIfNotSpecified(string publishUrl, int port)
        {
            string[] colonParts = publishUrl.Split(new char[] {':'});

            if (colonParts.Length == 1)
            {
                // No port was specified so we need to add it in
                int slashIndex = publishUrl.IndexOf('/');

                if (slashIndex > -1)
                {
                    //Before slash
                    publishUrl = publishUrl.Insert(slashIndex, ":" + port.ToString());
                }
                else
                {
                    //No Slash
                    publishUrl = publishUrl + ":" + DefaultPort;
                }
            }

            if (colonParts.Length > 1)
            {
                // It's possible that a port was specified, but we're not sure.  Apps like Monaco do weird
                // things like put colon characters in the path and who knows what might happen in the future.
                // We're being extra careful here to make sure that we only look for ports after the hostname.
                // This means right after a colon, but never following ANY '/' characters.

                // Examples of colonParts[0] might be
                // test.com
                // foo.com/bar
                int slashIndex = colonParts[0].IndexOf('/');

                if (slashIndex > -1)
                {
                    // Since a slash was found before the first colon, we know that the first colon was
                    // not used for the port.  Therefore we need to inject the default port before the first slash
                    colonParts[0] = colonParts[0].Insert(slashIndex, ":" + port.ToString());

                    publishUrl = string.Join(":", colonParts);
                }
            }

            return publishUrl;
        }
    }
}
