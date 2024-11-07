using System;

public class Alumno
{
    public string NombreAlumno { get; set; }
    public string NumeroCuenta { get; set; }
    public string Email { get; set; }
}

public interface IAsignatura
{
    double CalcularNotaFinal();
    double CalcularNotaFinal(int nota1, int nota2, int nota3);
    string MensajeNotaFinal(double notaFinal);
    void Imprimir();
}

public class Asignatura : Alumno, IAsignatura
{
    public int N1 { get; set; }
    public int N2 { get; set; }
    public int N3 { get; set; }
    public string NombreAsignatura { get; set; }
    public string Horario { get; set; }
    public string NombreDocente { get; set; }

    public double CalcularNotaFinal()
    {
        return N1 + N2 + N3;
    }

    public double CalcularNotaFinal(int nota1, int nota2, int nota3)
    {
        return nota1 + nota2 + nota3;
    }

    public string MensajeNotaFinal(double notaFinal)
    {
        if (notaFinal >= 0 && notaFinal < 60)
            return "Reprobado";
        else if (notaFinal >= 60 && notaFinal < 80)
            return "Bueno";
        else if (notaFinal >= 80 && notaFinal < 90)
            return "Muy Bueno";
        else if (notaFinal >= 90 && notaFinal <= 100)
            return "Sobresaliente";
        else
            return "Nota fuera de rango";
    }

    public void Imprimir()
    {
        double notaFinal = CalcularNotaFinal();
        double notaFinalConParametros = CalcularNotaFinal(N1, N2, N3);
        string mensaje = MensajeNotaFinal(notaFinal);

        Console.WriteLine($"Nombre del alumno: {NombreAlumno}");
        Console.WriteLine($"Número de cuenta: {NumeroCuenta}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Asignatura: {NombreAsignatura}");
        Console.WriteLine($"Docente: {NombreDocente}");
        Console.WriteLine($"Horario: {Horario}");
        Console.WriteLine($"Nota Final: {notaFinal} - {mensaje}");
        Console.WriteLine($"Nota Final (usando parámetros): {notaFinalConParametros} - {mensaje}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Asignatura asignatura = new Asignatura();

        try
        {
            Console.WriteLine("Ingrese el nombre del alumno:");
            asignatura.NombreAlumno = Console.ReadLine();

            Console.WriteLine("Ingrese el número de cuenta:");
            asignatura.NumeroCuenta = Console.ReadLine();

            Console.WriteLine("Ingrese el email del alumno:");
            asignatura.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre de la asignatura:");
            asignatura.NombreAsignatura = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del docente:");
            asignatura.NombreDocente = Console.ReadLine();

            Console.WriteLine("Ingrese el horario:");
            asignatura.Horario = Console.ReadLine();

            Console.WriteLine("Ingrese la nota del primer parcial (máximo 30):");
            asignatura.N1 = int.Parse(Console.ReadLine());
            if (asignatura.N1 > 30) throw new Exception("La nota del primer parcial no puede ser mayor a 30");

            Console.WriteLine("Ingrese la nota del segundo parcial (máximo 30):");
            asignatura.N2 = int.Parse(Console.ReadLine());
            if (asignatura.N2 > 30) throw new Exception("La nota del segundo parcial no puede ser mayor a 30");

            Console.WriteLine("Ingrese la nota del tercer parcial (máximo 40):");
            asignatura.N3 = int.Parse(Console.ReadLine());
            if (asignatura.N3 > 40) throw new Exception("La nota del tercer parcial no puede ser mayor a 40");

            asignatura.Imprimir();
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Por favor ingrese un valor numérico válido para las notas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

