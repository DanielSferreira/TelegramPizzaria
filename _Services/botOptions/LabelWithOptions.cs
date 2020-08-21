
using System.Collections.Generic;

namespace TelegramPizzaria._Services.botOptions
{
    public struct LabelWithOptions
    {
        private string name;
        private List<string> option;
        public LabelWithOptions(string n, List<string> o)
        {
            name = n;
            option = o;
        }

        public string LabelQuestionCurrent() => this.name;
        public List<string> OptionQuestionCurrent() => this.option;
    }

}