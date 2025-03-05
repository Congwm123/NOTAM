namespace DscmApplication.Service.Jobs;

public class JobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions opts)
    {
        var fileCleanupJobKey = JobKey.Create(nameof(CollectNOTAMDataJob));

        opts.AddJob<CollectNOTAMDataJob>(jobBuilder => jobBuilder.WithIdentity(fileCleanupJobKey))
            .AddTrigger(trigger => trigger.ForJob(fileCleanupJobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInHours(8).RepeatForever()));
                                          //.WithCronSchedule("0 0 2 * * ?",
                                          //                  cron => cron.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"))));
    }
}