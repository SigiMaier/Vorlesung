// The blank lines seperate each new and seperate concept.
// The eye is drawn to the first line that follows a blank line

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Formatting
{
    public class BoldWidget : UserControl
    {
        public const string REGEXP = "'''.+?'''";

        private Pattern pattern = Pattern.Compile("''", Pattern.MULTILINE);

        public BoldWidget(ParentWidget parentWidget, string text)
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