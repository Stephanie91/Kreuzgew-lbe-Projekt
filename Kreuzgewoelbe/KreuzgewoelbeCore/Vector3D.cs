using System;

namespace KreuzgewoelbeCore
{
    public struct Vector3D : IEquatable<Vector3D>
    {
        private double _x;
        private double _y;
        private double _z;

        //C# 6.0 nicht möglich wegen VS 2013 in der Schule etc.

        public double Length { get { return Math.Sqrt(_x * _x + _y * _y + _z * _z); } }

        public double LengthSquared { get { return _x * _x + _y * _y + _z * _z; } }

        public double X
        {
            get
            {
                return _x;
            }
            //set
            //{
            //    _x = value;
            //}
        }

        public double Y
        {
            get
            {
                return _y;
            }
            //set
            //{
            //    _y = value;
            //}
        }

        public double Z
        {
            get
            {
                return _z;
            }
            //set
            //{
            //    _z = value;
            //}
        }

        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-vector._x, -vector._y, -vector._z);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        public static Vector3D operator /(Vector3D vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        public static bool operator ==(Vector3D left, Vector3D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3D left, Vector3D right)
        {
            return !left.Equals(right);
        }

        public Vector3D Normalize()
        {
            double num1 = Math.Abs(_x);
            double num2 = Math.Abs(_y);
            double num3 = Math.Abs(_z);
            if (num2 > num1)
                num1 = num2;
            if (num3 > num1)
                num1 = num3;
            _x = _x / num1;
            _y = _y / num1;
            _z = _z / num1;
            return this / Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public Vector3D Negate()
        {
            return new Vector3D(-_x, -_y, -_z);
        }

        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        public static Vector3D Subtract(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        public static Vector3D Multiply(Vector3D vector, double scalar)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        public static Vector3D Multiply(double scalar, Vector3D vector)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        public static Vector3D Divide(Vector3D vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return DotProduct(ref vector1, ref vector2);
        }

        private static double DotProduct(ref Vector3D vector1, ref Vector3D vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y + vector1._z * vector2._z;
        }

        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            Vector3D result;
            CrossProduct(ref vector1, ref vector2, out result);
            return result;
        }

        private static void CrossProduct(ref Vector3D vector1, ref Vector3D vector2, out Vector3D result)
        {
            result._x = vector1._y * vector2._z - vector1._z * vector2._y;
            result._y = vector1._z * vector2._x - vector1._x * vector2._z;
            result._z = vector1._x * vector2._y - vector1._y * vector2._x;
        }

        public bool Equals(Vector3D other)
        {
            return _x.Equals(other._x) && _y.Equals(other._y) && _z.Equals(other._z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3D && Equals((Vector3D)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _x.GetHashCode();
                hashCode = (hashCode * 397) ^ _y.GetHashCode();
                hashCode = (hashCode * 397) ^ _z.GetHashCode();
                return hashCode;
            }
        }
    }
}
