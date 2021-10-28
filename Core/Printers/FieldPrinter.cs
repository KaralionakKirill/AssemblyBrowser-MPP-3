using System.Reflection;
using System.Text;

namespace Core.Printers
{
    public class FieldPrinter: IPrinter
    {
        public bool CanPrint(MemberInfo info)
        {
            return info is FieldInfo;
        }

        public string Print(MemberInfo info)
        {
            var field = info as FieldInfo;
            var str = new StringBuilder();
            str.Append(field.IsPublic ? "public " : "private ")
                .Append(field.FieldType.Name)
                .Append(' ')
                .Append(field.Name);
            return str.ToString();
        }
    }
}