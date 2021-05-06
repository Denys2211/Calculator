using System;
using System.Collections.Generic;
using SQLite;

namespace AppData
{
    [Table("History")]
    public class History
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Expression { get; set; }
        public string Result { get; set; }
        public string DateTime { get; set; }
    }
}
