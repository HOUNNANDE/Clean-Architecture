using AutoMapper;
using MediatR;
using Serilog;
using Sofidy.Unicia.Application.Common.Exceptions;
using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.DTO.SalesforceService.SObjectModel;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sofidy.Unicia.Application.Features.CallbackFeatures.PostCallback
{
    public record PostCallbackRequest : IRequest<PostCallbackResponse>
    {
        public Guid Id { get; set; }
        public bool Force { get; set; } = false;
    }

    public class PostCallbackHandler : IRequestHandler<PostCallbackRequest, PostCallbackResponse>
    {
        private readonly IImportService _importService;
        private readonly IAckCacheService _ackService;
        private readonly ISalesforceService _salesforceService;
        private readonly IMapper _mapper;

        public PostCallbackHandler(IImportService importService, 
                                   IAckCacheService ackService,
                                   ISalesforceService salesforceService,
                                   IMapper mapper)
        {
            _importService = importService;
            _ackService = ackService;
            _salesforceService = salesforceService;
            _mapper = mapper;
        }

        public async Task<PostCallbackResponse> Handle(PostCallbackRequest request, CancellationToken cancellationToken)
        {
            var ackcache = await _ackService.Get(request.Id, cancellationToken);

            if (ackcache == null)
                throw new OperationArgumentNullException($"AckCache {request.Id}");

            var importStatusDto = await _importService.GetImportStatusByCType(ackcache.CTypes, ackcache.IdImport, cancellationToken);

            // None 
            if (importStatusDto.Status == ImportStatus.None)
                throw new OperationException($"No valid status determined for {ackcache.CTypes} : {ackcache.IdImport} ");

            if (!ackcache.FAcked || request.Force)
            {
                await InvokeSalesforceApi(importStatusDto, ackcache); 

                // Update Flag FAcked
                await _ackService.UpdateFacked(request.Id, cancellationToken);
            }

            return default;
        }

        public async Task InvokeSalesforceApi(ImportStatusDTO importStatusDto, AckCache ackCache)
        {
            if (importStatusDto.Status == ImportStatus.OK)
            {
                // OK
                // IConvert 
                var iConvert = await _importService.GetIConvertByIdClient(ackCache.CTypes, ackCache.IdClient);

                if (iConvert == null || iConvert.ICorresp1 == null)
                    throw new OperationArgumentNullException($"IConvert {ackCache.CTypes} : {ackCache.IdImport}");

                _salesforceService.UpdateCallbackSObject<SfUniciaTracableObject>(ackCache.CTypes, ackCache.IdClient, sObject =>
                {
                    sObject.IdUnicia = iConvert.ICorresp1;  // Id Unicia 
                    sObject.UniciaSyncStatus = "Synced"; // Unciia Sync Status "Synced" 
                });
            }
            else if (importStatusDto.Status == ImportStatus.KO)
            { 
                //TODOS
                //_salesforceService.UpdateCallbackSObject<SfUniciaTracableObject>(entity.CTypes, entity.IdClient, sObject =>
                //{ 
                //    sObject.UniciaSyncStatus = "Errors"; // Unciia Sync Status "Synced" 
                //});
            }
            else
                throw new OperationArgumentNullException($"Status for {ackCache.CTypes} : {ackCache.IdImport}");
        }
    }
}
