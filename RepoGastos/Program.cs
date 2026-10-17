namespace RepoGastos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GastoRepositorio repo = new GastoRepositorio();
            string opcion;

            do
            {
                opcion = MostrarMenu();

                switch (opcion)
                {
                    case "1":
                        RegistrarGasto(repo);
                        break;
                    case "2":
                        ListarGastos(repo);
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
            while (opcion != "3");
        }

        private static string MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("||| REPOSITORIO DE GASTOS |||");
            Console.WriteLine("Opcion #1.Registrar gasto");
            Console.WriteLine("Opcion #2.Listar gastos");
            Console.WriteLine("Opcion #3.Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine();
        }

        private static void RegistrarGasto(GastoRepositorio repo)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine().Trim();
            Console.Write("Monto: ");
            bool montoOk = decimal.TryParse(Console.ReadLine(), out decimal monto);
            Console.Write("Categoría: ");
            string categoria = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(descripcion) || !montoOk || monto <= 0 || string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            repo.Insertar(new Gasto
            {
                Descripcion = descripcion,
                Monto = monto,
                Categoria = categoria
            });
        }

        private static void ListarGastos(GastoRepositorio repo)
        {
            List<Gasto> lista = repo.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
                return;
            }

            decimal total = 0;
            foreach (Gasto g in lista)
            {
                Console.WriteLine(g);
                total += g.Monto;
            }

            Console.WriteLine($"TOTAL GASTADO: Q {total:N2}");
        }
    }
}