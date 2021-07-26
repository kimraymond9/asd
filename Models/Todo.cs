using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSqlDb.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        public Todo()
        {
            this.DateAdded = DateTime.UtcNow;
        }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

    }
}

