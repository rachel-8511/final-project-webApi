using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Project;
using Repository;
using Service;



        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<MyShop214189656Context>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings"]));


        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
        builder.Services.AddScoped<IRatingService, RatingService>();

        builder.Services.AddControllers();
        builder.Host.UseNLog();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRatingMiddleware();
        app.UseErrorHandlingMiddleware();
        app.MapControllers();

        app.UseStaticFiles();

        app.Run();
