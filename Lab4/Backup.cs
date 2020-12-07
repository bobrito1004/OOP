using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Lab4
{
    public class Backup
    {
        public long BackUpSizePrev { get; set; }
        public long BackUpSize { get; set; }
        public List<BackupFile> Files { get; }
        public List<BackupFile> Delta { get; }
        public List<RestorePoint> Points;
        private RemovedPoints _rpAlg;
        public int PrevRestorePoint = 0;
        public int PrevDeltaPoint = 0;

        public Backup()
        {
            BackUpSizePrev = 0;
            BackUpSize = 0;
            Files = new List<BackupFile>();
            Delta = new List<BackupFile>();
            Points = new List<RestorePoint>();
        }

        public void Add(string path)
        {
            var file = new FileInfo(path);
            if (!file.Exists)
            {
                throw new Exception();
            }

            Files.Add(new BackupFile(path));
            Delta.Add(new BackupFile(path));
        }

        public void Remove(string path)
        {
            foreach (var file in Files)
            {
                if (file.Name == path)
                {
                    Files.Remove(file);
                    return;
                }
            }

            //throw new Exception("No such file.");
        }

        public void Refresh()
        {
            foreach (var file in Files)
            {
                file.LastModified = file.Info.LastWriteTime;
                file.Size = file.CountSize();
            }
        }

        public void CheckForDelta()
        {
            foreach (var file in Files)
            {
                if (file.LastModified == file.Info.LastWriteTime) continue;
                Delta.Add(file);
                Delta[Delta.Count - 1].IsModified = true;
            }
        }

        public void CreatePoint(CreatePoint alg)
        {
            alg.CreatePoint(this);
        }
        
        public void RemovePoints()
        {
            _rpAlg?.PointToRemove(this);
        }

        public void SetAlg(RemovedPoints alg)
        {
            _rpAlg = alg;
        }
    }
}