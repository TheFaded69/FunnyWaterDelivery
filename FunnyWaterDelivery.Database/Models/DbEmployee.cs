namespace FunnyWaterDelivery.Database.Models;

public class DbEmployee : DbEntity<Guid>
{
    public virtual string Name { get; set; }
    
    public virtual string Surname { get; set; }
    
    public virtual string Patronymic { get; set; }
    
    public virtual EmployeeType EmployeeType { get; set; }
    
    public virtual DateTime DateOfBirth { get; set; }
}