using MagicVilla_CouponAPI.Data;
using MagicVilla_CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", () => {
    return Results.Ok(CuponStore.couponList);
}).WithName("GetCoupons")
    .Produces<IEnumerable<Coupon>>(200);

app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CuponStore.couponList.FirstOrDefault(x=>x.Id == id));
}).WithName("GetCoupon")
    .Produces<Coupon>(200); 

app.MapPost("/api/coupon", ([FromBody] Coupon coupon) =>
{
    if (coupon.Id != 0 || string.IsNullOrEmpty(coupon.Name)) 
    { 
        return Results.BadRequest("Invalid Id or Coupon Name"); 
    }
    if (CuponStore.couponList
        .FirstOrDefault(u=>u.Name.ToLower() == coupon.Name.ToLower()) != null )
    {
        return Results.BadRequest("Coupon Name already exists");
    }
    coupon.Id = CuponStore.couponList
        .OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
    
    CuponStore.couponList.Add(coupon);
    return Results.CreatedAtRoute("GetCoupon",new { id = coupon.Id},coupon);
}).WithName("CreateCoupon")
    .Accepts<Coupon>("application/json")
    .Produces<Coupon>(201)
    .Produces(400);

app.MapPut("/api/coupon", () =>
{

});

app.MapDelete("/api/coupon/{id:int}", (int id) => {
    return "";
});

app.Run();
