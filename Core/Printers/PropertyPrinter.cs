using System.Reflection;

namespace Core.Printers
{
    public class PropertyPrinter : IPrinter
    {
        public bool CanPrint(MemberInfo info)
        {
            return info is PropertyInfo;
        }

        public string Print(MemberInfo info)
        {
            var isGet = false;
            var isSet = false;
            var getView = "";
            var setView = "";
            var type = "";
            var property = info as PropertyInfo;
            var accessors = property.GetAccessors(true);
            foreach (var obj in accessors)
            {
                if (obj.ReturnType == typeof(void))
                {
                    isSet = true;
                    setView = obj.IsPublic ? "" : "private ";
                    type = obj.GetParameters()[0].ParameterType.Name;
                }
                else
                {
                    isGet = true;
                    getView = obj.IsPublic ? "public" : "private";
                    type = obj.ReturnType.Name;
                }
            }

            return $"{(isGet ? getView : setView)} {type} {info.Name} " +
                   $"{{ {(isGet ? "get;" : "")} {setView}{(isSet ? "set; " : "")}}}";
        }
    }
}