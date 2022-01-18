using Listy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Listy.Models
{
    public class ListItem
    {
        [Key]
        public int ListItemId { get; set; }

        public int ListyListId { get; set; }

        // Prevent reference loop in data
        [JsonIgnore]
        public ListyList ListyList { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string URL { get; set; }




    }




}
