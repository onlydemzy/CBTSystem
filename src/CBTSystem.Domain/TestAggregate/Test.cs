using CBTSystem.Domain.Common.Models;
using CBTSystem.Domain.TestAggregate.ValueObjects;

namespace CBTSystem.Domain.TestAggregate;
public sealed class Test:AggregateRoot<TestId,Guid>
{
    private readonly List<StudentSubjectGrouping> _studentSubjectGroupings=[];
    public string Title{get; private set;}
    public string Institution{get;private set;}
    public DateTime StartDate{get;private set;}
    public DateTime EndDate{get;private set;}
    public IReadOnlyList<StudentSubjectGrouping> StudentSubjectGroupings=>_studentSubjectGroupings.AsReadOnly();
    private Test(TestId testId,string title,string institution,DateTime startDate,DateTime endDate,List<StudentSubjectGrouping> studentSubjectGroupings):base(testId)
    {
        Title=title;
        Institution=institution;
        StartDate=startDate;
        EndDate=endDate;
        _studentSubjectGroupings=studentSubjectGroupings;
    }
    #pragma  warning disable
    private Test():base(default!)
    {

    }
    #pragma warning restore
    public static Test Create(string title,string institution,DateTime startDate,DateTime endDate, 
        List<StudentSubjectGrouping>? studentSubjectGroupings=null)
        {
            var test=new Test(
                TestId.CreateUnique(),title,
                institution,startDate,
                endDate,
                studentSubjectGroupings??[]
            );
            return test;
        }

    public static StudentSubjectGrouping AddSubjectGrouping(StudentSubjectGrouping studentSubjectGrouping)
    {
        return studentSubjectGrouping;
    }
    
}