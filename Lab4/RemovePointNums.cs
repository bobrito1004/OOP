using System;
using System.Linq;

namespace Lab4
{
    public class RemovePointNums : RemovePoint
    {
        private int _limit;
        public RemovePointNums(int limit)
        {
            _limit = limit;
        }
        public int RemovePoints(Backup backup)
        {
            if (backup.Points.Count > _limit)
            {
                var DeltaNumber = backup.Points.Count(rp => rp.IsDelta);
                if (backup.Points.Count - DeltaNumber - 1 < _limit)
                {
                    throw new Exception();
                }

                return backup.Points.Count - _limit;
            }
            throw new Exception();
        }
    }
}