using Academia.SemanaIntermedia.SysInventario.WebApi._Common;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario;
using Academia.SemanaIntermedia.SysInventario.WebApi.Domain;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario;
using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
     builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

builder.Services.AddDbContext<SysInventarioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConn"));
});

builder.Services.AddFsAuthService((options) =>
{
    options.Username = builder.Configuration.GetFromENV("Configuration.FsIdentityServer:Username");
    options.Password = builder.Configuration.GetFromENV("Configuration.FsIdentityServer:Password");
});

builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();
builder.Services.AddTransient<CommonService>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<ProductoService>();
builder.Services.AddTransient<InventarioService>();
builder.Services.AddTransient<SucursalService>();
builder.Services.AddTransient<ProductosDomain>();
builder.Services.AddTransient<InventarioDomain>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSwaggerForFsIdentityServer(options =>
{
    options.Title = "Prueba";
    options.Description = "Descripcion";
    options.Version = "v1.0";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithFsIdentityServer();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();
