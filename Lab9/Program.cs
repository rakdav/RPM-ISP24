Queue<Phone> q1 = new Queue<Phone>();
Phone p1 = new Phone()
{
    Name = "Samsung",
    Price=38000
};
q1.Enqueue(p1);
class Phone
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
