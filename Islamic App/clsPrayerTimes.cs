using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


public class clsIPInfo
{

    public string country { get; set; }

    public string city { get; set; }


    public static string IpFile = "IpFile.txt";




    public clsIPInfo(string city, string country)
    {
        this.city = city;
        this.country = country;
    }
    public static string OflineCountry;
}

public class clsPrayerTimesResponse
{
    public static string JsonFile = "LastPrayerData.json";

    public PrayerTimesData Data { get; set; }

    public static clsIPInfo Ip { get; set; }

    public static clsPrayerTimesResponse prayerTimesResponse { get; set; }

    private static readonly HttpClient client = new HttpClient();
    public static async Task<bool> IsConnectedToInternet()
    {
        try
        {
            // Send a request to the IP API
            string ipApiUrl = "http://ip-api.com/json/";
            var response = await client.GetAsync(ipApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var ipResponse = await client.GetStringAsync(ipApiUrl);
                var ipInfo = JsonConvert.DeserializeObject<clsIPInfo>(ipResponse);

                Ip = new clsIPInfo(ipInfo.city, ipInfo.country);
                File.WriteAllText(clsIPInfo.IpFile, ipInfo.country);
                return true;

            }
            else
            {
                Ip = null;
                return false;
            }
        }
        catch (HttpRequestException)
        {
            // If there is an exception, assume no internet connection
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    public static async Task GetPrayingResponse()
    {
        try
        {
            string prayerApiUrl = $"https://api.aladhan.com/v1/timingsByCity?city={Ip.city}&country={Ip.country}&method=2";

            var prayerResponse = await client.GetStringAsync(prayerApiUrl);


            clsPrayerTimesResponse prayerTimes = JsonConvert.DeserializeObject<clsPrayerTimesResponse>(prayerResponse);


            prayerTimesResponse = prayerTimes;
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show($"Request error: {e.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unexpected error: {ex.Message}");
        }
        SaveData();
    }

    public static async Task GetPrayingResponse(string City, string Country)
    {
        try
        {
            string prayerApiUrl = $"https://api.aladhan.com/v1/timingsByCity?city={City}&country={Country}&method=2";

            var prayerResponse = await client.GetStringAsync(prayerApiUrl);


            clsPrayerTimesResponse prayerTimes = JsonConvert.DeserializeObject<clsPrayerTimesResponse>(prayerResponse);

            prayerTimesResponse = prayerTimes;
        }
        catch (HttpRequestException e)
        {
            MessageBox.Show($"Request error: {e.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unexpected error: {ex.Message}");
        }


    }
    public static void GetOflinePrayingResponse()
    {
        try
        {
            if (!File.Exists(JsonFile) || !File.Exists(clsIPInfo.IpFile))
            {
                MessageBox.Show("Ofline BackUp file Not Foundd...");
                return;
            }
            string JsonData = File.ReadAllText(JsonFile);

            prayerTimesResponse = JsonConvert.DeserializeObject<clsPrayerTimesResponse>(JsonData);

            clsIPInfo.OflineCountry = File.ReadAllText(clsIPInfo.IpFile);

        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show($"Unexpected error: {ex.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unexpected error: {ex.Message}");
        }

    }

    private static void SaveData()
    {
        string jsonData = JsonConvert.SerializeObject(prayerTimesResponse);
        File.WriteAllText(JsonFile, jsonData);
    }

    public static Dictionary<string, string> countryCapitals = new Dictionary<string, string>
        {
            { "Afghanistan", "Kabul" },
            { "Albania", "Tirana" },
            { "Algeria", "Algiers" },
            { "Andorra", "Andorra la Vella" },
            { "Angola", "Luanda" },
            { "Antigua and Barbuda", "Saint John's" },
            { "Argentina", "Buenos Aires" },
            { "Armenia", "Yerevan" },
            { "Australia", "Canberra" },
            { "Austria", "Vienna" },
            { "Azerbaijan", "Baku" },
            { "Bahamas", "Nassau" },
            { "Bahrain", "Manama" },
            { "Bangladesh", "Dhaka" },
            { "Barbados", "Bridgetown" },
            { "Belarus", "Minsk" },
            { "Belgium", "Brussels" },
            { "Belize", "Belmopan" },
            { "Benin", "Porto-Novo" },
            { "Bhutan", "Thimphu" },
            { "Bolivia", "Sucre" }, // La Paz is the seat of government
            { "Bosnia and Herzegovina", "Sarajevo" },
            { "Botswana", "Gaborone" },
            { "Brazil", "Brasilia" },
            { "Brunei", "Bandar Seri Begawan" },
            { "Bulgaria", "Sofia" },
            { "Burkina Faso", "Ouagadougou" },
            { "Burundi", "Gitega" },
            { "Cabo Verde", "Praia" },
            { "Cambodia", "Phnom Penh" },
            { "Cameroon", "Yaoundé" },
            { "Canada", "Ottawa" },
            { "Central African Republic", "Bangui" },
            { "Chad", "N'Djamena" },
            { "Chile", "Santiago" },
            { "China", "Beijing" },
            { "Colombia", "Bogotá" },
            { "Comoros", "Moroni" },
            { "Congo (Congo-Brazzaville)", "Brazzaville" },
            { "Costa Rica", "San José" },
            { "Croatia", "Zagreb" },
            { "Cuba", "Havana" },
            { "Cyprus", "Nicosia" },
            { "Czech Republic", "Prague" },
            { "Democratic Republic of the Congo", "Kinshasa" },
            { "Denmark", "Copenhagen" },
            { "Djibouti", "Djibouti" },
            { "Dominica", "Roseau" },
            { "Dominican Republic", "Santo Domingo" },
            { "Ecuador", "Quito" },
            { "Egypt", "Cairo" },
            { "El Salvador", "San Salvador" },
            { "Equatorial Guinea", "Malabo" },
            { "Eritrea", "Asmara" },
            { "Estonia", "Tallinn" },
            { "Eswatini", "Mbabane" }, // Mbabane is administrative capital; Lobamba is legislative capital
            { "Ethiopia", "Addis Ababa" },
            { "Fiji", "Suva" },
            { "Finland", "Helsinki" },
            { "France", "Paris" },
            { "Gabon", "Libreville" },
            { "Gambia", "Banjul" },
            { "Georgia", "Tbilisi" },
            { "Germany", "Berlin" },
            { "Ghana", "Accra" },
            { "Greece", "Athens" },
            { "Grenada", "Saint George's" },
            { "Guatemala", "Guatemala City" },
            { "Guinea", "Conakry" },
            { "Guinea-Bissau", "Bissau" },
            { "Guyana", "Georgetown" },
            { "Haiti", "Port-au-Prince" },
            { "Honduras", "Tegucigalpa" },
            { "Hungary", "Budapest" },
            { "Iceland", "Reykjavik" },
            { "India", "New Delhi" },
            { "Indonesia", "Jakarta" },
            { "Iran", "Tehran" },
            { "Iraq", "Baghdad" },
            { "Ireland", "Dublin" },
            { "Israel", "Jerusalem" },
            { "Italy", "Rome" },
            { "Jamaica", "Kingston" },
            { "Japan", "Tokyo" },
            { "Jordan", "Amman" },
            { "Kazakhstan", "Astana" }, // Nur-Sultan is the capital
            { "Kenya", "Nairobi" },
            { "Kiribati", "Tarawa" },
            { "Kuwait", "Kuwait City" },
            { "Kyrgyzstan", "Bishkek" },
            { "Laos", "Vientiane" },
            { "Latvia", "Riga" },
            { "Lebanon", "Beirut" },
            { "Lesotho", "Maseru" },
            { "Liberia", "Monrovia" },
            { "Libya", "Tripoli" },
            { "Liechtenstein", "Vaduz" },
            { "Lithuania", "Vilnius" },
            { "Luxembourg", "Luxembourg City" },
            { "Madagascar", "Antananarivo" },
            { "Malawi", "Lilongwe" },
            { "Malaysia", "Kuala Lumpur" },
            { "Maldives", "Malé" },
            { "Mali", "Bamako" },
            { "Malta", "Valletta" },
            { "Marshall Islands", "Majuro" },
            { "Mauritania", "Nouakchott" },
            { "Mauritius", "Port Louis" },
            { "Mexico", "Mexico City" },
            { "Micronesia", "Palikir" },
            { "Moldova", "Chișinău" },
            { "Monaco", "Monaco" },
            { "Mongolia", "Ulaanbaatar" },
            { "Montenegro", "Podgorica" },
            { "Morocco", "Rabat" },
            { "Mozambique", "Maputo" },
            { "Myanmar (formerly Burma)", "Naypyidaw" },
            { "Namibia", "Windhoek" },
            { "Nauru", "Yaren District" }, // No official capital
            { "Nepal", "Kathmandu" },
            { "Netherlands", "Amsterdam" },
            { "New Zealand", "Wellington" },
            { "Nicaragua", "Managua" },
            { "Niger", "Niamey" },
            { "Nigeria", "Abuja" },
            { "North Korea", "Pyongyang" },
            { "North Macedonia", "Skopje" },
            { "Norway", "Oslo" },
            { "Oman", "Muscat" },
            { "Pakistan", "Islamabad" },
            { "Palau", "Ngerulmud" },
            { "Palestine State", "East Jerusalem" },
            { "Panama", "Panama City" },
            { "Papua New Guinea", "Port Moresby" },
            { "Paraguay", "Asunción" },
            { "Peru", "Lima" },
            { "Philippines", "Manila" },
            { "Poland", "Warsaw" },
            { "Portugal", "Lisbon" },
            { "Qatar", "Doha" },
            { "Romania", "Bucharest" },
            { "Russia", "Moscow" },
            { "Rwanda", "Kigali" },
            { "Saint Kitts and Nevis", "Basseterre" },
            { "Saint Lucia", "Castries" },
            { "Saint Vincent and the Grenadines", "Kingstown" },
            { "Samoa", "Apia" },
            { "San Marino", "San Marino" },
            { "Sao Tome and Principe", "São Tomé" },
            { "Saudi Arabia", "Riyadh" },
            { "Senegal", "Dakar" },
            { "Serbia", "Belgrade" },
            { "Seychelles", "Victoria" },
            { "Sierra Leone", "Freetown" },
            { "Singapore", "Singapore" },
            { "Slovakia", "Bratislava" },
            { "Slovenia", "Ljubljana" },
            { "Solomon Islands", "Honiara" },
            { "Somalia", "Mogadishu" },
            { "South Africa", "Pretoria" }, // Administrative; Cape Town (legislative); Bloemfontein (judicial)
            { "South Korea", "Seoul" },
            { "South Sudan", "Juba" },
            { "Spain", "Madrid" },
            { "Sri Lanka", "Sri Jayawardenepura Kotte" }, // Administrative; Colombo (commercial)
            { "Sudan", "Khartoum" },
            { "Suriname", "Paramaribo" },
            { "Sweden", "Stockholm" },
            { "Switzerland", "Bern" },
            { "Syria", "Damascus" },
            { "Tajikistan", "Dushanbe" },
            { "Tanzania", "Dodoma" },
            { "Thailand", "Bangkok" },
            { "Timor-Leste", "Dili" },
            { "Togo", "Lomé" },
            { "Tonga", "Nuku'alofa" },
            { "Trinidad and Tobago", "Port of Spain" },
            { "Tunisia", "Tunis" },
            { "Turkey", "Ankara" },
            { "Turkmenistan", "Ashgabat" },
            { "Tuvalu", "Funafuti" },
            { "Uganda", "Kampala" },
            { "Ukraine", "Kyiv" },
            { "United Arab Emirates", "Abu Dhabi" },
            { "United Kingdom", "London" },
            { "United States", "Washington, D.C." },
            { "Uruguay", "Montevideo" },
            { "Uzbekistan", "Tashkent" },
            { "Vanuatu", "Port Vila" },
            { "Vatican City", "Vatican City" },
            { "Venezuela", "Caracas" },
            { "Vietnam", "Hanoi" },
            { "Yemen", "Sana'a" },
            { "Zambia", "Lusaka" },
            { "Zimbabwe", "Harare" }
    };

    

}

public class PrayerTimesData
{
    public Timings Timings { get; set; }
    public Date Date { get; set; }
}

public class Timings
{
    public string Fajr { get; set; }
    public string Sunrise { get; set; }
    public string Dhuhr { get; set; }
    public string Asr { get; set; }
    public string Maghrib { get; set; }
    public string Isha { get; set; }
}

public class Date
{
    public Hijri Hijri { get; set; }
    public Gregorian Gregorian { get; set; }
}

public class Hijri
{
    public string Date { get; set; } // Hijri date in DD-MM-YYYY format
    public Weekday Weekday { get; set; }
    public Month Month { get; set; }
    public string Year { get; set; }
}

public class Gregorian
{
    public string Date { get; set; } // Gregorian date in DD-MM-YYYY format

    public Month Month { get; set; }
    public string Year { get; set; }
}

public class Weekday
{
    public string En { get; set; }
    public string Ar { get; set; }
}

public class Month
{
    public int Number { get; set; }
    public string En { get; set; }
    public string Ar { get; set; }
}


