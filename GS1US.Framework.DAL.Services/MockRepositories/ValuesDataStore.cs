using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.DAL.Services.MockRepositories
{
    public class ValuesDataStore : IValuesDataStore
    {
        public static ValuesDataStore Current { get; } = new ValuesDataStore();

        public List<ValuesString> Values { get; set; }

        public List<ValuesString> GetValues()
        {
            return Current.Values;
        }

        public ValuesDataStore()
        {
            // init dummy data
            Values = new List<ValuesString>()
            {
               new ValuesString(){ Name = "Value 1" },
               new ValuesString(){ Name = "Value 2" },
               new ValuesString(){ Name = "Value 3" },
               new ValuesString(){ Name = "Value 4" },
               new ValuesString(){ Name = "Value 5" },
               new ValuesString(){ Name = "Value 6" }
            };
        }
    }
}
