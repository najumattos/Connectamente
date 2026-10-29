namespace Connectamente.API.Data.Seeds;
public static class DatabaseSeeder
{
    public static void Seed(AppDbContext context)
    {
        PacienteSeed.Seed(context);
        VinculoPsicologoPacienteSeed.Seed(context);
    }

    public static async Task SeedAsync(
        AppDbContext context,
        CancellationToken cancellationToken)
    {
        await PacienteSeed.SeedAsync(
            context, cancellationToken);

        await VinculoPsicologoPacienteSeed.SeedAsync(
            context, cancellationToken);
    }
}