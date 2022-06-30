
public class ClaimsDepartmentRepository
{
    private readonly List<ClaimsDepartment> _claimsDatabase = new List<ClaimsDepartment>();
    int _count = 0;
    public bool AddClaimToDB(ClaimsDepartment claims)
    {
        if(claims != null)
        {
            _count++;
            claims.ID = _count;
            _claimsDatabase.Add(claims);
            return true;
        }
        else
        {
            return false;
        }
    }

    private List<ClaimsDepartment> GetAllClaims()
    {
        return _claimsDatabase;
    }

    
}