namespace LeavePayroll.Domain.Employees;

public enum Sex
{
    Male,
    Female
}

public enum MaritalStatus
{
    Single,
    Married,
    Divorced,
    WidowWidower
}

public enum EmploymentType
{
    PermanentLocal,
    FixedTermContract,
    PermanentInternational,
    ContractInternational,
    Probation,
    Other
}

public enum EmployeeStatus
{
    Active,
    Probationary,
    Suspended,
    Terminated,
    Resigned,
    Retired
}

public enum MovementActionType
{
    Promotion,
    Transfer,
    GradeSalaryChange,
    Combined
}

public enum MovementStatus
{
    Draft,
    PendingHR,
    PendingMD,
    Approved,
    Rejected
}

public enum MisconductCategory
{
    AttendancePunctuality,
    Insubordination,
    BreachOfBankPolicy,
    PoorPerformanceNegligence,
    BreachOfConfidentiality,
    AmlKycComplianceBreach,
    FraudDishonestyTheft,
    ViolationOfCodeOfEthics,
    HarassmentMisconduct,
    HealthSafetyViolation,
    Other
}

public enum DisciplinaryActionType
{
    NoActionCaseDismissed,
    VerbalWarning,
    WrittenWarning,
    FinalWrittenWarning,
    Suspension,
    Demotion,
    SummaryDismissal,
    Other
}

public enum MakerCheckerStatus
{
    Pending,
    Approved,
    Rejected
}
