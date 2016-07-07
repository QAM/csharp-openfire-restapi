using OpenfireAPI.entity;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using OpenfireAPI.util;

namespace OpenfireAPI
{
    class OpenfireAPIClient
    {
        private OpenfireClient client;
        private JsonDeserializer deserial;
        public OpenfireAPIClient(string url, int port, OpenfireAuthenticator authenticator) {
            client = new OpenfireClient(url, port, authenticator);
            deserial = new JsonDeserializer();
        }

        /*User related APIs*/
        public UserEntities getUsers()
        {
            IRestResponse response = client.get("users", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<UserEntities>(response) : null;
        }

        public UserEntity getUser(string username) {
            IRestResponse response = client.get("users/"+username, new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<UserEntity>(response) : null;
        }

        public bool createUser(UserEntity userEntity)
        {
            return client.isStatusCodeOK(client.post("users", userEntity, new Dictionary<string, string>()));
        }

        public bool deleteUser(string username) {
            return client.isStatusCodeOK(client.delete("users/" + username, null, new Dictionary<string, string>()));
        }

        public bool updateUser(string username, UserEntity userEntity) {
            return client.isStatusCodeOK(client.put("users/" + username, userEntity, new Dictionary<string, string>()));
        }

        public UserGroupsEntiry getUserGroups(string username) {
            IRestResponse response = client.get("users/"+username+"/groups", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<UserGroupsEntiry>(response) : null;
        }

        public bool addUserToGroups(string username, UserGroupsEntiry groups) {
            return client.isStatusCodeOK(client.post("users/" + username + "/groups", groups, new Dictionary<string, string>()));
        }

        public bool addUserToGroup(string username, string group) {
            return client.isStatusCodeOK(client.post("users/" + username + "/groups/" + group, null, new Dictionary<string, string>()));
        }

        public bool deleteUserFromGroups(string username, UserGroupsEntiry groups) {
            return client.isStatusCodeOK(client.delete("users/" + username + "/groups", groups, new Dictionary<string, string>()));
        }

        public bool deleteUserFromGroup(string username, string group) {
            return client.isStatusCodeOK(client.delete("users/" + username + "/groups/" + group, null, new Dictionary<string, string>()));
        }

        public bool lockoutUser(string username) {
            return client.isStatusCodeOK(client.post("lockouts/"+username, null, new Dictionary<string, string>()));
        }

        public bool unlockUser(string username) {
            return client.isStatusCodeOK(client.delete("lockouts/"+username, null, new Dictionary<string, string>()));
        }

        public RosterEntities getRoster(string username) {
            IRestResponse response = client.get("users/"+username+"/roster", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<RosterEntities>(response) : null;
        }

        public bool addRosterEntry(string username, RosterEntity rosterEntry) {
            return client.isStatusCodeOK(client.post("users/" + username + "/roster", rosterEntry, new Dictionary<string, string>()));
        }

        public bool deleteRosterEntry(string username, string jid) {
            return client.isStatusCodeOK(client.delete("users/" + username + "/roster/" + jid, null ,new Dictionary<string, string>()));
        }

        public bool updateRosterEntry(string username, RosterEntity rosterEntry)
        {
            return client.isStatusCodeOK(client.put("users/" + username + "/roster", rosterEntry, new Dictionary<string, string>()));
        }

        public SystemProperties getSystemProperties() {
            IRestResponse response = client.get("system/properties", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<SystemProperties>(response) : null;
        }

        public SystemProperty getSystemProperty(string propertyName) {
            IRestResponse response = client.get("system/properties/"+propertyName, new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<SystemProperty>(response) : null;
        }

        public bool createSystemProperty(SystemProperty systemProperty) {
            return client.isStatusCodeOK(client.post("system/properties", systemProperty, new Dictionary<string, string>()));
        }

        public bool updateSystemProperty(SystemProperty systemProperty) {
            return client.isStatusCodeOK(client.put("system/properties/"+systemProperty.key, systemProperty, new Dictionary<string, string>()));
        }

        public bool deleteSystemProperty(String propertyName) {
            return client.isStatusCodeOK(client.delete("system/properties/"+ propertyName, null, new Dictionary<string, string>()));
        }

        public GroupEntities getGroups() {
            IRestResponse response = client.get("groups" , new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<GroupEntities>(response) : null;
        }

        public GroupEntity getGroup(string groupName) {
            IRestResponse response = client.get("groups/" + groupName, new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<GroupEntity>(response) : null;
        }

        public bool createGroup(GroupEntity groupEntity) {
            return client.isStatusCodeOK(client.post("groups", groupEntity, new Dictionary<string, string>()));
        }

        public bool deleteGroup(string groupName) {
            return client.isStatusCodeOK(client.delete("groups/" + groupName, null, new Dictionary<string, string>()));
        }

        public bool updateGroup(GroupEntity groupEntity) {
            return client.isStatusCodeOK(client.put("groups/" + groupEntity.name, groupEntity, new Dictionary<string, string>()));
        }

        //TODO: /system/statistics/sessions
        //TODO: Chatroom

        public SessionEntities getSessions()
        {
            IRestResponse response = client.get("sessions", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<SessionEntities>(response) : null;
        }

        public SessionEntities getSessions(string username) {
            IRestResponse response = client.get("sessions/" + username, new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<SessionEntities>(response) : null;
        }

        public bool closeSessions(string username) {
            return client.isStatusCodeOK(client.delete("sessions/" + username, null, new Dictionary<string, string>()));
        }

        public bool broadcastMsg(MessageEntity messageEntity) {
            return client.isStatusCodeOK(client.post("messages/users", messageEntity, new Dictionary<string, string>()));
        }
    }
}
