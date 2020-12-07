using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.MagicButton
{
    public class Worker
    {
        public string Name { set; get; } = "";
        public string Faculty { set; get; } = "";
        public string Сathedra { set; get; } = "";
        public string Position { set; get; } = "";
        public string Salary { set; get; } = "";
        public string Time { set; get; } = "";

        public Worker() { }

        public void Set(int n, string value)
        {
            switch (n)
            {
                case 0:
                    Name = value;
                    break;
                case 1:
                    Faculty = value;
                    break;
                case 2:
                    Сathedra = value;
                    break;
                case 3:
                    Position = value;
                    break;
                case 4:
                    Salary = value;
                    break;
                default:
                    Time = value;
                    break;
            }
        }

        public string Get(int n)
        {
            switch (n)
            {
                case 0:
                    return Name;
                case 1:
                    return Faculty;
                case 2:
                    return Сathedra;
                case 3:
                    return Position;
                case 4:
                    return Salary;
                default:
                    return Time;
            }
        }
    }
}
