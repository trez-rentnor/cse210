class Fraction {
    private int top;
    private int bottom;

    public Fraction() : this(1, 1) { }

    public Fraction(int top) : this(top, 1) { }

    public Fraction(int top, int bottom) {
        this.top = top;
        this.bottom = bottom;
    }

    public void SetTop(int top) {
        this.top = top;
    }

    public int GetTop() {
        return top;
    }

    public void SetBottom(int bottom) {
        this.bottom = bottom;
    }

    public int GetBottom() {
        return bottom;
    }

    public string GetFractionString() {
        return $"{top}/{bottom}"; 
    }

    public double GetDecimalValue() {
        return (double)top / bottom;
    }
}