class Programa {
    static void Main()
    {
        string fichero = "";
        int opcion = 0;

        while (opcion != 6)
        {
            Console.WriteLine("\n--- MENU DE FICHEROS ---");
            Console.WriteLine("1. Crear un nuevo fichero");
            Console.WriteLine("2. Anadir registros");
            Console.WriteLine("3. Eliminar todos los registros");
            Console.WriteLine("4. Eliminar el fichero");
            Console.WriteLine("5. Visualizar los registros");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Introduce un numero valido.");
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1:
                    try
                    {
                        Console.Write("Nombre del fichero: ");
                        fichero = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(fichero))
                        {
                            Console.WriteLine("El nombre no puede estar vacio.");
                        }
                        else if (File.Exists(fichero))
                        {
                            Console.WriteLine("Ya existe un fichero con ese nombre.");
                        }
                        else
                        {
                            using (File.Create(fichero))
                            {
                            }

                            Console.WriteLine("Fichero creado.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al crear el fichero.");
                    }
                    break;

                case 2:
                    try
                    {
                        if (fichero == "" || !File.Exists(fichero))
                        {
                            Console.WriteLine("Primero debes crear un fichero.");
                        }
                        else
                        {
                            Console.Write("Escribe un registro: ");
                            string registro = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(registro))
                            {
                                Console.WriteLine("El registro no puede estar vacio.");
                            }
                            else
                            {
                                File.AppendAllText(fichero, registro + Environment.NewLine);
                                
                                Console.WriteLine("Registro anadido.");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al anadir el registro.");
                    }
                    break;

                case 3:
                    try
                    {
                        if (fichero == "" || !File.Exists(fichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                        }
                        else
                        {
                            File.WriteAllText(fichero, "");
                            Console.WriteLine("Todos los registros han sido eliminados.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al eliminar los registros.");
                    }
                    break;

                case 4:
                    try
                    {
                        if (fichero == "" || !File.Exists(fichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                        }
                        else
                        {
                            File.Delete(fichero);
                            fichero = "";
                            Console.WriteLine("Fichero eliminado.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al eliminar el fichero.");
                    }
                    break;

                case 5:
                    try
                    {
                        if (fichero == "" || !File.Exists(fichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                        }
                        else
                        {
                            string[] registros = File.ReadAllLines(fichero);

                            if (registros.Length == 0)
                            {
                                Console.WriteLine("El fichero esta vacio.");
                            }
                            else
                            {
                                foreach (string registro in registros)
                                {
                                    Console.WriteLine(registro);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al leer el fichero.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta.");
                    break;
            }
        }
    }
}