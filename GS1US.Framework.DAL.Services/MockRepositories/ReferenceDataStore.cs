using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GS1US.Framework.DAL.Services.MockRepositories
{
    public class ReferenceDataStore : IReferenceDataStore
    {
        public static ReferenceDataStore Current { get; } = new ReferenceDataStore();

        public List<ReferenceTable> Tables { get; set; }

        public IEnumerable<ReferenceTable> GetAllRefenceData()
        {
			TestAccessToApimEndPoint();
            return Current.Tables;
        }
        public IEnumerable<ReferenceTable> GetRefenceData(string applicationArea)
        {
            return Current.Tables.Where(t => t.ApplicationArea.Contains(applicationArea)).ToList();
        }

        public ReferenceDataStore()
        {
            // init dummy data
            Tables = new List<ReferenceTable>();
            Tables.Add(CountryTable());
			Tables.Add(IndustryTable());
			Tables.Add(UofMTable());
		}

		private async void TestAccessToApimEndPoint() {
			var path = "https://api.dev.gs1us.org/ProductManage/api/v1/reference";
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "33153b10674f4f1594e7a6168e6d8c68");

			// HttpResponseMessage 
				var response = await client.GetStringAsync(path);
			
		}

		private ReferenceTable CountryTable()
		{
            var countries = new List<GenericEntity>() {
    new GenericEntity()
		{
			Code = "AD",
			Name = "ANDORRA",
			SortOrder = 1,
			NumericCode = 20,
			ShowInUI = true,
			IsActive = false
        },
    new GenericEntity()
        {
            Code = "AE",
            Name = "UNITED ARAB EMIRATES",
            SortOrder = 2,
            NumericCode = 784,
            ShowInUI = true,
            IsActive = false
        },
	new GenericEntity()
		{
			Code = "AF",
			Name = "AFGHANISTAN",
			SortOrder = 1,
			NumericCode = 4,
			ShowInUI = true,
			IsActive = false
		},
	new GenericEntity()
			{
				Code = "AG",
				Name = "ANTIGUA AND BARBUDA",
				SortOrder = 1,
				NumericCode = 28,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AI",
				Name = "ANGUILLA",
				SortOrder = 1,
				NumericCode = 660,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AL",
				Name = "ALBANIA",
				SortOrder = 1,
				NumericCode = 8,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AM",
				Name = "ARMENIA",
				SortOrder = 1,
				NumericCode = 51,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AO",
				Name = "ANGOLA",
				SortOrder = 1,
				NumericCode = 24,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AQ",
				Name = "ANTARCTICA",
				SortOrder = 1,
				NumericCode = 10,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AR",
				Name = "ARGENTINA",
				SortOrder = 1,
				NumericCode = 32,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AS",
				Name = "AMERICAN SAMOA",
				SortOrder = 1,
				NumericCode = 16,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AT",
				Name = "AUSTRIA",
				SortOrder = 1,
				NumericCode = 40,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AU",
				Name = "AUSTRALIA",
				SortOrder = 1,
				NumericCode = 36,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AW",
				Name = "ARUBA",
				SortOrder = 1,
				NumericCode = 533,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AX",
				Name = "ALAND ISLANDS",
				SortOrder = 1,
				NumericCode = 248,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "AZ",
				Name = "AZERBAIJAN",
				SortOrder = 1,
				NumericCode = 31,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BA",
				Name = "BOSNIA AND HERZEGOVINA",
				SortOrder = 1,
				NumericCode = 70,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BB",
				Name = "BARBADOS",
				SortOrder = 1,
				NumericCode = 52,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BD",
				Name = "BANGLADESH",
				SortOrder = 1,
				NumericCode = 50,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BE",
				Name = "BELGIUM",
				SortOrder = 1,
				NumericCode = 56,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BF",
				Name = "BURKINA FASO",
				SortOrder = 1,
				NumericCode = 854,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BG",
				Name = "BULGARIA",
				SortOrder = 1,
				NumericCode = 100,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BH",
				Name = "BAHRAIN",
				SortOrder = 1,
				NumericCode = 48,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BI",
				Name = "BURUNDI",
				SortOrder = 1,
				NumericCode = 108,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BJ",
				Name = "BENIN",
				SortOrder = 1,
				NumericCode = 204,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BL",
				Name = "SAINT BARTHELEMY",
				SortOrder = 1,
				NumericCode = 652,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BM",
				Name = "BERMUDA",
				SortOrder = 1,
				NumericCode = 60,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BN",
				Name = "BRUNEI DARUSSALAM",
				SortOrder = 1,
				NumericCode = 96,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BO",
				Name = "BOLIVIA (PLURINATIONAL STATE OF)",
				SortOrder = 1,
				NumericCode = 68,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BQ",
				Name = "BONAIRE, SINT EUSTATIUS AND SABA",
				SortOrder = 1,
				NumericCode = 535,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BR",
				Name = "BRAZIL",
				SortOrder = 1,
				NumericCode = 76,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BS",
				Name = "BAHAMAS",
				SortOrder = 1,
				NumericCode = 44,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BT",
				Name = "BHUTAN",
				SortOrder = 1,
				NumericCode = 64,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BV",
				Name = "BOUVET ISLAND",
				SortOrder = 1,
				NumericCode = 74,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BW",
				Name = "BOTSWANA",
				SortOrder = 1,
				NumericCode = 72,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BY",
				Name = "BELARUS",
				SortOrder = 1,
				NumericCode = 112,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "BZ",
				Name = "BELIZE",
				SortOrder = 1,
				NumericCode = 84,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CA",
				Name = "CANADA",
				SortOrder = 1,
				NumericCode = 124,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CC",
				Name = "COCOS (KEELING) ISLANDS",
				SortOrder = 1,
				NumericCode = 166,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CD",
				Name = "CONGO, DEMOCRATIC REPUBLIC OF THE",
				SortOrder = 1,
				NumericCode = 180,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CF",
				Name = "CENTRAL AFRICAN REPUBLIC",
				SortOrder = 1,
				NumericCode = 140,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CG",
				Name = "CONGO",
				SortOrder = 1,
				NumericCode = 178,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CH",
				Name = "SWITZERLAND",
				SortOrder = 1,
				NumericCode = 756,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CI",
				Name = "COTE D'IVOIRE",
				SortOrder = 1,
				NumericCode = 384,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CK",
				Name = "COOK ISLANDS",
				SortOrder = 1,
				NumericCode = 184,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CL",
				Name = "CHILE",
				SortOrder = 1,
				NumericCode = 152,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CM",
				Name = "CAMEROON",
				SortOrder = 1,
				NumericCode = 120,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CN",
				Name = "CHINA",
				SortOrder = 1,
				NumericCode = 156,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CO",
				Name = "COLOMBIA",
				SortOrder = 1,
				NumericCode = 170,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CR",
				Name = "COSTA RICA",
				SortOrder = 1,
				NumericCode = 188,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CU",
				Name = "CUBA",
				SortOrder = 1,
				NumericCode = 192,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CV",
				Name = "CABO VERDE",
				SortOrder = 1,
				NumericCode = 132,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CW",
				Name = "CURACAO",
				SortOrder = 1,
				NumericCode = 531,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CX",
				Name = "CHRISTMAS ISLAND",
				SortOrder = 1,
				NumericCode = 162,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CY",
				Name = "CYPRUS",
				SortOrder = 1,
				NumericCode = 196,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CZ",
				Name = "CZECHIA",
				SortOrder = 1,
				NumericCode = 203,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DE",
				Name = "GERMANY",
				SortOrder = 1,
				NumericCode = 276,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DJ",
				Name = "DJIBOUTI",
				SortOrder = 1,
				NumericCode = 262,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DK",
				Name = "DENMARK",
				SortOrder = 1,
				NumericCode = 208,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DM",
				Name = "DOMINICA",
				SortOrder = 1,
				NumericCode = 212,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DO",
				Name = "DOMINICAN REPUBLIC",
				SortOrder = 1,
				NumericCode = 214,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DZ",
				Name = "ALGERIA",
				SortOrder = 1,
				NumericCode = 12,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EC",
				Name = "ECUADOR",
				SortOrder = 1,
				NumericCode = 218,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EE",
				Name = "ESTONIA",
				SortOrder = 1,
				NumericCode = 233,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EG",
				Name = "EGYPT",
				SortOrder = 1,
				NumericCode = 818,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EH",
				Name = "WESTERN SAHARA",
				SortOrder = 1,
				NumericCode = 732,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ER",
				Name = "ERITREA",
				SortOrder = 1,
				NumericCode = 232,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ES",
				Name = "SPAIN",
				SortOrder = 1,
				NumericCode = 724,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ET",
				Name = "ETHIOPIA",
				SortOrder = 1,
				NumericCode = 231,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FI",
				Name = "FINLAND",
				SortOrder = 1,
				NumericCode = 246,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FJ",
				Name = "FIJI",
				SortOrder = 1,
				NumericCode = 242,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FK",
				Name = "FALKLAND ISLANDS (MALVINAS)",
				SortOrder = 1,
				NumericCode = 238,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FM",
				Name = "MICRONESIA (FEDERATED STATES OF)",
				SortOrder = 1,
				NumericCode = 583,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FO",
				Name = "FAROE ISLANDS",
				SortOrder = 1,
				NumericCode = 234,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FR",
				Name = "FRANCE",
				SortOrder = 1,
				NumericCode = 250,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GA",
				Name = "GABON",
				SortOrder = 1,
				NumericCode = 266,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GB",
				Name = "UNITED KINGDOM OF GREAT BRITAIN AND NORTHERN  IRELAND",
				SortOrder = 1,
				NumericCode = 826,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GD",
				Name = "GRENADA",
				SortOrder = 1,
				NumericCode = 308,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GE",
				Name = "GEORGIA",
				SortOrder = 1,
				NumericCode = 268,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GF",
				Name = "FRENCH GUIANA",
				SortOrder = 1,
				NumericCode = 254,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GG",
				Name = "GUERNSEY",
				SortOrder = 1,
				NumericCode = 831,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GH",
				Name = "GHANA",
				SortOrder = 1,
				NumericCode = 288,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GI",
				Name = "GIBRALTAR",
				SortOrder = 1,
				NumericCode = 292,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GL",
				Name = "GREENLAND",
				SortOrder = 1,
				NumericCode = 304,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GM",
				Name = "GAMBIA",
				SortOrder = 1,
				NumericCode = 270,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GN",
				Name = "GUINEA",
				SortOrder = 1,
				NumericCode = 324,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GP",
				Name = "GUADELOUPE",
				SortOrder = 1,
				NumericCode = 312,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GQ",
				Name = "EQUATORIAL GUINEA",
				SortOrder = 1,
				NumericCode = 226,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GR",
				Name = "GREECE",
				SortOrder = 1,
				NumericCode = 300,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GS",
				Name = "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS",
				SortOrder = 1,
				NumericCode = 239,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GT",
				Name = "GUATEMALA",
				SortOrder = 1,
				NumericCode = 320,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GU",
				Name = "GUAM",
				SortOrder = 1,
				NumericCode = 316,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GW",
				Name = "GUINEA-BISSAU",
				SortOrder = 1,
				NumericCode = 624,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GY",
				Name = "GUYANA",
				SortOrder = 1,
				NumericCode = 328,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HK",
				Name = "HONG KONG",
				SortOrder = 1,
				NumericCode = 344,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HM",
				Name = "HEARD ISLAND AND MCDONALD ISLANDS",
				SortOrder = 1,
				NumericCode = 334,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HN",
				Name = "HONDURAS",
				SortOrder = 1,
				NumericCode = 340,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HR",
				Name = "CROATIA",
				SortOrder = 1,
				NumericCode = 191,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HT",
				Name = "HAITI",
				SortOrder = 1,
				NumericCode = 332,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "HU",
				Name = "HUNGARY",
				SortOrder = 1,
				NumericCode = 348,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ID",
				Name = "INDONESIA",
				SortOrder = 1,
				NumericCode = 360,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IE",
				Name = "IRELAND",
				SortOrder = 1,
				NumericCode = 372,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IL",
				Name = "ISRAEL",
				SortOrder = 1,
				NumericCode = 376,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IM",
				Name = "ISLE OF MAN",
				SortOrder = 1,
				NumericCode = 833,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IN",
				Name = "INDIA",
				SortOrder = 1,
				NumericCode = 356,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IO",
				Name = "BRITISH INDIAN OCEAN TERRITORY",
				SortOrder = 1,
				NumericCode = 86,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IQ",
				Name = "IRAQ",
				SortOrder = 1,
				NumericCode = 368,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IR",
				Name = "IRAN (ISLAMIC REPUBLIC OF)",
				SortOrder = 1,
				NumericCode = 364,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IS",
				Name = "ICELAND",
				SortOrder = 1,
				NumericCode = 352,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IT",
				Name = "ITALY",
				SortOrder = 1,
				NumericCode = 380,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "JE",
				Name = "JERSEY",
				SortOrder = 1,
				NumericCode = 832,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "JM",
				Name = "JAMAICA",
				SortOrder = 1,
				NumericCode = 388,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "JO",
				Name = "JORDAN",
				SortOrder = 1,
				NumericCode = 400,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "JP",
				Name = "JAPAN",
				SortOrder = 1,
				NumericCode = 392,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KE",
				Name = "KENYA",
				SortOrder = 1,
				NumericCode = 404,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KG",
				Name = "KYRGYZSTAN",
				SortOrder = 1,
				NumericCode = 417,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KH",
				Name = "CAMBODIA",
				SortOrder = 1,
				NumericCode = 116,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KI",
				Name = "KIRIBATI",
				SortOrder = 1,
				NumericCode = 296,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KM",
				Name = "COMOROS",
				SortOrder = 1,
				NumericCode = 174,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KN",
				Name = "SAINT KITTS AND NEVIS",
				SortOrder = 1,
				NumericCode = 659,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KP",
				Name = "KOREA (DEMOCRATIC PEOPLE'S REPUBLIC OF)",
				SortOrder = 1,
				NumericCode = 408,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KR",
				Name = "KOREA, REPUBLIC OF",
				SortOrder = 1,
				NumericCode = 410,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KW",
				Name = "KUWAIT",
				SortOrder = 1,
				NumericCode = 414,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KY",
				Name = "CAYMAN ISLANDS",
				SortOrder = 1,
				NumericCode = 136,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "KZ",
				Name = "KAZAKHSTAN",
				SortOrder = 1,
				NumericCode = 398,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LA",
				Name = "LAO PEOPLE'S DEMOCRATIC REPUBLIC",
				SortOrder = 1,
				NumericCode = 418,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LB",
				Name = "LEBANON",
				SortOrder = 1,
				NumericCode = 422,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LC",
				Name = "SAINT LUCIA",
				SortOrder = 1,
				NumericCode = 662,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LI",
				Name = "LIECHTENSTEIN",
				SortOrder = 1,
				NumericCode = 438,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LK",
				Name = "SRI LANKA",
				SortOrder = 1,
				NumericCode = 144,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LR",
				Name = "LIBERIA",
				SortOrder = 1,
				NumericCode = 430,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LS",
				Name = "LESOTHO",
				SortOrder = 1,
				NumericCode = 426,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LT",
				Name = "LITHUANIA",
				SortOrder = 1,
				NumericCode = 440,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LU",
				Name = "LUXEMBOURG",
				SortOrder = 1,
				NumericCode = 442,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LV",
				Name = "LATVIA",
				SortOrder = 1,
				NumericCode = 428,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LY",
				Name = "LIBYA",
				SortOrder = 1,
				NumericCode = 434,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MA",
				Name = "MOROCCO",
				SortOrder = 1,
				NumericCode = 504,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MC",
				Name = "MONACO",
				SortOrder = 1,
				NumericCode = 492,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MD",
				Name = "MOLDOVA, REPUBLIC OF",
				SortOrder = 1,
				NumericCode = 498,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ME",
				Name = "MONTENEGRO",
				SortOrder = 1,
				NumericCode = 499,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MF",
				Name = "SAINT MARTIN (FRENCH PART)",
				SortOrder = 1,
				NumericCode = 663,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MG",
				Name = "MADAGASCAR",
				SortOrder = 1,
				NumericCode = 450,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MH",
				Name = "MARSHALL ISLANDS",
				SortOrder = 1,
				NumericCode = 584,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MK",
				Name = "NORTH MACEDONIA",
				SortOrder = 1,
				NumericCode = 807,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ML",
				Name = "MALI",
				SortOrder = 1,
				NumericCode = 466,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MM",
				Name = "MYANMAR",
				SortOrder = 1,
				NumericCode = 104,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MN",
				Name = "MONGOLIA",
				SortOrder = 1,
				NumericCode = 496,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MO",
				Name = "MACAO",
				SortOrder = 1,
				NumericCode = 446,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MP",
				Name = "NORTHERN MARIANA ISLANDS",
				SortOrder = 1,
				NumericCode = 580,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MQ",
				Name = "MARTINIQUE",
				SortOrder = 1,
				NumericCode = 474,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MR",
				Name = "MAURITANIA",
				SortOrder = 1,
				NumericCode = 478,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MS",
				Name = "MONTSERRAT",
				SortOrder = 1,
				NumericCode = 500,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MT",
				Name = "MALTA",
				SortOrder = 1,
				NumericCode = 470,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MU",
				Name = "MAURITIUS",
				SortOrder = 1,
				NumericCode = 480,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MV",
				Name = "MALDIVES",
				SortOrder = 1,
				NumericCode = 462,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MW",
				Name = "MALAWI",
				SortOrder = 1,
				NumericCode = 454,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MX",
				Name = "MEXICO",
				SortOrder = 1,
				NumericCode = 484,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MY",
				Name = "MALAYSIA",
				SortOrder = 1,
				NumericCode = 458,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "MZ",
				Name = "MOZAMBIQUE",
				SortOrder = 1,
				NumericCode = 508,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NA",
				Name = "NAMIBIA",
				SortOrder = 1,
				NumericCode = 516,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NC",
				Name = "NEW CALEDONIA",
				SortOrder = 1,
				NumericCode = 540,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NE",
				Name = "NIGER",
				SortOrder = 1,
				NumericCode = 562,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NF",
				Name = "NORFOLK ISLAND",
				SortOrder = 1,
				NumericCode = 574,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NG",
				Name = "NIGERIA",
				SortOrder = 1,
				NumericCode = 566,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NI",
				Name = "NICARAGUA",
				SortOrder = 1,
				NumericCode = 558,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NL",
				Name = "NETHERLANDS",
				SortOrder = 1,
				NumericCode = 528,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NO",
				Name = "NORWAY",
				SortOrder = 1,
				NumericCode = 578,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NP",
				Name = "NEPAL",
				SortOrder = 1,
				NumericCode = 524,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NR",
				Name = "NAURU",
				SortOrder = 1,
				NumericCode = 520,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NU",
				Name = "NIUE",
				SortOrder = 1,
				NumericCode = 570,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "NZ",
				Name = "NEW ZEALAND",
				SortOrder = 1,
				NumericCode = 554,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "OM",
				Name = "OMAN",
				SortOrder = 1,
				NumericCode = 512,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PA",
				Name = "PANAMA",
				SortOrder = 1,
				NumericCode = 591,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PE",
				Name = "PERU",
				SortOrder = 1,
				NumericCode = 604,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PF",
				Name = "FRENCH POLYNESIA",
				SortOrder = 1,
				NumericCode = 258,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PG",
				Name = "PAPUA NEW GUINEA",
				SortOrder = 1,
				NumericCode = 598,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PH",
				Name = "PHILIPPINES",
				SortOrder = 1,
				NumericCode = 608,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PK",
				Name = "PAKISTAN",
				SortOrder = 1,
				NumericCode = 586,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PL",
				Name = "POLAND",
				SortOrder = 1,
				NumericCode = 616,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PM",
				Name = "SAINT PIERRE AND MIQUELON",
				SortOrder = 1,
				NumericCode = 666,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PN",
				Name = "PITCAIRN",
				SortOrder = 1,
				NumericCode = 612,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PR",
				Name = "PUERTO RICO",
				SortOrder = 1,
				NumericCode = 630,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PS",
				Name = "PALESTINE, STATE OF",
				SortOrder = 1,
				NumericCode = 275,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PT",
				Name = "PORTUGAL",
				SortOrder = 1,
				NumericCode = 620,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PW",
				Name = "PALAU",
				SortOrder = 1,
				NumericCode = 585,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PY",
				Name = "PARAGUAY",
				SortOrder = 1,
				NumericCode = 600,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "QA",
				Name = "QATAR",
				SortOrder = 1,
				NumericCode = 634,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RE",
				Name = "REUNION",
				SortOrder = 1,
				NumericCode = 638,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RO",
				Name = "ROMANIA",
				SortOrder = 1,
				NumericCode = 642,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RS",
				Name = "SERBIA",
				SortOrder = 1,
				NumericCode = 688,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RU",
				Name = "RUSSIAN FEDERATION",
				SortOrder = 1,
				NumericCode = 643,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RW",
				Name = "RWANDA",
				SortOrder = 1,
				NumericCode = 646,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SA",
				Name = "SAUDI ARABIA",
				SortOrder = 1,
				NumericCode = 682,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SB",
				Name = "SOLOMON ISLANDS",
				SortOrder = 1,
				NumericCode = 90,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SC",
				Name = "SEYCHELLES",
				SortOrder = 1,
				NumericCode = 690,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SD",
				Name = "SUDAN",
				SortOrder = 1,
				NumericCode = 729,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SE",
				Name = "SWEDEN",
				SortOrder = 1,
				NumericCode = 752,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SG",
				Name = "SINGAPORE",
				SortOrder = 1,
				NumericCode = 702,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SH",
				Name = "SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA",
				SortOrder = 1,
				NumericCode = 654,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SI",
				Name = "SLOVENIA",
				SortOrder = 1,
				NumericCode = 705,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SJ",
				Name = "SVALBARD AND JAN MAYEN",
				SortOrder = 1,
				NumericCode = 744,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SK",
				Name = "SLOVAKIA",
				SortOrder = 1,
				NumericCode = 703,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SL",
				Name = "SIERRA LEONE",
				SortOrder = 1,
				NumericCode = 694,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SM",
				Name = "SAN MARINO",
				SortOrder = 1,
				NumericCode = 674,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SN",
				Name = "SENEGAL",
				SortOrder = 1,
				NumericCode = 686,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SO",
				Name = "SOMALIA",
				SortOrder = 1,
				NumericCode = 706,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SR",
				Name = "SURIName",
				SortOrder = 1,
				NumericCode = 740,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SS",
				Name = "SOUTH SUDAN",
				SortOrder = 1,
				NumericCode = 728,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ST",
				Name = "SAO TOME AND PRINCIPE",
				SortOrder = 1,
				NumericCode = 678,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SV",
				Name = "EL SALVADOR",
				SortOrder = 1,
				NumericCode = 222,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SX",
				Name = "SINT MAARTEN (DUTCH PART)",
				SortOrder = 1,
				NumericCode = 534,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SY",
				Name = "SYRIAN ARAB REPUBLIC",
				SortOrder = 1,
				NumericCode = 760,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "SZ",
				Name = "ESWATINI",
				SortOrder = 1,
				NumericCode = 748,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TC",
				Name = "TURKS AND CAICOS ISLANDS",
				SortOrder = 1,
				NumericCode = 796,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TD",
				Name = "CHAD",
				SortOrder = 1,
				NumericCode = 148,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TF",
				Name = "FRENCH SOUTHERN TERRITORIES",
				SortOrder = 1,
				NumericCode = 260,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TG",
				Name = "TOGO",
				SortOrder = 1,
				NumericCode = 768,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TH",
				Name = "THAILAND",
				SortOrder = 1,
				NumericCode = 764,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TJ",
				Name = "TAJIKISTAN",
				SortOrder = 1,
				NumericCode = 762,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TK",
				Name = "TOKELAU",
				SortOrder = 1,
				NumericCode = 772,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TL",
				Name = "TIMOR-LESTE",
				SortOrder = 1,
				NumericCode = 626,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TM",
				Name = "TURKMENISTAN",
				SortOrder = 1,
				NumericCode = 795,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TN",
				Name = "TUNISIA",
				SortOrder = 1,
				NumericCode = 788,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TO",
				Name = "TONGA",
				SortOrder = 1,
				NumericCode = 776,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TR",
				Name = "TURKEY",
				SortOrder = 1,
				NumericCode = 792,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TT",
				Name = "TRINIDAD AND TOBAGO",
				SortOrder = 1,
				NumericCode = 780,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TV",
				Name = "TUVALU",
				SortOrder = 1,
				NumericCode = 798,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TW",
				Name = "TAIWAN, PROVINCE OF CHINA",
				SortOrder = 1,
				NumericCode = 158,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TZ",
				Name = "TANZANIA, UNITED REPUBLIC OF",
				SortOrder = 1,
				NumericCode = 834,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UA",
				Name = "UKRAINE",
				SortOrder = 1,
				NumericCode = 804,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UG",
				Name = "UGANDA",
				SortOrder = 1,
				NumericCode = 800,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UM",
				Name = "UNITED STATES MINOR OUTLYING ISLANDS",
				SortOrder = 1,
				NumericCode = 581,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "US",
				Name = "UNITED STATES OF AMERICA",
				SortOrder = 1,
				NumericCode = 840,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UY",
				Name = "URUGUAY",
				SortOrder = 1,
				NumericCode = 858,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UZ",
				Name = "UZBEKISTAN",
				SortOrder = 1,
				NumericCode = 860,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VA",
				Name = "HOLY SEE",
				SortOrder = 1,
				NumericCode = 336,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VC",
				Name = "SAINT VINCENT AND THE GRENADINES",
				SortOrder = 1,
				NumericCode = 670,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VE",
				Name = "VENEZUELA (BOLIVARIAN REPUBLIC OF)",
				SortOrder = 1,
				NumericCode = 862,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VG",
				Name = "VIRGIN ISLANDS (BRITISH)",
				SortOrder = 1,
				NumericCode = 92,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VI",
				Name = "VIRGIN ISLANDS (U.S.)",
				SortOrder = 1,
				NumericCode = 850,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VN",
				Name = "VIET NAM",
				SortOrder = 1,
				NumericCode = 704,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "VU",
				Name = "VANUATU",
				SortOrder = 1,
				NumericCode = 548,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WF",
				Name = "WALLIS AND FUTUNA",
				SortOrder = 1,
				NumericCode = 876,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WS",
				Name = "SAMOA",
				SortOrder = 1,
				NumericCode = 882,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "YE",
				Name = "YEMEN",
				SortOrder = 1,
				NumericCode = 887,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "YT",
				Name = "MAYOTTE",
				SortOrder = 1,
				NumericCode = 175,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ZA",
				Name = "SOUTH AFRICA",
				SortOrder = 1,
				NumericCode = 710,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ZM",
				Name = "ZAMBIA",
				SortOrder = 1,
				NumericCode = 894,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "ZW",
				Name = "ZIMBABWE",
				SortOrder = 1,
				NumericCode = 716,
				ShowInUI = true,
				IsActive = false
			},

			new GenericEntity()
			{
				Code = "XJ",
				Name = "ASIAN REGION",
				SortOrder = 1,
				NumericCode = 10001,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XB",
				Name = "NORTH AMERICAN REGION",
				SortOrder = 1,
				NumericCode = 10010,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "GC",
				Name = "PATENT OFFICE FOR THE ARAB STATES (GCC)",
				SortOrder = 1,
				NumericCode = 10027,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "IC",
				Name = "CANARY ISLANDS",
				SortOrder = 1,
				NumericCode = 10003,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EU",
				Name = "EUROPEAN UNION",
				SortOrder = 1,
				NumericCode = 10008,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RM",
				Name = "MADAGASCAR",
				SortOrder = 1,
				NumericCode = 10025,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XG",
				Name = "NORTH AFRICAN REGION",
				SortOrder = 1,
				NumericCode = 10013,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "PI",
				Name = "PHILIPPINES",
				SortOrder = 1,
				NumericCode = 10028,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RP",
				Name = "PHILIPPINES",
				SortOrder = 1,
				NumericCode = 10029,
				ShowInUI = false,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WO",
				Name = "WORLD INTELLECTUAL PROPERTY ORGANIZATION",
				SortOrder = 1,
				NumericCode = 10033,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RN",
				Name = "NIGER",
				SortOrder = 1,
				NumericCode = 10026,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WG",
				Name = "GRENADA",
				SortOrder = 1,
				NumericCode = 10018,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XD",
				Name = "SOUTH AMERICAN REGION",
				SortOrder = 1,
				NumericCode = 10011,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XF",
				Name = "SUB-SAHARAN AFRICAN REGION",
				SortOrder = 1,
				NumericCode = 10012,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WV",
				Name = "SAINT VINCENT AND THE GRENADINES",
				SortOrder = 1,
				NumericCode = 10030,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RI",
				Name = "INDONESIA",
				SortOrder = 1,
				NumericCode = 10020,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EW",
				Name = "ESTONIA",
				SortOrder = 1,
				NumericCode = 10007,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RL",
				Name = "LEBANON",
				SortOrder = 1,
				NumericCode = 10022,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XH",
				Name = "MIDDLE EASTERN REGION",
				SortOrder = 1,
				NumericCode = 10014,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DY",
				Name = "DAHOMEY",
				SortOrder = 1,
				NumericCode = 10005,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "YV",
				Name = "VENEZUELA (BOLIVARIAN REPUBLIC OF)",
				SortOrder = 1,
				NumericCode = 10032,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XC",
				Name = "CENTRAL AMERICAN REGION",
				SortOrder = 1,
				NumericCode = 10002,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "WW",
				Name = "WHOLE WORLD",
				SortOrder = 1,
				NumericCode = 10016,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "FL",
				Name = "LIECHTENSTEIN",
				SortOrder = 1,
				NumericCode = 10024,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "TA",
				Name = "TRISTAN DA CUNHA",
				SortOrder = 1,
				NumericCode = 10031,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "CP",
				Name = "CLIPPERTON ISLAND",
				SortOrder = 1,
				NumericCode = 10004,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "LF",
				Name = "LIBYA FEZZAN",
				SortOrder = 1,
				NumericCode = 10023,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XL",
				Name = "PACIFIC REGION",
				SortOrder = 1,
				NumericCode = 10015,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "EF",
				Name = "EUROPEAN UNION",
				SortOrder = 1,
				NumericCode = 10009,
				ShowInUI = false,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "UK",
				Name = "UNITED KINGDOM OF GREAT BRITAIN AND NORTHERN  IRELAND",
				SortOrder = 1,
				NumericCode = 10017,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "JA",
				Name = "JAMAICA",
				SortOrder = 1,
				NumericCode = 10021,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "DG",
				Name = "DIEGO GARCIA",
				SortOrder = 1,
				NumericCode = 10006,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "XE",
				Name = "AFRICAN REGION",
				SortOrder = 1,
				NumericCode = 10000,
				ShowInUI = true,
				IsActive = false
			},
			new GenericEntity()
			{
				Code = "RH",
				Name = "HAITI",
				SortOrder = 1,
				NumericCode = 10019,
				ShowInUI = true,
				IsActive = false
			}
			};

			var CountriesTable = new ReferenceTable() { 
                TableName = "Countries", 
                ApplicationArea = new List<string> { "product", "location" },
                Items = countries
            };

            return CountriesTable;
        }

		private ReferenceTable IndustryTable()
		{
			var industries = new List<GenericEntity>() {
				new GenericEntity()
					{
						Name = "General",
						Code = "General",
						SortOrder = 1
					},
				new GenericEntity()
				{
					Code = "CPG",
					Name = "CPG",
					SortOrder = 2
				},
				new GenericEntity(){
					Code = "Regulated Healthcare",
					Name = "Regulated Healthcare",
					SortOrder = 3
				},
				new GenericEntity(){
					Code = "Foodservice",
					Name = "Foodservice",
					SortOrder = 5
				},
				new GenericEntity(){
					Code = "Apparel",
					Name = "Apparel",
					SortOrder = 6
				},
				new GenericEntity(){
					Code = "CPG",
					Name = "CPG",
					SortOrder = 8
				},
				new GenericEntity(){
					Code = "Healthcare",
					Name = "Healthcare",
					SortOrder = 9
				},
				new GenericEntity(){
					Code = "Foodservice",
					Name = "Foodservice",
					SortOrder = 10
				}
					};

			var IdustriesTable = new ReferenceTable()
			{
				TableName = "Industries",
				ApplicationArea = new List<string> { "product", "home" },
				Items = industries
			};

			return IdustriesTable;
		}

		private ReferenceTable UofMTable()
		{
			var UOM = new List<GenericEntity>() {
				new GenericEntity() {
			Code = "in",
			Name = "Inches",
			SortOrder = 1
		},
		new GenericEntity() {
			Code = "ft",
			Name = "Feet",
			SortOrder = 2
		},
		new GenericEntity() {
			Code = "mm",
			Name = "Millimeters",
			SortOrder = 3,
		},
		new GenericEntity() {
			Code = "cm",
			Name = "Centimeters",
			SortOrder = 4
		},
		new GenericEntity() {
			Code = "m",
			Name = "Meters",
			SortOrder = 5
		},
		new GenericEntity() {
			Code = "oz",
			Name = "Ounces",
			SortOrder = 1
		},
		new GenericEntity() {
			Code = "lb",
			Name = "Pounds",
			SortOrder = 2
		},
		new GenericEntity() {
			Code = "g",
			Name = "Grams",
			SortOrder = 4
		},
		new GenericEntity() {
			Code = "kg",
			Name = "Kilograms",
			SortOrder = 5
		},
		new GenericEntity() {
			Code = "mg",
			Name = "Milligrams",
			SortOrder = 3
		},
		new GenericEntity() {
			Code = "ton",
			Name = "Short Ton",
			SortOrder = 6
		}
					};

			var UofMTable = new ReferenceTable()
			{
				TableName = "UnitOfMeasure",
				ApplicationArea = new List<string> { "product", "home" },
				Items = UOM
			};

			return UofMTable;
		}
	}
}
