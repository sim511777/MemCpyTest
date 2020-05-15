using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MemCpyTest {
    public class Util2 {
        [DllImport("msvcrt.dll")] public static extern IntPtr memset(IntPtr dst, int val, long count);
    }

    public class Util {
        [DllImport("msvcrt.dll")] public static extern IntPtr memcpy(IntPtr dst, IntPtr src, long count);
        [DllImport("Native.dll")] public static extern IntPtr C_Memcpy1(IntPtr dst, IntPtr src, long count);
        [DllImport("Native.dll")] public static extern IntPtr C_Memcpy4(IntPtr dst, IntPtr src, long count);
        [DllImport("Native.dll")] public static extern IntPtr C_Memcpy8(IntPtr dst, IntPtr src, long count);
        [DllImport("Native.dll")] public static extern IntPtr C_MemcpySse(IntPtr dst, IntPtr src, long count);
        
        public static unsafe IntPtr UnsafeMemcpy1(IntPtr _Dst, IntPtr _Src, long _Size) {
            byte* psrc = (byte*)_Src.ToPointer();
            byte* pdst = (byte*)_Dst.ToPointer();
            for (long i = 0; i < _Size; i++, psrc++, pdst++) {
                *pdst = *psrc;
            }
            return _Dst;
        }

        public static unsafe IntPtr UnsafeMemcpy4(IntPtr _Dst, IntPtr _Src, long _Size) {
            long num4 = _Size / 4;
            long remains = _Size % 4;
            UnsafeMemcpyUint32(_Dst, _Src, num4);
            UnsafeMemcpy1((IntPtr)((long)_Dst + (num4 * 4)), (IntPtr)((long)_Src + (num4 * 4)), remains);
            return _Dst;
        }

        public static unsafe IntPtr UnsafeMemcpy8(IntPtr _Dst, IntPtr _Src, long _Size) {
            long num8 = _Size / 8;
            long remains = _Size % 8;
            UnsafeMemcpyUInt64(_Dst, _Src, num8);
            UnsafeMemcpy1((IntPtr)((long)_Dst + (num8 * 8)), (IntPtr)((long)_Src + (num8 * 8)), remains);
            return _Dst;
        }

        public static unsafe IntPtr Unsafe_CopyBlock(IntPtr _Dst, IntPtr _Src, long _Size) {
            Unsafe.CopyBlock((void*)_Dst, (void*)_Src, (uint)_Size);
            return _Dst;
        }

        public static unsafe IntPtr Buffer_MemoryCopy(IntPtr _Dst, IntPtr _Src, long _Size) {
            Buffer.MemoryCopy((void*)_Src, (void*)_Dst, _Size, _Size);
            return _Dst;
        }

        private unsafe static IntPtr UnsafeMemcpyUint32(IntPtr _Dst, IntPtr _Src, long _Size) {
            uint* psrc = (uint*)_Src.ToPointer();
            uint* pdst = (uint*)_Dst.ToPointer();
            for (long i = 0; i < _Size; i++, psrc++, pdst++) {
                *pdst = *psrc;
            }
            return _Dst;
        }

        private unsafe static IntPtr UnsafeMemcpyUInt64(IntPtr _Dst, IntPtr _Src, long _Size) {
            ulong* psrc = (ulong*)_Src.ToPointer();
            ulong* pdst = (ulong*)_Dst.ToPointer();
            for (long i = 0; i < _Size; i++, psrc++, pdst++) {
                *pdst = *psrc;
            }
            return _Dst;
        }
    }
}
