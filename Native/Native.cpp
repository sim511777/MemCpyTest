// Native.cpp : DLL을 위해 내보낸 함수를 정의합니다.
//

#include "pch.h"
#include "framework.h"
#include "Native.h"

// 내보낸 함수의 예제입니다.
NATIVE_API int fnNative(void)
{
    return 0;
}

NATIVE_API void* C_Memcpy1(void *pdst, void *psrc, size_t nbyte) {
    BYTE* dst = (BYTE*)pdst;
    BYTE* src = (BYTE*)psrc;
    
    while (nbyte-- > 0)
        *dst++ = *src++;

    return pdst;
}

NATIVE_API void* C_Memcpy4(void *pdst, void *psrc, size_t nbyte) {
    int* dst_4 = (int*)pdst;
    int* src_4 = (int*)psrc;
    size_t repeat = nbyte >> 2;

    while (repeat-- > 0)
        *dst_4++ = *src_4++;

    BYTE* dst = (BYTE*)dst_4;
    BYTE* src = (BYTE*)src_4;

    repeat = nbyte % 4;
    for (size_t i = 0; i < repeat; ++i)
        dst[i] = src[i];

    return pdst;
}

NATIVE_API void* C_Memcpy8(void *pdst, void *psrc, size_t nbyte) {
    INT64* dst_8 = (INT64*)pdst;
    INT64* src_8 = (INT64*)psrc;
    size_t repeat = nbyte >> 3;

    while (repeat-- > 0)
        *dst_8++ = *src_8++;

    BYTE* dst = (BYTE*)dst_8;
    BYTE* src = (BYTE*)src_8;

    repeat = nbyte % 8;
    for (size_t i = 0; i < repeat; ++i)
        dst[i] = src[i];

    return pdst;
}

NATIVE_API void* C_MemcpySse(void *pdst, void *psrc, size_t nbyte) {
    __int64 nloop = nbyte / 16;
    __int64 nfinish = nloop * 16;
    __int64 nrest = nloop - nfinish;

    __m128i *mpdst = (__m128i*)pdst;
    __m128i *mpsrc = (__m128i*)psrc;

    for (__int64 x = 0; x < nloop; x++) {
        __m128i mvsrc = _mm_loadu_si128(mpsrc);
        _mm_storeu_si128(mpdst, mvsrc);
        mpdst++, mpsrc++;
    }

    if (nrest > 0) {
        BYTE *src = (BYTE*)psrc + nfinish;
        BYTE *dst = (BYTE*)pdst + nfinish;
        for (int i = 0; i < nrest; i++, src++, dst++) {
            *src = *dst;
        }
    }

    return pdst;
}