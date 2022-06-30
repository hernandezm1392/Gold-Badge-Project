using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly ClaimsDepartmentRepository _cRepo = new ClaimsDepartmentRepository();
    private readonly ClaimQueue _qRepo = new ClaimQueue();

    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void SeedData()
    {
        ClaimsDepartment queue1 = new ClaimsDepartment(285, ClaimType.Car, "car accident on 465", 400.00, new DateOnly(2018, 04, 25), new DateOnly(2021, 11, 6));
        ClaimsDepartment queue2 = new ClaimsDepartment(286, ClaimType.Home, "kitchen fire", 4000.00, new DateOnly(2018, 04, 11), new DateOnly(2022, 3, 14));
        ClaimsDepartment queue3 = new ClaimsDepartment(287, ClaimType.Theft, "Stolen pancakes", 4.00, new DateOnly(2018, 04, 27), new DateOnly(2022, 2, 11));

        _qRepo.AddClaimToQueue(queue1);
        _qRepo.AddClaimToQueue(queue2);
        _qRepo.AddClaimToQueue(queue3);
    }

    private void RunApplication()
    {
        Console.Clear();
        System.Console.WriteLine("*** KOMODO CLAIMS *** \n" +
        "What would you like to do? \n" +
        "--------------------------- \n" +
        "1. See All Claims \n" +
        "2. Take Care Of Next Claim \n" +
        "3. Enter A New Claim \n" +
        "4. Exit Application");

        string userInput = Console.ReadLine();
        switch(userInput)
        {
            case "1":
                SeeAllClaims();
                break;
            case "2":
                NextClaim();
                break;
            case "3":
                EnterNewClaim();
                break;
            case "4":
                CloseApplication();
                break;
            default:
                System.Console.WriteLine("Invalid Input");
                PressAnyKey();
                break;
        }
    }

    private void SeeAllClaims()
    {
        Console.Clear();

        if (_qRepo.GetClaims().Count > 0)
        {
            Queue<ClaimsDepartment> claim = _qRepo.GetClaims();
            System.Console.WriteLine(
                "Claim ID   Type     Description               Amount      Date Of Accident     Date Of Claim      Is Valid \n ");
            foreach(ClaimsDepartment c in claim)
            {
                DisplayClaim(c);
            }    
        } 
        else
        {
            System.Console.WriteLine("There are no claims to display.");
        }

        PressAnyKey();
    }

    private void NextClaim()
    {
        Console.Clear();
        if(_qRepo.GetClaims().Count > 0)
        {
            ClaimsDepartment nextClaim = _qRepo.ViewNextClaim();
            DisplayClaim(nextClaim);

            System.Console.WriteLine("Would you like to work this claim? y/n");
            string userSelection = Console.ReadLine();
            if(userSelection == "y")
            {
                Console.Clear();
                _qRepo.DiscardClaim();
                System.Console.WriteLine("You have selected this claim and it has been removed from the queue.");
            }
            else
            {
                System.Console.WriteLine("Failed to select this claim.");
            }
        }
        else
        {
            System.Console.WriteLine("No claims in the queue.");
        }

        PressAnyKey();
    }

    private void EnterNewClaim()
    {
        Console.Clear();
        ClaimsDepartment claim = new ClaimsDepartment();

        System.Console.WriteLine("*** NEW CLAIMS *** \n" +
        "------------------------------------ \n" +
        "Enter the Claim ID:");
        claim.ID = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Enter the Claim Type:");
        claim.TypeOfClaim = GetClaimType(claim);

        System.Console.WriteLine("Enter a claim description:");
        claim.Description = Console.ReadLine();

        System.Console.WriteLine("Enter the damage amount: \n");
        Console.Write("$ ");
        claim.ClaimAmount = double.Parse(Console.ReadLine());

        System.Console.WriteLine("Date of Accident(MM/DD/YYYY)");
        claim.DateOfIncident = DateOnly.Parse(Console.ReadLine());

        System.Console.WriteLine("Date of Claim(MM/DD/YYYY)");
        claim.DateOfClaim = DateOnly.Parse(Console.ReadLine());

        bool isSuccessful = _qRepo.AddClaimToQueue(claim);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Claim ID: {claim.ID} has been added to the queue.");
        }
        else
        {
            System.Console.WriteLine("Failed to add claim.");
        }

        PressAnyKey();
    }

    private void DisplayClaim(ClaimsDepartment claim)
    {
        System.Console.WriteLine(
            $"{claim.ID}        {claim.TypeOfClaim}    {claim.Description}          {claim.ClaimAmount}       {claim.DateOfIncident}         {claim.DateOfClaim}       {claim.IsValid} \n"
        );
    }

    private ClaimType GetClaimType(ClaimsDepartment claim)
    {
        System.Console.WriteLine(
            "1. Car \n" +
            "2. Theft \n" +
            "3. Home"
        );

        string userTypePick = Console.ReadLine()
        ;
        switch(userTypePick)
        {
            case "1":
                return ClaimType.Car;
            case "2":
                return ClaimType.Theft;
            case "3":
                return ClaimType.Home;
            default:
                System.Console.WriteLine("Invalid Input. Claim set as Undefined.");
                return ClaimType.Undefined;
        }
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press ANY key to continue...");
        Console.ReadLine();
        RunApplication();
    }

    private void PressAnyKeyTwo()
    {
        System.Console.WriteLine("Press ANY key to exit...");
        Console.ReadLine();
    }


    private void CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Good-bye!");
        PressAnyKeyTwo();
        Environment.Exit(0);
    }
}