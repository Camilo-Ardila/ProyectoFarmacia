using BibliotecaFarmacia.Clases;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            // Creación de los objetos ficticios de tipo Medicamento para poblar la lista Farmacia.l_disponibles

            Farmacia.l_disponibles.Add(new M_capsula("Paracetamol", "Genfar", new DateTime(2026, 5, 1), 300, 100, 500, "gel"));
            Farmacia.l_disponibles.Add(new M_capsula("Ibuprofeno", "MK", new DateTime(2025, 12, 15), 450, 80, 400, "polvo"));
            Farmacia.l_disponibles.Add(new M_capsula("Omeprazol", "La Santé", new DateTime(2027, 3, 10), 600, 50, 20, "gel"));
            Farmacia.l_disponibles.Add(new M_capsula("Amoxicilina", "Siegfried", new DateTime(2026, 8, 20), 550, 120, 250, "polvo"));
            Farmacia.l_disponibles.Add(new M_capsula("Doxiciclina", "Tecnoquímicas", new DateTime(2025, 10, 5), 700, 60, 100, "gel"));

            Farmacia.l_disponibles.Add(new M_pasta("Diclofenaco Gel", "Bayer", new DateTime(2026, 4, 15), 1200, 30, 50));
            Farmacia.l_disponibles.Add(new M_pasta("Ketoprofeno Gel", "Eurofarma", new DateTime(2027, 7, 30), 1400, 25, 75));
            Farmacia.l_disponibles.Add(new M_pasta("Naproxeno Crema", "Abbott", new DateTime(2026, 11, 1), 1100, 40, 60));
            Farmacia.l_disponibles.Add(new M_pasta("Clotrimazol", "Genfar", new DateTime(2025, 9, 25), 900, 35, 20));
            Farmacia.l_disponibles.Add(new M_pasta("Diclofenaco Potásico", "Tecnoquímicas", new DateTime(2026, 12, 10), 1250, 20, 100));

            Farmacia.l_disponibles.Add(new M_liquido("Jarabe para la tos", "MK", new DateTime(2026, 2, 18), 1500, 15, 120, "plástico"));
            Farmacia.l_disponibles.Add(new M_liquido("Antigripal", "La Santé", new DateTime(2025, 6, 9), 1800, 10, 100, "vidrio"));
            Farmacia.l_disponibles.Add(new M_liquido("Loratadina", "Siegfried", new DateTime(2026, 1, 20), 1000, 25, 60, "plástico"));
            Farmacia.l_disponibles.Add(new M_liquido("Ambroxol", "Abbott", new DateTime(2027, 3, 5), 1300, 18, 90, "vidrio"));
            Farmacia.l_disponibles.Add(new M_liquido("Acetaminofén Infantil", "Genfar", new DateTime(2025, 11, 14), 950, 12, 150, "plástico"));

            Console.WriteLine(Farmacia.l_disponibles);

        }
    }
}
