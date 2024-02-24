using Microsoft.AspNetCore.Http.HttpResults;

namespace Calculadora.Models
{
    public class Calculadora

    {
        public double Variavel1 { get; set; }
        public double Variavel2 { get; set; }
        public double Resultado { get; set; }

        public Calculadora() { }
        public Calculadora(double variavel1, double variavel2)
        {
            this.Variavel1 = variavel1;
            this.Variavel2 = variavel2;
        }
        public void soma()
        {
            Resultado = Variavel1 + Variavel2;
        }

        public void sub()
        {
            Resultado = Variavel1 - Variavel2;
        }
        public void div()
        {   
            Resultado = Variavel1 / Variavel2;
        }
        public void mult()
        {
            Resultado = Variavel1 * Variavel2;
        }
    }
}
