using Project2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Certificate
{
 
    [Key]
    [JsonIgnore]
    public Guid CertificateId { get; set; }

    [Required]
    [StringLength(200)] // Adjust the length based on your requirements
    [DistinctValues(ErrorMessage = "Values must be distinct")]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive integer")]
    public int Price { get; set; }

    //Need to replace a default image
    public string ImageSrc { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    //Navigation Property
    public List<Exam> Exams { get; set; }
    public ICollection<CandidateCertificates> CandidateCertificates { get; set; }

    // Constructor
    public Certificate()
    {
        // Initialize the CertificateID with a new GUID
        CertificateId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

}
