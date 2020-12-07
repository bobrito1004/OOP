namespace Lab4
{
    public class CreateNormalPoint : CreatePoint
    {
        public void CreatePoint(Backup backup)
        {
            backup.Delta.Clear();
            backup.Refresh(); 
            var rp = new RestorePoint(backup.Files, false);
            backup.BackUpSizePrev = rp.Size;
            backup.BackUpSize += rp.Size;
            backup.Points.Add(rp);
            backup.PrevRestorePoint = backup.Points.Count - 1;
            backup.RemovePoints();
        }
    }
}