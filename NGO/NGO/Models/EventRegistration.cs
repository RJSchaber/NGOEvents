
namespace NGO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [Serializable]
    public partial class EventRegistration
    {
        [Required][Key]
        public int RegistrationID { get; set; }

        [Required(ErrorMessage = "Please enter a your first name")]
        [Display(Name = "First Name", Prompt = "Enter First Name", Description = "First Name")]
        [MaxLength(50, ErrorMessage = "The name can not be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a your last name")]
        [Display(Name = "Last Name", Prompt = "Enter Last Name", Description = "Last Name")]
        [MaxLength(50, ErrorMessage = "The name can not be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a your email address")]
        [Display(Name = "Email Address", Prompt = "Enter Email Address", Description = "Email Address")]
        [MaxLength(100, ErrorMessage = "The Email Address can not be longer than 100 characters.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter a your phone number")]
        [Display(Name = "Phone Number", Prompt = "Enter Phone Number", Description = "Phone Number")]
        [MaxLength(10, ErrorMessage = "The Phone Number can not be longer than 10 characters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a your address")]
        [Display(Name = "Address", Prompt = "Enter Address", Description = "Address")]
        [MaxLength(200, ErrorMessage = "The Address can not be longer than 200 characters.")]
        public string Address { get; set; }

        [Range(0, 999)]
        [Display(Name = "Adult Tickets", Prompt = "Enter Amount of Adult Tickets", Description = "Adult Tickets")]
        public int AdultTickets { get; set; }

        [Range(0, 999)]
        [Display(Name = "Child Tickets", Prompt = "Enter Amount of Childrens Tickets", Description = "Childrens Tickets")]
        public int ChildTickets { get; set; }

        [Required][ForeignKey("Event")]
        public int EventID { get; set; }

        [NotMapped]
        [DataType(DataType.Currency)]
        [Display(Name = "Adult Ticket Cost", Prompt = "The Cost of Adult Tickets", Description = "Adult Ticket Cost")]
        public decimal AdultCost { get; set; }

        [NotMapped]
        [DataType(DataType.Currency)]
        [Display(Name = "Child Ticket Cost", Prompt = "The Cost of Childrens Tickets", Description = "Child Ticket Cost")]
        public decimal ChildCost { get; set; }

        [NotMapped]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Ticket Cost", Prompt = "The Cost of All Tickets", Description = "Total Ticket Cost")]
        public decimal TotalCost { get; set; }

        public virtual Event Event { get; set; }
    }
}
