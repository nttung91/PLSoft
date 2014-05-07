using System;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Closer
{
    public class TimePeriodClosingInfo
    {
        public int ArtId { get; set; }
        public DateTime? NewEftvTo { get; set; }
        public bool Valid { get; set; }

        public TimePeriodClosingInfo(bool valid, int artId, DateTime? newEftvTo)
        {
            ArtId = artId;
            NewEftvTo = newEftvTo;
            Valid = valid;
        }
    }
}