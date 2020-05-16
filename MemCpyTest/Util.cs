using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MemCpyTest {
    public class Util2 {
        [DllImport("msvcrt.dll")] public static extern IntPtr memset(IntPtr dst, int val, Int64 count);
    }

    public class Util {
        [DllImport("msvcrt.dll")] public static extern IntPtr memcpy(IntPtr _Dst, IntPtr _Src, Int64 _Size);
        [DllImport("Native.dll")] public static extern IntPtr C_Memcpy1(IntPtr _Dst, IntPtr _Src, Int64 _Size);
        [DllImport("Native.dll")] public static extern IntPtr C_Memcpy4(IntPtr _Dst, IntPtr _Src, Int64 _Size);
        [DllImport("Native.dll")] public static extern IntPtr C_MemcpySse(IntPtr _Dst, IntPtr _Src, Int64 _Size);
        
        public static unsafe IntPtr UnsafeMemcpy1(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
            Int64 size1 = _Size;
            
            byte* pdst1 = (byte*)_Dst;
            byte* psrc1 = (byte*)_Src;
            while (size1-- > 0)
                *pdst1++ = *psrc1++;
            
            return _Dst;
        }

        public static unsafe IntPtr UnsafeMemcpy4(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
            Int64 size4 = _Size / 4;
            Int64 size1 = _Size % 4;
            
            int* pdst4 = (int*)_Dst;
            int* psrc4 = (int*)_Src;
            while (size4-- > 0)
                *pdst4++ = *psrc4++;

            byte* pdst1 = (byte*)pdst4;
            byte* psrc1 = (byte*)psrc4;
            while (size1-- > 0)
                *pdst1++ = *psrc1++;

            return _Dst;
        }

        public static unsafe IntPtr Unsafe_CopyBlock(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
            Unsafe.CopyBlock((void*)_Dst, (void*)_Src, (uint)_Size);
            return _Dst;
        }

        public static unsafe IntPtr Buffer_MemoryCopy(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
            Buffer.MemoryCopy((void*)_Src, (void*)_Dst, _Size, _Size);
            return _Dst;
        }
    }
}
