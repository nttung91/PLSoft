using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Technical.Utilities.Cryptography
{
    public class CryptEngine : IDisposable
    {
        public enum AlgorithmType
        {
            None, Sha, Sha256, Sha384, Sha512, Md5,
            Des, Rc2, Rijndael, TripleDes, BlowFish, Twofish
        }

        private bool _isHash;
        private bool _isSymmetric;

        private AlgorithmType _algorithm = AlgorithmType.None;
        private HashAlgorithmEngine _he;
        private SymmetricAlgorithmEngine _se;

        private string _key;
        private const string DefaultKey = "a1b2c3d4e5f6g";

        public AlgorithmType Algorithm
        {
            get { return _algorithm; }
            set
            {
                _algorithm = value;
                InitializeEngine();
            }
        }

        public bool IsHashAlgorithm
        {
            get { return _isHash; }
        }

        public bool IsSymmetricAlgorithm
        {
            get { return _isSymmetric; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = formatKey(value); }
        }

        private string formatKey(string k)
        {
            if (string.IsNullOrEmpty(k)) return null;
            return k.Trim();
        }

        public CryptEngine()
        {
        }

        public CryptEngine(AlgorithmType al)
        {
            _algorithm = al;
            InitializeEngine();
        }

        public string Decrypt(string src)
        {
            string result = string.Empty;

            if (_isSymmetric)
            {
                if (_key == null) _key = DefaultKey;
                result = _se.Decrypting(src, _key);
            }

            return result;
        }

        public string Decrypt(string src, string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            if (_isHash) throw new CryptEngineException("Decrypt not possible for hash algorithm");

            string result = string.Empty;

            if (_isSymmetric)
            {
                result = _se.Decrypting(src, key);
            }

            return result;
        }

        public string Encrypt(string src)
        {
            string result = string.Empty;

            if (_isHash)
            {
                result = _he.Encoding(src);
            }
            else if (_isSymmetric)
            {
                if (_key == null) _key = DefaultKey;
                result = _se.Encrypting(src, _key);
            }

            return result;
        }

        public string Encrypt(string src, string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            string result = string.Empty;

            if (_isHash)
            {
                result = _he.Encoding(src);
            }
            else if (_isSymmetric)
            {
                result = _se.Encrypting(src, key);
            }

            return result;
        }

        private void DestroyEngine()
        {
            _se = null;
            _he = null;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                DestroyEngine();
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool InitializeEngine(AlgorithmType at)
        {
            _algorithm = at;

            return InitializeEngine();
        }

        public bool InitializeEngine()
        {
            if (_algorithm == AlgorithmType.None)
                return false;

            if (_algorithm == AlgorithmType.BlowFish ||
                _algorithm == AlgorithmType.Des ||
                _algorithm == AlgorithmType.Rc2 ||
                _algorithm == AlgorithmType.Rijndael ||
                _algorithm == AlgorithmType.TripleDes ||
                _algorithm == AlgorithmType.Twofish)
            {
                _isSymmetric = true;
                _isHash = false;
            }
            else
                if (_algorithm == AlgorithmType.Md5 ||
                    _algorithm == AlgorithmType.Sha ||
                    _algorithm == AlgorithmType.Sha256 ||
                    _algorithm == AlgorithmType.Sha384 ||
                    _algorithm == AlgorithmType.Sha512)
                {
                    _isSymmetric = false;
                    _isHash = true;
                }

            _se = null;
            _he = null;
            switch (_algorithm)
            {
                case AlgorithmType.BlowFish:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.BlowFish);
                    break;
                case AlgorithmType.Des:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.Des);
                    break;
                case AlgorithmType.Md5:
                    _he = new HashAlgorithmEngine(HashAlgorithmEngine.EncodeMethodEnum.Md5);
                    break;
                case AlgorithmType.Rc2:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.Rc2);
                    break;
                case AlgorithmType.Rijndael:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.Rijndael);
                    break;
                case AlgorithmType.Sha:
                    _he = new HashAlgorithmEngine(HashAlgorithmEngine.EncodeMethodEnum.Sha);
                    break;
                case AlgorithmType.Sha256:
                    _he = new HashAlgorithmEngine(HashAlgorithmEngine.EncodeMethodEnum.Sha256);
                    break;
                case AlgorithmType.Sha384:
                    _he = new HashAlgorithmEngine(HashAlgorithmEngine.EncodeMethodEnum.Sha384);
                    break;
                case AlgorithmType.Sha512:
                    _he = new HashAlgorithmEngine(HashAlgorithmEngine.EncodeMethodEnum.Sha512);
                    break;
                case AlgorithmType.TripleDes:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.TripleDes);
                    break;
                case AlgorithmType.Twofish:
                    _se = new SymmetricAlgorithmEngine(SymmetricAlgorithmEngine.EncodeMethodEnum.Twofish);
                    break;
                default:
                    return false;
            }
            return true;
        }

        public class HashAlgorithmEngine
        {
            public enum EncodeMethodEnum
            {
                Sha, Sha256, Sha384, Sha512, Md5
            }

            private readonly HashAlgorithm _encodeMethod;

            public HashAlgorithmEngine(HashAlgorithm serviceProvider)
            {
                _encodeMethod = serviceProvider;
            }

            public HashAlgorithmEngine(EncodeMethodEnum iSelected)
            {
                switch (iSelected)
                {
                    case EncodeMethodEnum.Sha:
                        _encodeMethod = new SHA1CryptoServiceProvider();
                        break;
                    case EncodeMethodEnum.Sha256:
                        _encodeMethod = new SHA256Managed();
                        break;
                    case EncodeMethodEnum.Sha384:
                        _encodeMethod = new SHA384Managed();
                        break;
                    case EncodeMethodEnum.Sha512:
                        _encodeMethod = new SHA512Managed();
                        break;
                    case EncodeMethodEnum.Md5:
                        _encodeMethod = new MD5CryptoServiceProvider();
                        break;
                }
            }

            public string Encoding(string source)
            {
                byte[] bytIn = System.Text.Encoding.Unicode.GetBytes(source);

                byte[] bytOut = _encodeMethod.ComputeHash(bytIn);

                // convert into Base64 so that the result can be used in xml
                return Convert.ToBase64String(bytOut, 0, bytOut.Length);
            }
        }

        public class SymmetricAlgorithmEngine
        {
            public enum EncodeMethodEnum
            {
                Des, Rc2, Rijndael, TripleDes, BlowFish, Twofish
            }

            private readonly SymmetricAlgorithm _encodeMethod;

            public SymmetricAlgorithmEngine(SymmetricAlgorithm serviceProvider)
            {
                _encodeMethod = serviceProvider;
            }

            public SymmetricAlgorithmEngine(EncodeMethodEnum iSelected)
            {
                switch (iSelected)
                {
                    case EncodeMethodEnum.Des:
                        _encodeMethod = new DESCryptoServiceProvider();
                        break;
                    case EncodeMethodEnum.Rc2:
                        _encodeMethod = new RC2CryptoServiceProvider();
                        break;
                    case EncodeMethodEnum.Rijndael:
                        _encodeMethod = new RijndaelManaged();
                        break;
                    case EncodeMethodEnum.TripleDes:
                        _encodeMethod = new TripleDESCryptoServiceProvider();
                        break;
                    case EncodeMethodEnum.BlowFish:
                        _encodeMethod = new BlowfishAlgorithm {Mode = CipherMode.CBC, KeySize = 40};
                        _encodeMethod.GenerateKey();
                        _encodeMethod.GenerateIV();
                        break;
                    case EncodeMethodEnum.Twofish:
                        _encodeMethod = new Twofish {Mode = CipherMode.CBC};
                        _encodeMethod.GenerateKey();
                        _encodeMethod.GenerateIV();
                        break;

                }
            }

            private byte[] GetValidKey(string key)
            {
                string sTemp;
                if (_encodeMethod.LegalKeySizes.Length > 0)
                {
                    int moreSize = _encodeMethod.LegalKeySizes[0].MinSize;
                    // key sizes are in bits

                    while (key.Length * 8 > moreSize &&
                           _encodeMethod.LegalKeySizes[0].SkipSize > 0 &&
                           moreSize < _encodeMethod.LegalKeySizes[0].MaxSize)
                    {
                        moreSize += _encodeMethod.LegalKeySizes[0].SkipSize;
                    }

                    if (key.Length * 8 > moreSize)
                        sTemp = key.Substring(0, (moreSize / 8));
                    else
                        sTemp = key.PadRight(moreSize / 8, ' ');
                }
                else
                    sTemp = key;

                // convert the secret key to byte array
                return Encoding.ASCII.GetBytes(sTemp);
            }

            private byte[] getValidIV(String initVector, int validLength)
            {
                if (initVector.Length > validLength)
                {
                    return Encoding.ASCII.GetBytes(initVector.Substring(0, validLength));
                }
                return Encoding.ASCII.GetBytes(initVector.PadRight(validLength, ' '));
            }

            public static string BufToStr(byte[] buf)
            {
                var result = new StringBuilder(buf.Length * 3);

                for (int nI = 0, nC = buf.Length; nI < nC; nI++)
                {
                    if (0 < nI) result.Append(' ');
                    result.Append(buf[nI].ToString("x2"));
                }
                return result.ToString();
            }

            public string Encrypting(string source, string key)
            {
                if (source == null || key == null || source.Length == 0 || key.Length == 0)
                    return null;

                if (_encodeMethod == null) return "Under Construction";

                var buf = new byte[3];

                byte[] srcData = Encoding.Unicode.GetBytes(source);
                var sin = new MemoryStream();
                sin.Write(srcData, 0, srcData.Length);
                sin.Position = 0;
                var sout = new MemoryStream();

                _encodeMethod.Key = GetValidKey(key);
                _encodeMethod.IV = getValidIV(key, _encodeMethod.IV.Length);

                var encStream = new CryptoStream(sout, _encodeMethod.CreateEncryptor(), CryptoStreamMode.Write);
                long lLen = sin.Length;
                int nReadTotal = 0;
                while (nReadTotal < lLen)
                {
                    int nRead = sin.Read(buf, 0, buf.Length);
                    encStream.Write(buf, 0, nRead);
                    nReadTotal += nRead;
                }
                encStream.Close();

                byte[] encData = sout.ToArray();

                // convert into Base64 so that the result can be used in xml
                return Convert.ToBase64String(encData);
            }

            public string Decrypting(string source, string key)
            {
                if (source == null || key == null || source.Length == 0 || key.Length == 0)
                    return null;

                if (_encodeMethod == null) return "Under Construction";

                var buf = new byte[3];

                byte[] encData = Convert.FromBase64String(source);
                var sin = new MemoryStream(encData);
                var sout = new MemoryStream();

                _encodeMethod.Key = GetValidKey(key);
                _encodeMethod.IV = getValidIV(key, _encodeMethod.IV.Length);

                var decStream = new CryptoStream(sin, _encodeMethod.CreateDecryptor(), CryptoStreamMode.Read);

                long lLen = sin.Length;
                int nReadTotal = 0;
                while (nReadTotal < lLen)
                {
                    int nRead = decStream.Read(buf, 0, buf.Length);
                    if (0 == nRead) break;

                    sout.Write(buf, 0, nRead);
                    nReadTotal += nRead;
                }

                decStream.Close();

                byte[] decData = sout.ToArray();

                var ascEnc = new UnicodeEncoding();
                return ascEnc.GetString(decData);
            }
        }
    }
}
