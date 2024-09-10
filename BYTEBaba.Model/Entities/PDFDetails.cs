using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;


namespace BYTEBaba.Model.Entities
{
    [Table(name:nameof(PDFDetails))]
    public class PDFDetails
    {
        [Key]       
        public int Id { get; set; }        
        public string? Name { get; set; }       
        public string? Owner { get; set; }
       
    }
}
