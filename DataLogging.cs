using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace AirfcraftBasicFlight_v2
{

    class DataLogging

    {

        public void SaveSumulated(List<DataLog> dataToSave)

        {
            // Use the current time to set the File Name
            DateTime time = DateTime.Now;
            string fileName = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + "_" + time.Hour.ToString() +
                time.Minute.ToString() + time.Second.ToString();
            // File Path
            XmlWriter dataLog = XmlWriter.Create("C:\\WorkSpace\\Programming\\SOV\\AirfcraftBasicFlight_v2\\"+fileName+ ".xml");

            //Writing to File
            dataLog.WriteStartDocument();
            dataLog.WriteStartElement("GeoPoints");

            foreach (var item in dataToSave)

            {
                dataLog.WriteStartElement("GeoLocation");
                dataLog.WriteAttributeString("Latitude", item.Point.Latitude.ToString());
                dataLog.WriteAttributeString("Longitude", item.Point.Longitude.ToString());
                dataLog.WriteAttributeString("Time", item.TimeStamp.ToString());

            }
            dataLog.WriteEndDocument();
            dataLog.Close();

        }

    }

}
