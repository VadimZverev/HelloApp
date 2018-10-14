namespace HelloApp.Models
{
    public class Geometry
    {
        public int Altitude { get; set; } // Основание
        public int Height { get; set; } // высота

        public double GetSquare() // вычисление площади треугольника
        {
            return Altitude * Height / 2;
        }
    }
}
