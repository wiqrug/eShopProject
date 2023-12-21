using Microsoft.AspNetCore.Identity;
using Project2.Models;
using System;
using System.ComponentModel.DataAnnotations; 

public class Candidate : User
{
    //[Required]
    //public Guid CandidateID { get; set; }


    public int CandidateNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [StringLength(100)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [StringLength(50)]
    public string Gender { get; set; } 

    [StringLength(100)]
    public string NativeLanguage { get; set; } 

    public DateTime? BirthDate { get; set; }

    [StringLength(50)]
    public string PhotoIDType { get; set; } 

    [StringLength(50)]
    public string PhotoIDNumber { get; set; } 

    public DateTime? PhotoIDIssueDate { get; set; }


    [StringLength(200)]
    public string Address { get; set; } 

    [StringLength(200)]
    public string AddressLine2 { get; set; } 

    [Required]
    [StringLength(100)]
    public string CountryOfResidence { get; set; }

    [StringLength(100)]
    public string StateOrTerritoryOrProvince { get; set; } 

    [StringLength(100)]
    public string TownOrCity { get; set; } 

    [StringLength(20)]
    public string PostalCode { get; set; } 

    [StringLength(20)]
    public string LandlineNumber { get; set; } 

    [StringLength(20)]
    public string MobileNumber { get; set; }


    public Candidate() : base()
    {

    }
}
