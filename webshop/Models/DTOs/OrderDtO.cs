using System;
using System.Collections.Generic;

public class OrderDTO
{
    public int Id { get; set; }
    public int companyId { get; set; }
    public int totalPrice { get; set; }
    public int status { get; set; }
    public string paymentMethod { get; set; }
    public string createdBy { get; set; }
    public DateTime created { get; set; }
    public ICollection<Order_DetailDTO> Order_Details { get; set; }
}

