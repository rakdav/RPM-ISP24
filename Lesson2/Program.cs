Counter counter1 = new Counter { Value = 45 };
Counter counter2 = new Counter { Value = 34 };
Counter sum1 = counter1.Add(counter2);
Console.WriteLine(sum1.Value);
Counter sum2 = counter1 + counter2;
Console.WriteLine(sum2.Value);
Counter sum3 = counter1 - counter2;
Console.WriteLine(sum3.Value);
bool res1 = counter1 > counter2;
Counter sum4 = counter1 + 56;
Console.WriteLine(sum4.Value);
Counter counter3 = counter1++;
Console.WriteLine(counter3.Value);
if(!counter1) Console.WriteLine(true);
else Console.WriteLine(false);
int x = (int)counter1;
Console.WriteLine(x);
Counter counter4 = 67;
Console.WriteLine(counter4.Value);
OurTime time = 3567;
Console.WriteLine(time);
OurTime our = new OurTime
{
    Hour = 3,
    Minute = 20,
    Second = 45
};
int t = (int)our;
Console.WriteLine(t);
class Counter
{
    public int Value { get; set; }
    public static implicit operator Counter(int x)
    {
        return new Counter { Value = x };
    }
    public static explicit operator int(Counter counter)
    {
        return counter.Value;
    }
    public Counter Add(Counter c)
    {
       return new Counter { Value = this.Value + c.Value };
    }
    public static Counter operator +(Counter c1,Counter c2)
    {
        return new Counter { Value = c1.Value + c2.Value };
    }
    public static Counter operator +(Counter c,int value)
    {
        return new Counter { Value = c.Value + value };
    }
    public static Counter operator -(Counter c1, Counter c2)
    {
        return new Counter { Value = c1.Value - c2.Value };
    }
    public static bool operator >(Counter c1, Counter c2)
    {
        return c1.Value > c2.Value;
    }
    public static bool operator <(Counter c1, Counter c2)
    {
        return c1.Value < c2.Value;
    }
    public static Counter operator ++(Counter c)
    {
        return new Counter { Value = c.Value++ };
    }
    public static Counter operator --(Counter c)
    {
        return new Counter { Value = c.Value-- };
    }
    public static bool operator true(Counter c1)
    {
        return c1.Value != 0;
    }
    public static bool operator false(Counter c1)
    {
        return c1.Value == 0;
    }
    public static bool operator !(Counter c1)
    {
        return c1.Value == 0;
    }
}
class OurTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }

    public static implicit operator OurTime(int x)
    {
        return new OurTime
        {
            Hour=x/3600,
            Minute=x%3600/60,
            Second= x % 60
        };
    }
    public static explicit operator int(OurTime t)
    {
        return t.Hour*3600+t.Minute*60+t.Second;
    }

    public override string? ToString()
    {
        return Hour+":"+Minute+":"+Second;
    }
}

