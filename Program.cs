var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<RoviPractic.BL.Auth.IAuthBL, RoviPractic.BL.Auth.AuthBL>();
builder.Services.AddSingleton<RoviPractic.BL.Auth.IEncrypt, RoviPractic.BL.Auth.Encrypt>();
builder.Services.AddScoped<RoviPractic.BL.Auth.ICurrentUser, RoviPractic.BL.Auth.CurrentUser>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<RoviPractic.DAL.IAuthDAL,RoviPractic.DAL.AuthDAL>();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();