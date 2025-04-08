class Inventory : BaseClass {
    public string user_id;
    public string item_id;
    public int _quantity = 1;
    public int quantity
    {
        get => _quantity;
        set {
            if (value < 0)
                throw new ArgumentException("Quantity cannot be lees than 0.");
            _quantity = value;
        }
    }

    public Inventory(string user_id, string item_id, int quantity = 1) {
        this.user_id = user_id;
        this.item_id = item_id;
        this.quantity = quantity;
    }
}