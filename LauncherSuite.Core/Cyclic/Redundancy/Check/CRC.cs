using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Cyclic.Redundancy.Check
{
    public sealed class CRC : HashAlgorithm
    {
        public const uint DefaultPolynomial = 0xEDB88320;
        public const uint DefaultSeed = 0xFFFFFFFF;

        private static uint[]? _defaultTable;
        private readonly uint[] _table;
        private readonly uint _seed;
        private uint _hash;

        public CRC()
            : this(DefaultPolynomial, DefaultSeed)
        {
        }

        public CRC(uint polynomial, uint seed)
        {
            _table = InitializeTable(polynomial);
            _seed = seed;
            Initialize();
        }

        public override void Initialize()
        {
            _hash = _seed;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            _hash = CalculateHash(_table, _hash, array, ibStart, cbSize);
        }

        protected override byte[] HashFinal()
        {
            var buffer = UInt32ToBigEndianBytes(~_hash);
            HashValue = buffer;
            return buffer;
        }

        public override int HashSize => 32;

        public static uint Compute(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            return Compute(DefaultPolynomial, DefaultSeed, buffer);
        }

        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == DefaultPolynomial && _defaultTable != null)
            {
                return _defaultTable;
            }

            var table = new uint[256];
            for (uint i = 0; i < table.Length; i++)
            {
                var entry = i;
                for (var j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                    {
                        entry = (entry >> 1) ^ polynomial;
                    }
                    else
                    {
                        entry >>= 1;
                    }
                }

                table[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
            {
                _defaultTable = table;
            }

            return table;
        }

        private static uint CalculateHash(IReadOnlyList<uint> table, uint seed, byte[] buffer, int start, int size)
        {
            var crc = seed;
            var length = start + size;
            for (var i = start; i < length; i++)
            {
                crc = (crc >> 8) ^ table[(byte)buffer[i] ^ (crc & 0xFF)];
            }

            return crc;
        }

        private static byte[] UInt32ToBigEndianBytes(uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }
    }
}
