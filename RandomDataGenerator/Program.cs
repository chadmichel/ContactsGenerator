using System;
using System.Collections.Generic;
using System.IO;

namespace RandomDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // create data sets
            var nameDataSet = new Bogus.DataSets.Name();
            var addressDataSet = new Bogus.DataSets.Address();
            var phoneDataSet = new Bogus.DataSets.PhoneNumbers();

            // create list to hold results
            var list = new List<Address>();

            for (var i = 0; i < 780000; i++)
            {
                // generate a result
                var address = new Address();

                address.First = nameDataSet.FirstName();
                address.Last = nameDataSet.LastName();

                address.Street = addressDataSet.StreetAddress();
                address.City = addressDataSet.City();
                address.State = addressDataSet.State();
                address.Zip = addressDataSet.ZipCode();
                address.Phone = phoneDataSet.PhoneNumberFormat(0);

                list.Add(address);
            }

            // serialize to output.json
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            File.WriteAllText("output.json", json);
        }
    }


    class Address
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
