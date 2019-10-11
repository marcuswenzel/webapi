using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPWEB.API.Resources
{
    public class SaveParticipantResource
    {
        [Required]
        [MaxLength(400)]
        public string Name { get; set; }
    }
}
