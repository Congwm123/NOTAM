namespace NOTAMApplication.Services.Services.Interfaces;

public interface INOTAMServices
{
    Task<List<NOTAMModel>> GetNOTAMByFacility(string facility);
}
