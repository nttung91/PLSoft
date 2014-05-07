namespace Technical.Utilities.Cryptography
{
	/// <summary>  
	///   Blowfish ECB implementation
	/// </summary>
	/// <remarks>
	///   Use this class to encrypt or decrypt byte arrays or a single
	///   block with Blowfish in the ECB (Electronic Code Book) mode,
	///   they key length can be flexible from zero up to 56 bytes.
	/// </remarks>
	public class Blowfish
	{
		/// <summary>
		///   maximum (and recommended) key size in bytes
		/// </summary>
		public const int MaxKeyLength = 56;

		/// <summary>
		///   block size in bytes
		/// </summary>
		/// <remarks>
		///   (please note that data has to be aligned to the block size) 
		/// </remarks>
		public const int BLOCKSIZE = 8;

		const int PBOX_ENTRIES = 18;
		const int SBOX_ENTRIES = 256;

		uint[] m_pbox;
		uint[] m_sbox1;
		uint[] m_sbox2;
		uint[] m_sbox3;
		uint[] m_sbox4;

		int m_nIsWeakKey;

		/// <summary>
		/// to check if the key used is weak, which means that eventually
		/// an attack is easier to apply than simple brute force on keys;
		/// due to the randomness such a case is very unlikely to happen
		/// </summary>
		public bool IsWeakKey
		{
			get
			{
				// (NOTE: for performance reason we don't do the weak key 
				//  check during the initialization, but on demand only)

				if (-1 == m_nIsWeakKey)
				{
					m_nIsWeakKey = 0;

					int nI, nJ;
					for (nI = 0; nI < SBOX_ENTRIES - 1; nI++) 
					{
						nJ = nI + 1;
						while (nJ < SBOX_ENTRIES) 
						{
							if ((m_sbox1[nI] == m_sbox1[nJ]) |
							    (m_sbox2[nI] == m_sbox2[nJ]) | 
							    (m_sbox3[nI] == m_sbox3[nJ]) |
							    (m_sbox4[nI] == m_sbox4[nJ])) break;
							else nJ++;
						}
						if (nJ < SBOX_ENTRIES)
						{
							m_nIsWeakKey = 1;
							break;
						}
					}
				}

				return (1 == m_nIsWeakKey);
			}
		}

		/// <summary>
		///   standard constructor
		/// </summary>
		/// <param name="key"> 
		///   the key material, up to MAXKYELENGTH bytes, oversized material is ignored
		/// </param>
		public Blowfish
			(byte[] key) 
		{
			int nI;

			m_pbox = new uint[PBOX_ENTRIES];

			for (nI = 0; nI < PBOX_ENTRIES; nI++)
			{
				m_pbox[nI] = BlowfishTables.pbox_init[nI];
			}

			m_sbox1 = new uint[SBOX_ENTRIES];
			m_sbox2 = new uint[SBOX_ENTRIES];
			m_sbox3 = new uint[SBOX_ENTRIES];
			m_sbox4 = new uint[SBOX_ENTRIES];

			for (nI = 0; nI < SBOX_ENTRIES; nI++) 
			{
				m_sbox1[nI] = BlowfishTables.sbox_init_1[nI];
				m_sbox2[nI] = BlowfishTables.sbox_init_2[nI];
				m_sbox3[nI] = BlowfishTables.sbox_init_3[nI];
				m_sbox4[nI] = BlowfishTables.sbox_init_4[nI];
			}

			// xor the key over the p-boxes

			int nLen = key.Length;
			if (nLen == 0) return; 
			int nKeyPos = 0;
			uint unBuild = 0;

			for (nI = 0; nI < PBOX_ENTRIES; nI++)
			{
				for (int nJ = 0; nJ < 4; nJ++) 
				{
					unBuild = (unBuild << 8) | key[nKeyPos];
      
					if (++nKeyPos == nLen) 
					{ 
						nKeyPos = 0;
					}
				}
				m_pbox[nI] ^= unBuild;
			}


			// encrypt all boxes with the all zero string
			uint unZeroHi = 0;
			uint unZeroLo = 0;

			for (nI = 0; nI < PBOX_ENTRIES; nI += 2) 
			{
				BaseEncrypt(ref unZeroHi, ref unZeroLo);
				m_pbox[nI] = unZeroHi;
				m_pbox[nI + 1] = unZeroLo;
			}
			for (nI = 0; nI < SBOX_ENTRIES; nI += 2) 
			{
				BaseEncrypt(ref unZeroHi, ref unZeroLo);
				m_sbox1[nI] = unZeroHi;
				m_sbox1[nI + 1] = unZeroLo;
			}
			for (nI = 0; nI < SBOX_ENTRIES; nI += 2) 
			{
				BaseEncrypt(ref unZeroHi, ref unZeroLo);
				m_sbox2[nI] = unZeroHi;
				m_sbox2[nI + 1] = unZeroLo;
			}
			for (nI = 0; nI < SBOX_ENTRIES; nI += 2) 
			{
				BaseEncrypt(ref unZeroHi, ref unZeroLo);
				m_sbox3[nI] = unZeroHi;
				m_sbox3[nI + 1] = unZeroLo;
			}
			for (nI = 0; nI < SBOX_ENTRIES; nI += 2) 
			{
				BaseEncrypt(ref unZeroHi, ref unZeroLo);
				m_sbox4[nI] = unZeroHi;
				m_sbox4[nI + 1] = unZeroLo;
			}

			m_nIsWeakKey = -1;
		}


		/// <summary>
		///   deletes all internal data structures and invalidates this instance
		/// </summary>
		/// <remarks>
		///   Call this method as soon as the work with a particular instance is
		///   done. By this no sensitive translated key material remains. The
		///   instance is invalid after this call and usage can lead to unexpected
		///   results.
		/// </remarks> 
		public virtual void Burn() 
		{
			int nI;

			for (nI = 0; nI < PBOX_ENTRIES; nI++)
			{
				m_pbox[nI] = 0;
			}

			for (nI = 0; nI < SBOX_ENTRIES; nI++)
			{
				m_sbox1[nI] = m_sbox2[nI] = m_sbox3[nI] = m_sbox4[nI] = 0;
			}
		}



		static readonly byte[] TEST_KEY = { 0x1c, 0x58, 0x7f, 0x1c, 0x13, 0x92, 0x4f, 0xef };
		static readonly uint[] TEST_VECTOR_PLAIN  = { 0x30553228, 0x6d6f295a };
		static readonly uint[] TEST_VECTOR_CIPHER = { 0x55cb3774, 0xd13ef201 };


		/// <summary>
		///   executes a selftest
		/// </summary>
		/// <remarks>
		///   Call this method to make sure that the instance is able to produce
		///   valid output according to the specification.
		/// </remarks>
		/// <returns>
		///   true: selftest passed / false: selftest failed
		/// </returns>
		public static bool SelfTest()
		{
			uint unHi = TEST_VECTOR_PLAIN[0];
			uint unLo = TEST_VECTOR_PLAIN[1];

			Blowfish bf = new Blowfish(TEST_KEY);

			bf.Encrypt(ref unHi, ref unLo);

			if ((unHi != TEST_VECTOR_CIPHER[0]) ||
				(unLo != TEST_VECTOR_CIPHER[1]))
			{
				return false;
			}

			bf.Decrypt(ref unHi, ref unLo);

			if ((unHi != TEST_VECTOR_PLAIN[0]) ||
				(unLo != TEST_VECTOR_PLAIN[1]))
			{
				return false;
			}

			return true;
		}

		protected void BaseEncrypt
			(ref uint unHiRef,
			ref uint unLoRef)
		{
			// copy to local cache (faster)
   
			uint unHi = unHiRef; 
			uint unLo = unLoRef; 

			// and use local references, too

			uint[] sbox1 = m_sbox1;
			uint[] sbox2 = m_sbox2;
			uint[] sbox3 = m_sbox3;
			uint[] sbox4 = m_sbox4;

			uint[] pbox = m_pbox;

			// encrypt the block, unrolled loop and odd/even changes to maximize the speed

			unHi ^= pbox[0];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[1];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[2];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[3];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[4];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[5];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[6];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[7];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[8];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[9];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[10];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[11];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[12];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[13];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[14];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[15];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[16];

			// finalize and copy back

			unLoRef = unHi;
			unHiRef = unLo ^ pbox[17];
		}

		/// <summary>
		///   encrypts a single block
		/// </summary>
		/// <remarks>
		///   Use this method to encrypt one logical block, which is passed
		///   as two 32bit halves. If you extract the block from a sequence
		///   of bytes you have to do it in the network byte order.
		/// </remarks>
		/// <param name="unHiRef">
		///   reference to the high 32 bits of the block
		/// </param>
		/// <param name="unLoRef">
		///   reference to the low 32 bits of the block
		/// </param>
		public virtual void Encrypt
			(ref uint unHiRef,
			ref uint unLoRef)
		{
			BaseEncrypt(ref unHiRef, ref unLoRef);
		}


		/// <summary>
		///   encrypts single bytes
		/// </summary>
		/// <remarks>
		///   Use this method to encrypt bytes from one array to another one.
		///   You can also use the same array for input and output. Note that
		///   the number of bytes must be adjusted to the block size of the
		///   algorithm. Overlapping bytes will not be encrypted. No check for
		///   buffer overflows are made.
		/// </remarks>
		/// <param name="dataIn"> input buffer </param>
		/// <param name="dataOut"> output buffer </param>
		/// <param name="nPosIn"> where to start reading in the input buffer </param>
		/// <param name="nPosOut"> where to start writing to the output buffer </param>
		/// <param name="nCount"> number ob bytes to encrypt </param>
		/// <returns>
		///   number of blocks processed
		/// </returns>
		public int Encrypt
			(byte[] dataIn,
			byte[] dataOut,
			int nPosIn,
			int nPosOut,
			int nCount) 
		{
			// count in blocks
			nCount >>= 3;

			for (int nI = 0; nI < nCount; nI++)
			{
				// load the bytes into two 32bit words, which together represent the block

				uint unHi = (((uint) dataIn[nPosIn]) << 24) |
					(((uint) dataIn[nPosIn + 1]) << 16) |
					(((uint) dataIn[nPosIn + 2]) << 8) |
					dataIn[nPosIn + 3];
 
				uint unLo = (((uint) dataIn[nPosIn + 4]) << 24) |
					(((uint) dataIn[nPosIn + 5]) << 16) |
					(((uint) dataIn[nPosIn + 6]) << 8) |
					dataIn[nPosIn + 7];

				// encrypt that construct

				Encrypt(ref unHi, ref unLo);

				// write the encrypted block back

				dataOut[nPosOut]     = (byte)(unHi >> 24);
				dataOut[nPosOut + 1] = (byte)(unHi >> 16);
				dataOut[nPosOut + 2] = (byte)(unHi >> 8);
				dataOut[nPosOut + 3] = (byte)unHi;
				dataOut[nPosOut + 4] = (byte)(unLo >> 24);
				dataOut[nPosOut + 5] = (byte)(unLo >> 16);
				dataOut[nPosOut + 6] = (byte)(unLo >> 8);
				dataOut[nPosOut + 7] = (byte)unLo;

				nPosIn += 8; 
				nPosOut += 8;
			}

			return nCount;
		}



		/// <summary>
		///   decrypts a single block
		/// </summary>
		/// <remarks>
		///   Use this method to decrypt one logical block, which is passed
		///   as two 32bit halves. If you extract the block from a sequence
		///   of bytes you have to do it in the network byte order.
		/// </remarks>
		/// <param name="unHiRef">
		///   reference to the high 32 bits of the block
		/// </param>
		/// <param name="unLoRef">
		///   reference to the low 32 bits of the block
		/// </param>
		public virtual void Decrypt
			(ref uint unHiRef,
			ref uint unLoRef)
		{
			// (same procedure and tricks as above)
   
			uint unHi = unHiRef; 
			uint unLo = unLoRef; 

			uint[] sbox1 = m_sbox1;
			uint[] sbox2 = m_sbox2;
			uint[] sbox3 = m_sbox3;
			uint[] sbox4 = m_sbox4;

			uint[] pbox = m_pbox;

			unHi ^= pbox[(int)(17)];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[16];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[15];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[14];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[13];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[12];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[11];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[10];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[9];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[8];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[7];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[6];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[5];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[4];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[3];
			unLo ^= (((sbox1[(int)(unHi >> 24)] + sbox2[(int)((unHi >> 16) & 0x0ff)]) ^ sbox3[(int)((unHi >> 8) & 0x0ff)]) + sbox4[(int)(unHi & 0x0ff)]) ^ pbox[2];
			unHi ^= (((sbox1[(int)(unLo >> 24)] + sbox2[(int)((unLo >> 16) & 0x0ff)]) ^ sbox3[(int)((unLo >> 8) & 0x0ff)]) + sbox4[(int)(unLo & 0x0ff)]) ^ pbox[1];

			unLoRef = unHi;
			unHiRef = unLo ^ pbox[0];
		}


		/// <summary>
		///   decrypts single bytes
		/// </summary>
		/// <remarks>
		///   Use this method to decrypt bytes from one array to another one.
		///   You can also use the same array for input and output. Note that
		///   the number of bytes must be adjusted to the block size of the
		///   algorithm. Overlapping bytes will not be decrypted. No check for
		///   buffer overflows are made.
		/// </remarks>
		/// <param name="dataIn"> input buffer </param>
		/// <param name="dataOut"> output buffer </param>
		/// <param name="nPosIn"> where to start reading in the input buffer </param>
		/// <param name="nPosOut"> where to start writing to the output buffer </param>
		/// <param name="nCount"> number ob bytes to decrypt </param>
		/// <returns>
		///   number of blocks processed
		/// </returns>
		public int Decrypt
			(byte[] dataIn,
			byte[] dataOut,
			int nPosIn,
			int nPosOut,
			int nCount) 
		{
			// count in blocks
			nCount >>= 3;

			for (int nI = 0; nI < nCount; nI++)
			{
				// load the bytes into two 32bit words, which together represent the block

				uint unHi = (((uint) dataIn[nPosIn]) << 24) |
					(((uint) dataIn[nPosIn + 1]) << 16) |
					(((uint) dataIn[nPosIn + 2]) << 8) |
					dataIn[nPosIn + 3];
 
				uint unLo = (((uint) dataIn[nPosIn + 4]) << 24) |
					(((uint) dataIn[nPosIn + 5]) << 16) |
					(((uint) dataIn[nPosIn + 6]) << 8) |
					dataIn[nPosIn + 7];

				// encrypt that construct

				Decrypt(ref unHi, ref unLo);

				// write the encrypted block back

				dataOut[nPosOut]     = (byte)(unHi >> 24);
				dataOut[nPosOut + 1] = (byte)(unHi >> 16);
				dataOut[nPosOut + 2] = (byte)(unHi >> 8);
				dataOut[nPosOut + 3] = (byte)unHi;
				dataOut[nPosOut + 4] = (byte)(unLo >> 24);
				dataOut[nPosOut + 5] = (byte)(unLo >> 16);
				dataOut[nPosOut + 6] = (byte)(unLo >> 8);
				dataOut[nPosOut + 7] = (byte)unLo;

				nPosIn += 8; 
				nPosOut += 8;
			}

			return nCount;
		}
	}
}
