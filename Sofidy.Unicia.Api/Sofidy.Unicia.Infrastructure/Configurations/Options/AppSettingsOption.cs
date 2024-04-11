using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Configurations.Options
{
    internal record AppSettingsOption
    {
        public const string Name = "AppSettings";
        public List<string> Files { get; set; } = new List<string>();
    }
}
