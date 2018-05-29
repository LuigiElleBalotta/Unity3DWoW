﻿using Assets.Scripts.Shared;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Client.Authentication
{
    public class WorldServerList : IEnumerable<WorldServerInfo>
    {
        public int Count { get; private set; }

        public WorldServerList(BinaryReader reader)
        {
            reader.ReadUInt32();

            Count = reader.ReadUInt16();
            Exchange.authClient.RealmServerList = new WorldServerInfo[Count];

            for (int i = 0; i < Count; ++i)
                Exchange.authClient.RealmServerList[i] = new WorldServerInfo(reader);
        }

        public WorldServerInfo this[int index]
        {
            get { return Exchange.authClient.RealmServerList[index]; }
        }

        #region IEnumerable<WorldServerInfo> Members

        public IEnumerator<WorldServerInfo> GetEnumerator()
        {
            foreach (WorldServerInfo server in Exchange.authClient.RealmServerList)
                yield return server;
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (WorldServerInfo realm in Exchange.authClient.RealmServerList)
                yield return realm;
        }

        #endregion
    }
}
