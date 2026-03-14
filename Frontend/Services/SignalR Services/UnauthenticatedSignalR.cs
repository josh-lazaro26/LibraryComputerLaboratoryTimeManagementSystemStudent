using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.SignalR_Services
{
    internal class UnauthenticatedSignalR
    {
        private HubConnection _connection;

        public event Action Restart;

        public async Task InitializeAsync()
        {
            _connection = new HubConnectionBuilder()
           .WithUrl("https://internet-laboratory-time-management.onrender.com/api/v1/hubs/client-device", options =>
           {
               options.HttpMessageHandlerFactory = _ => new HttpClientHandler
               {
                   ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
               };
           })
           .WithAutomaticReconnect()
           .Build();

            _connection.On("Restart", () =>
            {
                Console.WriteLine("This PC is restarting...");
                Restart?.Invoke();
            });

            _connection.Closed += (error) =>
            {
                Console.WriteLine("The server might shutdown or terminated...");
                Environment.Exit(0);
                return Task.CompletedTask;
            };

            // Retry until server is reachable (Render.com cold start can take 30-60s)
            while (true)
            {
                try
                {
                    await _connection.StartAsync();
                    Console.WriteLine($"UnauthenticatedSignalR: Connected — {_connection.State}");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"UnauthenticatedSignalR: StartAsync failed — {ex.Message}. Retrying in 5s...");
                    await Task.Delay(5000);
                }
            }

            try
            {
                await _connection.InvokeAsync("RegisterDevice", Environment.MachineName);
                Console.WriteLine($"Device registered: {Environment.MachineName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RegisterDevice failed: {ex.Message}");
            }
        }
    }
}