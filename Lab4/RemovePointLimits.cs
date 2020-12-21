using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    public class RemovePointLimits : RemovedPoints
    {
        private List<RemovePoint> _limits;
        private bool Max = true;
        private bool Min = false;

        public RemovePointLimits()
        {
            _limits = new List<RemovePoint>();
        }

        public void AddLimits(Backup backup, RemovePoint limits)
        {
            _limits.Add(limits);
            PointToRemove(backup);
        }

        void DeleteLimits(Backup backup, RemovePoint limits)
        {
            _limits.Remove(limits);
        }

        public void setLimitMax()
        {
            Max = true;
            Min = false;
        }
        public void PointToRemove(Backup backup)
        {
            if (_limits.Count == 0) return;
            var pts = 0;
            if (Max)
            {
                pts = Int32.MinValue;
                foreach (var point in _limits)
                {
                    pts = Math.Max(point.RemovePoints(backup), pts);
                }
            }
            else
            {
                pts = Int32.MaxValue;
                foreach (var point in _limits)
                {
                    pts = Math.Min(point.RemovePoints(backup), pts);
                }
            }

            backup.PrevRestorePoint -= pts;
            backup.PrevDeltaPoint -= pts;
            for (int i = 0; i < pts; i++)
            {
                backup.Points.RemoveAt(0);
            }
        }
    }
}