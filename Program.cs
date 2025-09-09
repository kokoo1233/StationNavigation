using Microsoft.AspNetCore.HttpOverrides; // <--- 1. 이 줄 추가
using Microsoft.EntityFrameworkCore;
using StationNavigation.Data;
using StationNavigation.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
});

// DbContextFactory와 일반 DbContext 둘 다 등록
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>();
builder.Services.AddScoped<IStationInfoService, StationInfoService>();


var app = builder.Build();

// --- 2. 이 부분 추가 ---
// Nginx 같은 리버스 프록시를 사용한다고 알려주는 설정
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
// --------------------

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection(); // <--- 3. 이 줄을 주석 처리하거나 삭제
app.UseStaticFiles();
app.UseRouting();
app.UseWebSockets();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
