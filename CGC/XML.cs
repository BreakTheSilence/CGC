using System;
using System.Text;
using System.Xml;
using System.Drawing;
using System.IO;

namespace CGC
{
    static class Config
    {
        static XmlTextWriter textWritter;
        static string currentDirectory;
        static string configFilePath;
        static XmlDocument document;
        static XmlNode element;
        static XmlNode subElement;
        static string lastOpenedFile;

        static Config()
        {
            currentDirectory = Environment.CurrentDirectory;
            configFilePath = currentDirectory + "//config.ini";
        }

        public static bool SaveToConfigurationFile()
        {
            File.Delete(configFilePath);
            try
            {
                CreateConfigurationFile();
                OpenConfigurationFile(); 
                AddMassPercent();
                AddTotalMass();
                AddColors();
                AddPointRadius();
                document.Save(configFilePath);
            }
            catch (Exception) { return false; }
            return true;
        }
        
        private static void AddPointRadius()
        {
            element = document.CreateElement("PointSize");
            document.DocumentElement.AppendChild(element);
            AddElement("segment0", Convert.ToString(ProgramData.GetPointRadius()));
        }

        private static void AddColors()
        {
            element = document.CreateElement("PointsColor");
            document.DocumentElement.AppendChild(element);
            Color[] colorArray = ProgramData.GetRefPointColors();
            for (int i = 0; i < colorArray.Length; i++)
                AddElement("segment" + Convert.ToString(i), Convert.ToString(colorArray[i].ToArgb()));
        }

        private static void AddTotalMass()
        {
            element = document.CreateElement("TotalMass");
            document.DocumentElement.AppendChild(element);
            AddElement("segment0", Convert.ToString(ProgramData.GetTotalMass()));
        }

        private static void AddMassPercent()
        {
            element = document.CreateElement("MassPercent");
            document.DocumentElement.AppendChild(element);
            decimal[] massPrecent = ProgramData.GetRefSegmentsMassPercent();
            for (int i = 0; i < massPrecent.Length; i++)
                AddElement("segment" + Convert.ToString(i), Convert.ToString(massPrecent[i]));
        }

        private static void AddElement(string nodeName, string innerText)
        {
            subElement = document.CreateElement(nodeName);
            subElement.InnerText = Convert.ToString(innerText);
            element.AppendChild(subElement);
        }

        private static void CreateConfigurationFile()
        {
            textWritter = new XmlTextWriter(configFilePath, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("Settings");
            textWritter.WriteEndElement();
            textWritter.Close();
        }

        private static void OpenConfigurationFile()
        {
            document = new XmlDocument();
            document.Load(configFilePath);
        }

        public static bool LoadFromConfigurationFile()
        {
            decimal summ = 0;
            try
            {
                document = new XmlDocument();
                document.Load(configFilePath);
                element = document.GetElementsByTagName("Settings")[0];
                foreach (XmlElement subElement in element)
                {
                    switch (subElement.Name)
                    {
                        case "MassPercent":
                            decimal[] readMassPrecent = ProgramData.GetRefSegmentsMassPercent();  
                            int i = 0;
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                readMassPrecent[i] = Convert.ToDecimal(subElementTwo.InnerText);
                                summ += readMassPrecent[i];
                                i++;
                            }
                            break;
                        case "TotalMass":
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                ProgramData.SetTotalMass(Convert.ToDecimal(subElementTwo.InnerText));
                            }
                            break;
                        case "PointsColor":
                            Color[] readArray = ProgramData.GetRefSegmetsColorArray();
                            i = 0; 
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                readArray[i] = Color.FromArgb(Convert.ToInt32(subElementTwo.InnerText));
                                i++;
                            }
                            break;
                        case "PointSize":
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                ProgramData.SetPointRadius(Convert.ToInt32(subElementTwo.InnerText));
                            }
                            break;
                    }
                }
                document.Save(configFilePath);
            }
            catch (Exception) { return false; }
            if (summ != 100)
                return false;
            return true;
        }

        private static void CreateSaveFile(string savePath)
        {
            textWritter = new XmlTextWriter(savePath, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("Settings");
            textWritter.WriteEndElement();
            textWritter.Close();
        }

        private static void OpenSavingFile(string savePath)
        {
            document = new XmlDocument();
            document.Load(savePath);
        }

        private static void AddPointsCoordinates()
        {
            element = document.CreateElement("PointsCoordinates");
            document.DocumentElement.AppendChild(element);
            Point[] coodrinates = ProgramData.GetActiveLayerPointsCoordinates();
            for (int i = 0; i < coodrinates.Length - 1; i++)
            {
                AddElement("PointX" + Convert.ToString(i), Convert.ToString(coodrinates[i].X));
                AddElement("PointY" + Convert.ToString(i), Convert.ToString(coodrinates[i].Y));
            }
        }

        public static bool SaveFile(string savePath = "cur")
        {
            try
            {
                if (savePath == "cur")
                {
                    savePath = lastOpenedFile;
                }
                else
                    lastOpenedFile = savePath;                
                CreateSaveFile(savePath);
                OpenSavingFile(savePath);
                AddMassPercent();
                AddTotalMass();
                AddColors();
                AddPointRadius();
                AddPointsCoordinates();
                document.Save(savePath);
            }
            catch (Exception) { return false; }
            return true;         
        }

        public static bool OpenSavedFile(string openPath)
        {
            decimal summ = 0;
            lastOpenedFile = openPath;
            try
            {
                document = new XmlDocument();
                document.Load(openPath);
                element = document.GetElementsByTagName("Settings")[0];
                foreach (XmlElement subElement in element)
                {
                    switch (subElement.Name)
                    {
                        case "MassPercent":
                            decimal[] readMassPrecent = ProgramData.GetRefSegmentsMassPercent();
                            int i = 0;
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                readMassPrecent[i] = Convert.ToDecimal(subElementTwo.InnerText);
                                summ += readMassPrecent[i];
                                i++;
                            }
                            break;
                        case "TotalMass":
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                ProgramData.SetTotalMass(Convert.ToDecimal(subElementTwo.InnerText));
                            }
                            break;
                        case "PointsColor":
                            Color[] readArray = ProgramData.GetRefSegmetsColorArray();
                            i = 0;
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                readArray[i] = Color.FromArgb(Convert.ToInt32(subElementTwo.InnerText));
                                i++;
                            }
                            break;
                        case "PointSize":
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                ProgramData.SetPointRadius(Convert.ToInt32(subElementTwo.InnerText));
                            }
                            break;
                        case "PointsCoordinates":
                            i = 0;
                            int[] readPointArray = new int[40];
                            foreach (XmlElement subElementTwo in subElement)
                            {
                                readPointArray[i] = Convert.ToInt32(subElementTwo.InnerText);
                                i++;
                            }
                            i = 0;
                            for (int j = 0; j < 40; j += 2)
                            {
                                ProgramData.SetPoint(new Point(readPointArray[j], readPointArray[j + 1]), i);
                                i++;
                            }
                            break;
                    }
                }
                document.Save(configFilePath);
            }
            catch (Exception) { return false; }
            if (summ != 100)
                return false;
            return true; 
        }
    }
}