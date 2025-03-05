namespace NOTAMApplication.Services.Utils.Mapper;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<NOTAMModel, NOTAM>();
        CreateMap<NOTAM, NOTAMModel>();
    }
}
