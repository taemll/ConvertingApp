using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfApp2
{
    class ExchangeRate
    {
        public string title { get; set; }
        public double description { get; set; }
        public int quant { get; set; }

        public ExchangeRate(string title,double description,int quant)
        {
            this.title = title;
            this.description = description;
            this.quant = quant;
        }
        public ExchangeRate() { }

        public List<ExchangeRate> UseXml()
        {
            List<ExchangeRate> connection = new List<ExchangeRate>();
            string path = "http://www.nationalbank.kz/rss/rates_all.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNodeList mytitle = xmldoc.GetElementsByTagName("title");
            XmlNodeList mydescription = xmldoc.GetElementsByTagName("description");
            XmlNodeList myquant = xmldoc.GetElementsByTagName("quant");
            string invalid = "Official exchange rates of National Bank of Republic Kazakhstan";
            for (int i = 0; i < mytitle.Count; i++)
            {
                ExchangeRate currency = new ExchangeRate();
                if (mydescription[i].InnerText.ToString() != invalid)
                {
                    currency.title = mytitle[i].InnerText.ToString();
                    currency.description = Convert.ToDouble(mydescription[i].InnerText.Replace(".", ","));
                    currency.quant = Convert.ToInt32(myquant[i - 1].InnerText);
                    connection.Add(currency);
                }
                
            }
            return connection;
        }
    }
}
