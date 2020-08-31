using System.Collections.Generic;

namespace BotOptions.Options
{
    public abstract class IOption
    {

        public string LabelQuestionCurrent { get; set; }
        public List<string> OptionQuestionCurrent { get; set; }
        public string OptionFromOrigin { get; set; }


    }
}