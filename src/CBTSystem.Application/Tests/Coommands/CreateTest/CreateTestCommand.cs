using CBTSystem.Domain.TestAggregate;
using ErrorOr;
using MediatR;

namespace CBTSystem.Application.Commands.CreateTest;
public record CreateTestCommand(
    string Title,
    string Institution,
    DateTime StartDate,
    DateTime EndDate,
    List<CreateStudentSubjectGroupingCommand> StudentSubjectGroupings
):IRequest<ErrorOr<Test>>;

public record CreateStudentSubjectGroupingCommand(
    string Title,
    DateTime TestStartTime,
    DateTime TestEndTime,
    string Status,
    int Capacity
);