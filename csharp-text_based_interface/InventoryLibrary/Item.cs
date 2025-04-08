class Item : BaseClass {
    public string name { get; set; }
    public string description { get; set; }

    private float _price;
    public float price {
        get => (float)Math.Round(_price, 2);
        set => _price = value;
    }

    public List<string> tags { get; set; } = new List<string>();

    public Item(string name) {
        this.name = name;
    }
}