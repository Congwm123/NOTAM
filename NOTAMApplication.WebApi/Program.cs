using NOTAMApplication.Services.Services.Implementations;
using NOTAMApplication.Services.Utils.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddQuartz();
builder.Services.AddQuartzHostedService(opts => opts.WaitForJobsToComplete = true);
builder.Services.ConfigureOptions<JobSetup>();
builder.Services.AddAutoMapper(typeof(MapperProfiles));

builder.Services.AddDbContext<NOTAMDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    //options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection"))
    );
builder.Services.AddScoped<INOTAMServices, NOTAMServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
