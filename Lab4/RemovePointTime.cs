using System;
using System.Linq;

namespace Lab4
{
    public class RemovePointTime : RemovePoint
    {
        private DateTime _limit;

        public RemovePointTime(DateTime limit)
        {
            _limit = limit;
        }

        public int RemovePoints(Backup backup)
        {
            return backup.Points.Count(point => point.Created < _limit);
        }
    }
}