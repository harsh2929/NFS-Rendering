using System;

namespace NFSCore
{
    public static class PacketParse
    {
        private const int SLED_PACKET_LENGTH = 232; // FM7
        private const int DASH_PACKET_LENGTH = 311; // FM7
        private const int FH7_PACKET_LENGTH = 324; // FH4

        public static bool IsSledFormat(byte[] packet)
        {
            return packet.Length == SLED_PACKET_LENGTH;
        }

        public static bool IsDashFormat(byte[] packet)
        {
            return packet.Length == DASH_PACKET_LENGTH;
        }

        public static bool IsFH7Format(byte[] packet)
        {
            return packet.Length == FH7_PACKET_LENGTH;
        }

        internal static float GetSingle(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 4);
            return BitConverter.ToSingle(bytes, index);
        }

        internal static uint GetUInt16(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 2);
            return BitConverter.ToUInt16(bytes, index);
        }

        internal static uint GetUInt32(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 4);
            return BitConverter.ToUInt32(bytes, index);
        }

        internal static uint GetUInt8(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 1);
            return bytes[index];
        }

        internal static int GetInt8(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 1);
            return Convert.ToInt16((sbyte)bytes[index]);
        }

        private static void ByteCheck(byte[] bytes, int index, int byteCount)
        {
            if (index + byteCount <= bytes.Length)
            {
                return;
            }

            throw new ArgumentException("Space overflow");
        }
    }
}


/*
**using System;

namespace NFSCore
{
    /// <summary>
    /// Helper class for parsing NFS packets.
    /// </summary>
    public static class PacketParse
    {
        private const int SLED_PACKET_LENGTH = 232; // FM7
        private const int DASH_PACKET_LENGTH = 311; // FM7
        private const int FH7_PACKET_LENGTH = 324; // FH4

        /// <summary>
        /// Determines if the given packet is in the Sled format.
        /// </summary>
        public static bool IsSledPacket(byte[] packet)
        {
            return packet.Length == SLED_PACKET_LENGTH;
        }

        /// <summary>
        /// Determines if the given packet is in the Dash format.
        /// </summary>
        public static bool IsDashPacket(byte[] packet)
        {
            return packet.Length == DASH_PACKET_LENGTH;
        }

        /// <summary>
        /// Determines if the given packet is in the FH7 format.
        /// </summary>
        public static bool IsFH7Packet(byte[] packet)
        {
            return packet.Length == FH7_PACKET_LENGTH;
        }

        /// <summary>
        /// Gets a single-precision floating-point number from the given byte array.
        /// </summary>
        internal static float GetSingle(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 4);
            return BitConverter.ToSingle(bytes, index);
        }

        /// <summary>
        /// Gets a 16-bit unsigned integer from the given byte array.
        /// </summary>
        internal static ushort GetUInt16(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 2);
            return BitConverter.ToUInt16(bytes, index);
        }

        /// <summary>
        /// Gets a 32-bit unsigned integer from the given byte array.
        /// </summary>
        internal static uint GetUInt32(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 4);
            return BitConverter.ToUInt32(bytes, index);
        }

        /// <summary>
        /// Gets an 8-bit unsigned integer from the given byte array.
        /// </summary>
        internal static byte GetUInt8(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 1);
            return bytes[index];
        }

        /// <summary>
        /// Gets an 8-bit signed integer from the given byte array.
        /// </summary>
        internal static sbyte GetInt8(byte[] bytes, int index)
        {
            ByteCheck(bytes, index, 1);
            return (sbyte)bytes[index];
        }
*/
