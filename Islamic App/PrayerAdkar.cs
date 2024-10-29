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
    public partial class fmPrayerAdkar : Form
    {
        public fmPrayerAdkar()
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

        private void fmPrayerAdkar_Load(object sender, EventArgs e)
        {
            tbAdkars.Text = "يستطيع المسلم أن يختار من هذه الأدعية عند الاستفتاح -أي بعد تكبيرة الإحرام وقبل قراءة الفاتحة-، ومن أدعية استفتاح الصلاة ما يأتي: (كان النبيَّ -صلَّى اللهُ عليه وسلَّم- إذا افتتح الصلاةَ قال: سبحانك اللَّهُمََّ وبحَمْدِك، وتبارك اسمُك، وتعالى جَدُّك، ولا إلهَ غَيرُك).[١] (كانَ رَسولُ اللَّهِ -صَلَّى اللهُ عليه وسلَّم- يَسْكُتُ بيْنَ التَّكْبِيرِ وبيْنَ القِرَاءَةِ إسْكَاتَةً -قالَ أَحْسِبُهُ قالَ: هُنَيَّةً- فَقُلتُ: بأَبِي وأُمِّي يا رَسولَ اللَّهِ، إسْكَاتُكَ بيْنَ التَّكْبِيرِ والقِرَاءَةِ ما تَقُولُ؟ قالَ: أَقُولُ: اللَّهُمَّ بَاعِدْ بَيْنِي وبيْنَ خَطَايَايَ، كما بَاعَدْتَ بيْنَ المَشْرِقِ والمَغْرِبِ، اللَّهُمَّ نَقِّنِي مِنَ الخَطَايَا كما يُنَقَّى الثَّوْبُ الأبْيَضُ مِنَ الدَّنَسِ، اللَّهُمَّ اغْسِلْ خَطَايَايَ بالمَاءِ والثَّلْجِ والبَرَدِ).[٢] (وَجَّهْتُ وَجْهي لِلَّذِي فَطَرَ السَّمَوَاتِ وَالأرْضَ حَنِيفًا، وَما أَنَا مِنَ المُشْرِكِينَ، إنَّ صَلَاتِي وَنُسُكِي، وَمَحْيَايَ وَمَمَاتي لِلَّهِ رَبِّ العَالَمِينَ، لا شَرِيكَ له، وَبِذلكَ أُمِرْتُ وَأَنَا مِنَ المُسْلِمِينَ، اللَّهُمَّ أَنْتَ المَلِكُ لا إلَهَ إلَّا أَنْتَ، أَنْتَ رَبِّي وَأَنَا عَبْدُكَ، ظَلَمْتُ نَفْسِي، وَاعْتَرَفْتُ بذَنْبِي، فَاغْفِرْ لي ذُنُوبِي جَمِيعًا، إنَّه لا يَغْفِرُ الذُّنُوبَ إلَّا أَنْتَ، وَاهْدِنِي لأَحْسَنِ الأخْلَاقِ، لا يَهْدِي لأَحْسَنِهَا إلَّا أَنْتَ، وَاصْرِفْ عَنِّي سَيِّئَهَا، لا يَصْرِفُ عَنِّي سَيِّئَهَا إلَّا أَنْتَ، لَبَّيْكَ وَسَعْدَيْكَ، وَالْخَيْرُ كُلُّهُ في يَدَيْكَ، وَالشَّرُّ ليسَ إلَيْكَ، أَنَا بكَ وإلَيْكَ، تَبَارَكْتَ وَتَعَالَيْتَ، أَسْتَغْفِرُكَ وَأَتُوبُ إلَيْكَ).[٣]";
        }
    }
}
