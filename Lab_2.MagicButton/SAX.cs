using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2.MagicButton
{
    class SAX : IStrategy
    {
        public static Worker WorkerS = new Worker();
        static List<Worker> ResultSearch = new List<Worker>();

        public List<Worker> SearchWorker(Worker W, string path)
        {
            ResultSearch.Clear();
            WorkerS = W;
            Parsing(path);
            return ResultSearch;
        }
        private static void Parsing(string path)
        {
            //int w = 0;
            var xmlTxt = new XmlTextReader(@path);
            while (xmlTxt.Read())
            {
                //w = 0;
                if (xmlTxt.HasAttributes)
                {
                    Worker result = new Worker();
                    while(xmlTxt.MoveToNextAttribute())
                    {
                        if(xmlTxt.Name == "Name")
                        {
                            if(WorkerS.Name != "" && WorkerS.Name !=xmlTxt.Value)
                            {
                                break;
                            }
                            result.Name = xmlTxt.Value;
                        }
                        if (xmlTxt.Name == "Faculty")
                        {
                            if (WorkerS.Faculty != "" && WorkerS.Faculty != xmlTxt.Value)
                            {
                                break;
                            }
                            result.Faculty = xmlTxt.Value;
                        }
                        if (xmlTxt.Name == "Сathedra")
                        {
                            if (WorkerS.Сathedra != "" && WorkerS.Сathedra != xmlTxt.Value)
                            {
                                break;
                            }
                            result.Сathedra = xmlTxt.Value;
                        }
                        if (xmlTxt.Name == "Position")
                        {
                            if (WorkerS.Position != "" && WorkerS.Position != xmlTxt.Value)
                            {
                                break;
                            }
                            result.Position = xmlTxt.Value;
                        }
                        if (xmlTxt.Name == "Salary")
                        {
                            if (WorkerS.Salary != "" && WorkerS.Salary != xmlTxt.Value)
                            {
                                break;
                            }
                            result.Salary = xmlTxt.Value;
                        }
                        if (xmlTxt.Name == "Time")
                        {
                            if (WorkerS.Time != "" && WorkerS.Time != xmlTxt.Value)
                            {
                                break;
                            }
                            result.Time= xmlTxt.Value;
                            ResultSearch.Add(result);

                        }
                    }
                }
                 
            }
        }
    }
}
