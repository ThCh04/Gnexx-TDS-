using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Gnexx.Models.Entities
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string MemberName { get; set; }


    }
}


