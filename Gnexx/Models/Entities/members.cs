using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Gnexx.Models.Entities
{
    public class members
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }


    }
}


