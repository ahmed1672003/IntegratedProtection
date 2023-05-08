namespace IntegratedProtection.Core.BaseEntity;

[NotMapped]
public class Base<TKey>
{
    public virtual TKey Id { get; set; }
}
