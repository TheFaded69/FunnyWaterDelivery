namespace FunnyWaterDelivery.Database.Models;

public class DbOrder : DbEntity<Guid>
{
    public virtual DateTime OrderDate { get; set; }
    
    public virtual decimal Total { get; set; }
    
    public virtual DbEmployee Employee { get; set; }
    
    public virtual DbPartner Partner { get; set; }
}