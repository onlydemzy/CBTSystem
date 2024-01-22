using System.Runtime.InteropServices;
using CBTSystem.Domain.Common.Models;
using CBTSystem.Domain.Entities.ValueObjects;

namespace CBTSystem.Entities;

public sealed class User:AggregateRoot<UserId,string>
{
    public string UserName{get;private set;}
    public string FullName{get;private set;}
    public string Email{get;private set;}
    public string Password{get;private set;}
    public string ProgrammeCode{get;private set;}
    public string UserRole{get;private set;}


    private User(UserId userId, string userName,string fullName,string email,string password, 
    string programmeCode, string userRole):base(userId)
    {
        UserName=userName;
        FullName=fullName;
        Email=email;
        Password=password;
        ProgrammeCode=programmeCode;
        UserRole=userRole;
    }
    #pragma warning disable
    private User():base(default!){}//private Test():base(default!)
    #pragma warning restore
    public static User Create(string userId,string userName,string fullName,string email,string password, 
    string programmeCode, string userRole)
    {
        string _userId;
        if(userId is null)
        {
            _userId=Guid.NewGuid().ToString();
        }
        else{
            _userId=userId;
        }
        return new User(UserId.Create(_userId),userName,fullName, email,password, 
        programmeCode, userRole);
    }

    
}