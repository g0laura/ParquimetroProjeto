using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquimetroProjeto
{
    internal class Zone
    {
        private double hourRate;              //Preço por hora
        private int duration;                 //Duração maxima permitida
        private int capacity;                 //Capacidade do estacionamento
        private string[] parkingSlots;        //Array com os lugares do estacionamento
        private double saldo;                 //Total de dinheiro introduzido
        private double totalIncome;           //Total de dinheiro cobrado
        private int parkingSpot;              //Lugar do estacionamento, corresponde a posição do array em parkingSlots
        private List<Ticket> lstTickets;      //Lista dos tickets funciona como histórico
        private string licensePlate;          //Matrícula
        private double ticketDuration;        //Duração do ticket
        private double change;                //Troco
        private DateTime entryTime;           //Hora de entrada do carro
        private DateTime timeOut;             //Hora prevista de saída consoante o pagamento
        private DateTime? timeOutTrue = null; //Hora de saída do carro, pode ser null

        //Métodos get e set para cada variável
        public double HourRate { get => hourRate; set => hourRate = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string[] ParkingSlots { get => parkingSlots; set => parkingSlots = value; }
        public double TotalIncome { get => totalIncome; set => totalIncome = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public List<Ticket> LstTickets { get => lstTickets; set => lstTickets = value; }
        public int ParkingSpot { get => parkingSpot; set => parkingSpot = value; }
        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public double TicketDuration { get => ticketDuration; set => ticketDuration = value; }
        public DateTime TimeOut { get => timeOut; set => timeOut = value; }
        public DateTime EntryTime { get => entryTime; set => entryTime = value; }
        public double Change { get => change; set => change = value; }
        public DateTime? TimeOutTrue { get => timeOutTrue; set => timeOutTrue = value; }

        public Zone(double hourRate, int duration, int capacity) //construtor da zona com parametros usados no main
        {
            this.LstTickets = new List<Ticket>();
            this.HourRate = hourRate;
            this.Duration = duration;
            this.Capacity = capacity;
            this.parkingSlots = new string[capacity]; //O tamanho do array dependerá da capacidade do estacionamento que é gerada com o método Random
            this.TotalIncome = totalIncome;
            this.Saldo = saldo;
            this.ParkingSpot = parkingSpot;
            this.LicensePlate = licensePlate;
            this.TicketDuration = ticketDuration;
            this.Change = change;
            this.EntryTime = entryTime;
            this.TimeOut = timeOut;
            this.TimeOutTrue = timeOutTrue;
        }

        public void GetZoneInfo() //Método para imprimir informação das zonas, usado no menu Cliente e Administrador.
        {
            Console.WriteLine("Tarifa da zona: " + hourRate + " EUR/h ");
            Console.WriteLine("Duração de estacionamento: " + duration + " minutos");
            Console.WriteLine("Capacidade: " + capacity + "\n");
        }

        public void ParkCar() //Método para estacionar, usado no menu Cliente
        {
            Boolean login = true; //Controlador 
            double coin = 0;      //moeda
            double[] coinsArray = { 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2 }; // Array moedas válidas

            //Introdução de moedas
            while (login == true)
            {
                Console.WriteLine("\nIntroduza uma das seguintes moedas: 0,01 | 0,02 | 0,05 | 0,1 | 0,2 | 0,5 | 1 | 2 | Prima 0 para parar.");
                 
                if ((double.TryParse(Console.ReadLine(), out coin) && (coinsArray.Contains(coin))))  //Se a moeda é double e está dentro dos valores permitidos do array.
                {
                    saldo = saldo + coin; //contador
                }

                if (coin == 0) //Se a moeda é igual a 0

                {
                    if (saldo > 0)  //E o saldo acumulado for maior que 0
                    {
                        Console.WriteLine("\nIntroduziu um total de " + saldo + " euros");

                        ParkingArray(); //Método para aceder ao Array dos lugares de estacionamento e validação do lugar       

                        ValidLicense(); //Método para verificar a matrícula

                        parkingSlots[parkingSpot] = licensePlate; //Inserir a matrícula no lugar de estacionamento escolhido.

						bool isValidAnswer = false;

						while (!isValidAnswer) //Validar resposta
						{
							Console.WriteLine("\nConfirma a operação? 1 - Sim | 2 - Não");
							string input = Console.ReadLine();

							if (int.TryParse(input, out int answer)) //será aceite apenas se for um inteiro
                            {
								if (answer == 1 || answer == 2) //Só aceita resposta de 1 (sim) ou 2 (não)
								{
									isValidAnswer = true;

									if (answer == 1)  //Continua a operação
									{
										GenerateTicket(); //Método para gerar o ticket

										Ticket newParkingTicket = new Ticket(licensePlate, parkingSpot, totalIncome, ticketDuration, entryTime, timeOut, timeOutTrue); //Inicializador do ticket com os parâmetros

										LstTickets.Add(newParkingTicket); //Adiciona os novos tickets na lista de tickets.

										saldo = 0;     //reinicia o saldo
										login = false; //termina 
									}
									else //Anula a operação 
									{
										Console.WriteLine("Dinheiro devolvido: " + saldo + " EUR."); //Devolver o dinheiro introduzido
										Console.WriteLine("Obrigada, volte sempre");
										saldo = 0; //reinicia o saldo
										parkingSlots[parkingSpot] = null; //anula o lugar escolhido antes de cancelar
										login = false;//termina
									}
								}
								else
								{
									Console.WriteLine("Por favor, introduza 1 ou 2");
								}
							}
							else
							{
								Console.WriteLine("Por favor, introduza 1 ou 2");
							}
						}
					}
                }
                else
                {
                    continue;
                }
            }
        }

        public void GenerateTicket() //Método para gerar tickets onde o tempo é gerado com base no dinheiro introduzido

        {
            double maxMoney = (hourRate * duration) / 60; //Cálculo para o dinheiro máximo permitido 
            ticketDuration = (saldo * 60) / hourRate;     //Cálculo para a duração do ticket em base ao saldo

            entryTime = DateTime.Now; //Hora de entrada do carro
            timeOut = DateTime.Now.AddMinutes(ticketDuration); //Hora prevista de saída onde se adiciona a duração em minutos ao tempo atual.

            DateTime currentTime = DateTime.Now; //Tempo atual
            DateTime saturday = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 14, 0, 0); //Estabelecer a hora maxima para o Sábado
            DateTime weekDay = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 00, 0); //Estabelecer a hora maxima de Segunda a Sexta

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && timeOut > saturday) //Se o dia atual for Sábado e o Calculo da hora de saída for maior que 14 horas.
            {
                if (ticketDuration > duration) //Se a duração do ticket for maior que a duração máxima permitida nessa zona
                {
                    ticketDuration = duration;     //A duração do ticket passa a ter a duração máxima permitida da zona.
                    change = saldo - maxMoney;     //Cálculo de troco 
                    totalIncome = saldo - change;  //Total de dinheiro cobrado
                    timeOut = DateTime.Now.AddMinutes(ticketDuration);  //Actualização do tempo de saída previsto.

                    PrintTicket(); //Método para imprimir o ticket
                }
                else //Se a duração do ticket não for maior que a duração permitida
                {
                    timeOut = saturday; //O tempo de saída previsto passa a ter 14 horas
                    ticketDuration = (int)(timeOut - entryTime).TotalMinutes; //Duração do ticket é igual ao tempo de saída previsto menos o a hora de entrada actual.
                    totalIncome = (ticketDuration * HourRate) / 60; //Total cobrado
                    change = saldo - totalIncome; //Troco

                    PrintTicket();
                }

            }
            else if (timeOut > weekDay) //Se o tempo de saída previsto for maior que 20 horas
            {
                if (ticketDuration > duration) //Se a duração do ticket for maior que a duração máxima permitida
                {
                    ticketDuration = duration; //A duração do ticket passa a ter a duração máxima permitida da zona.
                    change = saldo - maxMoney;  //Cálculo de troco
                    totalIncome = saldo - change; //Total de dinheiro cobrado
                    timeOut = DateTime.Now.AddMinutes(ticketDuration); //Actualização do tempo de saída previsto.

                    PrintTicket();
                }
                else //Se a duração do ticket não for maior que a duração permitida
                {
                    timeOut = weekDay; //O tempo de saída previsto passa a ter 20 horas
                    ticketDuration = (int)(timeOut - entryTime).TotalMinutes;  //Duração do ticket é igual ao tempo de saída previsto menos o a hora de entrada actual.
                    totalIncome = (ticketDuration * HourRate) / 60; //Total de dinheiro cobrado
                    change = saldo - totalIncome;  //Cálculo de troco

                    PrintTicket();
                }
            }
            else if (saldo > maxMoney) //Se o saldo ultrapassa o máximo de dinheiro permitido.
            {

                change = saldo - maxMoney;  //Cálculo de troco
                totalIncome = saldo - change; //Total de dinheiro cobrado
                ticketDuration = duration; //A duração do ticket passa a ter a duração máxima permitida da zona.
                timeOut = DateTime.Now.AddMinutes(ticketDuration); //Actualização do tempo de saída previsto.

                PrintTicket();

            }
            else if (saldo < maxMoney) //Se o saldo for menor que o valor máximo permitido pela zona
            {
                totalIncome = saldo; //Total de dinheiro cobrado

                PrintTicket();
            }
        }

        public void ParkingArray()
        {
			bool isValidInput = false;
			
            Console.WriteLine("\nEsta é a lista de lugares: ");

            //Array para verificação dos lugares
            for (int parkingSpot = 0; parkingSpot < capacity; parkingSpot++)
            {
                if (string.IsNullOrEmpty(parkingSlots[parkingSpot])) //Lugares vazios
                {

                    Console.WriteLine((parkingSpot + 1) + " | Livre"); //Sumamos +1 para que não exista lugar 0.
                }

                else //Lugares ocupados
                {
                    Console.WriteLine((parkingSpot + 1) + " | Ocupado");
                }
            }
			
			while (!isValidInput) //Validação do lugar 
			{
				Console.WriteLine("\nQual é o lugar que quer estacionar?");
				string input = Console.ReadLine();

				if (int.TryParse(input, out int parkingSpotNumber) && parkingSpotNumber > 0 && parkingSpotNumber <= capacity) //Será aceite apenas se for um inteiro e dentro dos limites do array
				{
					parkingSpot = parkingSpotNumber - 1;//A variável parkingSpot assume o valor inserido pelo cliente, -1 porque o valor mostrado anterior é +1 no método ParkingArray
					
                    if (string.IsNullOrEmpty(parkingSlots[parkingSpot])) //Se o lugar está vazio
					{
						isValidInput = true;
					}
					else //Se o lugar está ocupado
					{
						Console.WriteLine("Lugar já ocupado. Por favor escolha outro.");
					}
				}
				else //Senão estiver dentro do array ou se não for um inteiro
				{
					Console.WriteLine("Por favor, introduza um número válido dentro dos limites do estacionamento.");
				}
			}

		}
	

        public int OutCar() //Método para tirar o carro
        {
            Console.WriteLine("Qual é o lugar que está estacionado?");

            parkingSpot = (int.Parse(Console.ReadLine()) - 1); //Seleciona o lugar onde está estacionado

            parkingSlots[parkingSpot] = null; //Passa a ter o valor null na posição selecionada.


            foreach (var ticket in LstTickets) //Para guardar dentro do ticket/histórico
            {
                if (ticket.Spot == parkingSpot) //Se for verdadeiro atualiza a data e hora de saída
                {
                    ticket.OutTimeTrue = DateTime.Now;
                    continue;
                }
            }
            return parkingSpot;
        }

        public void ValidLicense() //Método para introduzir e verificar a matrícula
        {
            Console.WriteLine("\nIntroduza a sua matrícula: ");
            licensePlate = Console.ReadLine();

            while (licensePlate.Length != 6) //Condição de que a matrícula tem de ter 6 caracteres
            {
                Console.WriteLine("Insira uma matrícula válida de 6 caracteres.");
                licensePlate = Console.ReadLine();
            }
        }

        public void PrintTicket() //Método para imprimir o ticket
        {
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine(" ");
            Console.WriteLine("                      TICKET DE");
            Console.WriteLine("                    ESTACIONAMENTO");
            Console.WriteLine("");
            Console.WriteLine($"            Data e hora de entrada: {entryTime}");
            Console.WriteLine($"            Data e hora de saída: {timeOut}");
            Console.WriteLine(" ");
            Console.WriteLine($"            Matrícula: {licensePlate} ");
            Console.WriteLine($"            Duração: {Math.Round(ticketDuration, 2)} minutos"); //Método para arredondar o valor com duas casas decimais
            Console.WriteLine($"            Lugar: {parkingSpot + 1}");
            Console.WriteLine(" ");
            Console.WriteLine($"            Saldo inserido: {saldo} EUR");
            Console.WriteLine($"            Preço: {Math.Round(totalIncome, 2)} EUR");
            Console.WriteLine($"            Troco: {Math.Round(change, 2)} EUR");
            Console.WriteLine(" ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine();
        }
        public double TicketIncome() //Método para contabilizar o lucro
        {
            double totalIncomeAllTickets = 0;

            foreach (Ticket item in LstTickets) //Soma do dinheiro cobrado para cada ticket
            {
                totalIncomeAllTickets += Math.Round(item.TotalIncome, 2);
            }

            return totalIncomeAllTickets; //Retorna o valor total ganho
        }

        public void CheckHistory() //Método para registrar o histórico.
        {
            DateTime now = DateTime.Now;
            int timeExtra = 0; //Variável para ver o tempo excedido
            
            Console.ForegroundColor = ConsoleColor.Red; //Cor das letras
            Console.WriteLine("Lugar |Matrícula  |Data entrada          |Data limite de saída   |Tempo excedido   |Data de saída");
            Console.ResetColor(); //Apagar a cor anterior

            foreach (Ticket item in LstTickets) //Para cada ticket é calculado o tempo excedido em minutos, com base no tempo actual e o tempo de saída previsto.
            {
                if (now > item.OutTime)
                {
                    timeExtra = (int)(now - timeOut).TotalMinutes;
                }
                //Impressão do histórico
                
                Console.WriteLine((item.Spot + 1) + "      " + item.LicensePlate + "      " + item.EntryTime + "    " + item.OutTime + "     " + timeExtra + " minutos         " + item.OutTimeTrue);
                
            }
        }
    }
}