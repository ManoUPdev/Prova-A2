using Microsoft.EntityFrameworkCore;
using EmanuelGalindo_MariaFernandaMolinas_BancoDeDados.Data;
using EmanuelGalindo_MariaFernandaMolinas_BancoDeDados.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=EmanuelGalindo_MariaFernandaMolinas.db"));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}


app.MapPost("/funcionario/cadastrar", async (Funcionarios funcionario, AppDbContext db) =>
{
    db.Funcionarios.Add(funcionario);
    await db.SaveChangesAsync();
    return Results.Created($"/funcionario/{funcionario.Id}", funcionario);
});

app.MapGet("/funcionario/listar", async (AppDbContext db) =>
    await db.Funcionarios.ToListAsync());

app.MapPost("/folha/cadastrar", async (Folha folha, AppDbContext db) =>
{
    db.Folhas.Add(folha);
    await db.SaveChangesAsync();
    return Results.Created($"/folha/{folha.Id}", folha);
});

app.MapGet("/folha/listar", async (AppDbContext db) =>
    await db.Folhas.ToListAsync());

app.MapGet("/folha/buscar/{cpf}/{mes}/{ano}", async (string cpf, int mes, int ano, AppDbContext db) =>
{
    var funcionario = await db.Funcionarios.FirstOrDefaultAsync(f => f.Cpf == cpf);
    if (funcionario == null) return Results.NotFound("Funcionário não encontrado.");

    var folhas = await db.Folhas
        .Where(f => f.FuncionarioId == funcionario.Id && f.Mes == mes && f.Ano == ano)
        .ToListAsync();

    return Results.Ok(folhas);
});

app.Run();
