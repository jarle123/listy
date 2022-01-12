using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Listy.Models
{
    public class ListyList
    {

        [Key]
        public int ListyListId { get; set; }
        public string Title { get; set; }

        public List<ListItem> ListItems { get; set; }



    }
}
