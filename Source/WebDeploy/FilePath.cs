using System;

namespace WebDeploy
{
    /// <summary>
    /// TODO
    /// </summary>
    public class FilePath
    {
        public string FullPath { get; set; }


        public static implicit operator FilePath(string path)
        {
            /// TODO
            return new FilePath();
        }

        public string GetExtension()
        {
            return null;
        }

        public FilePath MakeAbsolute()
        {
            throw new NotImplementedException();
        }
    }
}