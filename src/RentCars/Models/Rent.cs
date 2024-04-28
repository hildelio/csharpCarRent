using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        DaysRented = daysRented;

        if (person.PersonType == PersonType.Physical)
        {
            Price = vehicle.PricePerDay * daysRented;
        }
        else if (person.PersonType == PersonType.Legal)
        {
            Price = vehicle.PricePerDay * daysRented * 0.9;
        }
        Status = RentStatus.Confirmed;
        vehicle.IsRented = true;
        Vehicle = vehicle;
        person.Debit += Price;
        Person = person;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        if (Status == RentStatus.Confirmed)
        {
            Status = RentStatus.Canceled;
            Vehicle.IsRented = false;
            Person.Debit -= Price;
            Console.WriteLine("Aluguel cancelado com sucesso!");
        }
        else
        {
            Console.WriteLine("Não é possível cancelar um aluguel inexistente.");
        }
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        if (Status == RentStatus.Confirmed)
        {
            Status = RentStatus.Finished;
            Vehicle.IsRented = false;
            Console.WriteLine("Aluguel finalizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Não é possível cancelar um aluguel inexistente.");
        }
    }
}