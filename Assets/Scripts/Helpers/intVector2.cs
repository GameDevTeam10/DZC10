struct intVector2
{
    private int x;
    private int y;

    public intVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void setPosition(int newX, int newY)
    {
        this.x = newX;
        this.y = newY;
    }

    public int getX()
    {
        return this.x;
    }

    public int getY()
    {
        return this.y;
    }

    public static bool operator ==(intVector2 vector1, intVector2 vector2)
    {
        return vector1.getX() == vector2.getX() && vector1.getY() == vector2.getY();
    }

    public static bool operator !=(intVector2 vector1, intVector2 vector2)
    {
        return vector1.getX() != vector2.getX() || vector1.getY() != vector2.getY();
    }

    public intVector2 moveNorth()
    {
        return new intVector2(this.getX(), this.getY() + 1);
    }

    public intVector2 moveEast()
    {
        return new intVector2(this.getX() + 1, this.getY());
    }

    public intVector2 moveSouth()
    {
        return new intVector2(this.getX(), this.getY() - 1);
    }

    public intVector2 moveWest()
    {
        return new intVector2(this.getX() - 1, this.getY());
    }
}


