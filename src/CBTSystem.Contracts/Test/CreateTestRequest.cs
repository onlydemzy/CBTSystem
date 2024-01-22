using System.Net;

namespace CBTSystem.Contracts.Test;
public record CreateTestRequest(
    string Title,
    string Institution,
    DateTime StartDate,
    DateTime EndDate,
    
    List<StudentSubjectGrouping> StudentSubjectGroupings
);

public record StudentSubjectGrouping(
    string Title,
    DateTime TestStartTime,
    DateTime TestEndTime,
    string Status,
    int Capacity
);