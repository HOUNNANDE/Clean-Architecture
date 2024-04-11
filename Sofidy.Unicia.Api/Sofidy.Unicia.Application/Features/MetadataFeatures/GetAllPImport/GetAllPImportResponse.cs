using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Common.Exceptions;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.DTO.AckCacheService;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using Unicia.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllPImport
{
    public record GetAllPImportResponse
    {
        public decimal ITyparam { get; set; }
        public string IClient { get; set; } = null!;

        public string? ICorresp1 { get; set; }

        public string? ICorresp2 { get; set; }

        public string? ICorresp3 { get; set; }

        /// <summary>
        /// Descritptif du Transcodage saisi
        /// </summary>
        public string? TDescriptif { get; set; }
    }
}
