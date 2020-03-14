namespace HandyTools.Extensions
{
	public static class BitOperations
	{
		#region byte
		private static byte GetBitAsByte(int bit) => (byte)(1 << (bit - 1));
		public static bool HasBit(this byte number, int bit) => (number & GetBitAsByte(bit)) > 0;
		public static byte PutBit(this byte number, int bit) => (byte)(number | GetBitAsByte(bit));
		public static byte RemoveBit(this byte number, int bit) => (byte)(number & ~GetBitAsByte(bit));
		#endregion

		#region sbyte
		private static sbyte GetBitAsSByte(int bit) => (sbyte)(1 << (bit - 1));
		public static bool HasBit(this sbyte number, int bit) => (number & GetBitAsSByte(bit)) > 0;
		public static sbyte PutBit(this sbyte number, int bit) => (sbyte)(number | GetBitAsSByte(bit));
		public static sbyte RemoveBit(this sbyte number, int bit) => (sbyte)(number & ~GetBitAsSByte(bit));
		#endregion

		#region int
		private static int GetBitAsInt(int bit) => 1 << (bit - 1);
		public static bool HasBit(this int number, int bit) => (number & GetBitAsInt(bit)) > 0;
		public static int PutBit(this int number, int bit) => number | GetBitAsInt(bit);
		public static int RemoveBit(this int number, int bit) => number & ~GetBitAsInt(bit);
		#endregion

		#region uint
		private static uint GetBitAsUInt(int bit) => (uint)1 << (bit - 1);
		public static bool HasBit(this uint number, int bit) => (number & GetBitAsUInt(bit)) > 0;
		public static uint PutBit(this uint number, int bit) => number | GetBitAsUInt(bit);
		public static uint RemoveBit(this uint number, int bit) => number & ~GetBitAsUInt(bit);
		#endregion

		#region short
		private static short GetBitAsShort(int bit) => (short)(1 << (bit - 1));
		public static bool HasBit(this short number, int bit) => (number & GetBitAsShort(bit)) > 0;
		public static short PutBit(this short number, int bit) => (short)(number | GetBitAsShort(bit));
		public static short RemoveBit(this short number, int bit) => (short)(number & ~GetBitAsShort(bit));
		#endregion

		#region ushort
		private static ushort GetBitAsUShort(int bit) => (ushort)(1 << (bit - 1));
		public static bool HasBit(this ushort number, int bit) => (number & GetBitAsUShort(bit)) > 0;
		public static ushort PutBit(this ushort number, int bit) => (ushort)(number | GetBitAsUShort(bit));
		public static ushort RemoveBit(this ushort number, int bit) => (ushort)(number & ~GetBitAsUShort(bit));
		#endregion

		#region long
		private static long GetBitAsLong(int bit) => 1L << (bit - 1);
		public static bool HasBit(this long number, int bit) => (number & GetBitAsLong(bit)) > 0;
		public static long PutBit(this long number, int bit) => number | GetBitAsLong(bit);
		public static long RemoveBit(this long number, int bit) => number & ~GetBitAsLong(bit);
		#endregion

		#region ulong
		private static ulong GetBitAsULong(int bit) => 1UL << (bit - 1);
		public static bool HasBit(this ulong number, int bit) => (number & GetBitAsULong(bit)) > 0;
		public static ulong PutBit(this ulong number, int bit) => number | GetBitAsULong(bit);
		public static ulong RemoveBit(this ulong number, int bit) => number & ~GetBitAsULong(bit);
		#endregion
	}
}