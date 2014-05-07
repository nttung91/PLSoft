using System;
using System.IO;

namespace Technical.Utilities.FileService
{
    public class DirectoryCopier
    {
        public CopyParameter CopyParameter { get; private set; }

        public DirectoryCopier(CopyParameter copyParameter)
        {
            CopyParameter = copyParameter;
        }

        public CopyResult Copy()
        {
            var result = new CopyResult();
            try
            {
                try
                {
                    CopyDirectoryAndSubdirectories(CopyParameter.SourceDirectoryInfo,
                        CopyParameter.DestinationDirectoryInfo);
                }
                catch (IOException ex)
                {
                    result.HasError = true;
                    result.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }


        private void CopyDirectoryAndSubdirectories(DirectoryInfo sourceDirectoryInfo,
            DirectoryInfo destinationDirectoryInfo)
        {
            if (!destinationDirectoryInfo.Exists)
            {
                destinationDirectoryInfo.Create();
            }

            foreach (var sourceFileInfo in sourceDirectoryInfo.GetFiles())
            {
                sourceFileInfo.CopyTo(Path.Combine(destinationDirectoryInfo.FullName, sourceFileInfo.Name), true);
            }

            foreach (var sourceDirectoryInfoSubdirectories in sourceDirectoryInfo.GetDirectories())
            {
                CopyDirectoryAndSubdirectories(sourceDirectoryInfoSubdirectories,
                    new DirectoryInfo(Path.Combine(destinationDirectoryInfo.FullName,
                        sourceDirectoryInfoSubdirectories.Name)));
            }
        }
    }
}