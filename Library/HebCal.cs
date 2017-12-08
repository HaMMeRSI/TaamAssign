using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class HebCal
    {
        private static List<HebCalItem> HolidayList { get; set; }

        static HebCal()
        {
          HolidayList = new List<HebCalItem>();
            JObject HebCalResponse = RESTReader.GET(@"http://www.hebcal.com/hebcal/?v=1&cfg=json&maj=on&min=on&mod=on&nx=off&year=now&month=x&ss=off&mf=off&c=off&geo=none&m=50&s=off&o=off");

            foreach (JObject item in (HebCalResponse["items"] as JArray))
            {
                HolidayList.Add(new HebCalItem(DateTime.Parse(item["date"].ToString()), item["title"].ToString(), item["hebrew"].ToString()));
            } 
        }

        public bool IsDateHitsHoliday(DateTime date)
        {
            foreach (HebCalItem item in HolidayList)
            {
                if(date == item.Date) {
                    return true;
                }
            }

            return false;
        }
    }

    public class HebCalItem
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Hebrew { get; set; }

        public HebCalItem(DateTime Date, string Title, string Hebrew)
        {
            this.Date = Date;
            this.Title = Title;
            this.Hebrew = Hebrew;
        }
    }

}
