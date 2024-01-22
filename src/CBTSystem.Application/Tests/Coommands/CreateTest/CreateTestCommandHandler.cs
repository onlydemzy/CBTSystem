using CBTSystem.Domain.TestAggregate;
using ErrorOr;
using MediatR;

namespace CBTSystem.Application.Commands.CreateTest;
public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, ErrorOr<Test>>
{
    public async Task<ErrorOr<Test>> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        List<StudentSubjectGrouping> studentSubjectGroupings=[];
        var test=Test.Create(
            request.Title,request.Institution,
            request.StartDate, request.EndDate,
            request.StudentSubjectGroupings
                .ConvertAll(gp=>StudentSubjectGrouping.Create(
                    gp.Title,
                    request.StartDate,
                    request.EndDate, "Created",
                    0
                ))
        );

        return test;
    }
}