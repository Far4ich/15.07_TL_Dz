using MedicineApi.Infrastructure.Data;
using MedicineApi.Services;
using Microsoft.EntityFrameworkCore;
using MedicineApi.Infrastructure.Data.HospitalModel;
using MedicineApi.Infrastructure.Data.DoctorModel;
using MedicineApi.Infrastructure.Data.PatientModel;
using MedicineApi.Infrastructure.UoW;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MedicineContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {
        //var message = ex.Message;
    }
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IHospitalRepository, SqlHospitalRepository>();
builder.Services.AddScoped<IHospitalService, HospitalService>();

builder.Services.AddScoped<IDoctorRepository, SqlDoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IPatientRepository, SqlPatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();
app.MapControllers();
app.Run();
app.UseCors(x => x
    .WithOrigins("http://localhost:4200")
    .AllowCredentials()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());