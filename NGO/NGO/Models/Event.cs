
namespace NGO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.EventRegistrations = new HashSet<EventRegistration>();
        }
        public enum Categories
        {
            Conference,
            Seminar,
            Presentation,
            Spiritual,
            Social
        }

        public enum Registration
        {
            True,
            False
        }

        [Required]
        [Key]
        public int EventID { get; set; }

        [MaxLength(50, ErrorMessage = "The name can not be longer than 50 characters.")]
        [Required(ErrorMessage = "Please enter a name for this event.")]
        [Display(Name = "Event Name", Prompt = "Enter Event Name", Description = "Event Name")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please enter a brief description for this event.")]
        [MinLength(10, ErrorMessage = "The description needs to be at least 10 characters.")]
        [MaxLength(200, ErrorMessage = "The description can not be longer than 200 characters.")]
        [Display(Name = "Event Description", Prompt = "Enter Event Description", Description = "Event Description")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Please select a category for this event")]
        [Display(Name = "Event Category", Prompt = "Select Event Category", Description = "Event Category")]
        public string EventCategory { get; set; }

        [Required(ErrorMessage = "Please enter a start date for this event.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event Start Date", Prompt = "Enter Start Date", Description = "Event Start Date")]
        public DateTime EventStartDate { get; set; }

        [Required(ErrorMessage = "Please enter an end date for this event.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event End Date", Prompt = "Enter Event End Date", Description = "Event End Date")]
        public DateTime EventEndDate { get; set; }

        [Required(ErrorMessage = "Please enter a starting time for this event.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "Event Start Time", Prompt = "Enter Event Start Time", Description = "Event Start Time")]
        public string EventStartTime { get; set; }

        [Required(ErrorMessage = "Please enter an ending time for this event.")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "Event End Time", Prompt = "Enter Event End Time", Description = "Event End Time")]
        public string EventEndTime { get; set; }

        [Required(ErrorMessage = "Please enter the location for this event.")]
        [MinLength(5, ErrorMessage = "The location needs to be at least 5 characters.")]
        [MaxLength(200, ErrorMessage = "The location can not be longer than 200 characters.")]
        [Display(Name = "Event Location", Prompt = "Enter Event Location", Description = "Event Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Is the registration for this event open or not?")]
        [Display(Name = "Registration Open", Prompt = "Is The Registration Open?", Description = "Registration is open or closed")]
        public string RegOpen { get; set; }

        [Display(Name = "Event Image", Prompt = "Select Event Image", Description = "Event Image")]
        public string EventImage { get; set; }

        [Required(ErrorMessage = "Please enter a ticket price for adults for this event.")]
        [Range(1, 999)]
        [DataType(DataType.Currency)]
        [Display(Name = "Adult Ticket Price", Prompt = "Enter The Price Of An Adult Ticket", Description = "Adult Ticket Price")]
        public decimal AdultTicket { get; set; }

        [Required(ErrorMessage = "Please enter a ticket price for children for this event.")]
        [Range(1, 999)]
        [DataType(DataType.Currency)]
        [Display(Name = "Child Ticket Price", Prompt = "Enter The Price Of A Child Ticket", Description = "Child Ticket Price")]
        public decimal ChildTicket { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}
