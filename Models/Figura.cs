namespace MiAPI.Models
{
    public abstract class Figura
    {
        public string Tipo { get; set; }
        public abstract double CalcularArea();
        public abstract double CalcularVolumen();
    }

    public class Cubo : Figura
    {
        public double Lado { get; set; }

        public Cubo()
        {
            Tipo = "Cubo";
        }

        public override double CalcularArea()
        {
            return 6 * Math.Pow(Lado, 2);
        }

        public override double CalcularVolumen()
        {
            return Math.Pow(Lado, 3);
        }
    }

    public class Esfera : Figura
    {
        public double Radio { get; set; }

        public Esfera()
        {
            Tipo = "Esfera";
        }

        public override double CalcularArea()
        {
            return 4 * Math.PI * Math.Pow(Radio, 2);
        }

        public override double CalcularVolumen()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radio, 3);
        }
    }

    public class Cilindro : Figura
    {
        public double Radio { get; set; }
        public double Altura { get; set; }

        public Cilindro()
        {
            Tipo = "Cilindro";
        }

        public override double CalcularArea()
        {
            return 2 * Math.PI * Radio * (Radio + Altura);
        }

        public override double CalcularVolumen()
        {
            return Math.PI * Math.Pow(Radio, 2) * Altura;
        }
    }
} 