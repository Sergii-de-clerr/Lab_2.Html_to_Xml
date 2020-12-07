using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2.MagicButton
{
    class DOM : IStrategy
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
            XmlDocument XmlTxt = new XmlDocument();
            XmlTxt.Load(@path);
            Recurse(XmlTxt.DocumentElement, 0);
        }
        private static void Recurse(XmlNode node,int level)
        {
            Worker result = new Worker();
            if (level == 1)
            {
                int w = 0;
                foreach (XmlAttribute a in node.Attributes)
                {
                    if (a.Name == "Name")
                    {
                        if (WorkerS.Name != "" && WorkerS.Name != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Name = a.Value;
                    }
                    if (a.Name == "Faculty")
                    {
                        if (WorkerS.Faculty != "" && WorkerS.Faculty != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Faculty = a.Value;
                    }
                    if (a.Name == "Сathedra")
                    {
                        if (WorkerS.Сathedra != "" && WorkerS.Сathedra != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Сathedra = a.Value;
                    }
                    if (a.Name == "Position")
                    {
                        if (WorkerS.Position != "" && WorkerS.Position != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Position = a.Value;
                    }
                    if (a.Name == "Salary")
                    {
                        if (WorkerS.Salary != "" && WorkerS.Salary != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Salary = a.Value;
                    }
                    if (a.Name == "Time")
                    {
                        if (WorkerS.Time != "" && WorkerS.Time != a.Value)
                        {
                            w = 1;
                            break;
                        }
                        result.Time = a.Value;
                    }
                }
                if (w == 0)
                {
                    ResultSearch.Add(result);
                }
            }
            foreach (XmlNode n in node.ChildNodes)
            {
                Recurse(n, level + 1);
            }
        }
    }
 }