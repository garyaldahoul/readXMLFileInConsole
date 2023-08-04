using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etteplant_XMLFile_API.Models
{
    public class TransUnit
    {
        [Key]
        public int Id { get; set; }
        
        public string? Target { get; set; }
    
        public string? Source { get; set; }
    }
}

