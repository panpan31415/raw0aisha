using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.DAL.ReadOnly
{
    public class History
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SearchDate { get; set; }
    }
}