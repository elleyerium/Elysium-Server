namespace NetCoreServer.Server
{
    public enum MessageType
    {
        Authorization = 1,
        AuthorizationResponse = 2,
        GetConcurrentUsers = 3,
        GetConcurrentUsersResponse = 4,
        UserConnected = 6, //Broadcast
        UserDisconnected = 8, //Broadcast
        LeaderboardsRequest = 9,
        LeaderboardsResponse = 10,
        GetPlayerStats = 11,
        PlayerStatsResponse = 12,
        SendChatMessage = 13,
        IncomingChatMessage = 14, //Broadcast
        CreateOnlineRoomRequest = 15,
        CreateOnlineRoomResponse = 16 //Broadcast
    }
}