using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Implementations
{
    public class PresenceTracker
    {
        // userId => set of connectionIds
        private readonly ConcurrentDictionary<string, HashSet<string>> _onlineUsers =
            new ConcurrentDictionary<string, HashSet<string>>();

        private readonly object _lock = new object();

        // returns true if this was the first connection for the user (user became online)
        public bool UserConnected(string userId, string connectionId)
        {
            lock (_lock)
            {
                if (!_onlineUsers.TryGetValue(userId, out var connections))
                {
                    connections = new HashSet<string>();
                    _onlineUsers[userId] = connections;
                }
                connections.Add(connectionId);
                return connections.Count == 1;
            }
        }

        // returns true if user completely disconnected (no more connections)
        public bool UserDisconnected(string userId, string connectionId)
        {
            lock (_lock)
            {
                if (!_onlineUsers.TryGetValue(userId, out var connections)) return false;

                connections.Remove(connectionId);

                if (connections.Count == 0)
                {
                    _onlineUsers.TryRemove(userId, out _);
                    return true;
                }
                return false;
            }
        }

        public string[] GetConnections(string userId)
        {
            if (_onlineUsers.TryGetValue(userId, out var connections))
                return connections.ToArray();
            return Array.Empty<string>();
        }

        public IEnumerable<string> GetOnlineUsers() => _onlineUsers.Keys;
    }
}
