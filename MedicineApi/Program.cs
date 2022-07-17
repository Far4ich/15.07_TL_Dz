using MedicineApi.Repositories;
using MedicineApi.Services;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();

builder.Services.AddScoped<IHospitalRepository>(s =>
    new SqlHospitalRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IDoctorRepository>( s =>
    new SqlDoctorRepository( builder.Configuration.GetValue<string>( "DefaultConnection" ) ) );
builder.Services.AddScoped<IPatientRepository>(s =>
    new SqlPatientRepository(builder.Configuration.GetValue<string>("DefaultConnection")));

builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();
app.MapControllers();

app.Run();