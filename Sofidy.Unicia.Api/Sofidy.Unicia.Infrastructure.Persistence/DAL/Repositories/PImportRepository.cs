﻿using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories
{
    public class PImportRepository : BaseRepository<UniciaImportContext, PImport>, IPImportRepository
    {
        public PImportRepository(UniciaImportContext context) : base(context)
        {
        }
    }
}