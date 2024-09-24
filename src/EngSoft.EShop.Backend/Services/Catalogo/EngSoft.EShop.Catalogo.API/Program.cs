var builder = WebApplication.CreateBuilder(args);

#region Configura��o Inje��o de Dependencia (DI) para o container.

// adicionando Carter DI
builder.Services.AddCarter();

// Adicionando Mediator DI Configuration
builder.Services.AddMediatR(config => 
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// adicionando o Marter no DI
builder.Services.AddMarten(config => 
{
    config.Connection(builder.Configuration.GetConnectionString("DatabaseMartenPostgres")!);
    
}).UseLightweightSessions();

#endregion // Fim Configura��o Inje��o de Dependencia (DI)

var app = builder.Build();

#region Configura��o do Pipeline.

app.MapCarter();


#endregion // Fim Configura��o do Pipeline 

app.Run();
