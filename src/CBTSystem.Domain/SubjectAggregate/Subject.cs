using CBTSystem.Domain.Common.Models;
using CBTSystem.Domain.SubjectAggregate.ValueObjects;
using CBTSystem.Domain.TestAggregate.ValueObjects;


namespace CBTSystem.Domain.SubjectAggregate;
public sealed class Subject:AggregateRoot<SubjectId,Guid>
{
    public string SubjectCode{get;private set;}
    public string Title{get;private set;}
    public TestId? TestId{get;private set;}

    private Subject(SubjectId subjectId,string subjectCode,string title,TestId? testId):base(subjectId)
    {
        SubjectCode=subjectCode;
        Title=title;
        TestId=testId;
    }

    #pragma warning disable
    private Subject():base(default!){}
    #pragma warning restore
    public static Subject Create(string subjectCode,string title,TestId? testId)
    =>new(SubjectId.CreateUnique(),
    subjectCode,title,testId
    );


    
}