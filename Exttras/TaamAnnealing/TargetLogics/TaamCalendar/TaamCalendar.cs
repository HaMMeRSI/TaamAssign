using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaamLogics
{
    public class TaamCalendar
    {
        public static int TaamDuration = 13 * 7;
        public static int TaamDurationErrorMargin = 2;
        public static int ChunksCount = (int)Math.Round(365.0 / TaamCalendar.TaamDuration);

        public TaamChunk[] GetTaamChunks(DateTime StartDate)
        {
            HebCal HebCalendar = new HebCal();
            DateTime CurrentDate = StartDate;
            int nChunkReduce = 0;
            TaamChunk[] Assignments = new TaamChunk[TaamCalendar.ChunksCount];

            bool IsValidDate = !HebCalendar.IsDateHitsHoliday(CurrentDate);
            while (!IsValidDate)
            {
                CurrentDate = CurrentDate.AddDays(7);
                nChunkReduce += 7;
                IsValidDate = !HebCalendar.IsDateHitsHoliday(CurrentDate);
            }

            for (int i = 0; i < TaamCalendar.ChunksCount; i++)
            {
                TaamChunk Chunk = new TaamChunk();
                Chunk.Start = new DateTime(CurrentDate.Ticks);

                CurrentDate = CurrentDate.AddDays(TaamCalendar.TaamDuration - nChunkReduce);
                nChunkReduce = 0;

                IsValidDate = !HebCalendar.IsDateHitsHoliday(CurrentDate);
                while (!IsValidDate)
                {
                    CurrentDate = CurrentDate.AddDays(7);
                    nChunkReduce += 7;
                    IsValidDate = !HebCalendar.IsDateHitsHoliday(CurrentDate);
                }

                Chunk.End = new DateTime(CurrentDate.Ticks);

                Assignments[i] = Chunk; 
            }

            return Assignments;
        }
    }
}
