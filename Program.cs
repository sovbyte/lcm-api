var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("arnur_sovetkali_gmail_com", (string x, string y) =>
{
    if (!ulong.TryParse(x, out var valX) || !ulong.TryParse(y, out var valY))
    {
        return Results.Text("NaN", "text/plain");
    }

    if (valX == 0 || valY == 0)
    {
        return Results.Text("0", "text/plain");
    }

    var a = valX;
    var b = valY;

    var gcd = Gcd(a, b);
    var lcm = (a / gcd) * b;

    return Results.Text(lcm.ToString(), "text/plain");
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
return;

static ulong Gcd(ulong a, ulong b)
{
    while (b != 0)
    {
        var t = b;
        b = a % b;
        a = t;
    }
    return a;
}