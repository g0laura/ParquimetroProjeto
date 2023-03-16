namespace ParquimetroProjeto
{
    internal class Ticket //Classe ticket e suas variáveis
    {
        private string licensePlate;    //Matrícula
        private double totalIncome;     //Total de dinheiro cobrado
        private double ticketDuration;  //Duração do ticket
        private int spot;               //Lugar do estacionamento
        private DateTime entryTime;     //Hora de entrada do carro
		private DateTime outTime;       //Hora prevista de saída consoante o pagamento
        private DateTime? outTimeTrue;  //Hora de saída do carro

        //Get e Set das propriedades do Ticket
        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public double TotalIncome { get => totalIncome; set => totalIncome = value; }
        public double TicketDuration { get => ticketDuration; set => ticketDuration = value; }
        public int Spot { get => spot; set => spot = value; }
        public DateTime EntryTime { get => entryTime; set => entryTime = value; }
		public DateTime OutTime { get => outTime; set => outTime = value; }
        public DateTime? OutTimeTrue { get => outTimeTrue; set => outTimeTrue = value; }

		public Ticket(string licensePlate, int spot, double totalIncome, double ticketDuration, DateTime entryTime, DateTime outTime, DateTime? outTimeTrue) //Construtor do ticket
		{
			this.LicensePlate = licensePlate;
			this.TicketDuration = ticketDuration;
			this.TotalIncome = totalIncome;
			this.Spot = spot;
			this.EntryTime = entryTime;
			this.OutTime = outTime;
			this.OutTimeTrue = outTimeTrue;
		}
	}
}