using System;
using System.Linq;

namespace mytemplate.UserControls.Captcha
{
    public partial class MyCaptcha : System.Web.UI.UserControl
    {
        public int MaxLetterCount { get; set; }

        private string GeneratedText
        {
            get
            {
                return String.IsNullOrEmpty(GeneratedTextHidden.Value) ? null :
                    GeneratedTextHidden.Value;
            }
            set
            {
                // Encrypt the value before storing it in viewstate.
                GeneratedTextHidden.Value = value;
            }
        }

        public bool IsValid
        {
            get
            {
                // if (String.IsNullOrEmpty(TxtCpatcha.Text)) 
                //    TxtCpatcha.Text = Request.Form[TxtCpatcha.ClientID];
                string param = TxtCaptcha.Text;
                if (param != null)
                {
                    bool result = GeneratedText.ToUpper() == param.Trim().ToUpper();
                    TryNew();
                    return result;
                }
                else
                    return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GeneratedText == null)
                TryNew();
        }

        protected void ImageButton_Click(object sender, EventArgs e)
        {
            TryNew();
        }

        public void TryNew()
        {
            // TxtCpatcha.Text = "";
            char[] Valichars = { '1', '2', '3', '4', '5', '6', '7', '8', '9','a','b','c','d','e','f','g','h','i',
                           'j','k','l','m','n','p','q','r','s','t','u','v','w','x','y','z' };
            string Captcha = "";
            int LetterCount = MaxLetterCount > 5 ? MaxLetterCount : 5;
            for (int i = 0; i < LetterCount; i++)
            {
                char newChar = (char)0;
                do
                {
                    newChar = Char.ToUpper(Valichars[new Random(DateTime.Now.Millisecond).Next(Valichars.Count() - 1)]);
                }
                while (Captcha.Contains(newChar));
                Captcha += newChar;
            }
            GeneratedText = Captcha;

            ImgCaptcha.ImageUrl = "~/UserControls/Captcha/GetImgText.ashx?CaptchaText=" +
                Server.UrlEncode(Convert.ToBase64String(SecurityHelper.EncryptString(Captcha)));
        }
    }
}