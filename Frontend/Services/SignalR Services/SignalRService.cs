using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

internal class SignalRService
{
    private HubConnection _connection;
    private readonly Func<Task<string>> _tokenProvider;

    // Student listeners (matching hub events from image)
    public event Action<Guid> LoggedOutSession;
    public event Action<TimeSpan> UpdatedStudentSession;  // hub: "UpdatedSession"
    public event Action Terminate;                         // hub: "Terminate"
    public event Action Restart;
    public SignalRService(Func<Task<string>> tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    protected SignalRService() { }

    public async Task InitializeAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://internet-laboratory-time-management.onrender.com/api/v1/hubs/session", options =>
            {
                options.AccessTokenProvider = _tokenProvider;
                options.HttpMessageHandlerFactory = _ => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
            })
            .WithAutomaticReconnect()
            .Build();

        RegisterHandlers();
        await _connection.StartAsync();
    }

    public HubConnection GetHubConnection() => _connection;

    public void RegisterHandlers()
    {
        _connection.On("LoggedOutSession", (Guid userId) =>
        {
            LoggedOutSession.Invoke(userId);
        });

        _connection.On<TimeSpan>("UpdatedSession", (duration) =>
        {
            UpdatedStudentSession?.Invoke(duration);
        });

        _connection.On("Terminate", () =>
        {
            Terminate?.Invoke();
        });

        _connection.On("Restart", () =>
        {
            Restart?.Invoke();
        });

        Console.WriteLine("SignalR handlers registered.");
    }
}