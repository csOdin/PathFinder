namespace csOdin.PathFinder.Enums
{
    public enum RelativeLocation
    {
        None = 0,

        Self = 100100100,
        Left = 99100100,
        FrontLeft = 99100101,
        Front = 100100101,
        FrontRight = 101100101,
        Right = 101100100,
        BackRight = 101100099,
        Back = 100100099,
        BackLeft = 99100099,

        Top = 100101100,
        TopLeft = 99101100,
        TopFrontLeft = 99101101,
        TopFront = 100101101,
        TopFrontRight = 101101101,
        TopRight = 101101100,
        TopBackRight = 101101099,
        TopBack = 100101099,
        TopBackLeft = 99101099,

        Bottom = 100099100,
        BottomLeft = 99099100,
        BottomFrontLeft = 99099101,
        BottomFront = 100099101,
        BottomFrontRight = 101099101,
        BottomRight = 101099100,
        BottomBackRight = 101099099,
        BottomBack = 100099099,
        BottomBackLeft = 99099099
    }
}
