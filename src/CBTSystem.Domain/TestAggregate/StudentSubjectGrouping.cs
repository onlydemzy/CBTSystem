using System.Linq.Expressions;
using CBTSystem.Domain.Common.Models;
using CBTSystem.Domain.TestAggregate.ValueObjects;

namespace CBTSystem.Domain.TestAggregate;
public sealed class StudentSubjectGrouping:AggregateRoot<StudentSubjectGroupingId, Guid>
{
    
    public string Title{get;private set;}
    public DateTime TestStartTime{get;private set;}
    public DateTime TestEndTime{get;private set;}
    public string Status{get;private set;}
    public int Capacity{get;private set;}
    private StudentSubjectGrouping(StudentSubjectGroupingId studentSubjectGroupingId,string title,
        DateTime testStartDate, DateTime testEndDate, string status,int capacity):base(studentSubjectGroupingId)
    {
        Title=title;
        TestStartTime=testStartDate;
        TestEndTime=testEndDate;
        Status=status;
        Capacity=capacity;
        
    }

    public static StudentSubjectGrouping Create(string title,DateTime testStartDate, DateTime testEndDate, string status,int capacity)
    => new (
        StudentSubjectGroupingId.CreateUnique(),title,
        testStartDate,testEndDate,status,capacity
    );
    
}