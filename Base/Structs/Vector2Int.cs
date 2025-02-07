﻿using Microsoft.Xna.Framework;
using System;
using System.Runtime.Serialization;

namespace TileSystem2.Base.Structs
{
    public struct Vector2Int
    {
        [DataMember]
        public int X;
        [DataMember]
        public int Y;

        public static Vector2Int Zero { get; private set; } = new(0, 0);
        public static Vector2Int One { get; private set; } = new(1, 1);
        public static Vector2Int UnitX { get; private set; } = new(1, 0);
        public static Vector2Int UnitY { get; private set; } = new(0, 1);

        public Vector2Int(int x, int z)
        {
            X = x;
            Y = z;
        }

        public Vector2Int(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public Vector2Int(int value)
        {
            X = value;
            Y = value;
        }

        public Vector2Int(Vector2 vector)
        {
            X = (int)vector.X;
            Y = (int)vector.Y;
        }

        public Vector2Int(Vector2Int other)
        {
            X = other.X;
            Y = other.Y;
        }

        public int Length {
            get { return (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)); }
        }

        public Vector2Int Normalized {
            get {
                return new(
                    X = X == 0 ? 0 : X / Length,
                    Y = Y == 0 ? 0 : Y / Length);
            }
        }

        public override bool Equals(object obj)
            => obj is Vector2Int v && Equals(v);

        public bool Equals(Vector2Int other)
            => X == other.X && Y == other.Y;

        public static bool operator ==(Vector2Int left, Vector2Int right)
            => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Vector2Int left, Vector2Int right)
            => left.X != right.X || left.Y != right.Y;

        public static Vector2Int operator *(Vector2Int left, Vector2Int right)
            => new(left.X * right.X, left.Y * right.Y);

        public static Vector2Int operator *(float left, Vector2Int right)
            => new(left * right.X, left * right.Y);

        public static Vector2Int operator *(Vector2Int left, float right)
            => new(left.X * right, left.Y * right);

        public static Vector2Int operator /(Vector2Int left, Vector2Int right)
           => new(left.X / right.X, left.Y / right.Y);

        public static Vector2Int operator /(float left, Vector2Int right)
            => new(left / right.X, left / right.Y);

        public static Vector2Int operator /(Vector2Int left, float right)
            => new(left.X / right, left.Y / right);

        public static Vector2Int operator +(Vector2Int left, Vector2Int right)
            => new(left.X + right.X, left.Y + right.Y);

        public static Vector2Int operator -(Vector2Int left, Vector2Int right)
            => new(left.X - right.X, left.Y - right.Y);

        public Vector2 ToVector2() => new(X, Y);
        public Point ToPoint() => new(X, Y);
        public void Normalize() => this = Normalized;
        public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();
        public override string ToString() => $"X:{X}, Y:{Y}";
    }
}