namespace BitMaster.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string CarType { get; set; }
        public string PlateNumber { get; set; }

        // Для отображения в выпадающих списках (экипаж)
        public string DisplayName
        {
            get { return Brand + " (" + PlateNumber + ")"; }
        }
    }

    public class Driver
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LicenseNumber { get; set; }
        public int ExperienceYears { get; set; }

        public string DisplayName
        {
            get
            {
                var name = LastName + " " + FirstName;
                if (!string.IsNullOrWhiteSpace(MiddleName))
                    name += " " + MiddleName;
                return name;
            }
        }
    }

    public class Crew
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public bool Active { get; set; }
    }
}
