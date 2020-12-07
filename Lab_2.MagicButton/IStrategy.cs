using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.MagicButton
{
     public interface IStrategy
{
        List<Worker> SearchWorker(Worker W, string path);
}
 
public class Search
{
    public IStrategy SearchStrategy { get; set; }
 
    public Search(IStrategy _strategy)
    {
            SearchStrategy = _strategy;
    }
 
    public List<Worker> ExecuteSearch(Worker W, string path)
    {
            return  SearchStrategy.SearchWorker(W, path);
    }
}
}
