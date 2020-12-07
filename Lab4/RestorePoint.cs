using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public class RestorePoint
    {
        private static int ID;
        private int _id;
        public DateTime Created;
        public long Size { get;}
        private List<BackupFile> _files;
        public bool IsDelta;

        public RestorePoint(List<BackupFile> files, bool delta)
        {
            _id = ID;
            ID++;
            Created = DateTime.Now;
            _files = new List<BackupFile>();
            _files.AddRange(files);
            if (delta)
            {
                Size = GetDeltaSize();
            }
            else
            {
                Size = GetSize();
            }
            IsDelta = delta;
        }

        private long GetSize()
        {
            return _files.Sum(file => file.Size);
        }

        private long GetDeltaSize()
        {
            long size = 0;
            for (var i = 0; i < _files.Count; i++)
            {
                if (_files[i].IsModified)
                {
                    size += _files[i].SizeDiff;
                }
                else
                {
                    size += _files[i].Size;
                }
            }

            return size;
        }
    }
}