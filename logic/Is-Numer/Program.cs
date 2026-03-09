// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ingrese numero: ");
var numberString = Console.ReadLine();
var numberInt = int.Parse(numberString!);
if  (numberInt % 2 == 0)
{
    Console.WriteLine("El numero es par");
}
else
{
    Console.WriteLine("El numero es impar");
}
