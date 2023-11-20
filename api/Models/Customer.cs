namespace api.Models
{
    public class Customer
    {
        //[JsonIgnore]
        public int UserID { get; set; }

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Email { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [StringValue]
        [MaxLengthCharacters(40)]
        public string Password { get; set; }= string.Empty;

        [IntValue(ErrorMessage = "The 'RegionID' property must be an integer.")]
        public int RegionID { get; set; }

        [IntValue(ErrorMessage = "The 'Nit' property must be an integer.")]
        [RangeValueInt(100000000, 999999999)]
        public int Nit { get; set; }
    }
}