//---------------------------------------------------------------------------

#include <vcl.h>
#include <emmintrin.h>
#pragma hdrstop

#include "Unit3.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm3 *Form3;
//---------------------------------------------------------------------------
String FormatString(const TCHAR* format, ...) {
    va_list args;
    va_start (args, format);

    String text;
    text.vprintf(format, args);

    va_end (args);

    return text;
}

double GetTimeHigh() {
    static LARGE_INTEGER freq;
    static BOOL r = QueryPerformanceFrequency(&freq);
    LARGE_INTEGER cnt;
    QueryPerformanceCounter(&cnt);
    return (double)cnt.QuadPart / freq.QuadPart;
}

double GetTimeMs() {
    return GetTimeHigh() * 1000;
}

void* C_MemcpySse(void *pdst, void *psrc, size_t nbyte) {
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

void *src;
void *dst;
INT64 bytes;
__fastcall TForm3::TForm3(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm3::btnMemcpyClick(TObject *Sender)
{
    double t0 = GetTimeMs();

    memcpy(dst, src, bytes);

    double dt = GetTimeMs() - t0;

    String str = FormatString(L"memcpy 5GB - %.3f ms", dt);
    lbxLog->Items->Add(str);
}
//---------------------------------------------------------------------------

void __fastcall TForm3::btnMemcpySseClick(TObject *Sender)
{
    double t0 = GetTimeMs();

    C_MemcpySse(dst, src, bytes);

    double dt = GetTimeMs() - t0;

    String str = FormatString(L"C_MemcpySse 5GB - %.3f ms", dt);
    lbxLog->Items->Add(str);
}
//---------------------------------------------------------------------------

void __fastcall TForm3::Button1Click(TObject *Sender)
{
    lbxLog->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TForm3::FormCreate(TObject *Sender)
{
    double t0 = GetTimeMs();

    bytes = (INT64)5000 * 1024 * 1024;
    src = new BYTE[bytes];
    memset(src, 0, bytes);
    dst = new BYTE[bytes];
    memset(src, 0, bytes);

    double dt = GetTimeMs() - t0;

    String str = FormatString(L"Alloc 5GB - %.3f ms", dt);
    lbxLog->Items->Add(str);
}
//---------------------------------------------------------------------------

