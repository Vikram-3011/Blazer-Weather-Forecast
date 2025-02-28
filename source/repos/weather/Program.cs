//using BlazorApp.Components;
using BlazorApp.Controllers;
using MudBlazor.Services;
using BlazorApp.Singletons;
using BlazorApp.Services;
using Supabase;
using weather.Components;
//using weather.controllers;

var builder = WebApplication.CreateBuilder(args);

var supabaseUrl = "https://bajutnvhyeqagxzpvqzd.supabase.co";
var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJhanV0bnZoeWVxYWd4enB2cXpkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjkwNjAxOTEsImV4cCI6MjA0NDYzNjE5MX0.PYtqTZ18H2Vbz285ZytBrfDvAdTBlbfnoOAFLfR_N6Q";

var options = new SupabaseOptions { AutoConnectRealtime = true };
var supabaseClient = new Supabase.Client(supabaseUrl, supabaseKey, options);

builder.Services.AddSingleton(supabaseClient);
builder.Services.AddScoped<AuthService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
//builder.Services.AddScoped<DatabaseController>();
//builder.Services.AddScoped<SupabaseController>();
builder.Services.AddSingleton<UserStateManager>();
builder.Services.AddScoped<DatabaseController>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
