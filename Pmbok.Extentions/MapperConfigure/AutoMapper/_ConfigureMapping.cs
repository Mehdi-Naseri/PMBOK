using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace Pmbok.Extentions.MapperConfigure.AutoMapper
{
    public class _ConfigureMapping
    {
        public static void Configure()
        {
            Mapper.Configuration.AddProfile(new ConfigureProjectMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentValueMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentFileMapping());
            Mapper.Configuration.AddProfile(new ConfigureProjectDocumentFileDeletedMapping());
        }
    }
}
