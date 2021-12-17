using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class TaskItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End")]
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
    }
}