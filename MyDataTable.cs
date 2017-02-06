using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App3
{
    public class myDataTable
    {
        public myDataTable() 
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }

    }
}
