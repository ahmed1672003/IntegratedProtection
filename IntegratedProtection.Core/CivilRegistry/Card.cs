﻿namespace IntegratedProtection.Core.CivilRegistry;

[Table("Cards", Schema = "CivilRegistry"), PrimaryKey(nameof(Id))]
public class Card : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    public string CardPath { get; set; }

    [MaxLength(100)]
    public string Job { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public int PersonId { get; set; }

    [ForeignKey(name: nameof(PersonId))]
    public Person Person { get; set; }

    [NotMapped]
    public bool IsValid
    {
        get
        {
            if (Convert.ToInt32(EndDate.Year) - Convert.ToInt32(CreatedDate.Year) <= 10)
                return true;
            else
                return false;
        }
    }
    public Card()
    {
        CreatedDate = DateTime.Now.Date;
        EndDate = CreatedDate.AddYears(6).Date;
    }
}
