namespace FunnyWaterDelivery.Database.Models;

public class DbPartner : DbEntity<Guid>
{
    public virtual string Name { get; set; }
    
    public virtual string INN { get; set; }
    
    public virtual DbEmployee? Curator { get; set; } 
}