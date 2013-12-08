using System;

namespace NealFordFt.ErrorHandling
{
    public class Either<TLeft, TRight>
    {
        private TLeft left = default(TLeft);
        private TRight right = default(TRight);

        private Either(TLeft l, TRight r)
        {
            left = l;
            right = r;
        }

        public static Either<TLeft, TRight> MakeLeft(TLeft l)
        {
            return new Either<TLeft, TRight>(l, default(TRight));
        }

        public static Either<TLeft, TRight> MakeRight(TRight r)
        {
            return new Either<TLeft, TRight>(default(TLeft), r);
        }

        public TLeft Left
        {
            get { return left; }
        }

        public TRight Right
        {
            get { return right; }
        }

        public bool IsLeft
        {
            get { return !object.Equals(left, default(TLeft)); }
        }

        public bool IsRight
        {
            get {  return !object.Equals(right, default(TRight)); }
        }

        public void Fold(Action<TLeft> leftOption, Action<TRight> rightOption)
        {
            if (!IsRight)
                leftOption(left);
            else
                rightOption(right);
        }
    }
}
