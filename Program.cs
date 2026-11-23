using Microsoft.EntityFrameworkCore;
using tarea_semana_4.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(campo => $"El campo {campo} debe ser un número.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((valor, campo) => $"El valor '{valor}' no es válido para {campo}.");
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(campo => $"El campo {campo} es obligatorio.");
});

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("BibliotecaContext")
        ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'BibliotecaContext'.")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
