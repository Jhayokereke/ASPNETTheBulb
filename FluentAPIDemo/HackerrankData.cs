using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPIDemo
{
    public class HackerrankData
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public Datum[] data { get; set; }
        public override string ToString()
        {
            return $"Page: {page}, PerPage: {per_page}, Total: {total}, TotalPages: {total_pages}";
        }
    }

    public class Datum
    {
        public int id { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public int submitted { get; set; }
        public DateTime updated_at { get; set; }
        public int submission_count { get; set; }
        public int comment_count { get; set; }
        public long created_at { get; set; }
    }

}
