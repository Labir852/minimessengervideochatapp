using Microsoft.AspNetCore.SignalR;

public class CallHub : Hub
{
    public async Task SendOffer(string receiverId, string offer)
    {
        await Clients.User(receiverId).SendAsync("ReceiveOffer", Context.UserIdentifier, offer);
    }

    public async Task SendAnswer(string receiverId, string answer)
    {
        await Clients.User(receiverId).SendAsync("ReceiveAnswer", Context.UserIdentifier, answer);
    }

    public async Task SendICECandidate(string receiverId, string candidate)
    {
        await Clients.User(receiverId).SendAsync("ReceiveICECandidate", Context.UserIdentifier, candidate);
    }
}
