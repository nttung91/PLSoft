using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
 

namespace Technical.Utilities.Zip
{
    public static class Zip
    {      
        /// <summary>
        /// Writes a zip file.
        /// </summary>
        /// <param name="filesToZip">The files to zip.</param>
        /// <param name="path">The destination path.</param>
        /// <param name="compression">The compression level.</param>
        public static void ToFile(string sourceFile, string zipFileName)
        {           
            //reading buffer
            byte[] mBuffer = new Byte[200000];
            //bytes read out
            int bytesRead;

            //create new zip archive
            ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipFileName));
            zipStream.SetLevel(9);

            //create new checksum
            Crc32 crc32 = new Crc32();

            //create new zip entry
            FileInfo fi = new FileInfo(sourceFile);
            ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));
            entry.DateTime = fi.LastWriteTime;
            entry.Size = fi.Length;

            //open source file
            FileStream sourceFileStream = File.OpenRead(sourceFile);

            //reset CRC
            crc32.Reset();
 
            //add new entry to zip file
            zipStream.PutNextEntry(entry); 

            //read source file
            while (sourceFileStream.Position < sourceFileStream.Length)
	        {
                bytesRead = sourceFileStream.Read(mBuffer, 0, mBuffer.Length);
                zipStream.Write(mBuffer, 0, bytesRead);
                crc32.Update(mBuffer, 0, bytesRead);
	        }

            //store CRC value of this entry
            entry.Crc = crc32.Value;

            //close entry
            zipStream.CloseEntry();

            //close source file
            sourceFileStream.Close();
           
            //close zip archive
            zipStream.Finish();
            zipStream.Flush();
            zipStream.Close();
            zipStream.Dispose();
        }

        /// <summary>
        /// Writes zip file to memory stream.
        /// </summary>
        /// <param name="filesToZip">The files to zip.</param>
        /// <param name="path">The destination path.</param>
        /// <param name="compression">The compression level.</param>
        public static MemoryStream ToMemoryStream(string sourceFile)
        {
            //memory stream
            MemoryStream msCompressed = new MemoryStream();

            //reading buffer
            byte[] mBuffer = new Byte[200000];
            //bytes read out
            int bytesRead;

            //create new zip archive
            ZipOutputStream zipStream = new ZipOutputStream(msCompressed);
            zipStream.SetLevel(9);

            //create new checksum
            Crc32 crc32 = new Crc32();

            //create new zip entry
            FileInfo fi = new FileInfo(sourceFile);
            ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));
            entry.DateTime = fi.LastWriteTime;
            entry.Size = fi.Length;

            //open source file
            FileStream sourceFileStream = File.OpenRead(sourceFile);

            //reset CRC
            crc32.Reset();

            //add new entry to zip file
            zipStream.PutNextEntry(entry);

            //read source file
            while (sourceFileStream.Position < sourceFileStream.Length)
            {
                bytesRead = sourceFileStream.Read(mBuffer, 0, mBuffer.Length);
                zipStream.Write(mBuffer, 0, bytesRead);
                crc32.Update(mBuffer, 0, bytesRead);
            }

            //store CRC value of this entry
            entry.Crc = crc32.Value;

            //close entry
            zipStream.CloseEntry();

            //close source file
            sourceFileStream.Close();

            //close zip archive
            zipStream.Finish();
            zipStream.Flush();
            //don't close stream here
            //zipStream.Close();
            //zipStream.Dispose();

            msCompressed.Position = 0;

            return msCompressed;
        }

        /// <summary>
        /// Writes zip file to byte array.
        /// </summary>
        /// <param name="filesToZip">The files to zip.</param>
        /// <param name="path">The destination path.</param>
        /// <param name="compression">The compression level.</param>
        public static byte[] ToByteArray(string sourceFile)
        {
            byte[] zipFile;

            //memory stream
            MemoryStream msCompressed = new MemoryStream();

            //reading buffer
            byte[] mBuffer = new Byte[200000];
            //bytes read out
            int bytesRead;

            //create new zip archive
            ZipOutputStream zipStream = new ZipOutputStream(msCompressed);
            zipStream.SetLevel(9);

            //create new checksum
            Crc32 crc32 = new Crc32();

            //create new zip entry
            FileInfo fi = new FileInfo(sourceFile);
            ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));
            entry.DateTime = fi.LastWriteTime;
            entry.Size = fi.Length;

            //open source file
            FileStream sourceFileStream = File.OpenRead(sourceFile);

            //reset CRC
            crc32.Reset();

            //add new entry to zip file
            zipStream.PutNextEntry(entry);

            //read source file
            while (sourceFileStream.Position < sourceFileStream.Length)
            {
                bytesRead = sourceFileStream.Read(mBuffer, 0, mBuffer.Length);
                zipStream.Write(mBuffer, 0, bytesRead);
                crc32.Update(mBuffer, 0, bytesRead);
            }

            //store CRC value of this entry
            entry.Crc = crc32.Value;

            //close entry
            zipStream.CloseEntry();

            //close source file
            sourceFileStream.Close();

            //close zip archive
            zipStream.Finish();
            zipStream.Flush();

            //get byte array
            zipFile = msCompressed.ToArray();

            zipStream.Close();
            zipStream.Dispose();

            msCompressed.Close();
            msCompressed.Dispose();

            return zipFile;
        }
    }
}
