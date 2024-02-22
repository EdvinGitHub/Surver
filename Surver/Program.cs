using Surver;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
BonkData data = new();

app.MapGet("/", data.GetSomething);
app.MapGet("/hello", () => "goodbye");
app.MapGet("/bonk/{number}", data.GetBonk);

app.Urls.Add("http://*:5038");
app.MapPost("/teacher", data.PostBonk);



app.Run();
Bonk bonk = new();
class BonkData 
{
public IResult PostBonk()
{
    Console.WriteLine("lonk");
    return Results.Ok();
}
public IResult GetBonk(int number)
{   
    List<Bonk> bonks = new()
    {
        new Bonk() {Name = "bonk", HitBonks = 3},
        new Bonk() {Name = "lonk", HitBonks = 2}
    };
    // if(number == 1)
    // {
    // return "Bonk!";
    // }
    // string hej ="";
    if (number > 0 || number >= bonks.Count)
    {
        return Results.NotFound();
    }
    return Results.Ok(bonks[number]);
    


}

public string GetSomething()
{
    return "Hello World!";
}

}

