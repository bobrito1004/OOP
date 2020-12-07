using System;
using System.Data.SqlTypes;

namespace Lab4
{
    public class CreateDeltaPoints : CreatePoint
    {
        public void CreatePoint(Backup backup)
        {
            if(backup.Points.Count == 0) throw new Exception();
            backup.CheckForDelta();
            RestorePoint temp = new RestorePoint(backup.Files, false);
            var deltaSize = temp.Size - backup.Points[backup.PrevRestorePoint].Size;
            backup.BackUpSizePrev = temp.Size;
            backup.BackUpSize += deltaSize;
            RestorePoint rp = new RestorePoint(backup.Delta, true);
            backup.Points.Add(rp);
            backup.PrevDeltaPoint = backup.Points.Count - 1;
            backup.Refresh();
        }
    }
}