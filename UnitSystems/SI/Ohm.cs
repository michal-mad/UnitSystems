﻿using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Ohm : IUnit
    {
        public double Value { get; set; }
        public string Symbol()
        {
            return "Ω";
        }

        public static QuotientOf<Ohm, Metre> operator /(Ohm ohm, Metre metre)
        {
            return new QuotientOf<Ohm, Metre>(ohm, metre);
        }

        public static Watt operator /(SquareOf<Volt> squareVolt, Ohm ohm)
        {
            return new Watt() { Value = squareVolt.Value / ohm.Value };
        }

        public static Watt operator *(SquareOf<Ampere> squareAmper, Ohm ohm)
        {
            return new Watt() { Value = squareAmper.Value * ohm.Value };
        }

        #region +/-
        public static Ohm operator +(Ohm ohm1, Ohm ohm2)
        {
            return new Ohm() { Value = ohm1.Value + ohm2.Value };
        }
        public static Ohm operator -(Ohm ohm1, Ohm ohm2)
        {
            return new Ohm() { Value = ohm1.Value - ohm2.Value };
        }
        #endregion

        public static implicit operator Ohm(double value)
        {
            return new Ohm() { Value = value };
        }
    }
}