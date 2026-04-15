
using Backend_Game.Shared.Infrastructure.GameHub;
using Microsoft.AspNetCore.SignalR;
namespace Backend_Game._Module.Match_Map_1.Configurations
{
    public static class RouteConfiguration
    {
        public static IEndpointRouteBuilder AddRouteMap1Configurations(this IEndpointRouteBuilder endpoints)
        {
            //Kết nối sokcet cho gamehub
            endpoints.MapHub<Shared.Infrastructure.GameHub.GameHub>("/gamehub");
            return endpoints;
        }
    }
}