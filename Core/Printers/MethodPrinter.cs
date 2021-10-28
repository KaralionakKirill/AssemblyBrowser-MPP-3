using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Printers
{
    public class MethodPrinter : IPrinter
    {
        public bool CanPrint(MemberInfo info)
        {
            return info is MethodInfo;
        }

        public string Print(MemberInfo info)
        {
            var method = info as MethodInfo;
            var str = new StringBuilder();
            var parameters = method.GetParameters()
                .Select(parameterInfo => parameterInfo.ParameterType.Name);
            str.Append(method.IsPublic ? "public " : "private ")
                .Append(method.ReturnType.Name)
                .Append(' ')
                .Append(method.Name)
                .Append($"({string.Join(", ", parameters)})");
            return str.ToString();
        }
    }
}