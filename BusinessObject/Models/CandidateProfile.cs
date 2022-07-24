using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.Models
{
    public partial class CandidateProfile
    {
        [BindProperty]
        [Required(ErrorMessage ="Candidate's Id is required")]
        public string CandidateId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Candidate's name is required")]
        [StringLength(100,ErrorMessage ="Full name must be greater than 12 character", MinimumLength =12)]
        public string Fullname { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Candidate's birthday is required")]
        public DateTime? Birthday { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Short Description is required")]
        [StringLength(200, ErrorMessage = "Short Description must be greater than 12 character", MinimumLength = 12)]
        public string ProfileShortDescription { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Profile Url is required")]
        public string ProfileUrl { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Posting id is required")]
        public string PostingId { get; set; }

        public virtual JobPosting Posting { get; set; }
    }
}
