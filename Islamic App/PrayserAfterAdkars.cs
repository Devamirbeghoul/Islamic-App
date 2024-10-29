using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Islamic_App
{
    public partial class fmPrayserAfterAdkars : Form
    {
        public fmPrayserAfterAdkars()
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

        private void fmPrayserAfterAdkars_Load(object sender, EventArgs e)
        {
            tbAdkars.Text = "قراءة سورة الإخلاص، والمعوذتين (سورة الفلق وسورة الناس). قراءة آية الكرسي. (اللَّهُمَّ أَنْتَ السَّلَامُ وَمِنْكَ السَّلَامُ، تَبَارَكْتَ ذَا الجَلَالِ وَالإِكْرَامِ)،[٢] مرة واحدة. (لا إلَهَ إلَّا اللَّهُ وَحْدَهُ لا شَرِيكَ له، له المُلْكُ وَلَهُ الحَمْدُ وَهو علَى كُلِّ شيءٍ قَدِيرٌ، اللَّهُمَّ لا مَانِعَ لِما أَعْطَيْتَ، وَلَا مُعْطِيَ لِما مَنَعْتَ، وَلَا يَنْفَعُ ذَا الجَدِّ مِنْكَ الجَدُّ)،[٣] مرة واحدة. (لا إلَهَ إلَّا اللَّهُ وَحْدَهُ لا شَرِيكَ له، له المُلْكُ وَلَهُ الحَمْدُ وَهو علَى كُلِّ شيءٍ قَدِيرٌ، لا حَوْلَ وَلَا قُوَّةَ إلَّا باللَّهِ، لا إلَهَ إلَّا اللَّهُ، وَلَا نَعْبُدُ إلَّا إيَّاهُ، له النِّعْمَةُ وَلَهُ الفَضْلُ، وَلَهُ الثَّنَاءُ الحَسَنُ، لا إلَهَ إلَّا اللَّهُ مُخْلِصِينَ له الدِّينَ ولو كَرِهَ الكَافِرُونَ)،[٤] مرو واحدة. قال رسول الله: (مَن سَبَّحَ اللَّهَ في دُبُرِ كُلِّ صَلاةٍ ثَلاثًا وثَلاثِينَ، وحَمِدَ اللَّهَ ثَلاثًا وثَلاثِينَ، وكَبَّرَ اللَّهَ ثَلاثًا وثَلاثِينَ، فَتْلِكَ تِسْعَةٌ وتِسْعُونَ، وقالَ: تَمامَ المِئَةِ: لا إلَهَ إلَّا اللَّهُ وحْدَهُ لا شَرِيكَ له، له المُلْكُ وله الحَمْدُ وهو علَى كُلِّ شيءٍ قَدِيرٌ غُفِرَتْ خَطاياهُ وإنْ كانَتْ مِثْلَ زَبَدِ البَحْرِ).[٥] (مُعَقِّباتٌ لا يَخِيبُ قائِلُهُنَّ، أوْ فاعِلُهُنَّ، ثَلاثٌ وثَلاثُونَ تَسْبِيحَةً، وثَلاثٌ وثَلاثُونَ تَحْمِيدَةً، وأَرْبَعٌ وثَلاثُونَ تَكْبِيرَةً، في دُبُرِ كُلِّ صَلاةٍ).[٦] (يسبِّحُ أحدُكُم في دُبِرِ كلِّ صلاةٍ عشرًا ويحمَدُ عشرًا ويُكبِّرُ عشرًا فَهيَ خمسونَ ومائةٌ في اللِّسانِ وألفٌ وخَمسمائةٍ في الميزانِ).[٧]";

        }
    }
}
