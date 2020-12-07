using System;
using System.IO;

namespace Lab4
{
    public class BackupFile
    {
        public FileInfo Info { get; }
        public string Name { get; }
        public long Size { get; set; }
        public bool IsModified { get; set; }
        public long SizeDiff;
        public DateTime LastModified;

        public BackupFile(string path)
        {
            Info = new FileInfo(path);
            Name = Info.FullName;
            LastModified = Info.LastWriteTime;
            Size = CountSize();
            SizeDiff = Size;
            IsModified = false;
        }

        public long CountSize()
        {
            if ((Info.Attributes & FileAttributes.Directory) != FileAttributes.Directory) return Info.Length;
            long size = 0;
            foreach (var file in Directory.GetFiles(Name))
            {
                size += file.Length;
            }
            return size;
            
        }
    }
}
