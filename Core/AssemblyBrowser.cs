using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Printers;

namespace Core
{
    public class AssemblyBrowser
    {
        private readonly Assembly _assembly;
        private readonly List<IPrinter> _printers;

        public AssemblyBrowser(string file)
        {
            _printers = new List<IPrinter>()
            {
                new FieldPrinter(),
                new MethodPrinter(),
                new PropertyPrinter()

            };
            _assembly = Assembly.LoadFrom(file);
        }

        public List<string> GetNamespaces()
        {
            return _assembly.GetTypes()
                .Select(type => type.Namespace)
                .Where(obj => obj is not null)
                .Distinct()
                .Where(obj => !obj.StartsWith("System"))
                .Where(obj => !obj.StartsWith("Microsoft"))
                .ToList();
        }

        public List<string> GetTypes(string ns)
        {
            return _assembly.GetTypes()
                .Where(obj => obj.Namespace is not null)
                .Where(obj => obj.Namespace.Equals(ns))
                .Select(obj => obj.Name)
                .Where(obj => !obj.Contains('<'))
                .ToList();
        }

        public List<string> GetMethods(string ns, string tp)
        {
            return _assembly.GetTypes()
                .Where(obj => obj.Namespace is not null)
                .Where(obj => obj.Namespace.Equals(ns))
                .First(obj => obj.Name.Equals(tp))
                .GetMembers(BindingFlags.NonPublic | BindingFlags.Public 
                                                   | BindingFlags.Static | BindingFlags.Instance)
                .Where(obj => !obj.Name.Contains('<'))
                .Select(GetSignature)
                .ToList();
        }
        
        private string GetSignature(MemberInfo info)
        {
            foreach (var printer in _printers.Where(printer => printer.CanPrint(info)))
            {
                return printer.Print(info);
            }
            return "<some member>";
        }
    }
}