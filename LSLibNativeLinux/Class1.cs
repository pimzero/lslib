using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LSLib.Native
{
public class LZ4FrameCompressor {
	[DllImport("liblz4.so", CharSet = CharSet.Unicode)]
	private static unsafe extern UIntPtr LZ4F_createCompressionContext(UIntPtr* cctxPtr, uint version);

	[DllImport("liblz4.so", CharSet = CharSet.Unicode)]
	private static extern uint LZ4F_isError(UIntPtr code);


	public static byte[] Compress(byte[] compressed) {
		throw new NotSupportedException("LZ4 compression is currently unsupported");
		/*
		UIntPtr cctx;
		UIntPtr error;
		unsafe {
			 error = LZ4F_createCompressionContext(&cctx, 100);
		}
		if (LZ4F_isError(error) != 0) {
			throw new Exception("Failed to create LZ4 compression context");
		}*/
		return compressed;
	}
	public static byte[] Decompress(byte[] compressed) {
		throw new NotSupportedException("LZ4 decompression is currently unsupported");
		return compressed;
	}
}

public class Granny2Compressor {
	public static byte[] Decompress(Int32 format, byte[] compressed, Int32 decompressedSize, Int32 stop0, Int32 stop1, Int32 stop2) {
		throw new NotSupportedException("GR2 decompression is currently unsupported");
		return compressed;
	}

	public static byte[] Decompress4(byte[] compressed, Int32 decompressedSize) {
		throw new NotSupportedException("GR2 decompression is currently unsupported");
		return compressed;
	}

}
}
