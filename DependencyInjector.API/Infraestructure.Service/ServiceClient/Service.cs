using DependencyInjector.API.Infraestructure.Service.Interfaces;
using System;

namespace DependencyInjector.API.Infraestructure.Service.ServiceClient
{
    public class Service : IService
    {
        private readonly Guid _guid = Guid.NewGuid();

        public Guid GetGuid() => _guid;
    }
}
