using System.Text;
using biblotecaCartelera;
using biblotecaConfiteria;
using biblotecaSalas;
using biblotecaTaquilla;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------BIENVENIDOS--------------------------");
            Console.WriteLine("Esta es una primera version de un sitema de Gestion para un cinema. A continuacion encontrar un menu en el cual prodra"
            + "\nrealizar las acciones que desee siguiendo las intricciones");
            int op = 0;
            BulletinBoard bulletinboard = new BulletinBoard();
            ClientQueue clientQueue = new ClientQueue();
            RegPurchase regPurchase = new RegPurchase();
            AdminRoom rooms = new AdminRoom();
            ProductsList productsList = new ProductsList();
            //CREACION DE LAS SALAS 
            Room room1 = new Room();
            Room room2 = new Room();
            Room room3 = new Room();
            Room room4 = new Room();
            Room room5 = new Room();    
            Room room6 = new Room();
            Room room7 = new Room();
            rooms.addRoom(room1);
            rooms.addRoom(room2);
            rooms.addRoom(room3);
            rooms.addRoom(room4);
            rooms.addRoom(room5);
            rooms.addRoom(room6);
            rooms.addRoom(room7);
            //Creaccion de productos
            Product product1 = new Product(1, "GASEOSA",5000);
            Product product2 = new Product(2, "PALOMITAS CON DULCE",7000);
            Product product3 = new Product(3, "PERRO CALIENTE",12000);
            Product product4 = new Product(4, "CHOCOLATINA JUMBO",5000);
            Product product5 = new Product(5, "COMBO: GASEOSA Y DOS PALOMITAS",16000);
            productsList.addProduct(product1);
            productsList.addProduct(product2);
            productsList.addProduct(product3);
            productsList.addProduct(product4);
            productsList.addProduct(product5);
            bool verification = true;
            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Escoja la opcion que quiere realizar:");
                        Console.WriteLine("1. Agregar pelicula a la cartelera \n2. Ingresar cliente a la fila\n3. Atender cliente en taquilla y reservar asiento\n"
                        + "4. Registrar compra en confiteria \n5. Mostrar historial de compras \n6. Mostrar estado de  las salas\n7. Eliminar pelicula\n8. Salir");
                        Console.WriteLine(bulletinboard.toString() + " kk");

                        op = int.Parse(Console.ReadLine());
                        if (op >= 1 && op <= 8)
                        {
                            verification = true;
                            switch (op)
                            {
                                case 1:
                                    Console.WriteLine("BIENVENIDO A LA OPCION DE: Agregar pelicula a la cartelera");
                                    Console.WriteLine("¿Cual es el nombre de la pelicula a agregar?");
                                    string namemovie = Console.ReadLine().ToUpper();
                                    Console.WriteLine("¿Cual es la categoria de la pelicula?");
                                    string classification = Console.ReadLine();
                                    Console.WriteLine("¿Cual es la duracion de la pelicula?(en minutos)");
                                    int timemovie = int.Parse(Console.ReadLine());
                                    Console.WriteLine("¿Cual es el genero de la pelicula?");
                                    string gender = Console.ReadLine();
                                    Console.WriteLine("¿Cual es la hora de funcion? (Con el siguiente formato #,##)");
                                    double hourmovie = double.Parse(Console.ReadLine());
                                    Movie movie = new Movie(namemovie, gender, timemovie, classification, hourmovie);
                                    bulletinboard.addMovie(movie);
                                    if (rooms.toStringnotbusy != null)
                                    {
                                        int numberRoom = 0;
                                        do
                                        {
                                            Console.WriteLine("¿En que salas se va a trasmitir esa pelicula?(Ingrese el Numero de sala)");
                                            Console.WriteLine(rooms.toStringnotbusy());
                                            Console.WriteLine("8. SALIR.");
                                            numberRoom = int.Parse(Console.ReadLine());
                                            if (rooms.verificateMovieinroom(numberRoom))
                                            {
                                                rooms.setMovieRoom(movie, numberRoom);

                                            }
                                            else
                                            {
                                                if (numberRoom != 8)
                                                {
                                                    Console.WriteLine("ESA SALA YA TIENE UNA PELICULA ASIGNADA O NO ES UN NUMERO CORRECTO DE SALA");
                                                }
                                            }
                                        } while (numberRoom != 8);

                                    }
                                    else
                                    {
                                        Console.WriteLine("TODAS LAS SALAS ESTAN OCUPADAS, SI QUIERE ADICIONAR UNA NUEVA PELICULA ELIMINE UNA PELICULA YA EXISTENTE PARA DESOCUPAR UNA SALA");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        if (bulletinboard.movieArray.Count != 0)
                                        {
                                            Console.WriteLine("BIENVENIDO A LA OPCION DE: Ingresar cliente a la fila");
                                            Console.WriteLine("¿Cual es el ID del cliente?");
                                            int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("¿Cual es el nombre del cliente?");
                                            string nameclient = Console.ReadLine();
                                            Console.WriteLine("¿Cual es la edad del cliente?");
                                            int age = int.Parse(Console.ReadLine());
                                            Console.WriteLine("¿Cual es las sigientes peliculas va a ver? (escriba el nombre de la pelicula como aparece ahi) ");
                                            Console.WriteLine(bulletinboard.toString());
                                            string clientmovie = Console.ReadLine().ToUpper();
                                            Movie movieclient = bulletinboard.getMoviebyName(clientmovie);
                                            Console.WriteLine("¿En que sala quiere ver la pelicula seleccionada? (Escoja el Numero de sala)");
                                            Console.WriteLine(rooms.getRoomfree(movieclient));
                                            int clientroom = int.Parse(Console.ReadLine());
                                            Room clientRoom = rooms.getRoombyNumberroom(clientroom);
                                            Client client = new Client(id, nameclient, age, clientRoom);
                                            clientQueue.enqueueClient(client);
                                            break;
                                        }
                                        else
                                        {
                                            throw new MyExection("No hay peliculas en la cartelera, por favor agregue una pelicula primero");
                                        }

                                    }
                                    catch (MyExection e)
                                    {
                                        Console.WriteLine("Error: " + e.Message);
                                        break;
                                    }
                                case 3:
                                    try
                                    {
                                        if (clientQueue.clientsqueue.Count != 0)
                                        {
                                            Console.WriteLine("BIENVENIDO A LA OPCION DE: Atender cliente en taquilla y reservar asiento");
                                            Client clientatent = clientQueue.clientsqueue.Peek();
                                            Console.WriteLine(clientatent.toString());
                                            Room clientroomate = clientatent.room;
                                            Console.WriteLine("Ingrese en que haciento quiere sentarse (indique el numero columna y luego el de fila)");
                                            Console.WriteLine(clientroomate.showSeats());
                                            Console.WriteLine("Numero de fila");
                                            int m = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Numero de columna");
                                            int n = int.Parse(Console.ReadLine());
                                            bool var = clientatent.room.reserveSeat(n, m);
                                            if (var)
                                            {
                                                Console.WriteLine("SE RESERVO ASIENTO DE MANERA EXITOSA");
                                                Console.WriteLine("FACTURA");
                                                Console.WriteLine("--------------------------------------");
                                                Console.WriteLine(clientatent.toString() + $"\n {clientroomate.toString()}\t En el asiento: {m},{n} ");
                                                clientQueue.removeClient();
                                            }
                                            else
                                            {
                                                Console.WriteLine("SE RESERVO UN HACIENTO INEXSISTE O OCUPADO");
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            throw new MyExection("No hay clientes en la fila, por favor ingrese un cliente primero");
                                        }
                                    }
                                    catch (MyExection e)
                                    {
                                        Console.WriteLine("Error: " + e.Message);
                                        break;
                                    }
                                case 4:
                                    try
                                    {
                                        if (clientQueue.clientsqueue.Count != 0)
                                        {
                                            Console.WriteLine("BIENVENIDO A LA OPCION DE: Registrar compra en confiteria");
                                            Console.WriteLine("¿Cual de los clientes va a realizar la compra?(escriba el ID)");
                                            Console.WriteLine(clientQueue.toString());
                                            int idclientproduc = int.Parse(Console.ReadLine());
                                            int oproduct = 0;
                                            ProductsList productsbuy = new ProductsList();
                                            do
                                            {
                                                Console.WriteLine("Escoja el id del producto que quiere, si quiere finalizar su compra escoja la opcion 6:");
                                                Console.WriteLine(productsList.showProducts());
                                                Console.WriteLine("6. Salir");
                                                oproduct = int.Parse(Console.ReadLine());
                                                if (oproduct == 6) break;
                                                Product product = productsList.searchProductById(oproduct);
                                                productsbuy.addProduct(product);
                                            } while (oproduct != 6);
                                            int total = productsbuy.calculateTotal(productsbuy);
                                            Purchase purchase = new Purchase(idclientproduc, productsbuy, total);
                                            Console.WriteLine("FACTURA\n_____________________________________________________________");
                                            Console.WriteLine(purchase.toString());
                                            regPurchase.pushPruchase(purchase);
                                            break;
                                        }
                                        else
                                        {
                                            throw new MyExection("No hay clientes en la fila, por favor ingrese un cliente primero");
                                        }
                                    }
                                    catch (MyExection e)
                                    {
                                        Console.WriteLine("Error: " + e.Message);
                                        break;
                                    }
                                case 5:
                                    Console.WriteLine("BIENVENIDO A LA OPCION DE:  Mostrar historial de compras");
                                    if (regPurchase.purchases.Count != 0)
                                    {
                                        Console.WriteLine(regPurchase.toString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("No hay compras registradas");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("BIENVENIDO A LA OPCION DE:  Mostrar estado de  las salas");
                                    Console.WriteLine(rooms.showCapacityofRooms());
                                    break;
                                case 7:
                                    try
                                    {
                                        if (bulletinboard.movieArray.Count != 0)
                                        {
                                            Console.WriteLine("BIENVENIDO A LA OPCION DE: Eliminar pelicula");
                                            Console.WriteLine("Escoja la pelicula que va a eliminar escribiendo su nombre:");
                                            Console.WriteLine(bulletinboard.toString());
                                            string namemoviedelete = Console.ReadLine().ToUpper();
                                            rooms.removeMovie(namemoviedelete);
                                            bulletinboard.deleteMovie(namemoviedelete);
                                            break;
                                        }
                                        else
                                        {
                                            throw new MyExection("No hay peliculas en la cartelera, por favor agregue una pelicula primero");
                                        }
                                    }
                                    catch (MyExection e)
                                    {
                                        Console.WriteLine("Error: " + e.Message);
                                        break;
                                    }

                                case 8: break;
                            }
                        }
                        else
                        {
                            verification = false;
                            StringBuilder txt = new StringBuilder();
                            txt.Append("La opcion ");
                            txt.Append(op);
                            txt.Append(" NO es valida.");
                            throw new MyExection(txt.ToString());
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error: EL FORMATO QUE SE INGRESO NO ES VALIDO." );
                        Console.WriteLine("Por favor ingrese un numero valido");
                    }
                    catch (MyExection e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        Console.WriteLine("Por favor ingrese un numero valido");
                    }
                    finally
                    {
                        Console.WriteLine("Fin de la transaccion");
                    }
                } while (!verification);
                
            } while (op != 8);
        }
    }
}
