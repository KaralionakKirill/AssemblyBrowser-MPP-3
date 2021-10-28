using System.Reflection;

namespace Core.Printers
{
    public interface IPrinter
    {
        public bool CanPrint(MemberInfo info);
        public string Print(MemberInfo info);
    }
}