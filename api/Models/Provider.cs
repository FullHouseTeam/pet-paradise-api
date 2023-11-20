namespace api.Models
{
    public class Provider
    {
        //[JsonIgnore]
        public int ProviderID { get; set; }

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Nationality { get; set; }= string.Empty;
    }
}