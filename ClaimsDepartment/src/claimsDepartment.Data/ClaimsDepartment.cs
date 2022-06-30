using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ClaimsDepartment
{
    public ClaimsDepartment(){}

    public ClaimsDepartment
    (
        int id,
        ClaimType typeOfClaim,
        string description,
        double claimAmount,
        DateOnly dateOfIncident,
        DateOnly dateOfClaim
    )
    {
        ID = id;
        TypeOfClaim = typeOfClaim;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }

    public int ID { get; set; }
    public ClaimType TypeOfClaim { get; set; }
    public string Description { get; set; }
    public double ClaimAmount { get; set; }
    public DateOnly DateOfIncident { get; set; }
    public DateOnly DateOfClaim { get; set; }
    public bool IsValid 
    { 
        get
        {
            int result = DateOfIncident.CompareTo(DateOfClaim);
            string timeResult;
            if(result > 30)
            {
                return false;
            }
            else if (result <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}