using System.Linq;

namespace Lab4
{
    public class RemovePointSize : RemovePoint
    {
        private long _limits;

        public RemovePointSize(long limits)
        {
            _limits = limits;
        }

        public int RemovePoints(Backup backup)
        {
            if (backup.BackUpSize > _limits)
            {
                long removeSize = 0;
                int removePoints = 0;
                while (removePoints < backup.Points.Count && backup.BackUpSize - _limits > removeSize)
                {
                    removeSize += backup.Points[removePoints].Size;
                    removePoints++;
                }
                return removePoints;
            }

            return 0;
        }
    }
}