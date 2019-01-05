using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracehelper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sample> samples = new List<Sample>();
            DataTable datatable = new DataTable();
            Console.WriteLine("Enter tace file path");
            string path = Console.ReadLine();
            StreamReader streamreader = new StreamReader(@path);
            char[] delimiter = new char[] { '\t' };
            string[] columnheaders = streamreader.ReadLine().Split(delimiter);
            foreach (string columnheader in columnheaders)
            {
                datatable.Columns.Add(columnheader); 
            }

            while (streamreader.Peek() > 0)
            {
                DataRow datarow = datatable.NewRow();
                datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
                datatable.Rows.Add(datarow);
            }
            
            foreach (DataRow row in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(row) == 0)
                    continue; // skipping headers

                samples.Add(new Sample()
                {
                    Id = Convert.ToInt32(row.ItemArray[0]),
                    NodeName = Convert.ToString(row.ItemArray[1]),
                    NodeType = Convert.ToString(row.ItemArray[2]),
                    RequestStartTime = Convert.ToDateTime(row.ItemArray[3]),
                    RequestEndTime = Convert.ToDateTime(row.ItemArray[4]),
                });
            }
            DisplayStats(samples);
            Console.ReadLine();
        }

        public static void DisplayStats(List<Sample> samples)
        {
            
            double totalTime = 0;
            

            foreach (var item in samples)
            {
                totalTime = totalTime + item.RequestEndTime.Subtract(item.RequestStartTime).TotalMilliseconds;
            }

            Console.WriteLine("RTT :" + totalTime / samples.Count + " ms");
        }
    }

    public class Sample
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public string NodeType { get; set; }
        public System.DateTime RequestStartTime { get; set; }
        public System.DateTime RequestEndTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
