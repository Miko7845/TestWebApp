using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebApp.Utilities
{
    public static class ValidateClass
    {
        public static bool IsDateTimeListInOrder(List<DateTime> dateTimeList)
        {
            var previousDateTimeItem = dateTimeList.LastOrDefault();

            foreach (DateTime currentDateTimeItem in dateTimeList)
            {
                if (currentDateTimeItem.CompareTo(previousDateTimeItem) < 0)
                    return false;
            }

            return true;
        }

        public static bool IsValidJson(string strInput)
        {
            try
            {
                var obj = JToken.Parse(strInput);
                return true;
            }
            catch (JsonReaderException jex)
            {
                Console.WriteLine(jex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
