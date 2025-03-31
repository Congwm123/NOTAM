namespace NOTAMApplication.Services.Services.Implementations;

public class NOTAMServices : INOTAMServices
{
    private ILogger<NOTAMServices> _logger;
    private readonly NOTAMDbContext _dbContext;
    private readonly IMapper _mapper;
    public NOTAMServices(ILogger<NOTAMServices> logger, NOTAMDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<Result> GetNOTAMByFacility(string facility)
    {
        _logger.LogInformation(nameof(GetNOTAMByFacility));
        var response = new List<NOTAMModel>();
        if (!string.IsNullOrEmpty(facility))
        {
            var nOTAMs = await _dbContext.NOTAMs.Where(x => x.FacilityDesignator.ToLower() == facility.ToLower() && x.CollectDate == DateOnly.FromDateTime(DateTime.Now)).ToListAsync();
            _mapper.Map(nOTAMs, response);
        }
        return Result.Success(response);
    }
}
