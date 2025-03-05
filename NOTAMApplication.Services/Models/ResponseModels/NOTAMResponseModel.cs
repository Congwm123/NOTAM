namespace NOTAMApplication.Services.Models.ResponseModels;

public class NOTAMResponseModel
{

    [JsonProperty("notamList")]
    public List<NOTAMModel> NotamList { get; set; }
}

public class NOTAMModel
{
    public string FacilityDesignator { get; set; } = string.Empty;
    public string NotamNumber { get; set; } = string.Empty;
    public string FeatureName { get; set; } = string.Empty;
    public string IssueDate { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public string IcaoMessage { get; set; } = string.Empty;
    public string TraditionalMessage { get; set; } = string.Empty;
    public string PlainLanguageMessage { get; set; } = string.Empty;
    public string TraditionalMessageFrom4thWord { get; set; } = string.Empty;
    public string IcaoId { get; set; } = string.Empty;
    public string AccountId { get; set; } = string.Empty;
    public string AirportName { get; set; } = string.Empty;
    public bool Procedure { get; set; }
    public int UserID { get; set; }
    public long TransactionID { get; set; }
    public bool CancelledOrExpired { get; set; }
    public bool DigitalTppLink { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool ContractionsExpandedForPlainLanguage { get; set; }
    public string Keyword { get; set; } = string.Empty;
    public bool Snowtam { get; set; }
    public string Geometry { get; set; } = string.Empty;
    public bool DigitallyTransformed { get; set; }
    public string MessageDisplayed { get; set; } = string.Empty;
    public bool HasHistory { get; set; }
    public bool MoreThan300Chars { get; set; }
    public bool ShowingFullText { get; set; }
    public int LocID { get; set; }
    public bool DefaultIcao { get; set; }
    public long CrossoverTransactionID { get; set; }
    public string CrossoverAccountID { get; set; } = string.Empty;
    public string MapPointer { get; set; } = string.Empty;
    public int RequestID { get; set; }
}

