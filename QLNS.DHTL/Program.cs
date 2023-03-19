using QLNS.BL;
using QLNS.DL;
using QLNS.Common.entities;
using QLNS.BL.BaseBL;
using QLNS.DL.ContractDL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QLNS.DHTL.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
            .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

// Add services to the container.
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
builder.Services.AddScoped<IEmployeeDL, EmployeeDL>();
builder.Services.AddScoped<IStudentBL, StudentBL>();
builder.Services.AddScoped<IStudentDL, StudentDL>();
builder.Services.AddScoped<IClassificationBL, ClassificationBL>();
builder.Services.AddScoped<IClassificationDL, ClassificationDL>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IDepartmentDL, DepartmentDL>();
builder.Services.AddScoped<IDisciplineBL, DisciplineBL>();
builder.Services.AddScoped<IDisciplineDL, DisciplineDL>(); 
builder.Services.AddScoped<IFacultyBL, FacultyBL>();
builder.Services.AddScoped<IFacultyDL, FacultyDL>();
builder.Services.AddScoped<IPositionBL, PositionBL>();
builder.Services.AddScoped<IPositionDL, PositionDL>();
builder.Services.AddScoped<IRecruitmentBL, RecruitmentBL>();
builder.Services.AddScoped<IRecruitmentDL, RecruitmentDL>();
builder.Services.AddScoped<IEducationProgramBL, EducationProgramBL>();
builder.Services.AddScoped<IEducationProgramDL, EducationProgramDL>();
builder.Services.AddScoped<ISalaryBL, SalaryBL>();
builder.Services.AddScoped<ISalaryDL, SalaryDL>();
builder.Services.AddScoped<IStatusEmployeeBL, StatusEmployeeBL>();
builder.Services.AddScoped<IStatusEmployeeDL, StatusEmployeeDL>();
builder.Services.AddScoped<IStatusStudentBL, StatusStudentBL>();
builder.Services.AddScoped<IStatusStudentDL, StatusStudentDL>();
builder.Services.AddScoped<ITranningCertificationBL, TranningCertificationBL>();
builder.Services.AddScoped<ITranningCertificationDL, TranningCertificationDL>();

builder.Services.AddScoped<IContractBL, ContractBL>();
builder.Services.AddScoped<IContractDL, ContractDL>();
builder.Services.AddScoped<IBonusBL, BonusBL>();
builder.Services.AddScoped<IBonusDL, BonusDL>();
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
AuthorsController.configuration = builder.Configuration;
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});

// cấu hình swagger authorize
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
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

// authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey
       (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        //(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false
    };
});


builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

