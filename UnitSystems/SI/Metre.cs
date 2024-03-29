﻿namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Metre : IUnit, IPrefixable, IReplicable<Metre>, IComparable, IComparable<Metre>, IEquatable<Metre>
    {
        public string Symbol => "m";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Metre(double value)
        {
            Value = value;
        }

        internal Metre(Millimetre unit)
            : this()
        {
            Value = Prefixes.GetConversionFactor(unit.Prefix, Prefix) * unit.Value;
        }

        #region +/-

        public static Metre operator +(Metre left, Metre right)
        {
            return new(left.Value + right.Value);
        }

        public static Metre operator -(Metre left, Metre right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Metre operator *(Metre unit, double multiplier)
        {
            return new Metre(unit.Value * multiplier);
        }

        public static Metre operator *(double multiplier, Metre unit)
        {
            return new Metre(unit.Value * multiplier);
        }

        public static Metre operator /(Metre dividend, double divisor)
        {
            return new Metre(dividend.Value / divisor);
        }

        public static double operator /(Metre dividend, Metre divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region m² = m·m
        public static SquareOf<Metre> operator *(Metre left, Metre right)
        {
            return new(left.Value * right.Value);
        }
        #endregion

        #region m = m² / m
        public static Metre operator /(SquareOf<Metre> left, Metre right)
        {
            return new(left.Value / right.Value);
        }
        #endregion

        #region Casting/Conversion

        public static implicit operator Metre(double value)
        {
            return new(value);
        }

        public static explicit operator Metre(Millimetre unit)
        {
            return new Metre(unit);
        }

        #endregion


        #region IReplicable implementation

        public Metre ReplicateFrom(double value)
        {
            return new Metre(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Metre other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Metre other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Metre other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Metre left, Metre right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Metre left, Metre right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Metre left, Metre right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Metre left, Metre right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Metre left, Metre right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Metre left, Metre right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}