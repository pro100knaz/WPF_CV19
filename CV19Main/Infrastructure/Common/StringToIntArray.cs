using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CV19Main.Infrastructure.Common
{
    [MarkupExtensionReturnType(typeof(int[]))]
    internal class StringToIntArray : MarkupExtension
    {

        [ConstructorArgument("Str")]
        public string Str { get; set; }  

        public char Separator { get; set; } = ';';



        public StringToIntArray() { }
        public StringToIntArray(string s) => Str = s;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Str.Split(new char[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                .DefaultIfEmpty()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
