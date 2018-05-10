// FFT.h : Fast Fourier Transform, FFT
////////////////////////////////////////////////////////////////////////////////

#ifndef   _FFT_H_
#define   _FFT_H_   ADLINK Technology Inc.

// -----------------------------------------------------------------------------
// Magic Numbers
// -----------------------------------------------------------------------------

#define  FFT_PI         3.14159265358979323846264338327
#define  FFT_FORWARD    0
#define  FFT_INVERSE    1
#define  FFT_FALSE      0
#define  FFT_TRUE       1
#define  FFT_DEFECT     0xFFFFFFFF
#define  FFT_R2D        (180.0/FFT_PI)
#define  FFT_D2R        (FFT_PI/180.0)

#define  FFT__E__NOERR                  0
#define  FFT__E__INVALID_ARGUMENT       1
#define  FFT__E__UNAVAILABLE_MEMORY     2
#define  FFT__E__NOT_POWER_OF_TWO       3
#define  FFT__E__DEFECTIVE_HARMONIC     4

// -----------------------------------------------------------------------------
// Function Prototypes
// -----------------------------------------------------------------------------
#ifndef  U16
typedef  unsigned short  U16;    
#endif
#ifndef  U32
typedef  unsigned long  U32;    // 0..4294967295
#endif
#ifndef  F32
typedef  float          F32;    // 4 byte real
#endif
#ifndef  F64
typedef  double         F64;    // 8 byte real
#endif

#ifdef __cplusplus
extern "C" {
#endif

/*
**  The following function tests whether its argument is a power of two for any
**  non-negative exponent k: x==2^k
*/
U32 __stdcall
is_power_of_two(
      U32       dwNumber       // [IN ] number for checking, x
    );                              // [RET] 1) yes, 0) no

/*
**  The following function return the number of bits needed of its argument
*/
U32 __stdcall
number_of_bits_needed(
      U32       dwPowerOfTwo   // [IN ] number, must be power of two
    );                              // [RET] number of bits needed of its argument

/*
**  The following function reverses the bit order of index number
*/
U32 __stdcall
reverse_bits(
      U32       dwIndex        // [IN ] index number
    , U32       dwNumBits      // [IN ] number of bits of index
    );                              // [RET] reversed bit order of the index number

/*
**  The following function returns an "abstract frequency" of a given index into a
**  buffer with a given number of frequency samples.
**  Multiply return value by sampling rate to get frequency expressed in Hz.
*/
F64 __stdcall
index_to_frequency(
      U32       dwSamples      // [IN ] number of samples
    , U32       dwIndex        // [IN ] index
    );                              // [RET] abstract frequency

/*
**  This returns a static constant error string corresponded its argument
*/
const char* __stdcall
fft_errmsg(
      U32       dwIndex        // [IN ] error index, result of the following functions
    );                              // [RET] error string corresponded its argument

/*
**  The fft() computes the Fourier transform or inverse transform of the complex inputs
**  to produce the complex outputs. The number of samples must be a power of two to
**  do the recursive decomposition of the FFT algorithm.
**
**  The fft_F64() maybe faster than fft_F32(), because the argument's type of the
**  internal computing functions is F64.
**
**  If you pass lpSrcImag = 0, these functions will "pretend" that it is an array of
**  all zeroes.
**
**  <<< CHECKING >>>
**  U32  __error_index = fft_xxx(...);
**  if ( __error_index ) { puts(fft_errmsg(__error_index)); return false; }
*/
U32 __stdcall
fft_float(
      U32       IsInverse      // [IN ] 0) forward, x) inverse transform
    , U32       dwSamples      // [IN ] number of samples, must be power of 2
    , const F32*   lpSrcReal      // [IN ] source samples, reals
    , const F32*   lpSrcImag      // [IN ] source samples, imaginaries, could be NULL
    , F32*         lpTgtReal      // [OUT] target outputs, reals
    , F32*         lpTgtImag      // [OUT] target outputs, imaginaries
    );                              // [RET] 0) no error, x) error index

U32 __stdcall
fft_double(
      U32       IsInverse      // [IN ] 0) forward, x) inverse transform
    , U32       dwSamples      // [IN ] number of samples, must be power of 2
    , const F64*  lpSrcReal      // [IN ] source samples, reals
    , const F64*  lpSrcImag      // [IN ] source samples, imaginaries, could be NULL
    , F64*        lpTgtReal      // [OUT] target outputs, reals
    , F64*        lpTgtImag      // [OUT] target outputs, imaginaries
    );                              // [RET] 0) no error, x) error index

U32 __stdcall
fft_spectrum_float(
      U32       dwSamples      // [IN ] number of samples, must be power of 2
    , const F32*   lpSrcReal      // [IN ] source samples, real part
    , const F32*   lpSrcImag      // [IN ] source samples, image part, could be NULL
    , F32*         lpPowerSp      // [OUT] power outputs, reals only
    , F32*         lpPhaseSp      // [OUT] phase outputs, reals only, radians
    );                              // [RET] 0) no error, x) error index

U32 __stdcall
fft_spectrum_double(
      U32       dwSamples      // [IN ] number of samples, must be power of 2
    , const F64*  lpSrcReal      // [IN ] source samples, real part
    , const F64*  lpSrcImag      // [IN ] source samples, image part, could be NULL
    , F64*        lpPowerSp      // [OUT] power outputs, reals only
    , F64*        lpPhaseSp      // [OUT] phase outputs, reals only, radians
    );                              // [RET] 0) no error, x) error index

/*
**  These will do one array multiplication with the input array and the N-point
**  symmetric Hanning/Hamming window in a column array.
**
**  If you pass lpSources = 0, these will get pure "window" values.
**
**  <<< CHECKING >>>
**  U32  __actual = haxxing(dwSamples, ...);
**  if ( __actual != dwSamples ) { return false; }
*/
U32 __stdcall
hanning(
      U32       dwSamples      // [IN ] number of samples
    , const F64*  lpSources      // [IN ] source samples, reals, could be 0
    , F64*        lpTargets      // [OUT] target results, reals
    );                              // [RET] actual processed count

U32 __stdcall
hamming(
      U32       dwSamples      // [IN ] number of samples
    , const F64*  lpSources      // [IN ] source samples, reals, could be 0
    , F64*        lpTargets      // [OUT] target results, reals
    );                              // [RET] actual processed count

U32 __stdcall
kaiser(
      unsigned           dwSamples       // [IN ] number of samples
    , const F64*    lpSources       // [IN ] source samples, reals, could be 0
    , F64*          lpTargets       // [OUT] target results, reals
	, F64           beta            // [IN ] beta for kaiser window
	);		                        // [RET] actual processed count
/*
**  This is used to calculate SNR, SINAD, THD, ENOB and SFDR values.
**
**  SINAD  : Signal-to-Noise and Distortion Ratio
**  SNR    : Signal-to-Noise Ratio
**  THD    : Total Harmonic Distortion
**  ENOB   : Effective Number of Bits
**  SFDR   : Spurious-Free Dynamic Range
**  MSB    : Maximum Spurious Bin
**
**  There are some suggested values as follow:
**      dwMainSpan <-- max(5, dwSamples/200)
**      dwHarmSpan <-- 1
**      dwSearch   <-- max(dwHarmSpan, dwHalf >> 4)
**      range(center, span) = [center-span, center+span]
**
**  [NOTE] Defective Harmonic <-- FFT_DEFECT (0xFFFFFFFF);
**         For this procedure to work, ensure the folded back high order harmonics
**         do not overlap with dc or signal or lower order harmonics.
**
**  <<< CHECKING >>>
**  U32  __error_index = dynamic_performance(...);
**  if ( __error_index ) { puts(fft_errmsg(__error_index)); return false; }
*/
U32 __stdcall
dynamic_performance(
      U32       dwHalf         // [IN ] half number of samples, must be power of 2
    , const F64*  lpSpectrum     // [IN ] array, fft power spectrum
    , U32       dwIndexDc      // [IN ] parameter used to avoid the dc stuff
    , U32       dwSearch       // [IN ] approximate search span for harmonics on each side
    , U32       dwMainSpan     // [IN ] span of the main signal frequency on each side
    , U32       dwHarmSpan     // [IN ] span of the harmonic frequency on each side
    , U32       dwHarmCount    // [IN ] harmonic count
    , U32*      lpHarmIndexes  // [OUT] array, harmonic frequencies (indexes)
    , F64*        lpHarmPowers   // [OUT] array, harmonic powers
    , F64*        lpSINAD        // [OUT] pointer, signal-to-noise and distortion ratio
    , F64*        lpSNR          // [OUT] pointer, signal-to-noise ratio
    , F64*        lpTHD          // [OUT] pointer, total harmonic distortion
    , F64*        lpENOB         // [OUT] pointer, effective number of bits
    , F64*        lpSFDR         // [OUT] pointer, spurious-free dynamic range
    , U32*      lpMsbIndex     // [OUT] pointer, maximum spurious frequency (index)
    , F64*        lpMsbPower     // [OUT] pointer, maximum spurious power
    );                              // [RET] 0) no error, x) error index

/*
**  This is used to calculate IMD value
*/
U32 __stdcall
imd_performance(
      U32           dwHalf          // [IN ] half number of samples, must be power of 2
    , const F64*    lpSpectrum      // [IN ] array, fft power spectrum
    , U32           dwIndexDc       // [IN ] parameter used to avoid the dc stuff
    , U32           dwSearch        // [IN ] approximate search span for IMD on each side
    , U32           dwMainSpan      // [IN ] span of the main signal frequency on each side, [0,dwSearch]
    , U32           dwImdSpan       // [IN ] span of the IMD frequency on each side, [0,dwSearch]
    , U32           dwImdCount      // [IN ] IMD count, include signal
    , U32*          lpImdIndexes    // [OUT] array, IMD frequencies (indexes)
    , F64*          lpImdPowers     // [OUT] array, IMD powers
    );                              // [RET] 0) no error, x) error index
/*
**  This is used to calculate MultiTone value
*/
U32 __stdcall
multitone_performance(
      U32           dwHalf          // [IN ] half number of samples, must be power of 2
    , const F64*    lpSpectrum      // [IN ] array, fft power spectrum
    , U32           dwIndexDc       // [IN ] parameter used to avoid the dc stuff
    , U32           dwMainSpan      // [IN ] span of the main signal frequency on each side, [0,dwSearch]
    , U32           dwToneCount     // [IN ] Tone counts
    , U32*          lpToneIndexes   // [OUT] array, tone frequencies (indexes)
    , F64*          lpTonePowers    // [OUT] array, tone powers
    );                              // [RET] 0) no error, x) error index

/*
**  iba : index-based array   <-- [ c1d1, c2d1, c3d1, ..., c1d2, c2d2, c3d2, ... ]
**  cba : channel-based array <-- [ c1d1, c1d2, ..., c2d1, c2d2, ..., c3d1, c3d2, ... ]
**
**  [NOTE] length(array) = dwChannels * dwSamples;
*/
void __stdcall
iba2cba(
      U32       dwChannels     // [IN ] number of channels
    , U32       dwSamples      // [IN ] number of samples for each channels
    , const F64*  lpIba          // [IN ] source index-based array
    , F64*        lpCba          // [OUT] target channel-based array
    );

void __stdcall
cba2iba(
      U32       dwChannels     // [IN ] number of channels
    , U32       dwSamples      // [IN ] number of samples for each channels
    , const F64*  lpCba          // [IN ] source channel-based array
    , F64*        lpIba          // [OUT] target index-based array
    );

/*
**  <<< CHECKING >>>
**  F64*  __ending = log10_xxx(dwLen, ..., lpTgt, ...);
**  if ( __ending != lpTgt +dwLen ) { return false; }
*/
F64 __stdcall
log10_single(
      F64  x                     // [IN ] source number <-- x
    );                              // [RET] log10 value   <-- log10(x)

F64* __stdcall
log10_range(
      U32   dwLen         // [IN ] array length      <-- n
    , const F64*   lpSrc         // [IN ] source array      <-- xx
    ,       F64*   lpTgt         // [OUT] target array, log <-- log10(xx)
    );                              // [RET] ending pointer    <-- lpTgt +n

F64* __stdcall
log10_complex(
      U32   dwLen         // [IN ] array length              <-- n
    , const F64*   lpSrcReal     // [IN ] source array, real part   <-- a
    , const F64*   lpSrcImag     // [IN ] source array, image part  <-- b
    ,       F64*   lpTgt         // [OUT] target array, log complex <-- 0.5*log10(a^2+b^2)
    );                              // [RET] ending pointer            <-- lpTgt +n

F64* __stdcall
log10_db(
      U32   dwLen         // [IN ] array length           <-- n
    , const F64*   lpSrc         // [IN ] source array           <-- x
    ,       F64*   lpTgt         // [OUT] target array, db value <-- d+c*log10(x)
    , const F64    cdMult = 1.0  // [OPT] constant multiplier    <-- c
    , const F64    cdBias = 0.0  // [OPT] constant bias          <-- d
    );                              // [RET] ending pointer         <-- lpTgt +n

F64* __stdcall
log10_power(
      U32   dwLen         // [IN ] array length              <-- n
    , const F64*   lpSrcReal     // [IN ] source reals              <-- a
    , const F64*   lpSrcImag     // [IN ] source images             <-- b
    ,       F64*   lpTgtPw       // [OUT] target powers, could be 0 <-- a^2+b^2
    ,       F64*   lpTgtPd       // [OUT] target powers, db value   <-- d+c*log10(a^2+b^2)
    , const F64    cdMult = 1.0  // [OPT] constant multiplier       <-- c
    , const F64    cdBias = 0.0  // [OPT] constant bias             <-- d
    );                              // [RET] ending pointer            <-- lpTgtPd +n

F64* __stdcall
log10_normalize(
      U32   dwLen         // [IN ] array length                 <-- n
    , const F64*   lpSrcReal     // [IN ] source reals                 <-- a
    , const F64*   lpSrcImag     // [IN ] source images                <-- b
    ,       F64*   lpTgtPw       // [OUT] target powers, could be 0    <-- a^2+b^2
    ,       F64*   lpTgtPd       // [OUT] target powers, normalize db  <-- d-m+c*log10(a^2+b^2)
    , const F64    cdMult  = 1.0 // [OPT] constant multiplier          <-- c
    , const F64    cdBias  = 0.0 // [OPT] constant bias                <-- d
    ,       F64*   lpMaxPd = 0   // [OPT] maximum db value, could be 0 <-- m
    );                              // [RET] ending pointer               <-- lpTgtPd +n


#ifdef __cplusplus
}
#endif


#endif  // _FFT_H_
