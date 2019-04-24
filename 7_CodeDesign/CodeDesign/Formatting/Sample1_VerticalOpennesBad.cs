// Taking out the blank lines has a bad effect on the readability of the code

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Formatting
{
    public class BoldWidgetBad : UserControl
    {
        public const string REGEXP = "'''.+?'''";
        private Pattern pattern = Pattern.Compile("''", Pattern.MULTILINE);
        public BoldWidgetBad(ParentWidget parentWidget, string text)
        {
            Match match = this.pattern.Matcher(text);
            match.NextMatch();
            this.ControlAdded += BoldWidget_ControlAdded;
        }
        public string Render()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("");
            return stringBuilder.ToString();
        }
        private void BoldWidget_ControlAdded(object sender, ControlEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}