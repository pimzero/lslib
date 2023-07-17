using System;
using System.IO.Hashing;

namespace LSLib.Native
{
public class Crc32
{
	static UInt32[,] Crc32Lookup = new UInt32[8, 0x100];
	static bool Crc32LookupTableInitialized = false;

	private static void InitCrc32LookupTable() {
		if (Crc32LookupTableInitialized) return;


		for (uint i = 0; i <= 0xFF; i++)
		{
			UInt32 crc = i;
			for (uint j = 0; j < 8; j++)
				crc = (crc >> 1) ^ (UInt32)(-(crc & 1) & 0xedb88320u);
			Crc32Lookup[0, i] = crc;
		}

		for (uint i = 0; i <= 0xFF; i++)
		{
			Crc32Lookup[1, i] = (Crc32Lookup[0, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[0, i] & 0xFF];
			Crc32Lookup[2, i] = (Crc32Lookup[1, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[1, i] & 0xFF];
			Crc32Lookup[3, i] = (Crc32Lookup[2, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[2, i] & 0xFF];
			Crc32Lookup[4, i] = (Crc32Lookup[3, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[3, i] & 0xFF];
			Crc32Lookup[5, i] = (Crc32Lookup[4, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[4, i] & 0xFF];
			Crc32Lookup[6, i] = (Crc32Lookup[5, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[5, i] & 0xFF];
			Crc32Lookup[7, i] = (Crc32Lookup[6, i] >> 8) ^ Crc32Lookup[0, Crc32Lookup[6, i] & 0xFF];
		}

		Crc32LookupTableInitialized = true;
	}

	public static UInt32 Compute(byte[] input, UInt32 previousCrc32) {
		var crc = new System.IO.Hashing.Crc32();

		crc.Append(input);

		return BitConverter.ToUInt32(crc.GetCurrentHash(), 0);
	}
	/*
	public static UInt32 Compute(byte[] input, UInt32 previousCrc32) {
		if (input.Length == 0)
		{
			return previousCrc32;
		}

		Int32 current = 0;
		int length = input.Length;
		UInt32 crc = ~previousCrc32;

		InitCrc32LookupTable();

		// process eight bytes at once
		while (length >= 8)
		{
			UInt32 one = BitConverter.ToUInt32(input, current++) ^ crc;
			UInt32 two = BitConverter.ToUInt32(input, current++);
			crc = Crc32Lookup[7, one & 0xFF] ^
				Crc32Lookup[6, (one >> 8) & 0xFF] ^
				Crc32Lookup[5, (one >> 16) & 0xFF] ^
				Crc32Lookup[4, one >> 24] ^
				Crc32Lookup[3, two & 0xFF] ^
				Crc32Lookup[2, (two >> 8) & 0xFF] ^
				Crc32Lookup[1, (two >> 16) & 0xFF] ^
				Crc32Lookup[0, two >> 24];
			length -= 8;
		}
		Int32 currentChar = current * 4;
		// remaining 1 to 7 bytes
		while (length-- > 0)
			crc = (crc >> 8) ^ Crc32Lookup[0, (crc & 0xFF) ^ input[currentChar++]];

		return ~crc;
	}
	*/
}

public class LZ4FrameCompressor {
	public static byte[] Compress(byte[] compressed) {
		return compressed;
	}
	public static byte[] Decompress(byte[] compressed) {
		return compressed;
	}
}

public class Granny2Compressor {
	public static byte[] Decompress(Int32 format, byte[] compressed, Int32 decompressedSize, Int32 stop0, Int32 stop1, Int32 stop2) {
		return compressed;
	}

	public static byte[] Decompress4(byte[] compressed, Int32 decompressedSize) {
		return compressed;
	}

}
}
