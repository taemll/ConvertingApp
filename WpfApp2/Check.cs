using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Check
    {
        public static string ConvertValue(List<ExchangeRate> rates, string inputValue, string input_combobox, string output_combobox, bool check)
        {
            double input = Convert.ToDouble(inputValue);
            double value, desc;
            foreach (var item in rates)
            {
                if (output_combobox == item.title || input_combobox == item.title)
                {
                    desc = item.description;
                    if (check) value = (input / desc) * item.quant;
                    else value = (input * desc) / item.quant;
                    return Math.Round(value, 3).ToString();
                }
            }
            return null;
        }
    }
}
