using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var strDbConn = builder.Configuration.GetConnectionString("ConexionDb");

//aca ubicamos el contex para conexion a base de datos
builder.Services.AddDbContext<AgendamientoWebDbContext>(options =>
                options.UseSqlServer(strDbConn, ef => ef.MigrationsAssembly(typeof(AgendamientoWebDbContext).Assembly.FullName)), ServiceLifetime.Scoped);

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    // SWAGGER HERRAMIENTA QUE NOS PERMITE VER METODOS POST POT GET Y TODO LO QUE TENGA QUE VER CON LA BASE DE DATOS AQUIN LA APLICACION WEB
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Seguimiento de Empleo SEHE API",
        Description = "Autenticación con JWT y Swagger"
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Preparando al programa para inyectar los servicios
builder.Services.AddTransient<ICamposComplementosPersonasServicios, CamposComplementosPersonasServicios>();
builder.Services.AddTransient<ICitasPorLocacionesServicios, CitasPorLocacionesServicios>();
builder.Services.AddTransient<ICitasPorProgramacionesDeServiciosServicios, CitasPorProgramacionesDeServiciosServicios>();
builder.Services.AddTransient<ICitasServicios, CitasServicios>();
builder.Services.AddTransient<ICiudadesServicios, CiudadesServicios>();
builder.Services.AddTransient<IComplementosPersonasServicios, ComplementosPersonasServicios>();
builder.Services.AddTransient<IContactosEmpresasServicios, ContactosEmpresasServicios>();
builder.Services.AddTransient<IEmpresasServicios, EmpresasServicios>();
builder.Services.AddTransient<IIntegrantesPorCitasServicios, IntegrantesPorCitasServicios>();
builder.Services.AddTransient<IInventariosServicios, InventariosServicios>();

builder.Services.AddTransient<ILocacionesServicios, LocacionesServicios>();
builder.Services.AddTransient<IPaisesServicios, PaisesServicios>();
builder.Services.AddTransient<IPersonasServicios, PersonasServicios>();
builder.Services.AddTransient<IProgramacionesDeServiciosServicios, ProgramacionesDeServiciosServicios>();
builder.Services.AddTransient<IRolesServicios, RolesServicios>();
builder.Services.AddTransient<IRolesUsuariosServicios, RolesUsuariosServicios>();

builder.Services.AddTransient<IServiciosServicios, ServiciosServicios>();
builder.Services.AddTransient<ITiposDocumentosServicios, TiposDocumentosServicios>();
builder.Services.AddTransient<ITiposNegociosServicios, TiposNegociosServicios>();
builder.Services.AddTransient<IUbicacionesServicios, UbicacionesServicios>();
builder.Services.AddTransient<IUsuariosServicios, UsuariosServicios>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seguimiento_HESE v1"));
    app.UseSwaggerUI(c => {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Name of Your API v1");
    });
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
  //  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seguimiento_HESE v1"));
    app.UseSwaggerUI(c => {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Name of Your API v1");
    });

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
