using System;

namespace InSimDotNet.Packets {
    /// <summary>
    /// New connection packet.
    /// </summary>
    /// <remarks>
    /// Sent when a connection joins a host.
    /// </remarks>
    public class IS_NCI : IPacket {
        /// <summary>
        /// Gets the size of the packet.
        /// </summary>
        public byte Size { get; private set; }

        /// <summary>
        /// Gets the type of the packet.
        /// </summary>
        public PacketType Type { get; private set; }

        /// <summary>
        /// Gets the request ID.
        /// </summary>
        public byte ReqI { get; private set; }

        /// <summary>
        /// Gets the unique ID of the connection.
        /// </summary>
        public byte UCID { get; private set; }

        /// <summary>
        /// Gets the LFS username of the connection.
        /// </summary>
        public byte Language { get; set; }

        /// <summary>
        /// Gets the LFS UserID
        /// </summary>
        public uint UserID { get; set; }

        /// <summary>
        /// Gets the IP Address of the connection.
        /// </summary>
        public uint IPAddress { get; set; }

        /// <summary>
        /// Creates a new new connection packet.
        /// </summary>
        public IS_NCI() {
            Size = 16;
            Type = PacketType.ISP_NCI;
        }

        /// <summary>
        /// Creates a new new connection packet.
        /// </summary>
        /// <param name="buffer">A buffer contaning the packet data.</param>
        public IS_NCI(byte[] buffer)
            : this() {
            PacketReader reader = new PacketReader(buffer);
            Size = reader.ReadByte();
            Type = (PacketType)reader.ReadByte();
            ReqI = reader.ReadByte();
            UCID = reader.ReadByte();
            Language = reader.ReadByte();
            reader.Skip(3);  //sp1, sp2, sp3
            UserID = reader.ReadUInt32();
            IPAddress = reader.ReadUInt32();
        }
    }
}
