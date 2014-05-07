namespace Technical.Utilities.Cryptography
{

	/// <summary>
	///   helper class to enable CBCB for Blowfish
	/// </summary>
	/// <remarks>
	///   Use this class to encrypt or decrypt byte arrays or a single
	///   block with Blowfish in the CBC (Cipher Block Block Chaining) mode.
	/// </remarks>
	public class BlowfishCbc : Blowfish
	{

		uint m_unIvHi; 
		uint m_unIvLo;


		/// <summary>
		///   the current IV, Blowfish.BLOCKSIZE bytes large
		/// </summary>
		public byte[] Iv
		{
			set 
			{ 
				m_unIvHi = (((uint)value[0]) << 24) |
					(((uint)value[1]) << 16) |
					(((uint)value[2]) << 8) |
					((uint)value[3]);

				m_unIvLo = (((uint)value[4]) << 24) |
					(((uint)value[5]) << 16) |
					(((uint)value[6]) << 8) |
					((uint)value[7]);
			}

			get 
			{ 
				byte[] result = new byte[Blowfish.BLOCKSIZE];
 
				result[0] = (byte)(m_unIvHi >> 24);
				result[1] = (byte)(m_unIvHi >> 16);
				result[2] = (byte)(m_unIvHi >> 8);
				result[3] = (byte)m_unIvHi;
				result[4] = (byte)(m_unIvLo >> 24);
				result[5] = (byte)(m_unIvLo >> 16);
				result[6] = (byte)(m_unIvLo >> 8);
				result[7] = (byte)m_unIvLo;
  
				return result;
			}
		}

 
		/// <summary>
		///   standard constructor
		/// </summary>
		/// <param name="key"> 
		///   the key material, up to MAXKYELENGTH bytes, oversized material is ignored
		/// </param>
		/// <param name="iv"> 
		///   the initialization vector as a byte array of Blowfish.BLOCKSIZE length,
		///   no range checking, oversized data is ignored
		/// </param>
		public BlowfishCbc
			(byte[] key,
			byte[] iv) : base(key)
		{
			Iv = iv;
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
		public override void Burn() 
		{
			base.Burn();
  
			m_unIvHi = m_unIvLo = 0;
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
		public override void Encrypt
			(ref uint unHiRef,
			ref uint unLoRef)
		{
			unHiRef ^= m_unIvHi;
			unLoRef ^= m_unIvLo;

			BaseEncrypt(ref unHiRef, ref unLoRef);

			m_unIvHi = unHiRef;
			m_unIvLo = unLoRef;
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
		public override void Decrypt
			(ref uint unHiRef,
			ref uint unLoRef)
		{
			uint unBakHi = unHiRef;  
			uint unBakLo = unLoRef;

			base.Decrypt(ref unHiRef, ref unLoRef);

			unHiRef ^= m_unIvHi;
			unLoRef ^= m_unIvLo;

			m_unIvHi = unBakHi;
			m_unIvLo = unBakLo;
		}
	}
}
