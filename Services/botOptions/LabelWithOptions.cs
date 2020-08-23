using System.Collections.Generic;

namespace TelegramPizzaria.Services.botOptions
{
    public struct LabelWithOptions
    {
        private string name;
        private List<string> option;
        private List<int> tie_trigger;

        public LabelWithOptions(string n, List<string> o, List<int> t)
        {
            name = n;
            option = o;
            tie_trigger = t;
        }

        public string LabelQuestionCurrent() => this.name;
        public List<string> OptionQuestionCurrent() => this.option;
        public int Next(int i) => this.tie_trigger[i];
    }

}