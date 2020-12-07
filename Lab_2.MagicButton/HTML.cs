using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.MagicButton
{
    public class HTML
    {
        public string ConvertDataTableToHtml(List<Worker> ResultSearch)
        {
            string htmlString = "";

            StringBuilder htmlBuilder = new StringBuilder();
            if (ResultSearch.Count()==0)
            {
                htmlBuilder.Append("<html>\r\n");
                htmlBuilder.Append("<head>\r\n");
                htmlBuilder.Append("<meta charset = \"utf-8\">\r\n");
                htmlBuilder.Append("<title>");
                htmlBuilder.Append("Результати пошуку");
                htmlBuilder.Append("</title>\r\n");
                htmlBuilder.Append("</head>\r\n");
                htmlBuilder.Append("<body>\r\n");
                htmlBuilder.Append("Таких записів у базі даних не знайдено \r\n");
                htmlBuilder.Append("</body>");
                htmlBuilder.Append("</html>");
                htmlString = htmlBuilder.ToString();
                return htmlString;
            }

            htmlBuilder.Append("<html>\r\n");
            htmlBuilder.Append("<head>\r\n");
            htmlBuilder.Append("<meta charset = \"utf-8\">\r\n");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Результати пошуку");
            htmlBuilder.Append("</title>\r\n");
            htmlBuilder.Append("</head>\r\n");
            htmlBuilder.Append("<body>\r\n");


            htmlBuilder.Append("<table border = \"10\">");
            htmlBuilder.Append("<caption> Результати пошуку </caption >");
            htmlBuilder.Append("<tr align = \"center \">");
            htmlBuilder.Append("<th>  П.І.П  </th>");
            htmlBuilder.Append("<th>  факультет  </th>");
            htmlBuilder.Append("<th>  кафедра  </th>");
            htmlBuilder.Append("<th>  посада  </th>");
            htmlBuilder.Append("<th>  посадовий оклад  </th>");
            htmlBuilder.Append("<th>  час перебування на посаді  </th>");
            htmlBuilder.Append("</tr>");

            foreach (var w in ResultSearch)
            {
                htmlBuilder.Append("<tr align = \"center \">");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Name); htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Faculty); htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Сathedra); htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Position); htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Salary); htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>"); htmlBuilder.Append(w.Time); htmlBuilder.Append(" років"); htmlBuilder.Append("</td>");
                htmlBuilder.Append("</tr>");
            }
            
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            htmlString = htmlBuilder.ToString();

            return htmlString;
        }
    }
}
