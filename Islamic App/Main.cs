using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MP3Sharp;

namespace Islamic_App
{
    public partial class fmMainMenue : Form
    {
        public fmMainMenue()
        {
            InitializeComponent();
            CustomWindow(Color.FromArgb(128, 255, 128), Color.Black, Color.FromArgb(128, 255, 128), Handle);

        }

        private string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle)
        {
            IntPtr hWnd = handle;
            //Change caption color
            int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
            //Change font color
            int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
            //Change border color
            int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);

        }


        clsPrayerTimesResponse Times = new clsPrayerTimesResponse();
        TimeZoneInfo selectedTimeZone;
        short Seconds, Minutes, Hours;

        private Label[] lbCounters;
        private int[] Counters;

        void GetCountryTime(string country)
        {
            // Dictionary mapping country names to their primary time zone ID
            var countryTimeZones = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Afghanistan", "Afghanistan Standard Time" }, // Kabul
            { "Albania", "Central European Standard Time" }, // Tirana
            { "Algeria", "W. Central Africa Standard Time" }, // Algiers
            { "Andorra", "Central European Standard Time" }, // Andorra la Vella
            { "Angola", "W. Central Africa Standard Time" }, // Luanda
            { "Antigua and Barbuda", "SA Western Standard Time" }, // Saint John's
            { "Argentina", "Argentina Standard Time" }, // Buenos Aires
            { "Armenia", "Caucasus Standard Time" }, // Yerevan
            { "Australia", "AUS Eastern Standard Time" }, // Canberra
            { "Austria", "W. Europe Standard Time" }, // Vienna
            { "Azerbaijan", "Azerbaijan Standard Time" }, // Baku
            { "Bahamas", "Eastern Standard Time" }, // Nassau
            { "Bahrain", "Arabian Standard Time" }, // Manama
            { "Bangladesh", "Bangladesh Standard Time" }, // Dhaka
            { "Barbados", "SA Western Standard Time" }, // Bridgetown
            { "Belarus", "Belarus Standard Time" }, // Minsk
            { "Belgium", "Romance Standard Time" }, // Brussels
            { "Belize", "Central America Standard Time" }, // Belmopan
            { "Benin", "W. Central Africa Standard Time" }, // Porto-Novo
            { "Bhutan", "Bangladesh Standard Time" }, // Thimphu
            { "Bolivia", "SA Western Standard Time" }, // Sucre
            { "Bosnia and Herzegovina", "Central European Standard Time" }, // Sarajevo
            { "Botswana", "South Africa Standard Time" }, // Gaborone
            { "Brazil", "E. South America Standard Time" }, // Brasilia
            { "Brunei", "Singapore Standard Time" }, // Bandar Seri Begawan
            { "Bulgaria", "FLE Standard Time" }, // Sofia
            { "Burkina Faso", "Greenwich Standard Time" }, // Ouagadougou
            { "Burundi", "South Africa Standard Time" }, // Gitega
            { "Cabo Verde", "Cape Verde Standard Time" }, // Praia
            { "Cambodia", "SE Asia Standard Time" }, // Phnom Penh
            { "Cameroon", "W. Central Africa Standard Time" }, // Yaoundé
            { "Canada", "Eastern Standard Time" }, // Ottawa
            { "Central African Republic", "W. Central Africa Standard Time" }, // Bangui
            { "Chad", "W. Central Africa Standard Time" }, // N'Djamena
            { "Chile", "Pacific SA Standard Time" }, // Santiago
            { "China", "China Standard Time" }, // Beijing
            { "Colombia", "SA Pacific Standard Time" }, // Bogotá
            { "Comoros", "E. Africa Standard Time" }, // Moroni
            { "Congo (Congo-Brazzaville)", "W. Central Africa Standard Time" }, // Brazzaville
            { "Costa Rica", "Central America Standard Time" }, // San José
            { "Croatia", "Central European Standard Time" }, // Zagreb
            { "Cuba", "Cuba Standard Time" }, // Havana
            { "Cyprus", "GTB Standard Time" }, // Nicosia
            { "Czech Republic", "Central Europe Standard Time" }, // Prague
            { "Democratic Republic of the Congo", "W. Central Africa Standard Time" }, // Kinshasa
            { "Denmark", "Romance Standard Time" }, // Copenhagen
            { "Djibouti", "E. Africa Standard Time" }, // Djibouti
            { "Dominica", "SA Western Standard Time" }, // Roseau
            { "Dominican Republic", "SA Western Standard Time" }, // Santo Domingo
            { "Ecuador", "SA Pacific Standard Time" }, // Quito
            { "Egypt", "Egypt Standard Time" }, // Cairo
            { "El Salvador", "Central America Standard Time" }, // San Salvador
            { "Equatorial Guinea", "W. Central Africa Standard Time" }, // Malabo
            { "Eritrea", "E. Africa Standard Time" }, // Asmara
            { "Estonia", "FLE Standard Time" }, // Tallinn
            { "Eswatini", "South Africa Standard Time" }, // Mbabane
            { "Ethiopia", "E. Africa Standard Time" }, // Addis Ababa
            { "Fiji", "Fiji Standard Time" }, // Suva
            { "Finland", "FLE Standard Time" }, // Helsinki
            { "France", "Romance Standard Time" }, // Paris
            { "Gabon", "W. Central Africa Standard Time" }, // Libreville
            { "Gambia", "Greenwich Standard Time" }, // Banjul
            { "Georgia", "Georgian Standard Time" }, // Tbilisi
            { "Germany", "W. Europe Standard Time" }, // Berlin
            { "Ghana", "Greenwich Standard Time" }, // Accra
            { "Greece", "GTB Standard Time" }, // Athens
            { "Grenada", "SA Western Standard Time" }, // Saint George's
            { "Guatemala", "Central America Standard Time" }, // Guatemala City
            { "Guinea", "Greenwich Standard Time" }, // Conakry
            { "Guinea-Bissau", "Greenwich Standard Time" }, // Bissau
            { "Guyana", "SA Western Standard Time" }, // Georgetown
            { "Haiti", "SA Western Standard Time" }, // Port-au-Prince
            { "Honduras", "Central America Standard Time" }, // Tegucigalpa
            { "Hungary", "Central Europe Standard Time" }, // Budapest
            { "Iceland", "Greenwich Standard Time" }, // Reykjavik
            { "India", "India Standard Time" }, // New Delhi
            { "Indonesia", "SE Asia Standard Time" }, // Jakarta
            { "Iran", "Iran Standard Time" }, // Tehran
            { "Iraq", "Arabic Standard Time" }, // Baghdad
            { "Ireland", "GMT Standard Time" }, // Dublin
            { "Israel", "Israel Standard Time" }, // Jerusalem
            { "Italy", "W. Europe Standard Time" }, // Rome
            { "Jamaica", "SA Western Standard Time" }, // Kingston
            { "Japan", "Tokyo Standard Time" }, // Tokyo
            { "Jordan", "Jordan Standard Time" }, // Amman
            { "Kazakhstan", "Central Asia Standard Time" }, // Astana
            { "Kenya", "E. Africa Standard Time" }, // Nairobi
            { "Kiribati", "UTC+14" }, // Tarawa
            { "Kuwait", "Arabian Standard Time" }, // Kuwait City
            { "Kyrgyzstan", "Central Asia Standard Time" }, // Bishkek
            { "Laos", "SE Asia Standard Time" }, // Vientiane
            { "Latvia", "FLE Standard Time" }, // Riga
            { "Lebanon", "Middle East Standard Time" }, // Beirut
            { "Lesotho", "South Africa Standard Time" }, // Maseru
            { "Liberia", "Greenwich Standard Time" }, // Monrovia
            { "Libya", "Libya Standard Time" }, // Tripoli
            { "Liechtenstein", "W. Europe Standard Time" }, // Vaduz
            { "Lithuania", "FLE Standard Time" }, // Vilnius
            { "Luxembourg", "W. Europe Standard Time" }, // Luxembourg City
            { "Madagascar", "E. Africa Standard Time" }, // Antananarivo
            { "Malawi", "South Africa Standard Time" }, // Lilongwe
            { "Malaysia", "Singapore Standard Time" }, // Kuala Lumpur
            { "Maldives", "Sri Lanka Standard Time" }, // Malé
            { "Mali", "Greenwich Standard Time" }, // Bamako
            { "Malta", "W. Europe Standard Time" }, // Valletta
            { "Marshall Islands", "UTC+12" }, // Majuro
            { "Mauritania", "Greenwich Standard Time" }, // Nouakchott
            { "Mauritius", "Mauritius Standard Time" }, // Port Louis
            { "Mexico", "Central Standard Time (Mexico)" }, // Mexico City
            { "Micronesia", "UTC+10" }, // Palikir
            { "Moldova", "GTB Standard Time" }, // Chișinău
            { "Monaco", "W. Europe Standard Time" }, // Monaco
            { "Mongolia", "Ulaanbaatar Standard Time" }, // Ulaanbaatar
            { "Montenegro", "Central European Standard Time" }, // Podgorica
            { "Morocco", "Morocco Standard Time" }, // Rabat
            { "Mozambique", "South Africa Standard Time" }, // Maputo
            { "Myanmar (formerly Burma)", "Myanmar Standard Time" }, // Naypyidaw
            { "Namibia", "Namibia Standard Time" }, // Windhoek
            { "Nauru", "UTC+12" }, // Yaren
            { "Nepal", "Nepal Standard Time" }, // Kathmandu
            { "Netherlands", "W. Europe Standard Time" }, // Amsterdam
            { "New Zealand", "New Zealand Standard Time" }, // Wellington
            { "Nicaragua", "Central America Standard Time" }, // Managua
            { "Niger", "W. Central Africa Standard Time" }, // Niamey
            { "Nigeria", "W. Central Africa Standard Time" }, // Abuja
            { "North Korea", "Korea Standard Time" }, // Pyongyang
            { "North Macedonia", "Central European Standard Time" }, // Skopje
            { "Norway", "W. Europe Standard Time" }, // Oslo
            { "Oman", "Arabian Standard Time" }, // Muscat
            { "Pakistan", "Pakistan Standard Time" }, // Islamabad
            { "Palau", "Tokyo Standard Time" }, // Ngerulmud
            { "Palestine State", "Jerusalem Standard Time" }, // East Jerusalem
            { "Panama", "SA Pacific Standard Time" }, // Panama City
            { "Papua New Guinea", "West Pacific Standard Time" }, // Port Moresby
            { "Paraguay", "Paraguay Standard Time" }, // Asunción
            { "Peru", "SA Pacific Standard Time" }, // Lima
            { "Philippines", "Singapore Standard Time" }, // Manila
            { "Poland", "Central European Standard Time" }, // Warsaw
            { "Portugal", "GMT Standard Time" }, // Lisbon
            { "Qatar", "Arabian Standard Time" }, // Doha
            { "Romania", "GTB Standard Time" }, // Bucharest
            { "Russia", "Russian Standard Time" }, // Moscow
            { "Rwanda", "South Africa Standard Time" }, // Kigali
            { "Saint Kitts and Nevis", "SA Western Standard Time" }, // Basseterre
            { "Saint Lucia", "SA Western Standard Time" }, // Castries
            { "Saint Vincent and the Grenadines", "SA Western Standard Time" }, // Kingstown
            { "Samoa", "UTC+13" }, // Apia
            { "San Marino", "W. Europe Standard Time" }, // San Marino
            { "Sao Tome and Principe", "Greenwich Standard Time" }, // São Tomé
            { "Saudi Arabia", "Arabian Standard Time" }, // Riyadh
            { "Senegal", "Greenwich Standard Time" }, // Dakar
            { "Serbia", "Central European Standard Time" }, // Belgrade
            { "Seychelles", "Mauritius Standard Time" }, // Victoria
            { "Sierra Leone", "Greenwich Standard Time" }, // Freetown
            { "Singapore", "Singapore Standard Time" }, // Singapore
            { "Slovakia", "Central European Standard Time" }, // Bratislava
            { "Slovenia", "Central European Standard Time" }, // Ljubljana
            { "Solomon Islands", "UTC+11" }, // Honiara
            { "Somalia", "E. Africa Standard Time" }, // Mogadishu
            { "South Africa", "South Africa Standard Time" }, // Pretoria
            { "South Korea", "Korea Standard Time" }, // Seoul
            { "South Sudan", "E. Africa Standard Time" }, // Juba
            { "Spain", "Romance Standard Time" }, // Madrid
            { "Sri Lanka", "Sri Lanka Standard Time" }, // Sri Jayawardenepura Kotte
            { "Sudan", "E. Africa Standard Time" }, // Khartoum
            { "Suriname", "SA Eastern Standard Time" }, // Paramaribo
            { "Sweden", "W. Europe Standard Time" }, // Stockholm
            { "Switzerland", "W. Europe Standard Time" }, // Bern
            { "Syria", "Syria Standard Time" }, // Damascus
            { "Tajikistan", "West Asia Standard Time" }, // Dushanbe
            { "Tanzania", "E. Africa Standard Time" }, // Dodoma
            { "Thailand", "SE Asia Standard Time" }, // Bangkok
            { "Timor-Leste", "Tokyo Standard Time" }, // Dili
            { "Togo", "Greenwich Standard Time" }, // Lomé
            { "Tonga", "Tonga Standard Time" }, // Nuku'alofa
            { "Trinidad and Tobago", "SA Western Standard Time" }, // Port of Spain
            { "Tunisia", "W. Central Africa Standard Time" }, // Tunis
            { "Turkey", "Turkey Standard Time" }, // Ankara
            { "Turkmenistan", "West Asia Standard Time" }, // Ashgabat
            { "Tuvalu", "UTC+12" }, // Funafuti
            { "Uganda", "E. Africa Standard Time" }, // Kampala
            { "Ukraine", "FLE Standard Time" }, // Kyiv
            { "United Arab Emirates", "Arabian Standard Time" }, // Abu Dhabi
            { "United Kingdom", "GMT Standard Time" }, // London
            { "United States", "Eastern Standard Time" }, // Washington, D.C.
            { "Uruguay", "Montevideo Standard Time" }, // Montevideo
            { "Uzbekistan", "West Asia Standard Time" }, // Tashkent
            { "Vanuatu", "UTC+11" }, // Port Vila
            { "Vatican City", "W. Europe Standard Time" }, // Vatican City
            { "Venezuela", "Venezuela Standard Time" }, // Caracas
            { "Vietnam", "SE Asia Standard Time" }, // Hanoi
            { "Yemen", "Arabian Standard Time" }, // Sana'a
            { "Zambia", "South Africa Standard Time" }, // Lusaka
            { "Zimbabwe", "South Africa Standard Time" } // Harare
        };

            // Check if the country exists in the dictionary
            if (countryTimeZones.TryGetValue(country, out string timeZoneId))
                    selectedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                
        }

        private async void ShowErrorMessage(string message)
        {
            lblMessage.Visible = true; // Ensure the label is visible at the start
            lblMessage.Text = ""; // Clear the label

            // Show the message character by character
            foreach (char c in message.Trim())
            {
                lblMessage.Text += c;
                await Task.Delay(40); // Adjust the delay as needed
            }

            // Blink the message 10 times
            for (int i = 0; i < 10; i++)
            {
                lblMessage.Visible = !lblMessage.Visible; // Toggle visibility
                await Task.Delay(500); // 800ms delay between visibility toggles
            }

            // Make sure the label is visible at the end
            lblMessage.Visible = false;
        }

        private void FillComboBox()
        {
            foreach (string s in clsPrayerTimesResponse.countryCapitals.Keys)
            {
                CmbCountries.Items.Add(s);
            }
        }
        private async void frmPrayerTime_Load(object sender, EventArgs e)
        {
            CmbCountries.Visible = false;
            FillComboBox();

            lbCounters = new Label[] {lbCounter1 ,  lbCounter2 , lbCounter3 , lbCounter4 , lbCounter5 , lbCounter6 , lbCounter7 , lbCounter8 , lbCounter9 , lbCounter10 , lbCounter11 , lbCounter12};
            Counters = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            

            if (await clsPrayerTimesResponse.IsConnectedToInternet())
            {
                await clsPrayerTimesResponse.GetPrayingResponse();
                lblCountry.Text = "Country : " + clsPrayerTimesResponse.Ip.country;
                FillFormLabels();
                GetCountryTime(clsPrayerTimesResponse.Ip.country);
                lbCurrentTime.Text = TimeZoneInfo.ConvertTime(DateTime.Now, selectedTimeZone).ToString("HH:mm:ss");
                TimeNow.Start();
                
                SetNextPrayer();

            }
            else
            {

                if (!File.Exists(clsPrayerTimesResponse.JsonFile))
                {
                    ShowErrorMessage("You Are Ofline....Connect To Internt Access Data");
                    
                }
                else
                {

                    clsPrayerTimesResponse.GetOflinePrayingResponse();
                    lblCountry.Text = "Country : " + clsIPInfo.OflineCountry;
                    GetCountryTime(clsIPInfo.OflineCountry);
                    FillFormLabels();
                    lbCurrentTime.Text = TimeZoneInfo.ConvertTime(DateTime.Now, selectedTimeZone).ToString("HH:mm:ss");
                    TimeNow.Start();
                    
                    SetNextPrayer();
                    //MessageBox.Show("You Are Ofline....This Data is not Acurate ");
                    ShowErrorMessage("You Are Ofline....This Data is not Acurate ");
                }
            }
        }

        private void FillFormLabels()
        {
            Times = clsPrayerTimesResponse.prayerTimesResponse;


            lblFajer.Text = Times.Data.Timings.Fajr;
            lblDoher.Text = Times.Data.Timings.Dhuhr;
            lblAser.Text = Times.Data.Timings.Asr;
            lblMagrib.Text = Times.Data.Timings.Maghrib;
            lblIcha.Text = Times.Data.Timings.Isha;

            

        }

        private void chkCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCountry.Checked)
            {
                CmbCountries.Visible = true;
            }
            else
            {
                CmbCountries.Visible = false;
                clsPrayerTimesResponse.GetOflinePrayingResponse();
                lblCountry.Text = "Country : " + clsIPInfo.OflineCountry;
                FillFormLabels();
                GetCountryTime(clsIPInfo.OflineCountry);
                lbCurrentTime.Text = TimeZoneInfo.ConvertTime(DateTime.Now, selectedTimeZone).ToString("HH:mm:ss");
                SetNextPrayer();
            }
        }

        private async void CmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Country = CmbCountries.SelectedItem.ToString().Trim();
            string City = clsPrayerTimesResponse.countryCapitals[Country].Trim();

            if (await clsPrayerTimesResponse.IsConnectedToInternet())
            {
                await clsPrayerTimesResponse.GetPrayingResponse(City, Country);
                lblCountry.Text = "Country : " + Country;
                FillFormLabels();
                GetCountryTime(Country);
                lbCurrentTime.Text = TimeZoneInfo.ConvertTime(DateTime.Now, selectedTimeZone).ToString("HH:mm:ss");
                SetNextPrayer();


            }
            else
            {
                ShowErrorMessage("You Are Ofline.... ");
                // MessageBox.Show("You Are Ofline.... ");
            }
        }


        void ResetButton(Guna2Button Btn , Color color)
        {
            Btn.ForeColor = Color.FromArgb(0, 192, 0);
            Btn.FillColor = color;
            Btn.Checked = false;
        }

        void Reset()
        {
            ResetButton(btnMainMenue , Color.FromArgb(33, 42, 59));
            ResetButton(btnPrayers , Color.FromArgb(33, 42, 59));
            ResetButton(btnAdkar , Color.FromArgb(33, 42, 59));
            ResetButton(btnTasbih, Color.FromArgb(33, 42, 59));
            ResetButton(btnSpecial, Color.FromArgb(33, 42, 59));
        }

        void PerformClick(Guna2Button Btn)
        {
            Btn.ForeColor = Color.FromArgb(33, 42, 59);
            Btn.FillColor = Color.FromArgb(0, 192, 0);
            Btn.Checked = true;
        }

        private void btnMenue_Click(object sender, EventArgs e)
        {
            Reset();

            PerformClick(sender as Guna2Button);

            if (btnMainMenue.Checked)
            {
                tbcScreens.SelectedIndex = 0;
                return;
            }

            if (btnPrayers.Checked)
            {
                tbcScreens.SelectedIndex = 1;
                return;
            }

            if (btnAdkar.Checked)
            {
                tbcScreens.SelectedIndex = 2;
                return;
            }

            if (btnTasbih.Checked)
            {
                tbcScreens.SelectedIndex = 3;
                return;
            }

            if (btnSpecial.Checked)
            {
                tbcScreens.SelectedIndex = 4;
                return;
            }
        }

        private void TimeNow_Tick(object sender, EventArgs e)
        {
            lbCurrentTime.Text = TimeZoneInfo.ConvertTime(DateTime.Now, selectedTimeZone).ToString("HH:mm:ss");

        }

        private void RemainingTime_Tick(object sender, EventArgs e)
        {
            lbRemainigTime.Text = Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00");

            if (Seconds == 0)
            {
                if (Minutes == 0)
                {
                    if (Hours == 0)
                    {
                        RemainingTime.Stop();
                        PrayerTime.BalloonTipText = lbNextPrayer.Text;
                        PrayerTime.ShowBalloonTip(1000);
                    }

                    else
                    {
                        Hours--;
                        Minutes = 59;
                        Seconds = 59;
                    }
                }

                else
                {
                    Minutes--;
                    Seconds = 59;
                }
            }

            else
                Seconds--;

        }

        private void PrayerTime_BalloonTipShown(object sender, EventArgs e)
        {
            SetNextPrayer();
            RemainingTime.Start();
        }

        void SetNextPrayer()
        {
            if (Convert.ToDateTime(lbCurrentTime.Text) > Convert.ToDateTime(lblIcha.Text))
            {
                lbNextPrayer.Text = "الفجر";
                SetReaminingTime(SetRemainingTimeSpecialCase());
                return;
            }

            if (Convert.ToDateTime(lbCurrentTime.Text) > Convert.ToDateTime(lblFajer.Text))
            {
                if (Convert.ToDateTime(lbCurrentTime.Text) > Convert.ToDateTime(lblDoher.Text))
                {
                    if (Convert.ToDateTime(lbCurrentTime.Text) > Convert.ToDateTime(lblAser.Text))
                    {
                        if (Convert.ToDateTime(lbCurrentTime.Text) > Convert.ToDateTime(lblMagrib.Text))
                        {
                            SetReaminingTime(Convert.ToDateTime(lblIcha.Text).Subtract(Convert.ToDateTime(lbCurrentTime.Text)));
                            lbNextPrayer.Text = "العشاء";
                        }
                        
                        else
                        {
                            SetReaminingTime(Convert.ToDateTime(lblMagrib.Text).Subtract(Convert.ToDateTime(lbCurrentTime.Text)));
                            lbNextPrayer.Text = "المغرب";
                        }
                    }

                    else
                    {
                        SetReaminingTime(Convert.ToDateTime(lblAser.Text).Subtract(Convert.ToDateTime(lbCurrentTime.Text)));
                        lbNextPrayer.Text = "العصر";
                    }
                        
                }

                else
                {
                    SetReaminingTime(Convert.ToDateTime(lblDoher.Text).Subtract(Convert.ToDateTime(lbCurrentTime.Text)));
                    lbNextPrayer.Text = "الظهر";
                }
                    

            }

            else
            {
                lbNextPrayer.Text = "الفجر";
                SetReaminingTime(Convert.ToDateTime(lblFajer.Text).Subtract(Convert.ToDateTime(lbCurrentTime.Text)));
            }
               
        }

        void PerfromClick(Guna2Button btn)
        {
            btn.Checked = true;
            btn.FillColor = Color.FromArgb(0, 192, 0);
            btn.ForeColor = Color.FromArgb(192, 255, 192);
        }

        void ResetClick(Guna2Button btn)
        {
            btn.Checked = false;
            btn.FillColor = Color.FromArgb(192, 255, 192);
            btn.ForeColor = Color.FromArgb(0, 192, 0);
        }

        private void AdkarBtns_Click(object sender, EventArgs e)
        {
            PerfromClick(sender as Guna2Button);

            if (sender == btnNightAdkars)
            {
                fmNightAdkars NightAdkars = new fmNightAdkars();
                NightAdkars.ShowDialog();

                ResetClick(btnNightAdkars);
                return;
            }

            if (sender == btnMorningAdkars)
            {
                fmMorningAdkars MorningAdkars = new fmMorningAdkars();
                MorningAdkars.ShowDialog();

                ResetClick(btnMorningAdkars);
                return;
            }

            if (sender == btnAfternoonAdkars)
            {
                fmAfternoonAdkars AfternoonAdkars = new fmAfternoonAdkars();
                AfternoonAdkars.ShowDialog();

                ResetClick(btnAfternoonAdkars);
                return;
            }

            if (sender == btnPrayerAfterAdkars)
            {
                fmPrayserAfterAdkars PrayserAfterAdkars = new fmPrayserAfterAdkars();
                PrayserAfterAdkars.ShowDialog();

                ResetClick(btnPrayerAfterAdkars);
                return;
            }

            if (sender == btnPrayerAdkars)
            {
                fmPrayerAdkar PrayerAdkar = new fmPrayerAdkar();
                PrayerAdkar.ShowDialog();

                ResetClick(btnPrayerAdkars);
                return;
            }

            if (sender == btnEnd)
            {
                fmEnd End = new fmEnd();
                End.ShowDialog();

                ResetClick(btnEnd);
                return;
            }
        }

        void Add(int Index)
        {
            Counters[Index]++;
            lbCounters[Index].Text = Counters[Index].ToString();

            if (lbCounters[Index].Text == "100")
            {
                MessageBox.Show("Congratulations! You have completed 100 successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset(Index);
            }
        }

        void Reset(int Index)
        {
            Counters[Index] = 0;
            lbCounters[Index].Text = Counters[Index].ToString();
        }

        private void Praise_Click(object sender, EventArgs e)
        {
            Guna2ImageButton Btn = sender as Guna2ImageButton;

            int Index = Convert.ToInt32(Btn.Tag.ToString());

            Add(Index);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Guna2ImageButton Btn = sender as Guna2ImageButton;

            int Index = Convert.ToInt32(Btn.Tag.ToString());

            Reset(Index);
        }

        Guna2Button LastBtn = null;
        SoundPlayer Player;
        bool IsPlay = false;

        private void btnSpecialSCreen_Click(object sender, EventArgs e)
        {
            if (IsPlay)
            {
                Player.Stop();
                IsPlay = false;
            }
                

            if (LastBtn != null)
                ResetButton(LastBtn , Color.FromArgb(192, 255, 192));

            Guna2Button Btn = sender as Guna2Button;
            LastBtn = Btn;
            PerformClick(Btn);
            

            if (Btn == btn1)
            {
                Player = new SoundPlayer("First.wav");
                Player.Play();
                IsPlay = true;
                return;
            }

            if (Btn == btn3)
            {
                Player = new SoundPlayer("Second.wav");
                IsPlay = true;
                Player.Play();
                return;
            }

            if (Btn == btn4)
            {
                Player = new SoundPlayer("Third.wav");
                Player.Play();
                IsPlay = true;
                return;
            }
        }

        TimeSpan SetRemainingTimeSpecialCase()
        {
            TimeSpan Remain = Convert.ToDateTime("23:59:59").Subtract(Convert.ToDateTime(lbCurrentTime.Text));

            TimeSpan Current = Convert.ToDateTime(lblFajer.Text).Subtract(Convert.ToDateTime("00:00:00"));

            return Current.Add(Remain) ;
        }

        void SetReaminingTime(TimeSpan FullTime)
        {

            Seconds = Convert.ToInt16(FullTime.Seconds);
            Minutes = Convert.ToInt16(FullTime.Minutes);
            Hours = Convert.ToInt16(FullTime.Hours);

            lbRemainigTime.Text = Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00");

            RemainingTime.Start();
        }


    }
}

