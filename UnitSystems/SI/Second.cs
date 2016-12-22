﻿using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Second : IUnit
    {
        public double Value { get; set; }
        public string Symbol()
        {
            return "s";
        }

        #region F = s/Ω
        public static Farad operator /(Second second, Ohm ohm)
        {
            return new Farad() { Value = second.Value / ohm.Value };
        }
        #endregion

        #region +/-
        public static Second operator +(Second second1, Second second2)
        {
            return new Second() { Value = second1.Value + second2.Value };
        }
        public static Second operator -(Second second1, Second second2)
        {
            return new Second() { Value = second1.Value - second2.Value };
        }
        #endregion

        public static implicit operator Second(double value)
        {
            return new Second() { Value = value };
        }

        public static SquareOf<Second> operator ^(Second source, int expo)
        {
            return new SquareOf<Second>(source);
        }

    }
}