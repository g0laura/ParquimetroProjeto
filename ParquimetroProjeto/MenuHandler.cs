using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquimetroProjeto
{
    internal class MenuHandler //Classe menu
    {
        public void DrawMainMenu() //Menu principal
        {
            Console.Clear();
            Console.WriteLine("           +-----------------------------------------------+");
            Console.WriteLine("           |                                               |");
            Console.WriteLine($"                   Data e hora:  {DateTime.Now}           ");  //Data e hora actual
            Console.WriteLine("           |                                               |");
            Console.WriteLine("           |                 Bem-vindo a                   | ");
			Console.WriteLine("           |                                               |");
			Console.WriteLine("           |  ___________________________________________  |");
			Console.WriteLine("           | | R | E | Q | U | A | L | I | F | I | C | A | |");
			Console.WriteLine("           | |___|___|___|___|___|___|___|___|___|___|___| |");
			Console.WriteLine("           |             |   |   |   |   |                 |"); 
			Console.WriteLine("           |             | P | A | R | K |                 |");
			Console.WriteLine("           |             |___|___|___|___|                 |");
			Console.WriteLine("           |                                               |");
			Console.WriteLine("           |                                               |");
			Console.WriteLine("           |       Escolha uma das seguintes opções        |");
            Console.WriteLine("           |           1 - Menu administrador              |");
            Console.WriteLine("           |           2 - Menu cliente                    |");
            Console.WriteLine("           |           0 - Sair                            |");
            Console.WriteLine("           |                                               |");
            Console.WriteLine("           +-----------------------------------------------+");
        }

        public void DrawAdminMenu() //Menu administrador
        {
            Console.Clear();
            Console.WriteLine("Menu Administrador");
            Console.WriteLine(DateTime.Now + "\n"); //Data e hora actual

			Console.WriteLine("Escolha uma das seguintes opções");
            Console.WriteLine("1 - Ver zonas");
            Console.WriteLine("2 - Lucros");
            Console.WriteLine("3 - Histórico");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine("0 - Sair\n");
        }

        public void DrawClientMenu() //Menu Cliente
        {
            Console.Clear();
            Console.WriteLine("Menu Cliente");
            Console.WriteLine(DateTime.Now + "\n"); //Data e hora actual
			Console.WriteLine("Escolha uma das seguintes opções");
            Console.WriteLine("1 - Estacionar");
            Console.WriteLine("2 - Ver zonas");
            Console.WriteLine("3 - Sair do estacionamento");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine("0 - Sair\n");
        }
    }
}
