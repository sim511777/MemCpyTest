// Native.cpp : DLL을 위해 내보낸 함수를 정의합니다.
//

#include "pch.h"
#include "framework.h"
#include "Native.h"

NATIVE_API IntPtr C_Memcpy1(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
    Int64 size1 = _Size;

    // 1byte 단위로 복사
    byte* pdst1 = (byte*)_Dst;
    byte* psrc1 = (byte*)_Src;
    while (size1-- > 0)
        *pdst1++ = *psrc1++;

    return _Dst;
}

NATIVE_API IntPtr C_Memcpy4(IntPtr _Dst, IntPtr _Src, Int64 _Size) {
    Int64 size4 = _Size / 4;
    Int64 size1 = _Size % 4;

    // 4바이트 단위로 복사
    int* pdst4 = (int*)_Dst;
    int* psrc4 = (int*)_Src;
    while (size4-- > 0)
        *pdst4++ = *psrc4++;

    // 자투리 1바이트 단위로 복사
    byte* pdst1 = (byte*)pdst4;
    byte* psrc1 = (byte*)psrc4;
    while (size1-- > 0)
        *pdst1++ = *psrc1++;

    return _Dst;
}

NATIVE_API IntPtr C_MemcpySse(void *_Dst, void *_Src, Int64 _Size) {
    Int64 size16 = _Size / 16;
    Int64 size1 = size16 % 16;

    // 16바이트 단위로 복사 (SIMD사용)
    __m128i *pdst16 = (__m128i*)_Dst;
    __m128i *psrc16 = (__m128i*)_Src;
    while (size16-- > 0)
        _mm_storeu_si128(pdst16++, _mm_loadu_si128(psrc16++));

    // 자투리 1바이트 단위로 복사
    byte* pdst1 = (byte*)pdst16;
    byte* psrc1 = (byte*)psrc16;
    while (size1-- > 0)
        *pdst1++ = *psrc1++;

    return _Dst;
}