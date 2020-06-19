using DependencyInjector.API.Infraestructure.Service.Interfaces;
using System;

namespace DependencyInjector.API.Infraestructure.Service.ServiceClient
{
    public class SecondService : IService
    {
        private readonly IService _service;

        public SecondService(IService service)
        {
            _service = service;
        }

        public Guid GetGuid() => _service.GetGuid();
    }
}
