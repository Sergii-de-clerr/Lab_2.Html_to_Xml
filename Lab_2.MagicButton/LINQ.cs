using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_2.MagicButton
{
    class LINQ : IStrategy
    {
        public List<Worker> SearchWorker(Worker W, string path)
        {
            List<Worker> ResultSearch = new List<Worker>();
            var xmlTxt = XDocument.Load(@path);
            var result = (from worker in xmlTxt.Descendants("Worker")
                          where
                          ((W.Name == "" || W.Name == worker.Attribute("Name").Value) &&
                          (W.Faculty == ""|| W.Faculty == worker.Attribute("Faculty").Value) &&
                          (W.Сathedra == "" || W.Сathedra == worker.Attribute("Сathedra").Value) &&
                          (W.Position == "" || W.Position == worker.Attribute("Position").Value) &&
                          (W.Salary == "" || W.Salary == worker.Attribute("Salary").Value) &&
                          (W.Time == "" || W.Time == worker.Attribute("Time").Value))
                          select worker).ToList();
            foreach (var item in result)
            {
                Worker wrk = new Worker();
                wrk.Name = item.Attribute("Name").Value;
                wrk.Faculty = item.Attribute("Faculty").Value;
                wrk.Сathedra = item.Attribute("Сathedra").Value;
                wrk.Position = item.Attribute("Position").Value;
                wrk.Salary = item.Attribute("Salary").Value;
                wrk.Time = item.Attribute("Time").Value;
                ResultSearch.Add(wrk);
            }

            return ResultSearch;
        }
    }
}
