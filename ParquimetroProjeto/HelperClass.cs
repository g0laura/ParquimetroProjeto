using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquimetroProjeto
{
    internal class HelperClass //Classe com métodos auxiliares
    {
        public Boolean TimeIsValid() //Método para verificar o horário de funcionamento, retorna um true ou false
        {
            DateTime currentTime = DateTime.Now; //Variável com o tempo actual

			switch (currentTime.DayOfWeek) //Varia consoante o dia da semana
            {
                case DayOfWeek.Sunday: //Domingo

                    return false; //Não funciona o estacionamento 

                case DayOfWeek.Saturday: //Sábado

                    if (currentTime.Hour >= 9 && currentTime.Hour <= 13) //Funciona entre as 9 e 14 horas.
                    {
                        return true;
                    }
                    else
                    {
                        return false;  //Não funciona o estacionamento 
					}
                default: //Segunda a Sexta
                    if (currentTime.Hour >= 9 && currentTime.Hour <= 20) //Funciona entre as 9 e 20 horas.
					{
                        return true;
                    }
                    else
                    {
                        return false;  //Não funciona o estacionamento 
					}
            }
        }
    }
}
