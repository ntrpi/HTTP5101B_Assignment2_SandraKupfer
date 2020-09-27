using System;
using System.Reflection;

namespace HTTP5101B_Assignment2_SandraKupfer.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}