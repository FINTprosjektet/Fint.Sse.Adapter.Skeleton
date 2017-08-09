﻿﻿using Fint.SSE.Adapter.service;
using Fint.SSE.Customcode;
using FintEventModel.Model;
using System;

namespace Fint.SSE.Adapter
{
    public class EventStatusService : IEventStatusService
    {
        private IHttpService _httpService;
        private IConfigService _configService;

        public EventStatusService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
        }

        public Event<object> VerifyEvent(Event<object> evt)
        {
            if (ActionUtils.IsValidAction(evt.Action))
            {
                evt.Status = Status.PROVIDER_ACCEPTED;
            }
            else
            {
                evt.Status = Status.PROVIDER_REJECTED;
            }
            evt.Data.Clear();
            postStatus(evt);
            return evt;
        }

        private void postStatus(Event<object> evt)
        {
            _httpService.Post(_configService.StatusEndpoint, evt);
        }
    }
}
