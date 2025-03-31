namespace NOTAMApplication.Services.Services.Interfaces;

public interface INOTAMServices
{
    Task<Result> GetNOTAMByFacility(string facility);
}
