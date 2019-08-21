using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TalkingClock_RestService.Controllers

{

    public class TalkingClockController : ApiController

    {

        //GET: api/TalkingClock/GetTime/12.45

        public string GetTime(decimal uTime)

        {

            string[] number = uTime.ToString().Split('.');

            int hour = Convert.ToInt16(number[0]);

            int min = Convert.ToInt16(number[1]);



            if (hour > 12)

            {

                hour -= 12;

            }



            string[] nums = { "zero", "one", "two", "three", "four",

                            "five", "six", "seven", "eight", "nine",

                            "ten", "eleven", "twelve", "thirteen",

                            "fourteen", "fifteen", "sixteen", "seventeen",

                            "eighteen", "nineteen", "twenty", "twenty one",

                            "twenty two", "twenty three", "twenty four",

                            "twenty five", "twenty six", "twenty seven",

                            "twenty eight", "twenty nine",

                        };



            //check for mins    

            if (min > 0)

            {

                string displayMins = returnHReadableMins(min, nums);

                //check if hour is after half past

                if (min > 30)

                {

                    //check for timings between 12:31 and 12:58

                    if (hour == 12)

                    {

                        return displayMins + nums[(hour % 2) + 1];

                    }

                    else

                    {

                        return displayMins + nums[hour + 1];

                    }

                }

                //check if hour is before half past

                else

                {

                    return displayMins + nums[hour];

                }

            }

            else

            {

                return nums[hour] + " O'clock";

            }

        }



        //This method returns a string with text - "five past", "ten past", "half past"

        public static string returnHReadableMins(int minutes, string[] nums)

        {

            string returnHRText = "";



            if (minutes == 1)

            {

                returnHRText = "One minute past ";

            }

            else if (minutes == 15)

            {

                returnHRText = "Quarter past ";

            }

            else if (minutes == 30)

            {

                returnHRText = "Half past ";

            }

            else if (minutes == 45)

            {

                returnHRText = "Quarter to ";

            }

            else if (minutes == 59)

            {

                returnHRText = "One minute to ";

            }

            else if (minutes <= 30)

            {

                returnHRText = nums[minutes] + " minutes past ";

            }

            else if (minutes > 30)

            {

                returnHRText = nums[60 -

                    minutes] + " minutes to ";

            }



            return returnHRText;

        }

    }

}

