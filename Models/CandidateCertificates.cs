using Project2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CandidateCertificates
{

    [Key]
    public Guid RecordId { get; set; }

    [Required]
    [ForeignKey("Candidate")]
    public Guid CandidateId { get; set; }

    [Required]
    [ForeignKey("Certificate")]
    public Guid CertificateId { get; set; }
    private int? _mark=0;
    public int? Mark
    {
        get
        {
            return this._mark;
        }
        set
        {
            this._mark = value;
            CompletedAt = DateTime.Now;
        }
    } 

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; private set; }

    // Navigation properties
    public Candidate Candidate { get; set; }
    public Certificate Certificate { get; set; }




    public CandidateCertificates()
    {
        RecordId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }


}
