namespace api.Models
{
    public class Provider
    {
        //[JsonIgnore]
        public int ProviderID { get; set; }

        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [MaxLengthCharacters(40)]
        public string Nationality { get; set; }= string.Empty;
    }
}