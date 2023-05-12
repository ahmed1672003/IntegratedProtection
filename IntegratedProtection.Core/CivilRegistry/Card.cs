namespace IntegratedProtection.Core.CivilRegistry;

[Table("Cards", Schema = "CivilRegistry"), PrimaryKey(nameof(Id))]
public class Card : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(1024 * 1024 * 5)]
    public byte[]? CardPhoto { get; set; }


    [MaxLength(100)]
    public string Job { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }


    public int PersonId { get; set; }

    [ForeignKey(name: nameof(PersonId))]
    public Person Person { get; set; }

    [NotMapped]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime EndDate
    {
        get { return CreatedDate.AddYears(7); }
    }

    [NotMapped]
    public bool IsValid
    {
        get
        {
            if ((DateTime.Now.Year - CreatedDate.Year) <= 7)
                return true;
            else
                return false;
        }
    }
    public Card()
    {
        //CreatedDate = DateTime.Now.Date;
    }
}
