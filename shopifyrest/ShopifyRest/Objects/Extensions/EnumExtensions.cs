using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyRest.Objects.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Reads and uses the enum's <see cref="EnumMemberAttribute"/> for serialization. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSerializedString(this Enum input)
        {
            string name = input.ToString();
            MemberInfo[] info = input.GetType().GetMember(name);

            if (info.Length > 0)
            {
                var attribute = info[0].GetCustomAttribute<EnumMemberAttribute>();

                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            return name.ToLower();
        }
    }
}
