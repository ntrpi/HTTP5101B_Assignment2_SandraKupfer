using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HTTP5101B_Assignment2_SandraKupfer.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}