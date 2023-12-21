using FA.JustBlog.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//add dbcontext
builder.Services.AddDbContext<JustBlogContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add builder.Services to the container.
builder.Services.AddControllersWithViews();

//Add builder.Services UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

//add user identity
//builder.Services.AddControllersWithViews();
//builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<JustBlogContext>().AddDefaultTokenProviders();
//builder.Services.Configure<IdentityOptions>(opt =>
//{
//    opt.Password.RequiredLength = 6;
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequireDigit = true;
//    opt.Password.RequireLowercase = true;
//    opt.Password.RequireUppercase = false;
//    opt.User.RequireUniqueEmail = true;
//    opt.Lockout.MaxFailedAccessAttempts = 3;
//    opt.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(10);
//});
//builder.Services.AddHttpContextAccessor();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Auth/SignIn";
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSession();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}/{id?}");

app.Run();
