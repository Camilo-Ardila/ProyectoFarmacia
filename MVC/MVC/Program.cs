using BibliotecaFarmacia.Clases;
using MVC.Services;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // REGISTRAR EL SERVICIO DE INVENTARIO
            builder.Services.AddSingleton<InventarioService>();
            builder.Services.AddScoped<M_CompraService>();
            builder.Services.AddScoped<PersonaService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // CARGA DE DATOS INICIALES

            DateTime vencimientoProximo = DateTime.Now.AddDays(10);

            Farmacia.l_disponibles.Add(new M_capsula("Paracetamol", "Genfar", vencimientoProximo, 300, 100, 500, "gel"));
            Farmacia.l_disponibles.Add(new M_capsula("Ibuprofeno", "MK", vencimientoProximo, 450, 80, 400, "polvo"));
            Farmacia.l_disponibles.Add(new M_capsula("Omeprazol", "La Santé", vencimientoProximo, 600, 50, 20, "gel"));
            Farmacia.l_disponibles.Add(new M_capsula("Amoxicilina", "Siegfried", vencimientoProximo, 550, 120, 250, "polvo"));
            Farmacia.l_disponibles.Add(new M_capsula("Doxiciclina", "Tecnoquímicas", vencimientoProximo, 700, 60, 100, "gel"));

            Farmacia.l_disponibles.Add(new M_pasta("Diclofenaco Gel", "Bayer", vencimientoProximo, 1200, 30, 50));
            Farmacia.l_disponibles.Add(new M_pasta("Ketoprofeno Gel", "Eurofarma", vencimientoProximo, 1400, 25, 75));
            Farmacia.l_disponibles.Add(new M_pasta("Naproxeno Crema", "Abbott", vencimientoProximo, 1100, 40, 60));
            Farmacia.l_disponibles.Add(new M_pasta("Clotrimazol", "Genfar", vencimientoProximo, 900, 35, 20));
            Farmacia.l_disponibles.Add(new M_pasta("Diclofenaco Potásico", "Tecnoquímicas", vencimientoProximo, 1250, 20, 100));

            Farmacia.l_disponibles.Add(new M_liquido("Jarabe para la tos", "MK", vencimientoProximo, 1500, 15, 120, "plastico"));
            Farmacia.l_disponibles.Add(new M_liquido("Antigripal", "La Santé", vencimientoProximo, 1800, 10, 100, "vidrio"));
            Farmacia.l_disponibles.Add(new M_liquido("Loratadina", "Siegfried", vencimientoProximo, 1000, 25, 60, "plastico"));
            Farmacia.l_disponibles.Add(new M_liquido("Ambroxol", "Abbott", vencimientoProximo, 1300, 18, 90, "vidrio"));
            Farmacia.l_disponibles.Add(new M_liquido("Acetaminofén Infantil", "Genfar", vencimientoProximo, 950, 12, 150, "plastico"));


            Console.WriteLine(Farmacia.l_disponibles);
            

            app.Run();
        }
    }
}
