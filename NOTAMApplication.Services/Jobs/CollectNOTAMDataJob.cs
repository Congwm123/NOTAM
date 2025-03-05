namespace NOTAMApplication.Services.Jobs;

[DisallowConcurrentExecution]
public class CollectNOTAMDataJob : IJob
{
    private readonly ILogger<CollectNOTAMDataJob> _logger;
    private readonly HttpClient _httpClient;
    private readonly NOTAMDbContext _dbContext;
    private readonly IMapper _mapper;

    public CollectNOTAMDataJob(ILogger<CollectNOTAMDataJob> logger, NOTAMDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var currentNOTAMs = _dbContext.NOTAMs.Where(x => x.CollectDate == DateOnly.FromDateTime(DateTime.Now));
            var currentJobs = _dbContext.CrawlJobs.Where(x => x.CreatedAt == DateOnly.FromDateTime(DateTime.Now));
            _dbContext.NOTAMs.RemoveRange(currentNOTAMs);
            _dbContext.CrawlJobs.RemoveRange(currentJobs);

            var job = new CrawlJob
            {
                RunTime = DateTime.Now.ToUniversalTime(),
                JobName = "Crawl",
                Status = "Success",
            };
            await _dbContext.CrawlJobs.AddAsync(job);
            await _dbContext.SaveChangesAsync();
            var nOTAMs = new List<NOTAM>();
            foreach (var icaoCode in Airports.ICAOCodes)
            {
                var url = $"https://notams.aim.faa.gov/notamSearch/search?searchType=0&designatorsForLocation={icaoCode}";
                var requestBody = new StringContent("", Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, requestBody);
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<NOTAMResponseModel>(jsonContent)!;
                    _logger.LogInformation($"Data: {icaoCode} = {jsonContent}");
                    if (result.NotamList.Count > 0)
                    {
                        nOTAMs.AddRange(_mapper.Map<List<NOTAM>>(result.NotamList));
                    }
                }
                else
                {
                    _logger.LogError("Error");
                }
            }
            nOTAMs.ForEach(x => x.JobId = job.JobId);
            await _dbContext.NOTAMs.AddRangeAsync(nOTAMs);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error crawling data: {message}", ex.Message);
        }
    }
}
