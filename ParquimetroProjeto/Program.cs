namespace ParquimetroProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean login = true;
            int menuChoice;
            int menuLevel = 1;

            //Inicializador de zonas usando o construtor
            Zone zone1 = new Zone(1.15, 45, new Random().Next(1) + 10);       //Preço por hora: 1.15 €, Duração máxima: 45 minutos, a capacidade é gerada com o método Random.
            Zone zone2 = new Zone(1, 120, new Random().Next(1) + 10);         //Preço por hora: 1€, Duração máxima: 120 minutos, a capacidade é gerada com o método Random.
			Zone zone3 = new Zone(0.62, 999999, new Random().Next(1) + 10);   //Preço por hora: 0.62€, Duração máxima: 999999 minutos, a capacidade é gerada com o método Random.

			//Inicializador de menu
			MenuHandler menu = new MenuHandler();
            
            //Inicializador de Helper
            HelperClass helperClass = new HelperClass();

            if (helperClass.TimeIsValid()) //Chamada ao método para saber se está dentro do horario de funcionamento.
            {
                menu.DrawMainMenu(); //mostra menu principal
            }
            else
            {
                Console.WriteLine("Fora de horas"); //Não pode aceder ao parking
                login = false;
            }

            while (login == true) //Se a entrada deu certa
            {
				//Menu Principal
				if (menuLevel == 1) 
                {
                    try 
                    {
                        menuChoice = int.Parse(Console.ReadLine()); //Escolha do menu

                        switch (menuChoice)
                        {
                            case 1:
                                menu.DrawAdminMenu(); //Menu Administrador
                                menuLevel = 2;
                                break;
                            case 2:
                                menu.DrawClientMenu(); //Menu Cliente
                                menuLevel = 3;
                                break;
                            case 0:                    //Sair
                                login = false;
                                Console.Clear();
                                Console.WriteLine("Adeus, volte sempre");
                                break;
                        }
                    }

                    catch (FormatException ex) //captar erros
                    {
                        Console.WriteLine("\nErro: " + ex.Message + "\nEscolha uma opção válida do menu");
                    }
                }

                //Menu administrador
                else if (menuLevel == 2)
                {
                    try
                    {
                        menuChoice = int.Parse(Console.ReadLine()); 
                        
                        switch (menuChoice) //Escolher opção do menu
						{
                            case 1:
                                //Chamar método para ver zonas
                                Console.WriteLine("\n");
                                Console.ForegroundColor = ConsoleColor.Red; //Cor das letras
                                Console.WriteLine("Informação da zona 1: ");
                                Console.ResetColor(); //Apagar a cor anterior
                                zone1.GetZoneInfo();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Informação da zona 2: ");
                                Console.ResetColor();
                                zone2.GetZoneInfo();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Informação da zona 3: ");
                                Console.ResetColor();
                                zone3.GetZoneInfo();
                                

                                Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //volta ao menu principal
								break;

                            case 2:
                                //Chamar método para ver total de lucros
                                Console.WriteLine("Lucro da zona 1: " + zone1.TicketIncome() + " EUR");
                                Console.WriteLine("Lucro da zona 2: " + zone2.TicketIncome() + " EUR");
                                Console.WriteLine("Lucro da zona 3: " + zone3.TicketIncome() + " EUR");

                                Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //volta ao menu principal
								break;
                            
                            case 3:
                                //Chamar método para ver histórico
                                Console.ForegroundColor = ConsoleColor.DarkRed; //Cor das letras
                                Console.WriteLine("Histórico ZONA 1");
                                zone1.CheckHistory();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nHistórico ZONA 2");
                                zone2.CheckHistory();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nHistórico ZONA 3");
                                zone3.CheckHistory();
                                Console.ResetColor();//Apagar a cor anterior

                                Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //Volta ao menu principal
								break;

                            case 4: 
								//Chamar método para voltar ao menu principal
								menuLevel = 1;
                                menu.DrawMainMenu(); 
								break;

                            case 0: //Sair
                                login = false;
                                Console.Clear();
                                Console.WriteLine("Obrigada, volte sempre");
                                break;
                        }
                    }

                    catch (FormatException ex) //captar erros
                    {
                        Console.WriteLine("\nErro: " + ex.Message);
                        Console.WriteLine("\nEscolha uma opção válida");
                    }
                }
                //Menu cliente
                else if (menuLevel == 3)
                {
                    try
                    {
                        menuChoice = int.Parse(Console.ReadLine());
                        switch (menuChoice) //Escolher opção do menu
						{
                            case 1:
                                Console.WriteLine("Qual a zona que pretende estacionar: 1, 2 ou 3?");
                                int zoneChoice = int.Parse(Console.ReadLine()); //Escolher zona

								switch (zoneChoice)
                                {
                                    case 1:
                                        zone1.ParkCar(); //Método para estacionar
                                        break;
                                    
                                    case 2:
                                        zone2.ParkCar();
                                        break;
                                   
                                    case 3:
                                        zone3.ParkCar();
                                        break;
                                }

                                Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //Volta ao menu principal
								break;
                            case 2:
								//Método para ver informação das zonas
								Console.ForegroundColor = ConsoleColor.Red; //Cor das letras
								Console.WriteLine("Informação da zona 1: ");
								Console.ResetColor();//Apagar a cor anterior
								zone1.GetZoneInfo();
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Informação da zona 2: ");
								Console.ResetColor();
								zone2.GetZoneInfo();
								Console.ForegroundColor = ConsoleColor.Red; 
								Console.WriteLine("Informação da zona 3: ");
								Console.ResetColor();
								zone3.GetZoneInfo();
								

								Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //Volta ao menu principal
								break;
                            case 3:
                                Console.WriteLine("Qual a zona que está estacionado?"); 
                                int zoneOut = int.Parse(Console.ReadLine()); //Escolher a zona que está estacionado

                                switch (zoneOut)
								{    
                                    //Método para tirar o carro do estacionamento
									case 1:
                                        zone1.OutCar(); 
                                        Console.WriteLine("Obrigada, boa viagem");
                                        break;
                                    case 2:
                                        zone2.OutCar();
                                        Console.WriteLine("Obrigada, boa viagem");
                                        break;
                                    case 3:

                                        zone3.OutCar();
                                        Console.WriteLine("Obrigada, boa viagem");
                                        break;
                                }

                                Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal");
                                Console.ReadLine();
                                menuLevel = 1;
                                menu.DrawMainMenu(); //Volta ao menu principal
								break;
                            
                            case 4:
								//Chamar método para voltar ao menu principal
								menuLevel = 1;
                                menu.DrawMainMenu();
                                break;
                            
                            case 0:
                                login = false;
                                Console.Clear();
                                Console.WriteLine("Obrigada, volte sempre"); //Sair
                                break;
                        }
                    }

                    catch (FormatException ex) //Captar erros
                    {
                        Console.WriteLine("\nErro: " + ex.Message + "\n");
                        Console.WriteLine("Escolha uma opção válida");
                    }
                }
            }
        }
    }
}