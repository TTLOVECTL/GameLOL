//-------------------------------------------------
//                    TNet 3
// Copyright © 2012-2016 Tasharen Entertainment Inc
//-------------------------------------------------

using System;
using System.Net;
using System.IO;

namespace TNet
{
/// <summary>
/// Server list is a helper class containing a list of servers.
/// </summary>

public class ServerList
{
	public class Entry
	{
		public string name;
		public int playerCount;
		public IPEndPoint internalAddress;
		public IPEndPoint externalAddress;

		[System.NonSerialized] public long recordTime;

		public void WriteTo (BinaryWriter writer)
		{
			writer.Write(name);
			writer.Write((ushort)playerCount);
			Tools.Serialize(writer, internalAddress);
			Tools.Serialize(writer, externalAddress);
		}

		public void ReadFrom (BinaryReader reader)
		{
			name = reader.ReadString();
			playerCount = reader.ReadUInt16();
			Tools.Serialize(reader, out internalAddress);
			Tools.Serialize(reader, out externalAddress);
		}
	}

	/// <summary>
	/// List of active server entries. Be sure to lock it before using it,
	/// as it can be changed from a different thread.
	/// </summary>

	public List<Entry> list = new List<Entry>();

	static int SortByPC (Entry a, Entry b)
	{
		if (b.playerCount == a.playerCount) return a.name.CompareTo(b.name);
		return b.playerCount.CompareTo(a.playerCount);
	}

	static int SortAlphabetic (Entry a, Entry b) { return a.name.CompareTo(b.name); }

	/// <summary>
	/// Sort the server list, arranging it by the number of players.
	/// </summary>

	public void SortByPlayers () { list.Sort(SortByPC); }

	/// <summary>
	/// Sort the server list, arranging entries alphabetically.
	/// </summary>

	public void SortAlphabetic () { list.Sort(SortAlphabetic); }

	/// <summary>
	/// Add a new entry to the list.
	/// </summary>

	public Entry Add (string name, int playerCount, IPEndPoint internalAddress, IPEndPoint externalAddress, long time)
	{
		lock (list)
		{
			for (int i = 0; i < list.size; ++i)
			{
				Entry ent = list[i];

				if (ent.internalAddress.Equals(internalAddress) &&
					ent.externalAddress.Equals(externalAddress))
				{
					ent.name = name;
					ent.playerCount = playerCount;
					ent.recordTime = time;
					return ent;
				}
			}

			Entry e = new Entry();
			e.name = name;
			e.playerCount = playerCount;
			e.internalAddress = internalAddress;
			e.externalAddress = externalAddress;
			e.recordTime = time;
			list.Add(e);
			return e;
		}
	}

	/// <summary>
	/// Add a new entry.
	/// </summary>

	public Entry Add (Entry newEntry, long time)
	{
		lock (list) AddInternal(newEntry, time);
		return newEntry;
	}

	/// <summary>
	/// Remove an existing entry from the list.
	/// </summary>

	public Entry Remove (IPEndPoint internalAddress, IPEndPoint externalAddress)
	{
		lock (list)
		{
			for (int i = 0; i < list.size; ++i)
			{
				Entry ent = list[i];

				if (ent.internalAddress.Equals(internalAddress) &&
					ent.externalAddress.Equals(externalAddress))
				{
					list.RemoveAt(i);
					return ent;
				}
			}
		}
		return null;
	}

	/// <summary>
	/// Remove expired entries.
	/// </summary>

	public bool Cleanup (long time)
	{
		time -= 7000;
		bool changed = false;

		lock (list)
		{
			for (int i = 0; i < list.size; )
			{
				Entry ent = list[i];

				if (ent.recordTime < time)
				{
					changed = true;
					list.RemoveAt(i);
					continue;
				}
				++i;
			}
		}
		return changed;
	}

	/// <summary>
	/// Clear the list of servers.
	/// </summary>

	public void Clear () { lock (list) list.Clear(); }

	/// <summary>
	/// Save the list of servers to the specified binary writer.
	/// </summary>

	public void WriteTo (BinaryWriter writer)
	{
		writer.Write(GameServer.gameID);

		lock (list)
		{
			writer.Write((ushort)list.size);
			for (int i = 0; i < list.size; ++i)
				list[i].WriteTo(writer);
		}
	}

	/// <summary>
	/// Read a list of servers from the binary reader.
	/// </summary>

	public void ReadFrom (BinaryReader reader, long time)
	{
		if (reader.ReadUInt16() == GameServer.gameID)
		{
			lock (list)
			{
				int count = reader.ReadUInt16();

				for (int i = 0; i < count; ++i)
				{
					Entry ent = new Entry();
					ent.ReadFrom(reader);
					AddInternal(ent, time);
				}
			}
		}
	}

	/// <summary>
	/// Add a new entry. Not thread-safe.
	/// </summary>

	void AddInternal (Entry newEntry, long time)
	{
		for (int i = 0; i < list.size; ++i)
		{
			Entry ent = list[i];

			if (ent.internalAddress.Equals(newEntry.internalAddress) &&
				ent.externalAddress.Equals(newEntry.externalAddress))
			{
				ent.name = newEntry.name;
				ent.playerCount = newEntry.playerCount;
				ent.recordTime = time;
				return;
			}
		}
		newEntry.recordTime = time;
		list.Add(newEntry);
	}
}
}
