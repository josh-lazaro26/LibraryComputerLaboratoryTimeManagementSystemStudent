using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

internal class SignalRService
{
    private HubConnection _connection;
    private readonly Func<Task<string>> _tokenProvider;

    public event Action DisconnectUser;

    public event Action<TimeSpan> UpdatedStudentSession;

    public SignalRService(Func<Task<string>> tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    protected SignalRService() { }

    public async Task InitializeAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://192.168.8.4:7128/api/v1/hubs/session", options =>
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
    public HubConnection GetHubConnection()
    {
        return _connection;
    }
    public void RegisterHandlers()
    {
        _connection.On("DisconnectUser", () =>
        {
            DisconnectUser.Invoke();
        });
        _connection.On("UpdateStudentSession", (TimeSpan UpdatedStudentSessions) =>
        {
            UpdatedStudentSession.Invoke(UpdatedStudentSessions);
        });
        Console.WriteLine("User Disconnected");
    }
}
